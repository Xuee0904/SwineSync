using SwineSyncc.Data;
using SwineSyncc.Navigation.BreedingRecords;
using SwineSyncc.Navigation.PregnancyRecords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation
{
    public partial class SwineSyncTable : UserControl
    {
        private string tableQuery;
        private string currentTable;
        private const int IconWidth = 18;     
        private const int IconHeight = 18;
        private const int IconPadding = 6;     
        private const int ActionColWidth = IconWidth + IconPadding + 8; 
        // debounce timer for adaptive sizing
        private readonly System.Windows.Forms.Timer _adjustTimer = new System.Windows.Forms.Timer { Interval = 120 };

        // one-time initialization guards
        private bool _columnsInitialized;
        private int _cachedHeaderHeight;
        private bool _isAdjustingColumns;

        public SwineSyncTable()
        {
            InitializeComponent();
            this.Load += SwineSyncTable_Load;

            InitAdjustTimer();

            // wire data/size events
            dataGridView1.DataBindingComplete -= DataGridView1_DataBindingComplete;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;

            dataGridView1.SizeChanged -= DataGridView1_SizeChanged;
            dataGridView1.SizeChanged += DataGridView1_SizeChanged;

            // wire cell click for edit/delete
            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void SwineSyncTable_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        public void SetTableQuery(string tableName)
        {
            if (tableName == "SowTable")
                this.tableQuery = @"SELECT * FROM Pigs WHERE Sex = 'Female'";
            else if (tableName == "BoarTable")
                this.tableQuery = @"SELECT * FROM Pigs WHERE Sex = 'Male'";
            else if (tableName == "PigletTable")
                this.tableQuery = @"SELECT * FROM Piglets";
            else if (tableName == "BreedingRecords")
                this.tableQuery = @"SELECT b.BreedingID, pSow.Name AS SowName,
                                    CASE 
                                        WHEN LOWER(b.BreedingMethod) LIKE '%artificial insemination%' 
                                             THEN 'NULL' 
                                        ELSE pBoar.Name 
                                    END AS BoarName, b.BreedingMethod, b.BreedingDate, b.Result
                                    FROM BreedingRecords b
                                    LEFT JOIN Pigs pSow ON b.SowID = pSow.PigID
                                    LEFT JOIN Pigs pBoar ON b.BoarID = pBoar.PigID
                                    ORDER BY b.BreedingID;";
            else if (tableName == "PregnancyRecords")
                this.tableQuery = @"SELECT P.PregnancyID, PSow.Name, P.BreedingID,  P.ConfirmationDate, P.ExpectedFarrowingDate
                FROM PregnancyRecords AS P
                LEFT JOIN Pigs AS PSow ON P.PregnantPigID = PSow.PigID";
            else if (tableName == "Inventory")
                this.tableQuery = @"SELECT * FROM Inventory";
            else
                this.tableQuery = "SELECT * FROM " + tableName;

            // schema changed — allow defaults to re-run next time
            _columnsInitialized = false;
            this.currentTable = tableName;
        }

        public string GetTableQuery() => this.tableQuery;

        #region Load and initialization

        public void LoadTable()
        {
            var table = new DataTable();
            using (var conn = DBConnection.Instance.GetConnection())
            using (var adapter = new SqlDataAdapter(GetTableQuery(), conn))
            {
                adapter.Fill(table);
            }

            foreach (DataColumn c in table.Columns)
                Debug.WriteLine("Col: " + c.ColumnName);

            if (table.Rows.Count > 0)
                Debug.WriteLine("Row0: " + string.Join(", ", table.Rows[0].ItemArray));
            dataGridView1.DataSource = table;

            EnsureColumnDefaults();

            // appearance that is not per-column width
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            AddEditDeleteColumns();

            // schedule adaptive sizing (debounced)
            ScheduleAdjustColumns();
        }

        private void EnsureColumnDefaults()
        {
            if (_columnsInitialized) return;
            _columnsInitialized = true;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.MinimumWidth = Math.Max(100, col.MinimumWidth);
            }

            if (dataGridView1.IsHandleCreated)
            {
                using (var g = dataGridView1.CreateGraphics())
                {
                    var headerFont = dataGridView1.ColumnHeadersDefaultCellStyle.Font ?? dataGridView1.Font;
                    var fm = g.MeasureString("Mg", headerFont);
                    _cachedHeaderHeight = (int)Math.Ceiling(fm.Height) + 12;
                    dataGridView1.ColumnHeadersHeight = Math.Max(dataGridView1.ColumnHeadersHeight, _cachedHeaderHeight);
                }
            }
        }

        private void InitAdjustTimer()
        {
            _adjustTimer.Tick -= AdjustTimer_Tick;
            _adjustTimer.Tick += AdjustTimer_Tick;
        }

        private void AdjustTimer_Tick(object sender, EventArgs e)
        {
            _adjustTimer.Stop();
            AdjustColumnWidths();
        }

        private void ScheduleAdjustColumns()
        {
            _adjustTimer.Stop();
            _adjustTimer.Start();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ScheduleAdjustColumns();
        }

        private void DataGridView1_SizeChanged(object sender, EventArgs e)
        {
            ScheduleAdjustColumns();
        }

        #endregion

        #region Edit/Delete columns and handlers

        private void AddEditDeleteColumns()
        {
            // create padded icons once
            var editIcon = CreatePaddedIcon(Properties.Resources.EditIcon);
            var deleteIcon = CreatePaddedIcon(Properties.Resources.DeleteIcon);

            // ensure row height can fit the icons comfortably
            dataGridView1.RowTemplate.Height = Math.Max(dataGridView1.RowTemplate.Height, IconHeight + IconPadding + 6);

            // Edit column
            if (!dataGridView1.Columns.Contains("EditCol"))
            {
                var editCol = new DataGridViewImageColumn
                {
                    Name = "EditCol",
                    HeaderText = "",
                    Image = editIcon,
                    ImageLayout = DataGridViewImageCellLayout.Normal, // Normal keeps the padded image centered
                    Width = ActionColWidth,
                    ReadOnly = true
                };
                dataGridView1.Columns.Add(editCol);
            }
            else
            {
                var col = (DataGridViewImageColumn)dataGridView1.Columns["EditCol"];
                col.Image = editIcon;
                col.Width = ActionColWidth;
                col.ImageLayout = DataGridViewImageCellLayout.Normal;
            }

            // Delete column
            if (!dataGridView1.Columns.Contains("DeleteCol"))
            {
                var delCol = new DataGridViewImageColumn
                {
                    Name = "DeleteCol",
                    HeaderText = "",
                    Image = deleteIcon,
                    ImageLayout = DataGridViewImageCellLayout.Normal,
                    Width = ActionColWidth,
                    ReadOnly = true
                };
                dataGridView1.Columns.Add(delCol);
            }
            else
            {
                var col = (DataGridViewImageColumn)dataGridView1.Columns["DeleteCol"];
                col.Image = deleteIcon;
                col.Width = ActionColWidth;
                col.ImageLayout = DataGridViewImageCellLayout.Normal;
            }

            // Add a little cell padding so the icon looks like it's inside a small button
            if (dataGridView1.Columns.Contains("EditCol"))
            {
                dataGridView1.Columns["EditCol"].DefaultCellStyle.Padding = new Padding(4);
                dataGridView1.Columns["EditCol"].HeaderCell.Style.Padding = new Padding(4);
                dataGridView1.Columns["EditCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridView1.Columns.Contains("DeleteCol"))
            {
                dataGridView1.Columns["DeleteCol"].DefaultCellStyle.Padding = new Padding(4);
                dataGridView1.Columns["DeleteCol"].HeaderCell.Style.Padding = new Padding(4);
                dataGridView1.Columns["DeleteCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Optionally set per-row cell values to ensure consistent rendering
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (dataGridView1.Columns.Contains("EditCol")) row.Cells["EditCol"].Value = editIcon;
                if (dataGridView1.Columns.Contains("DeleteCol")) row.Cells["DeleteCol"].Value = deleteIcon;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col == null) return;

            if (col.Name == "EditCol")
                HandleEditClick(e.RowIndex, currentTable);
            else if (col.Name == "DeleteCol")
                HandleDeleteClick(e.RowIndex, currentTable);
        }

        private void HandleEditClick(int rowIndex, string currentTable)
        {
            var row = dataGridView1.Rows[rowIndex];
            if (row.IsNewRow) return;

            if (currentTable == "BreedingRecords")
            {
                var raw = row.Cells["BreedingID"]?.Value;
                if (raw == null || !int.TryParse(raw.ToString(), out int id)) return;

                using (var editForm = new EditBreeding(id))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadTable();
                }
            }
            if (currentTable == "PregnancyRecords")
            {
                var raw = row.Cells["PregnancyID"]?.Value;
                if (raw == null || !int.TryParse(raw.ToString(), out int id)) return;

                using (var editForm = new EditPregnancy(id))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadTable();
                }
            }
        }

        private void HandleDeleteClick(int rowIndex, string currentTable)
        {
            if(currentTable == "BreedingRecords")
            {
                var row = dataGridView1.Rows[rowIndex];
                if (row.IsNewRow) return;
                var raw = row.Cells["BreedingID"]?.Value;
                if (raw == null || !int.TryParse(raw.ToString(), out int id)) return;

                var result = MessageBox.Show($"Delete record {id}?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                using (var conn = DBConnection.Instance.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM BreedingRecords WHERE BreedingID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            LoadTable();
        }

        #endregion

        #region Adaptive column sizing

        private void AdjustColumnWidths()
        {
            if (_isAdjustingColumns) return;
            _isAdjustingColumns = true;

            try
            {
                var visibleCols = dataGridView1.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                if (visibleCols.Count == 0) return;

                // Reserve fixed width for action columns and exclude them from the data column distribution
                const int actionColWidth = 36; // change this to whatever fixed size you want
                var actionNames = new[] { "EditCol", "DeleteCol" };
                var actionCols = visibleCols.Where(c => actionNames.Contains(c.Name)).ToList();
                var dataCols = visibleCols.Except(actionCols).ToList();

                // Apply fixed sizing to action columns up front
                foreach (var a in actionCols)
                {
                    a.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    a.MinimumWidth = Math.Max(actionColWidth, a.MinimumWidth);
                    a.Width = Math.Max(actionColWidth, a.Width);
                    a.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    a.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                int clientWidth = dataGridView1.ClientSize.Width;
                int leftOffset = dataGridView1.RowHeadersVisible ? dataGridView1.RowHeadersWidth : 0;
                clientWidth -= leftOffset;

                // Subtract action columns total width from available client width
                int totalActionWidth = actionCols.Sum(c => c.Width);
                clientWidth -= totalActionWidth;

                bool vScrollVisible = dataGridView1.Controls.OfType<VScrollBar>().Any(v => v.Visible)
                                      || (dataGridView1.Rows.Count * dataGridView1.RowTemplate.Height) > dataGridView1.ClientSize.Height;
                if (vScrollVisible) clientWidth -= SystemInformation.VerticalScrollBarWidth;

                const int totalHorizontalPadding = 8;
                clientWidth -= totalHorizontalPadding;
                if (clientWidth < 0) clientWidth = 0;

                const int maxAutoColumns = 7;
                const int fixedColumnWidth = 140;
                const int minColumnWidth = 100;

                dataGridView1.SuspendLayout();
                try
                {
                    if (dataCols.Count == 0)
                    {
                        // No data columns to distribute; action columns already sized
                    }
                    else if (dataCols.Count <= maxAutoColumns)
                    {
                        int availableForData = Math.Max(0, clientWidth);
                        int baseWidth = Math.Max(minColumnWidth, availableForData / dataCols.Count);

                        for (int i = 0; i < dataCols.Count; i++)
                        {
                            var col = dataCols[i];
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.MinimumWidth = Math.Max(minColumnWidth, col.MinimumWidth);
                            col.Width = baseWidth;
                        }

                        int used = dataCols.Sum(c => c.Width) + totalActionWidth;
                        int remainder = (dataGridView1.ClientSize.Width - leftOffset - totalHorizontalPadding - (vScrollVisible ? SystemInformation.VerticalScrollBarWidth : 0)) - used;

                        if (remainder > 0)
                        {
                            var last = dataCols.Last();
                            last.Width = Math.Max(last.MinimumWidth, last.Width + remainder);
                            last.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else if (remainder < 0)
                        {
                            var last = dataCols.Last();
                            int shrink = Math.Min(last.Width - last.MinimumWidth, -remainder);
                            if (shrink > 0) last.Width -= shrink;
                            last.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dataCols.Last().AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    else
                    {
                        foreach (var col in dataCols)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.Width = Math.Max(fixedColumnWidth, minColumnWidth);
                        }

                        int used = dataCols.Sum(c => c.Width) + totalActionWidth;
                        int remainder = (dataGridView1.ClientSize.Width - leftOffset - totalHorizontalPadding - (vScrollVisible ? SystemInformation.VerticalScrollBarWidth : 0)) - used;
                        if (remainder > 0 && dataCols.Count > 0)
                        {
                            var last = dataCols.Last();
                            last.Width = Math.Max(last.MinimumWidth, last.Width + remainder);
                            last.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else if (dataCols.Count > 0)
                        {
                            dataCols.Last().AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
                finally
                {
                    dataGridView1.ResumeLayout();
                }

                // avoid immediate reentry; invalidate after event stack unwinds
                dataGridView1.BeginInvoke((Action)(() => dataGridView1.Invalidate()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"AdjustColumnWidths error: {ex}");
            }
            finally
            {
                _isAdjustingColumns = false;
            }
        }

        private Image CreatePaddedIcon(Image src)
        {
            if (src == null) return null;

            int destW = IconWidth + IconPadding;
            int destH = IconHeight + IconPadding;
            var dest = new Bitmap(destW, destH);
            dest.SetResolution(src.HorizontalResolution, src.VerticalResolution);

            using (var g = Graphics.FromImage(dest))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // compute centered destination rect for the visible icon area
                var destRect = new Rectangle(
                    (destW - IconWidth) / 2,
                    (destH - IconHeight) / 2,
                    IconWidth,
                    IconHeight);

                g.DrawImage(src, destRect, 0, 0, src.Width, src.Height, GraphicsUnit.Pixel);
            }

            return dest;
        }

        #endregion

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the column is BoarName
            if (dataGridView1.Columns[e.ColumnIndex].Name == "BoarName")
            {
                string cellValue = Convert.ToString(e.Value); // safe conversion

                if (e.Value == null ||
                    e.Value == DBNull.Value ||
                    string.IsNullOrEmpty(cellValue) ||
                    string.Equals(cellValue, "NULL", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "Null";
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }

        }
    }
}
