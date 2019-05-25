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

            _Button = new Button()
            {
                Name = IsUI ? ModuleUI?.ShowButtonCaption ?? "Settings" : "DON'T CLICK!"
            };
            if (IsUI)
                _Button.Click += (s, e) => ModuleUI?.ShowWindow();
            else
                _Button.Click += (s, e) => MessageBox.Show("I SAY DON'T F...... CKICK!", "WHY????", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
