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
        public Reminders()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;

            farrowingPanel.BackColor = Color.FromArgb(240, 237, 232);
            farrowingPb.Image = Properties.Resources.PigReminder;

            LoadNearestFarrowing();
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


    }
}
