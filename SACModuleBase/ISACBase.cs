using System;

namespace SACModuleBase
{
    public interface ISACBase
    {
        bool ModuleEnabled { get; set; }

        void ModuleInitialize(Models.SACInitialize initialize);
    }
}
