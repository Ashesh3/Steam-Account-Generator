using System;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class InputDialog : Form
    {
        public InputDialog(string error)
        {
            InitializeComponent();
            lblError.Text = error;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
