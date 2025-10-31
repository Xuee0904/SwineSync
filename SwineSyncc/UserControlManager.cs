using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc
{
    public class UserControlManager
    {
        private Panel _mainPanel;
        private PigManagement _pigUC;
        private PregnancyReccords _pregnancyUC;

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
    }
}
