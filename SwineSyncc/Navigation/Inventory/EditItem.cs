using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SwineSyncc.Data;

namespace SwineSyncc.Navigation
{
    public partial class EditItem : Form
    {
        private readonly int _ProductID;
        private Item fetchData;

        public EditItem(int id)
        {
            InitializeComponent();

            _ProductID = id; // assign the parameter

            var repo = new InventoryRepository();
            fetchData = repo.GetInventoryById(_ProductID);

            LoadInventoryData();

            buttonGroup1.CancelClicked += (s, e) => Close();
            buttonGroup1.ClearClicked += (s, e) => ClearFields();
            buttonGroup1.SaveClicked += SaveHandler;
        }

        private void EditItem_Load(object sender, EventArgs e)
        {
           
        }

 
        private void LoadInventoryData()
        {
            if (fetchData == null)
            {
                MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            comboProduct.SelectedItem = fetchData.ProductType;
            quantityTxt.Text = fetchData.Quantity.ToString();
            dtRecordDate.Value = fetchData.RecordDate;
            dtExpirationDate.Value = fetchData.ExpirationDate;
            descriptionTxt.Text = fetchData.Description ?? string.Empty;
        }


        private void SaveHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(quantityTxt.Text) || !int.TryParse(quantityTxt.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Quantity must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtExpirationDate.Value.Date < dtRecordDate.Value.Date)
            {
                MessageBox.Show("Expiration date cannot be earlier than record date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string product = comboProduct.SelectedItem?.ToString();
            DateTime recordDate = dtRecordDate.Value;
            DateTime expirationDate = dtExpirationDate.Value;
            string description = descriptionTxt.Text.Trim();

            try
            {
                using (SqlConnection conn = DBConnection.Instance.GetConnection())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Inventory
                        SET ProductType = @ProductType,
                            Quantity = @Quantity,
                            RecordDate = @RecordDate,
                            ExpirationDate = @ExpirationDate,
                            Description = @Description
                        WHERE ProductID = @ProductID;
                    ";

                    cmd.Parameters.AddWithValue("@ProductType", (object)product ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@RecordDate", recordDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                    cmd.Parameters.AddWithValue("@ProductID", _ProductID);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Record may have been removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
