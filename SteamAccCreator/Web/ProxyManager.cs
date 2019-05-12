using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SteamAccCreator.Web
{
    public class ProxyManager
    {
        private readonly Gui.MainForm MainForm;

        private object Sync = new object();
        private Models.ProxyItem _Current;
        public Models.ProxyItem Current
        {
            get
            {
                lock (Sync)
                    return _Current;
            }
            private set
            {
                lock (Sync)
                    _Current = value;
            }
        }
        public IWebProxy WebProxy => Current?.ToWebProxy();

        public IEnumerable<Models.ProxyItem> Proxies => MainForm.Configuration.Proxy.List;
        public bool Enabled => MainForm.Configuration.Proxy.Enabled;

        public ProxyManager(Gui.MainForm mainForm)
        {
            MainForm = mainForm;
        }

        public bool GetNew()
        {
            Logger.Trace("New proxy required...");
            if (!Enabled)
            {
                Current = null;
                return true;
            }

            var success = false;
            lock (Sync)
            {
                Logger.Debug("Proxies locked...");
                if (_Current == null)
                {
                    var enabledProxies = Proxies.Where(x => x?.Enabled ?? false);
                    if (enabledProxies.Count() > 0)
                    {
                        _Current = enabledProxies.First();
                        Logger.Trace($"New proxy is ({_Current.ProxyType.ToString()}) {_Current.Host}:{_Current.Port}");
                        success = true;
                    }
                    else
                        Logger.Warn("No working proxies using old!");
                }
                else
                {
                    var enabledProxies = new List<Models.ProxyItem>();
                    var oldProxyIndex = -1;
                    for (int i = 0; i < Proxies.Count(); i++)
                    {
                        var proxy = Proxies.ElementAtOrDefault(i);
                        if (proxy == null)
                            continue;

                        if (proxy == _Current)
                            oldProxyIndex = i;
                    }

                    if (oldProxyIndex > -1)
                    {
                        var _proxies = Proxies.ToList();
                        _proxies[oldProxyIndex].Enabled = false;
                        MainForm.Configuration.Proxy.List = _proxies;
                        Logger.Info($"Proxy ({_Current.ProxyType.ToString()}) {_Current.Host}:{_Current.Port} was disabled in list.");
                    }

                    if (enabledProxies.Count() > 0)
                    {
                        _Current = enabledProxies.First();
                        Logger.Trace($"New proxy is ({_Current.ProxyType.ToString()}) {_Current.Host}:{_Current.Port}");
                        success = true;
                    }
                    else
                        Logger.Warn("No working proxies using old!");
                }
                Logger.Debug($"Unlocking proxies...");
            }
            return success;
        }

        private object ThreadsSync = new object();
        private List<Thread> CheckThreads = new List<Thread>();

        public async Task CheckProxies(Action onDisabled,
            Action onError,
            Action onGood,
            Action onDone)
        {
            var proxies = Proxies.ToList();

            var threadEndCb = new Action<Thread>((t) =>
            {
                lock (ThreadsSync)
                    CheckThreads.Remove(t);
            });

            foreach (var proxy in proxies)
            {
                if (!(proxy?.Enabled ?? false))
                {
                    onDisabled?.Invoke();
                    continue;
                }

                var thread = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        var client = new RestSharp.RestClient("https://store.steampowered.com/login/")
                        {
                            Proxy = proxy.ToWebProxy()
                        };
                        var request = new RestSharp.RestRequest("", RestSharp.Method.GET);
                        var response = client.Execute(request);
                        if (!response.IsSuccessful)
                        {
                            proxy.Enabled = false;
                            proxy.Status = Enums.ProxyStatus.Broken;
                            onError?.Invoke();
                        }
                        else
                        {
                            if (Regex.IsMatch(response.Content, @"(steamcommunity\.com|steampowered\.com)", RegexOptions.IgnoreCase))
                            {
                                proxy.Status = Enums.ProxyStatus.Working;
                                onGood?.Invoke();
                            }
                            else
                            {
                                proxy.Enabled = false;
                                proxy.Status = Enums.ProxyStatus.Broken;
                                onError?.Invoke();
                            }
                        }

                        Logger.Debug($"Proxy({proxy.Host}:{proxy.Port}): {proxy.Status.ToString()}");
                        threadEndCb(Thread.CurrentThread);
                    }
                    catch (ThreadAbortException)
                    {
                        Logger.Info("Check proxy thread stopped.");
                        threadEndCb(Thread.CurrentThread);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Check proxy thread error.", ex);
                        onError?.Invoke();
                        threadEndCb(Thread.CurrentThread);
                    }
                }));

                CheckThreads.Add(thread);
            }

            await Task.Factory.StartNew(async () =>
            {
                var thrs = new List<Thread>(10);
                while (CheckThreads.Count > 0)
                {
                    lock (ThreadsSync)
                    {
                        var _thrs = CheckThreads.Take(10 - thrs.Count);
                        thrs.AddRange(_thrs);

                        for (int i = thrs.Count - 1; i > -1; i--)
                        {
                            var t = thrs.ElementAtOrDefault(i);
                            switch (t.ThreadState)
                            {
                                case ThreadState.Unstarted:
                                    t.Start();
                                    break;
                                case ThreadState.Stopped:
                                    thrs.Remove(t);
                                    break;
                            }
                        }
                    }

                    await Task.Delay(1000);
                }

                onDone?.Invoke();
            });
        }

        public void CancelChecking()
        {
            lock (ThreadsSync)
            {
                CheckThreads.RemoveAll(x => x.ThreadState == ThreadState.Unstarted);

                foreach (var thread in CheckThreads)
                {
                    thread.Abort();
                }
            }
        }
    }
}
