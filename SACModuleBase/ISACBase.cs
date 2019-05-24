using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACModuleBase
{
    public interface ISACBase
    {
        string ModuleName { get; }
        Version Version { get; }

        void Initialize();
    }
}
