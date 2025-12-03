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

namespace SwineSyncc.Navigation.BreedingRecords
{
    public partial class EditBreeding : Form
    {
        private int _breedingID;
        string[] breedingMethodValues = { "Natural Mating", "Artificial Insemination"};
        string[] resultValues = { "Success", "Failed", "Pending" };
        Breeding fetchData;
        public EditBreeding(int id)
        {
            InitializeComponent();
            _breedingID = id;
            var repo = new BreedingRepository();              // create repository
            fetchData = repo.GetBreedingById(_breedingID);  // get the actual record
        }

        private void LoadBreedingComboBoxes()
        {
            foreach (string breedingMethodValue in breedingMethodValues)
            {
                cbEditBreedingMethod.Items.Add(breedingMethodValue);
            }
            foreach (string resultValue in resultValues)
            {
                cbEditResult.Items.Add(resultValue);
            }
        }


        private void LoadBreedingData()
        {
            // Fetch the record first
            Breeding fetchData = new BreedingRepository().GetBreedingById(_breedingID);

            if (fetchData == null)
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Now populate controls
            cbEditBreedingSowName.SelectedValue = fetchData.SowID;
            cbEditBreedingBoarName.SelectedValue = fetchData.BoarID;
            cbEditBreedingMethod.SelectedItem = fetchData.BreedingMethod;
            dtpEditBreedingDate.Value = fetchData.BreedingDate;
            cbEditResult.SelectedItem = fetchData.Result;
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

                        cbEditBreedingSowName.Items.Clear();

                        while (reader.Read())
                        {
                            cbEditBreedingSowName.Items.Add(new SowName
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

                        cbEditBreedingBoarName.Items.Clear();

                        while (reader.Read())
                        {
                            cbEditBreedingBoarName.Items.Add(new BoarName
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

        private void EditBreeding_Load(object sender, EventArgs e)
        {
            LoadBreedingData();
            LoadBreedingComboBoxes();
            LoadSowNameCombo();
            LoadBoarNameCombo();
            lblEditBreeding.Text += " - ID: " + fetchData.BreedingID;
        }
    }
}
