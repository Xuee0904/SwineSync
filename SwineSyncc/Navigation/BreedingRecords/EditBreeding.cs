using SwineSyncc.Data;
using SwineSyncc.Navigation.Pig_Management;
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
using static SwineSyncc.Navigation.Pig_Management.AddBreeding;

namespace SwineSyncc.Navigation.BreedingRecords
{
    public partial class EditBreeding : Form
    {
        public event EventHandler SaveCompleted;

        private readonly int _breedingID;
        private Breeding fetchData;
       
        string[] breedingMethodValues = { "Natural", "Artificial insemination(AI)" };
        string[] resultValues = { "Success", "Failed", "Pending" };
        private bool _isInitializing;

        public EditBreeding(int id)
        {
            InitializeComponent();
            _breedingID = id;

            var repo = new BreedingRepository();
            fetchData = repo.GetBreedingById(_breedingID);

            buttonGroup1.CancelClicked += (s, e) => Close();
        }

        private void EditBreeding_Load(object sender, EventArgs e)
        {
            _isInitializing = true;

            if (fetchData == null)
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            LoadBreedingComboBoxes(); // method + result
            LoadSowNameCombo();       // sow list
            LoadBoarNameCombo();      // boar list

            cbEditBreedingMethod.SelectedItem = fetchData.BreedingMethod;
            cbEditResult.SelectedItem = fetchData.Result;
            dtpEditBreedingDate.Value = fetchData.BreedingDate;

            lblEditBreeding.Text += " - ID: " + fetchData.BreedingID;
           
            UpdateBoarComboState();

            _isInitializing = false;
        }       

        private void LoadBreedingComboBoxes()
        {
            cbEditBreedingMethod.Items.Clear();
            cbEditBreedingMethod.Items.AddRange(breedingMethodValues);

            cbEditResult.Items.Clear();
            cbEditResult.Items.AddRange(resultValues);
        }
        
        private void LoadSowNameCombo()
        {
            var sows = new List<SowName>();  

            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sows.Add(new SowName 
                        {
                            PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }

            
            cbEditBreedingSowName.DataSource = sows;
            cbEditBreedingSowName.DisplayMember = "Name";
            cbEditBreedingSowName.ValueMember = "PigID";
            
            cbEditBreedingSowName.SelectedItem = fetchData.SowName;
        }

        private void LoadBoarNameCombo()
        {
            var boars = new List<BoarName>();  

            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Male' ORDER BY Name";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        boars.Add(new BoarName 
                        {
                            PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }           
            boars.Insert(0, new BoarName { PigID = 0, Name = "Null" });

            cbEditBreedingBoarName.DataSource = boars;
            cbEditBreedingBoarName.DisplayMember = "Name";
            cbEditBreedingBoarName.ValueMember = "PigID";
           
            cbEditBreedingBoarName.SelectedItem = fetchData.BoarName;
        }

        private void cbEditBreedingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            
            var selected = cbEditBreedingMethod.SelectedItem as string;
            bool isAI = string.Equals(selected, "Artificial insemination(AI)", StringComparison.OrdinalIgnoreCase);

           
            UpdateBoarComboState();
        }
       
        private void UpdateBoarComboState()
        {
            var selected = cbEditBreedingMethod.SelectedItem as string;
            bool isAI = string.Equals(selected, "Artificial insemination(AI)", StringComparison.OrdinalIgnoreCase);

            cbEditBreedingBoarName.Enabled = !isAI;
            if (isAI)
            {
                cbEditBreedingBoarName.SelectedIndex = 0; 
                cbEditBreedingBoarName.BackColor = Color.LightGray; 
            }
            else
            {
                cbEditBreedingBoarName.BackColor = Color.White;
            }
        }

