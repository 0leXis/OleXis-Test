using System;
using System.Windows.Forms;

namespace TestirSystem
{
    public partial class PasswordDialog : Form
    {
        public string Password
        {
            get
            {
                return textBoxPassword.Text;
            }
        }

        public PasswordDialog()
        {
            InitializeComponent();
        }

        private void PasswordDialog_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
        }
    }
}
