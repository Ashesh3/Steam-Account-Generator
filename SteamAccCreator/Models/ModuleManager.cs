using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SteamAccCreator.Models
{
    public class ModuleManager
    {
        private List<ModuleBinding> _Modules = new List<ModuleBinding>();
        public IReadOnlyCollection<ModuleBinding> ModuleBindings => new ReadOnlyCollection<ModuleBinding>(_Modules);
        public IReadOnlyCollection<SACModuleBase.ISACBase> Modules => new ReadOnlyCollection<SACModuleBase.ISACBase>(_Modules.Select(x => x.Module).ToList());

        private Configuration Configuration;

        /* Modules directory model
         * 
         * |- .exe
         * |- modules
         *    |- config
         *       |- module_lib.name             <- here any configs for module
         *    |- required                       <- here any required libraries for module. Sub-directories will be checked and .dll will be loaded...
         *    |- *.dll                          <- here modules library. only .dll will be scanned for interfaces. You may put here for example .pdb to debug your module
         */
        public ModuleManager(Configuration configuration)
        {
            Configuration = configuration;

            // this will fix assembly not found error
            AppDomain.CurrentDomain.AssemblyResolve += (s, args) =>
            {
                foreach (var assebly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assebly.FullName == args.Name)
                        return assebly;
                }

                return null;
            };

            InitDirs();
            LoadRequiredLib();
            LoadModules();
        }

        private void InitDirs()
            => Utility.MkDirs(Pathes.DIR_MODULES, Pathes.DIR_MODULES_CONFIGS, Pathes.DIR_MODULES_REQUIRED);

        private void LoadRequiredLib()
        {
            Logger.Info("Loading required libraries...");

            var libs = Directory.GetFiles(Pathes.DIR_MODULES_REQUIRED, "*.dll", SearchOption.AllDirectories);
            var loadSuccess = 0; var loadFailed = 0;
            foreach (var lib in libs)
            {
                var libPath = lib.Replace(Pathes.DIR_MODULES_REQUIRED, "");

                Logger.Info($"Library '{libPath}': Loading...");
                try
                {
                    var asm = Assembly.LoadFile(lib);
                    AppDomain.CurrentDomain.Load(asm.GetName());

                    loadSuccess++;
                    Logger.Info($"Library '{libPath}': OK!");
                }
                catch (Exception ex)
                {
                    loadFailed++;
                    Logger.Error($"Library '{libPath}': ERROR!", ex);
                }
            }

            Logger.Info($"Loading required libraries done. Loaded: {loadSuccess}; Failed: {loadFailed}.");
        }

        private void LoadModules()
        {
            Logger.Info("Loading modules...");

            _Modules.Clear();

            var libs = Directory.GetFiles(Pathes.DIR_MODULES, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (var lib in libs)
            {
                var fileName = Path.GetFileName(lib);
                Logger.Info($"Module ['{fileName}',?,?,?]: Loading...");
                try
                {
                    var asm = Assembly.LoadFile(lib);
                    var asmTypes = (from type in asm.GetExportedTypes()
                                    where type.IsClass &&
                                    typeof(SACModuleBase.ISACBase).IsAssignableFrom(type) &&
                                    type.IsDefined(typeof(SACModuleBase.Attributes.SACModuleInfoAttribute))
                                    select type);

                    Logger.Info($"Module ['{fileName}',?,?,?]: {asmTypes.Count()} type(s) available.");

                    foreach (var asmType in asmTypes)
                    {
                        try
                        {
                            var asmInfo = asmType.GetCustomAttribute<SACModuleBase.Attributes.SACModuleInfoAttribute>();
                            if (asmInfo == null)
                            {
                                Logger.Warn($"Module ['{fileName}',?,?,?]: WTF? Cannot get info-attribute...");
                                continue;
                            }

                            var guid = asmInfo.Guid;
                            var mName = asmInfo.Name;
                            var mVer = asmInfo.Version;
                            var isDisabled = Configuration.DisabledModules.Any(g => g == guid);

                            if (isDisabled)
                                Logger.Warn($"Module ['{fileName}','{mName}',{mVer},{guid}]: Will be initialized anyway. To completely disabling module you need to remove '{fileName}' from '{Pathes.DIR_MODULES}'");

                            Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: Check for GUID free...");
                            if (!Modules.GuidIsFree(guid))
                            {
                                Logger.Warn($"Module ['{fileName}','{mName}',{mVer},{guid}]: Was not be loaded GUID is NOT free.");
                                continue;
                            }
                            Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: GUID is free.");

                            try
                            {
                                Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: Creating instance...");
                                var module = (SACModuleBase.ISACBase)Activator.CreateInstance(asmType);
                                Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: Seems to be created...");

                                Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: Initializing...");
                                module.ModuleEnabled = !isDisabled; // anyway need full init to enable/disable using gui and during runtime...
                                try
                                {
                                    var configDirectory = Path.Combine(Pathes.DIR_MODULES_CONFIGS, fileName);
                                    Utility.MkDirs(configDirectory);
                                    module.ModuleInitialize(new SACModuleBase.Models.SACInitialize()
                                    {
                                        ConfigurationPath = configDirectory
                                    });
                                    Logger.Info($"Module ['{fileName}','{mName}',{mVer},{guid}]: Initialized.");

                                    try
                                    {
                                        _Modules.Add(new ModuleBinding(module));
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Error($"Module ['{fileName}','{mName}',{mVer},{guid}]: Initialized but cannot add to module list...", ex);
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error($"Module ['{fileName}','{mName}',{mVer},{guid}]: Initialize module error.", ex);
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error($"Module ['{fileName}','{mName}',{mVer},{guid}]: Initialize assembly error.", ex);
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Module ['{fileName}',?,?]: Loading assembly error.", ex);
                            continue;
                        }
                        Logger.Info($"Module ['{fileName}',?,?]: Loading done.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Module ['{fileName}',?,?]: Loading error.", ex);
                }
            }

            Logger.Info("Loading modules done.");
        }
    }
}
