using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Models
{
    public class ModuleBinding
    {
        public SACModuleBase.ISACBase Module { get; private set; }
        public bool IsUI
            => typeof(SACModuleBase.ISACUserInterface).IsAssignableFrom(Module.GetType());
        private SACModuleBase.ISACUserInterface ModuleUI
            => IsUI ? (SACModuleBase.ISACUserInterface)Module : null;

        public bool Enabled
        {
            get => Module.ModuleEnabled;
            set => Module.ModuleEnabled = value;
        }
        public string Name => Module.ModuleName;
        public Version Version => Module.ModuleVersion;

        private readonly Button _Button;
        public Button Button => _Button;

        public ModuleBinding(SACModuleBase.ISACBase module)
        {
            Module = module;
            if (IsUI)
            {
                _Button = new Button()
                {
                    Name = ModuleUI?.ShowButtonCaption ?? "Settings"
                };
                _Button.Click += (s, e) => ModuleUI?.ShowWindow();
            }
        }
    }
}
