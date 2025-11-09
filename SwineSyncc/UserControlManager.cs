using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwineSyncc.Navigation;
using SwineSyncc.Data;

namespace SwineSyncc
{
    public class UserControlManager
    {
        private Panel _mainPanel;
        private PigManagement _pigUC;
        private PregnancyReccords _pregnancyUC;
        private UserManagement _userManagementUC;

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
            if (_pigUC == null)
            {
                _pigUC = new PigManagement(_mainPanel);
                _pigUC.RegisterPigClicked += (s, e) => LoadRegisterPig();
            }
            ShowUserControl(_pigUC);
        }


        public void LoadRegisterPig()
        {
            RegisterPig registerPig = new RegisterPig(_pigUC);

            registerPig.CancelClicked += (s, e) => ShowUserControl(_pigUC);
            registerPig.SaveCompleted += (s, e) => ShowUserControl(_pigUC);

            ShowUserControl(registerPig);
        }


        public void LoadPregnancyRecords()
        {
            if (_pregnancyUC == null)
            {
                _pregnancyUC = new PregnancyReccords();
            }
            ShowUserControl(_pregnancyUC);
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
                _userManagementUC = new UserManagement();

                _userManagementUC.AddUserClicked += (s, e) => LoadAddUser();
            }
            ShowUserControl(_userManagementUC);
        }


        public void LoadAddUser()
        {
            AddUser addUser = new AddUser();

            ShowUserControl(addUser);
        }
    }
}
