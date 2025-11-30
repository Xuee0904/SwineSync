using SwineSyncc.Data;
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
using static SwineSyncc.Navigation.Pig_Management.AddPiglet;

namespace SwineSyncc.Navigation.Pig_Management
{
    public partial class AddBreeding : UserControl
    {

        public event EventHandler SaveCompleted;
        public event EventHandler CancelClicked;

        public AddBreeding()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addBreedingPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addBreedingPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += (s, e) => SaveHandler(s, e);

            LoadBoarNameCombo();
            LoadSowNameCombo();
        }
        public class SowName
        {
            public int PigID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class BoarName
        {
            public int PigID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadSowNameCombo()
        {
            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboSow.Items.Clear();

                        while (reader.Read())
                        {
                            comboSow.Items.Add(new SowName
                            {
                                PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                                Name = reader["Name"].ToString()
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error lding data: " + ex.Message);
                    }
                }
            }
        }

        private void LoadBoarNameCombo()
        {
            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Male' ORDER BY Name";

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        comboBoar.Items.Clear();

                        while (reader.Read())
                        {
                            comboBoar.Items.Add(new BoarName
                            {
                                PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                                Name = reader["Name"].ToString()
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading data: " + ex.Message);
                    }
                }
            }
        }

        private void ClearFields()
        {
            comboSow.SelectedIndex = -1;
            comboBoar.SelectedIndex = -1;
            dtBreeding.Value = DateTime.Now;
            comboMethod.SelectedIndex = -1;
            comboResult.SelectedIndex = -1;
        }

        private void comboMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMethod.SelectedItem == null)
                return;

            string method = comboMethod.SelectedItem.ToString();

