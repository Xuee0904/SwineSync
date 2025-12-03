using SwineSyncc.Data;
using SwineSyncc.Navigation;
using SwineSyncc.Navigation.Pig_Management;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwineSyncc
{
    public class UserControlManager
    {
        private Panel _mainPanel;
        private PigManagement _pigUC;
        private PregnancyRecords _pregnancyUC;
        private UserManagement _userManagementUC;
        private BreedingRecords _breedingUC;
        private Reminders _remindersUC;
        private Inventory _inventoryUC;
        private HealthRecords _healthUC;
        private DashboardUI _dashboardUC;

        public UserControlManager(Panel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        private void ShowUserControl(UserControl uc)
        {         
            _mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            _mainPanel.Controls.Add(uc);
        }


        public void LoadPigManagement()
        {
            _pigUC = new PigManagement(_mainPanel);
            _pigUC.RegisterPigClicked += (s, e) => LoadAddPig();

            _pigUC.ToggleViewToTableClicked += (s, e) => LoadSowTable();

            ShowUserControl(_pigUC);
        }     
        

        public void LoadAddPig()
        {
            AddPig addPig = new AddPig();

            addPig.SowAddRequest += (s, e) => LoadAddSowInAddPig(addPig.FormsPanel);
            addPig.BoarAddRequest += (s, e) => LoadAddBoarInAddPig(addPig.FormsPanel);
            addPig.PigletAddRequest += (s, e) => LoadAddPigletInAddPig(addPig.FormsPanel);

            addPig.BackClicked += (s, e) => ShowUserControl(_pigUC);

            ShowUserControl(addPig);
        }

        public void LoadAddSowInAddPig(Panel formsPanel)
        {
            AddSow addSow = new AddSow();

            addSow.SaveCompleted += (s, e) =>
            {
                _pigUC.RefreshPigList();

                ShowUserControl(_pigUC);
            };

            addSow.CancelClicked += (s, e) =>
            {
                ShowUserControl(_pigUC);
            };

            formsPanel.Controls.Clear();

            addSow.Dock = DockStyle.Fill;
            addSow.Padding = new Padding(15);


            formsPanel.Controls.Add(addSow);
        }

        public void LoadAddBoarInAddPig(Panel formsPanel)
        {
            AddBoar addBoar = new AddBoar();

            addBoar.SaveCompleted += (s, e) =>
            {
                _pigUC.RefreshPigList();

                ShowUserControl(_pigUC);
            };

            addBoar.CancelClicked += (s, e) =>
            {
                ShowUserControl(_pigUC);
            };

            formsPanel.Controls.Clear();

            addBoar.Dock = DockStyle.Fill;
            addBoar.Padding = new Padding(15);

            formsPanel.Controls.Add(addBoar);
        }

        public void LoadAddPigletInAddPig(Panel formsPanel)
        {

            AddPiglet addPiglet = new AddPiglet();

            addPiglet.SaveCompleted += (s, e) =>
            {
                _pigUC?.RefreshPigList();
                ShowUserControl(_pigUC);
            };

            addPiglet.CancelClicked += (s, e) =>
            {
                ShowUserControl(_pigUC);
            };

            formsPanel.Controls.Clear();

            addPiglet.Dock = DockStyle.Fill;
            addPiglet.Padding = new Padding(10);
            formsPanel.Controls.Add(addPiglet);
        }

        //reserba
        /* public void LoadRegisterPig()
         {
             RegisterPig registerPig = new RegisterPig(_pigUC);

             registerPig.CancelClicked += (s, e) => ShowUserControl(_pigUC);
             registerPig.SaveCompleted += (s, e) => ShowUserControl(_pigUC);

             ShowUserControl(registerPig);
         }*/


        public void LoadPregnancyRecords()
        {
            if (_pregnancyUC == null)
            {
                _pregnancyUC = new PregnancyRecords();

                _pregnancyUC.AddPregnancyRecordClicked += (s, e) => LoadAddPregnancy();
            }
            ShowUserControl(_pregnancyUC);
        }

        public void LoadReminders()
        {
            if (_remindersUC == null)
            {
                _remindersUC = new Reminders();

            }
            ShowUserControl(_remindersUC);
        }

        public void LoadAddPregnancy()
        { 
            AddPregnancy addPregnancy = new AddPregnancy();
            ShowUserControl(addPregnancy);
        }

        public void LoadBreedingRecords()
        {
            if (_breedingUC == null)
            {
                _breedingUC = new BreedingRecords();

                _breedingUC.AddBreedingRecordClicked += (s, e) => LoadAddBreeding();
            }
            ShowUserControl(_breedingUC);
        }

        public void LoadAddBreeding()
        {
            AddBreeding addBreeding = new AddBreeding();

            addBreeding.CancelClicked += (s, e) => ShowUserControl(_breedingUC);

            ShowUserControl(addBreeding);
        }

        public void LoadRegisterPiglet(int motherPigId)
        {
            RegisterPiglet registerPiglet = new RegisterPiglet(motherPigId);

            registerPiglet.CancelClicked += (s, e) =>
            {
                var repo = new PigRepository();
                var pig = repo.GetPigById(motherPigId);
                if (pig != null)
                {
                    PigDetails pigDetails = new PigDetails(_mainPanel);
                    pigDetails.DisplayPigDetails(
                        pig.PigID,
                        pig.Name,
                        pig.Breed,
                        pig.Sex,
                        pig.Birthdate,
                        pig.Weight,
                        pig.Status
                    );
                    ShowUserControl(pigDetails);
                }
            };

            registerPiglet.SaveCompleted += (s, e) =>
            {
                var repo = new PigRepository();
                var pig = repo.GetPigById(motherPigId);
                if (pig != null)
                {
                    PigDetails pigDetails = new PigDetails(_mainPanel);
                    pigDetails.DisplayPigDetails(
                        pig.PigID,
                        pig.Name,
                        pig.Breed,
                        pig.Sex,
                        pig.Birthdate,
                        pig.Weight,
                        pig.Status
                    );
                    ShowUserControl(pigDetails);
                }
            };

            ShowUserControl(registerPiglet);
        }
      
        public void LoadPigletDetails(int pigletId)
        {
            PigletDetails pigletDetails = new PigletDetails(_mainPanel);

            pigletDetails.BackClicked += (s, motherPigId) =>
            {
                var repo = new PigRepository();
                var pig = repo.GetPigById(motherPigId);

                if (pig != null)
                {
                    PigDetails pigDetails = new PigDetails(_mainPanel);
                    pigDetails.DisplayPigDetails(
                        pig.PigID,
                        pig.Name,
                        pig.Breed,
                        pig.Sex,
                        pig.Birthdate,
                        pig.Weight,
                        pig.Status
                    );
                    ShowUserControl(pigDetails);
                }
            };

            pigletDetails.DisplayPigletDetails(pigletId);
            ShowUserControl(pigletDetails);
        }
    
        public void LoadUserManagement()
        {           
            if (_userManagementUC == null)
            {
                _userManagementUC = new UserManagement(_mainPanel);             
                _userManagementUC.AddUserClicked += (s, e) => LoadAddUser();
            }

            ShowUserControl(_userManagementUC);
        }

        public void LoadAddUser()
        {
            AddUser addUser = new AddUser();

            addUser.CancelClicked += (s, e) => ShowUserControl(_userManagementUC);

            addUser.SaveCompleted += (s, e) =>
            {
                ShowUserControl(_userManagementUC);
                _userManagementUC.RefreshUserList(); 
            };
            ShowUserControl(addUser);
        }       

        public void LoadSowTable()
        {
            SowTable sowTable = new SowTable(_mainPanel);

            sowTable.BackToCardViewClicked += (s, e) =>
            {              
                ShowUserControl(_pigUC);
            };

            ShowUserControl(sowTable);
        }

        public void LoadInventory()
        {
            if (_inventoryUC == null)
            {
                _inventoryUC = new Inventory();

            }
            ShowUserControl(_inventoryUC);
        }

        public void LoadHealthRecords()
        {
            if (_healthUC == null)
            {
                _healthUC = new HealthRecords();
            }
            ShowUserControl (_healthUC);
        }       

    }
}
