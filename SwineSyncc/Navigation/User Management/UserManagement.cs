using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation
{
    public partial class UserManagement : UserControl
    {

        public event EventHandler AddUserClicked;

        public UserManagement()
        {
            InitializeComponent();
    }

        private void addAccountBtn_Click(object sender, EventArgs e)
        {
            AddUserClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
