using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public partial class Dashboard : Form
    {
        private NavigationPanel navigationPanel;
        private PigManagement pigUC;
        private PregnancyReccords pregnancyUC;

        public Dashboard()
        {
            InitializeComponent();
            navigationPanel = new NavigationPanel();
            navPanel.Controls.Add(navigationPanel);
            
            navigationPanel.pigManagementBtn.Click += (s, e) => LoadPigManagement();
            navigationPanel.PregnancyRecordsClicked += (s, e) => LoadPregnancyRecords();

        }

        private void ShowUserControl(UserControl uc)
        {        
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void LoadPigManagement()
        {
            if (pigUC == null)
            {
                pigUC = new PigManagement();
                pigUC.RegisterPigClicked += (s, e) => LoadRegisterPig();
            }
            ShowUserControl(pigUC);
        }

        private void LoadRegisterPig()
        {                    
            RegisterPig registerPig = new RegisterPig(pigUC);

            registerPig.CancelClicked += (s, e) => ShowUserControl(pigUC);
            registerPig.SaveCompleted += (s, e) => ShowUserControl(pigUC);

            ShowUserControl(registerPig);
        }

        private void LoadPregnancyRecords()
        {
            if (pregnancyUC == null)
                pregnancyUC = new PregnancyReccords();

            ShowUserControl(pregnancyUC);
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void navPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
