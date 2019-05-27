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

        public string ButtonName => IsUI ? ModuleUI?.ShowButtonCaption ?? "Settings" : "NULL";
        public Action OnClick => () =>
        {
            if (IsUI)
                ModuleUI?.ShowWindow();
            else
                MessageBox.Show("No GUI here...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        public ModuleBinding(SACModuleBase.ISACBase module)
        {
            Module = module;
        }
    }
}
