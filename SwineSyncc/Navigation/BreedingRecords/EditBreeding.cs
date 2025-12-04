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
        private readonly int _breedingID;
        private Breeding fetchData;

        string[] breedingMethodValues = { "Natural Mating", "Artificial Insemination" };
        string[] resultValues = { "Success", "Failed", "Pending" };
        private bool _isInitializing;

        public EditBreeding(int id)
        {
            InitializeComponent();
            _breedingID = id;

            var repo = new BreedingRepository();
            fetchData = repo.GetBreedingById(_breedingID);
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

            // Initial boar state
            cbEditBreedingBoarName.Enabled = !string.Equals(cbEditBreedingMethod.SelectedItem as string, "Artificial Insemination", StringComparison.OrdinalIgnoreCase);
            if (!cbEditBreedingBoarName.Enabled) cbEditBreedingBoarName.SelectedIndex = -1;

            _isInitializing = false;
        }

        // Pig DTO used for binding
        private class Pig
        {
            public int PigID { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
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
            var sows = new List<Pig>();

            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Female' ORDER BY Name";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sows.Add(new Pig
                        {
                            PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }

            // Bind list to ComboBox so SelectedValue works
            cbEditBreedingSowName.DataSource = sows;
            cbEditBreedingSowName.DisplayMember = "Name";
            cbEditBreedingSowName.ValueMember = "PigID";
            cbEditBreedingSowName.SelectedItem = fetchData.SowName; // safe default
        }

        private void LoadBoarNameCombo()
        {
            var boars = new List<Pig>();

            string query = "SELECT PigID, Name FROM Pigs WHERE Sex = 'Male' ORDER BY Name";
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        boars.Add(new Pig
                        {
                            PigID = reader.GetInt32(reader.GetOrdinal("PigID")),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }
            // If you want a literal "Null" option visible in the dropdown, uncomment:
            boars.Insert(0, new Pig { PigID = 0, Name = "Null" });

            cbEditBreedingBoarName.DataSource = boars;
            cbEditBreedingBoarName.DisplayMember = "Name";
            cbEditBreedingBoarName.ValueMember = "PigID";
            cbEditBreedingBoarName.SelectedItem = fetchData.BoarName; // safe default
        }

        private void cbEditBreedingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;

            var selected = cbEditBreedingMethod.SelectedItem as string;
            bool isAI = string.Equals(selected, "Artificial Insemination", StringComparison.OrdinalIgnoreCase);

            cbEditBreedingBoarName.Enabled = !isAI;
            if (isAI)
            {
                // clear selection visually
                cbEditBreedingBoarName.SelectedIndex = -1;
            }
        }
    }
}
