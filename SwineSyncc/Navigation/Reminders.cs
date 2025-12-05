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
        public event EventHandler BreedingPanelClicked;
        public event EventHandler ExpirationPanelClicked;
        public Reminders()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;

            farrowingPanel.BackColor = Color.FromArgb(240, 237, 232);

            farrowingPb.Image = Properties.Resources.PigReminder;


            pendingBreedingPb.Image = Properties.Resources.PendingIcon;

            expirationPb.Image = Properties.Resources.ExpirationIcon;

            farrowingPanel.Click += ReminderFarrowing_Click;
            checkForFarrowingLbl.Click += ReminderFarrowing_Click;

            pendingBreedingPanel.Click += ReminderPendingBreeding_Click;
            labelPendingBreeding.Click += ReminderPendingBreeding_Click;

            expirationPanel.Click += ReminderExpiration_Click;
            checkExp.Click += ReminderExpiration_Click;

            LoadNearestFarrowing();
            LoadPendingBreedingReminder();
            LoadNearestExpiration();
            LoadPigletReleaseReminder();
        }

        private void ReminderFarrowing_Click(object sender, EventArgs e)
        {
            FarrowingPanelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ReminderPendingBreeding_Click(object sender, EventArgs e)
        {
            BreedingPanelClicked?.Invoke(this, EventArgs.Empty);
        }
        private void ReminderExpiration_Click(object sender, EventArgs e)
        {
            ExpirationPanelClicked?.Invoke(this, EventArgs.Empty);
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

        private void LoadNearestExpiration()
        {
            string query = @"
                SELECT TOP 1 
                    ProductType,
                    ExpirationDate
                FROM Inventory
                WHERE ExpirationDate >= CAST(GETDATE() AS DATE)
                ORDER BY ExpirationDate ASC;
            ";
            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productType = reader["ProductType"].ToString();
                            DateTime expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            int daysLeft = (expirationDate - DateTime.Now.Date).Days;
                            expirationLbl.Text =
                                $"{productType} expires in {daysLeft} day(s)\n" +
                                $"Expiration Date: {expirationDate:MMMM dd, yyyy}";
                        }
                        else
                        {
                            expirationLbl.Text = "No upcoming expirations.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {               
                expirationLbl.Text = "Error loading expiration reminder.";               
            }
        }

        private void LoadPigletReleaseReminder()
        {
            string query = @"
                        SELECT TOP 1
                        T.TagNumber,
                        DATEADD(DAY, 21, T.Birthdate) AS ReleaseDate
                        FROM Piglets T
                        WHERE DATEADD(DAY, 21, T.Birthdate) >= CAST(GETDATE() AS DATE)
                        ORDER BY ReleaseDate ASC;
                     ";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string tag = reader["TagNumber"].ToString();
                        DateTime releaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                        int daysLeft = (releaseDate - DateTime.Now.Date).Days;

                        releasePigletLbl.Text =
                            $"Piglet {tag} will be released in {daysLeft} day(s)\n" +
                            $"Release Date: {releaseDate:MMMM dd, yyyy}";
                    }
                    else
                    {
                        releasePigletLbl.Text = "No upcoming piglet release dates.";
                    }
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
                LoadNearestExpiration();
                LoadPigletReleaseReminder();
            }
        }

    }
}
