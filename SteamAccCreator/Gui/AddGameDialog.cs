using System;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class AddGameDialog : Form
    {
        public Models.GameInfo GameInfo { get; private set; }

        public AddGameDialog()
        {
            InitializeComponent();
        }

        public AddGameDialog(Models.GameInfo gameInfo) : this()
        {
            if (gameInfo == null)
                return;

            GameInfo = gameInfo;

            TbName.Text = gameInfo.Name;
            NumSubId.Value = gameInfo.SubId;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            GameInfo = new Models.GameInfo()
            {
                Name = TbName.Text,
                SubId = (int)NumSubId.Value
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
