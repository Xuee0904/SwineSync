using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class AddPig : UserControl
    {
        public event EventHandler BackClicked;

        public event EventHandler SowAddRequest;
        public event EventHandler BoarAddRequest;
        public event EventHandler PigletAddRequest;

        public AddPig()
        {
            InitializeComponent();

            sowRadioBtn.CheckedChanged += PigTypeRadioBtn_CheckedChanged;
            boarRadioBtn.CheckedChanged += PigTypeRadioBtn_CheckedChanged;
            pigletRadioBtn.CheckedChanged += PigTypeRadioBtn_CheckedChanged;
        }

        private void PigTypeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioBtn = sender as RadioButton;

            if (selectedRadioBtn != null && selectedRadioBtn.Checked)
            {
                formsPanel.Controls.Clear();

                if (selectedRadioBtn == sowRadioBtn)
                {
                    backBtn.Hide();

                    SowAddRequest?.Invoke(this, EventArgs.Empty);
                }

                if (selectedRadioBtn == boarRadioBtn)
                {
                    backBtn.Hide();

                    BoarAddRequest?.Invoke(this, EventArgs.Empty);
                }

                if (selectedRadioBtn == pigletRadioBtn)
                {
                    backBtn.Hide();

                    PigletAddRequest?.Invoke(this, EventArgs.Empty);
                }
                
            }
        }

        public Panel FormsPanel => formsPanel;

        private void backBtn_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}