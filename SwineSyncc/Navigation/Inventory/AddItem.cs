using SwineSyncc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SwineSyncc.Navigation
{
    public partial class AddItem : UserControl
    {

        public event EventHandler CancelClicked;
        public event EventHandler SaveCompleted;

        public AddItem()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(40);
            RoundedPanelStyle.ApplyRoundedCorners(addItemPanel, 40);

            this.BackColor = Color.WhiteSmoke;
            addItemPanel.BackColor = Color.FromArgb(217, 221, 220);

            buttonGroup1.CancelClicked += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += SaveHandler;
        }

        private void SaveHandler(object sender, EventArgs e)
        {

            if (comboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(quantityTxt.Text))
            {
                MessageBox.Show("Quantity is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityTxt.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtExpirationDate.Value < dtRecordDate.Value)
            {
                MessageBox.Show("Expiration date cannot be earlier than the record date.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string product = comboProduct.SelectedItem.ToString();
            DateTime recordDate = dtRecordDate.Value;
            DateTime expirationDate = dtExpirationDate.Value;
            string description = descriptionTxt.Text.Trim();

            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                {
                    string query = @"INSERT INTO Inventory
                             (ProductType, Quantity, RecordDate, ExpirationDate, Description)
                             VALUES (@ProductType, @Quantity, @RecordDate, @ExpirationDate, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductType", product);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@RecordDate", recordDate);
                        cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                        cmd.Parameters.AddWithValue("@Description", description);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Item added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveCompleted?.Invoke(this, EventArgs.Empty);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearFields()
        {
           comboProduct.SelectedIndex = -1;
           quantityTxt.Clear();
           dtRecordDate.Value = DateTime.Now;
           dtExpirationDate.Value = DateTime.Now;
           descriptionTxt.Clear();
        }

        private void buttonGroup1_Load(object sender, EventArgs e)
        {

        }

        private void addItemPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
