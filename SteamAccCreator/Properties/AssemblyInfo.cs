using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("SteamAccountGenerator")]
[assembly: AssemblyDescription("Steam Account Generator. Maintained by EarsKilla https://github.com/EarsKilla/")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#elif DEV_RELEASE
[assembly: AssemblyConfiguration("DEV-RELEASE")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("@DedSec1337")]
[assembly: AssemblyProduct("Steam Account Generator")]
[assembly: AssemblyCopyright("Copyright © 2019")]
[assembly: AssemblyTrademark("SteamAccountGenerator")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: Guid("1d27f487-c3e3-4f50-9d1e-6c0994280b79")]

// Major.Minor.Build
[assembly: AssemblyVersion("2.0.*")]
[assembly: AssemblyFileVersion("2.0.0")]
[assembly: NeutralResourcesLanguage("en")]

