using System;

namespace SACModuleBase
{
    public interface ISACBase
    {
        bool ModuleEnabled { get; set; }
        string ModuleName { get; }
        Version ModuleVersion { get; }

        void ModuleInitialize(Models.SACInitialize initialize);
    }
}