        private void SaveHandler(object sender, EventArgs e)
        {
            MessageBox.Show("SaveHandler started!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information); // di nalabas to ibig sabihin hindi ko na wire hahaha

           
        }
       
        private void BreedingToPregnancyTransition(SqlConnection conn, int breedingID, SowName selectedSow)
        {
            int sowID = selectedSow.PigID;

            DateTime expectedFarrowingDate = dtpEditBreedingDate.Value.AddDays(114);
            DateTime confirmationDate = DateTime.Today;

            string query = @"
                INSERT INTO PregnancyRecords
                (PregnantPigID, BreedingID, ConfirmationDate, ExpectedFarrowingDate)
                VALUES (@PregnantPigID, @BreedingID, @ConfirmationDate, @ExpectedFarrowingDate);
            ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))  
                {
                    cmd.Parameters.AddWithValue("@PregnantPigID", sowID);
                    cmd.Parameters.AddWithValue("@BreedingID", breedingID);
                    cmd.Parameters.AddWithValue("@ConfirmationDate", confirmationDate);
                    cmd.Parameters.AddWithValue("@ExpectedFarrowingDate", expectedFarrowingDate);

                    cmd.ExecuteNonQuery();
                }

                ActivityLogger.Log(
                    "Register pregnancy",
                    $"Pregnancy record added | Sow: {selectedSow.Name}, Breeding ID: {breedingID}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGroup1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbEditBreedingSowName.SelectedItem == null)
            {
                MessageBox.Show("Please select a sow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEditBreedingMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a breeding method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string method = cbEditBreedingMethod.SelectedItem.ToString();


            if (method == "Natural" && cbEditBreedingBoarName.SelectedItem == null)
            {
                MessageBox.Show("Please select a boar for natural breeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbEditResult.SelectedItem == null)
            {
                MessageBox.Show("Please select the breeding result.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEditBreedingDate.Value > DateTime.Now)
            {
                MessageBox.Show("Breeding date cannot be a future date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            SowName selectedSow = cbEditBreedingSowName.SelectedItem as SowName;
            BoarName selectedBoar = cbEditBreedingBoarName.SelectedItem as BoarName;


            if (selectedSow == null)
            {
                MessageBox.Show("Invalid sow selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sowId = selectedSow.PigID;

            object boarValue;

            if (method == "Artificial insemination(AI)")
            {
                boarValue = DBNull.Value;
            }
            else
            {
                if (selectedBoar == null || selectedBoar.PigID == 0)
                {
                    MessageBox.Show("Please select a valid boar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                boarValue = selectedBoar.PigID;
            }

            string result = cbEditResult.SelectedItem.ToString();
            DateTime breedingDate = dtpEditBreedingDate.Value;

            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = @"
                    UPDATE BreedingRecords
                    SET 
                        SowID = @SowID,
                        BoarID = @BoarID,
                        BreedingDate = @BreedingDate,
                        BreedingMethod = @Method,
                        Result = @Result
                    WHERE BreedingID = @BreedingID;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SowID", sowId);
                    cmd.Parameters.AddWithValue("@BoarID", boarValue);
                    cmd.Parameters.AddWithValue("@BreedingDate", breedingDate);
                    cmd.Parameters.AddWithValue("@Method", method);
                    cmd.Parameters.AddWithValue("@Result", result);
                    cmd.Parameters.AddWithValue("@BreedingID", _breedingID);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No changes were made. The record may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        MessageBox.Show("Breeding record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string logDescription;
                        if (method == "Artificial insemination(AI)")
                        {
                            logDescription = $"Breeding Updated (ID: {_breedingID}) | Method: AI | Sow: {selectedSow.Name}";
                        }
                        else
                        {
                            logDescription = $"Breeding Updated (ID: {_breedingID}) | Method: Natural | Sow: {selectedSow.Name}, Boar: {selectedBoar.Name}";
                        }

                        ActivityLogger.Log("Edit breeding", logDescription);


                        if (result == "Success" && fetchData.Result != "Success")
                        {
                            string checkQuery = "SELECT COUNT(*) FROM PregnancyRecords WHERE BreedingID = @BreedingID";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@BreedingID", _breedingID);
                                int existingPregnancies = (int)checkCmd.ExecuteScalar();
                                if (existingPregnancies == 0)
                                {
                                    BreedingToPregnancyTransition(conn, _breedingID, selectedSow);
                                }
                            }
                        }

                        SaveCompleted?.Invoke(this, new BreedingSaveEventArgs(_breedingID));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
