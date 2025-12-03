using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwineSyncc.Login;
using SwineSyncc.Navigation;

namespace SwineSyncc
{
    public partial class Dashboard : Form
    {
        private NavigationPanel navigationPanel;
        private UserControlManager ucManager;

        public Dashboard()
        {
            InitializeComponent();
            navigationPanel = new NavigationPanel();
            navPanel.Controls.Add(navigationPanel);

            ucManager = new UserControlManager(mainPanel);

            navigationPanel.PigManagementClicked += (s, e) => ucManager.LoadPigManagement();
            navigationPanel.PregnancyRecordsClicked += (s, e) => ucManager.LoadPregnancyRecords();
            navigationPanel.UserManagementClicked += (s, e) => ucManager.LoadUserManagement();
            navigationPanel.BreedingRecordsClicked += (s, e) => ucManager.LoadBreedingRecords();
            navigationPanel.RemindersClicked += (s, e) => ucManager.LoadReminders();
            navigationPanel.InventoryClicked += (s, e) => ucManager.LoadInventory();
            navigationPanel.HealthRecordsClicked += (s, e) => ucManager.LoadHealthRecords();
            //navigationPanel.DashboardClicked += (s, e) => ucManager.LoadDashboard();

            navigationPanel.DashboardClicked += (s, e) => ShowDashboard(); 

            ApplyAccessLevel();
            ShowDashboard();
        }

        private void ApplyAccessLevel()
        {
            if (Session.Role == "Assistant")
            {
                navigationPanel.HideUserManagementButton();
            }
            else if (Session.Role == "Admin")
            {
                
            }
        }

        private void ShowDashboard()
        {
            DashboardUI dashboard = new DashboardUI();         
            dashboard.TotalPigsPanelClicked += (s, e) =>
            {              
                navigationPanel.TriggerPigManagementClick();             
                ucManager.LoadPigManagement();
            };

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(dashboard);
            dashboard.Dock = DockStyle.Fill;
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
