using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SACModuleBase")]
[assembly: AssemblyDescription("Base library with interfaces to interract between SAC and modules")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#elif PRE_RELEASE
[assembly: AssemblyConfiguration("PRE-RELEASE")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("https://github.com/EarsKilla/")]
[assembly: AssemblyProduct("SACModuleBase")]
[assembly: AssemblyCopyright("Copyright © 2019")]
[assembly: AssemblyTrademark("SteamAccountGenerator")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: Guid("6ef56439-571f-4598-b89f-2fd4176142eb")]

// Major.Minor
[assembly: AssemblyVersion("1.0")]
[assembly: AssemblyFileVersion("1.0")]
