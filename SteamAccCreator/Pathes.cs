using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccCreator
{
    public static class Pathes
    {
        public static readonly string DIR_BASE = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DIR_GECKO = Path.Combine(DIR_BASE, "Firefox");

        public static readonly string DIR_MODULES = Path.Combine(DIR_BASE, "modules");
        public static readonly string DIR_MODULES_CONFIGS = Path.Combine(DIR_MODULES, "configs");
        public static readonly string DIR_MODULES_REQUIRED = Path.Combine(DIR_MODULES, "required");

        public static readonly string FILE_CONFIG = Path.Combine(DIR_BASE, "config.json");
        public static readonly string FILE_DISABLED_MODULES = Path.Combine(DIR_BASE, "modules_disabled.json");
    }
}