            if (method == "Artificial insemination(AI)")
            {
                comboBoar.Enabled = false;           // Disable boar selection
                comboBoar.SelectedIndex = -1;        // Clear selected boar
                comboBoar.BackColor = Color.LightGray; // Make UI clearer
            }
            else
            {
                comboBoar.Enabled = true;            // Re-enable boar selection
                comboBoar.BackColor = Color.White;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveHandler(object sender, EventArgs e)
        {
            if (comboSow.SelectedItem == null)
            {
                MessageBox.Show("Please select a sow.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboSow.Focus();
                return;
            }

            if (comboMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a breeding method.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMethod.Focus();
                return;
            }

            string method = comboMethod.SelectedItem.ToString();

            if (method == "Natural" && comboBoar.SelectedItem == null)
            {
                MessageBox.Show("Please select a boar for natural breeding.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoar.Focus();
                return;
            }

            if (comboResult.SelectedItem == null)
            {
                MessageBox.Show("Please select the breeding result.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboResult.Focus();
                return;
            }

            if (dtBreeding.Value > DateTime.Now)
            {
                MessageBox.Show("Breeding date cannot be a future date.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtBreeding.Focus();
                return;
            }

            SowName selectedSow = comboSow.SelectedItem as SowName;
            BoarName selectedBoar = comboBoar.SelectedItem as BoarName;

            int sowPigId = selectedSow.PigID;
            object boarValue;

            if (method == "Artificial insemination(AI)")
            {
                boarValue = DBNull.Value;
            }
            else
            {
                boarValue = selectedBoar.PigID;
            }

            string result = comboResult.SelectedItem.ToString();
            DateTime breedingDate = dtBreeding.Value;

            int newBreedingID = 0;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {

                string query = @"INSERT INTO BreedingRecords (SowID, BoarID, BreedingDate, BreedingMethod, Result)
                                VALUES (@SowPigID, @BoarPigID, @BreedingDate, @Method, @Result);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SowPigID", sowPigId);
                    cmd.Parameters.AddWithValue("@BoarPigID", boarValue);
                    cmd.Parameters.AddWithValue("@BreedingDate", breedingDate);
                    cmd.Parameters.AddWithValue("@Method", method);
                    cmd.Parameters.AddWithValue("@Result", result);

                    try
                    {
                        conn.Open();

                        object newId = cmd.ExecuteScalar();

                        if (newId != null && newId != DBNull.Value)
                        {
                            newBreedingID = Convert.ToInt32(newId);
                        }

                        MessageBox.Show(
                            "Breeding record has been successfully saved!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        string logDescription;
                        if (method == "Artificial insemination(AI)")
                        {
                            logDescription =
                                $"Breeding Added (ID: {newBreedingID}) | Method: AI | Sow: {selectedSow.Name}";
                        }
                        else
                        {
                            logDescription =
                                $"Breeding Added (ID: {newBreedingID}) | Method: Natural | Sow: {selectedSow.Name}, Boar: {selectedBoar.Name}";
                        }


                        ActivityLogger.Log("Register breeding", logDescription);

                        if (result == "Success")
                        {
                            BreedingToPregnancyTransition(conn, newBreedingID, selectedSow);
                        }

                        ClearFields();
                        SaveCompleted?.Invoke(this, new BreedingSaveEventArgs(newBreedingID));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Database Error: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        /* using (SqlConnection conn = DBConnection.Instance.GetConnection())
         {
             string query = @"INSERT INTO BreedingRecords 
                     (SowID, BoarID, BreedingDate, BreedingMethod, Result)
                     VALUES (@SowPigID, @BoarPigID, @BreedingDate, @Method, @Result);
                     SELECT SCOPE_IDENTITY();";

             using (SqlCommand cmd = new SqlCommand(query, conn))
             {
                 cmd.Parameters.AddWithValue("@SowPigID", sowPigId);
                 cmd.Parameters.AddWithValue("@BoarPigID", boarValue);
                 cmd.Parameters.AddWithValue("@BreedingDate", breedingDate);
                 cmd.Parameters.AddWithValue("@Method", method);
                 cmd.Parameters.AddWithValue("@Result", result);

                 object newId = cmd.ExecuteScalar();

                 if (newId != null && newId != DBNull.Value)
                 {
                     newBreedingID = Convert.ToInt32(newId);
                 }

                 if (result == "Success")
                 {
                     BreeedingToPregnancyTransition(conn, newBreedingID, selectedSow);
                 }

                 try
                 {
                     conn.Open();
                     cmd.ExecuteNonQuery();

                     MessageBox.Show(
                         "Breeding record has been successfully saved!",
                         "Success",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information
                     );

                     string logDescription;

                     if (method == "Artificial insemination(AI)")
                     {
                         logDescription =
                             $"Breeding Added | Method: AI | Sow: {selectedSow.Name}";
                     }
                     else
                     {
                         logDescription =
                             $"Breeding Added | Method: Natural | Sow: {selectedSow.Name}, Boar: {selectedBoar.Name}";
                     }


                     ActivityLogger.Log("Register breeding", logDescription);

                     ClearFields();
                     SaveCompleted?.Invoke(this, EventArgs.Empty);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(
                         "Database Error: " + ex.Message,
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
                 }
             }
         }*/

        public class BreedingSaveEventArgs : EventArgs
        {
            public int BreedingID { get; }
            public BreedingSaveEventArgs(int breedingID) => BreedingID = breedingID;
        }


        private void BreedingToPregnancyTransition(SqlConnection conn, int breedingID, SowName selectedSow)
        {
            string sowName = selectedSow.Name;
            int sowID = selectedSow.PigID;

            DateTime expectedFarrowingDate = dtBreeding.Value.AddDays(114);
            DateTime confirmationDate = DateTime.Today; //user should upfate this later

            string query = @"
                INSERT INTO PregnancyRecords
                (PregnantPigID, BreedingID, ConfirmationDate, ExpectedFarrowingDate)
                VALUES (@PregnantPigID, @BreedingID, @ConfirmationDate, @ExpectedFarrowingDate)
            ";

            try
            {
                using (conn = DBConnection.Instance.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PregnantPigID", sowID);
                    cmd.Parameters.AddWithValue("@BreedingID", breedingID);
                    cmd.Parameters.AddWithValue("@ConfirmationDate", confirmationDate);
                    cmd.Parameters.AddWithValue("@ExpectedFarrowingDate", expectedFarrowingDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ActivityLogger.Log(
                    "Register pregnancy",
                    $"Pregnancy record added | Sow: {sowName} (ID: {sowID}), Breeding ID: {breedingID}, " +
                    $"Confirmation Date: {confirmationDate:yyyy-MM-dd}, Expected Farrowing Date: {expectedFarrowingDate:yyyy-MM-dd}"
                );
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void comboSow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
