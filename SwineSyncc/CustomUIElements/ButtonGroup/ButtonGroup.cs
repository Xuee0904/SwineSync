using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.CustomUIElements.ButtonGroup
{
    public partial class ButtonGroup : UserControl
    {

        public event EventHandler CancelClicked;
        public event EventHandler ClearClicked;
        public event EventHandler SaveClicked;

        public ButtonGroup()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearClicked?.Invoke(this, EventArgs.Empty);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
