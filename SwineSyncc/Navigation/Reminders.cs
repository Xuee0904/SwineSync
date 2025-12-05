using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwineSyncc.Data;


namespace SwineSyncc.Navigation
{
    public partial class Reminders : UserControl
    {
        public event EventHandler FarrowingPanelClicked;
        public Reminders()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;

            farrowingPanel.BackColor = Color.FromArgb(240, 237, 232);
            farrowingPb.Image = Properties.Resources.PigReminder;


            pendingBreedingPb.Image = Properties.Resources.PendingIcon;

            farrowingPanel.Click += ReminderFarrowing_Click;
            checkForFarrowingLbl.Click += ReminderFarrowing_Click;


            LoadNearestFarrowing();
            LoadPendingBreedingReminder();
        }

        private void ReminderFarrowing_Click(object sender, EventArgs e)
        {
            FarrowingPanelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void LoadNearestFarrowing()
        {
            string query = @"
                SELECT TOP 1 
                    P.Name AS SowName,
                    PR.ExpectedFarrowingDate
                FROM PregnancyRecords PR
                INNER JOIN Pigs P ON P.PigID = PR.PregnantPigID
                WHERE PR.ExpectedFarrowingDate >= CAST(GETDATE() AS DATE)
                ORDER BY PR.ExpectedFarrowingDate ASC;
            ";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string sowName = reader["SowName"].ToString();
                        DateTime farrowDate = Convert.ToDateTime(reader["ExpectedFarrowingDate"]);

                        int daysLeft = (farrowDate - DateTime.Now.Date).Days;

                        farrowingLbl.Text =
                            $"{sowName} is due in {daysLeft} day(s)\n" +
                            $"Farrowing Date: {farrowDate:MMMM dd, yyyy}";
                    }
                    else
                    {
                        farrowingLbl.Text = "No upcoming farrowing dates.";
                    }
                }
            }
        }

        private void LoadPendingBreedingReminder()
        {
            string query = @"
                SELECT TOP 1
                    P.Name AS SowName,
                    DATEADD(DAY, 21, BR.BreedingDate) AS ConfirmationDue,
                    (SELECT COUNT(*) FROM BreedingRecords WHERE Result = 'Pending') AS TotalPending
                FROM BreedingRecords BR
                JOIN Pigs P ON BR.SowID = P.PigID
                WHERE BR.Result = 'Pending'
                ORDER BY ConfirmationDue ASC;
            ";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string sowName = reader["SowName"].ToString();
                    DateTime dueDate = Convert.ToDateTime(reader["ConfirmationDue"]);
                    int totalPending = Convert.ToInt32(reader["TotalPending"]);

                    pendingBreedingLbl.Text =
                        $"{totalPending} pending breeding confirmation(s)\n" +
                        $"Next due: {dueDate:MMM dd, yyyy}";
                }
                else
                {
                    pendingBreedingLbl.Text = "No pending breeding confirmations";
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            
            if (this.Visible)
            {
                LoadNearestFarrowing();
                LoadPendingBreedingReminder();
            }
        }

    }
}
