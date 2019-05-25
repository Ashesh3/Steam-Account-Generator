using System;
using System.Collections.Generic;
using System.Linq;

namespace SteamAccCreator
{
    public static class ModuleExtends
    {
        public static bool GuidIsFree(this IEnumerable<SACModuleBase.ISACBase> modules, Guid guid)
            => !(modules?.Any(m => m?.GetType()?.GUID == guid) ?? true);

        public static IEnumerable<SACModuleBase.ISACHandlerCaptcha> GetCaptchaSolvers(this IEnumerable<SACModuleBase.ISACBase> modules)
            => GetModulesByInterface<SACModuleBase.ISACHandlerCaptcha>(modules);
        public static IEnumerable<SACModuleBase.ISACHandlerReCaptcha> GetReCaptchaSolvers(this IEnumerable<SACModuleBase.ISACBase> modules)
            => GetModulesByInterface<SACModuleBase.ISACHandlerReCaptcha>(modules);
        public static IEnumerable<SACModuleBase.ISACHandlerMailBox> GetMailBoxes(this IEnumerable<SACModuleBase.ISACBase> modules)
            => GetModulesByInterface<SACModuleBase.ISACHandlerMailBox>(modules);
        public static IEnumerable<SACModuleBase.ISACUserInterface> GetUserInterfaces(this IEnumerable<SACModuleBase.ISACBase> modules)
            => GetModulesByInterface<SACModuleBase.ISACUserInterface>(modules);

        private static IEnumerable<T> GetModulesByInterface<T>(IEnumerable<SACModuleBase.ISACBase> modules)
            => modules?.Where(m => typeof(T).IsAssignableFrom(m.GetType())).Select(m => (T)m) ?? new T[0];
    }
}
