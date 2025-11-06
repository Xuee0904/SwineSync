using System;
using System.Windows.Forms;
using SwineSyncc.DynamicButtonLoader;

namespace SwineSyncc.Navigation
{
    public partial class PigDetails : UserControl
    {
        private Panel _mainPanel;
        private UserControlManager _controlManager;

        private int _motherPigId;

        public PigDetails(Panel mainPanel) : this()
        {
            _mainPanel = mainPanel;
            _controlManager = new UserControlManager(mainPanel);
        }

        public PigDetails()
        {
            InitializeComponent();
            RoundedPanelStyle.ApplyRoundedCorners(pigDetailsPanel, 20);
            pigDetailsPanel.BackColor = System.Drawing.Color.FromArgb(217, 221, 220);
            this.Padding = new Padding(40);
        }

        public void DisplayPigDetails(int id, string name, string breed, string sex, DateTime birthdate, int weight, string status)
        {
            _motherPigId = id;

            lblPig.Text = id.ToString();
            lblpignamelabel.Text = name;
            breedLbl.Text = breed;
            sexLbl.Text = sex;
            birthDateLbl.Text = birthdate.ToShortDateString();
            weightLbl.Text = weight.ToString();
            statusLbl.Text = status;

            if (sex.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {               
                currentPigletsLbl.Visible = true;
                rightLineLbl.Visible = true;
                leftLineLbl.Visible = true;
                addPigletBtn.Visible = true;
                flpCurrentPiglets.Visible = true;

                LoadPiglets();
            }
            else
            {
                currentPigletsLbl.Visible = false;
                rightLineLbl.Visible = false;
                leftLineLbl.Visible = false;
                addPigletBtn.Visible = false;
                flpCurrentPiglets.Visible = false;
            }
        }

        // loads dynamic buttons for piglets belonging to the current mother pig
        private void LoadPiglets()
        {
            var loader = new PigletLoader(flpCurrentPiglets, _motherPigId, OnPigletSelected);
            loader.LoadPiglets();
        }

        // when a piglet button is clicked
        private void OnPigletSelected(int pigletId)
        {
            // instead of creating the control manually, delegate to UserControlManager
            _controlManager.LoadPigletDetails(pigletId);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _controlManager.LoadPigManagement();
        }

        // when Add piglet button is clicked
        private void addPigletBtn_Click(object sender, EventArgs e)
        {
            _controlManager.LoadRegisterPiglet(_motherPigId);
        }
    }
}
