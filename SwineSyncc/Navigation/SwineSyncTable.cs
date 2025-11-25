using SwineSyncc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwineSyncc.Navigation
{
    public partial class SwineSyncTable : UserControl
    {
        string connectionString;
        private string tableQuery;
        // per-row animation guard
        private readonly System.Collections.Concurrent.ConcurrentDictionary<int, byte> _animatingRows
            = new System.Collections.Concurrent.ConcurrentDictionary<int, byte>();

        // helpers for per-row guard
        private bool TryStartAnimating(int rowIndex) => _animatingRows.TryAdd(rowIndex, 0);
        private void StopAnimating(int rowIndex) => _animatingRows.TryRemove(rowIndex, out _);

        public SwineSyncTable()
        {
            InitializeComponent();
            // Optional: wire Load event if not wired in designer
            this.Load -= SwineSyncTable_Load;
            this.Load += SwineSyncTable_Load;
        }

        private void SwineSyncTable_Load(object sender, EventArgs e)
        {
            // Load data and configure UI once
            LoadTable();
        }

        public void SetTableQuery(string tableName)
        {
            this.tableQuery = "SELECT * FROM " + tableName;
        }

        public string GetTableQuery()
        {
            return this.tableQuery;
        }

        #region Load and initialization

        public void LoadTable()
        {
            // Load data into a DataTable
            DataTable table = new DataTable();
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                string query = GetTableQuery();
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(table);
                }
            }

            // Assign data source first so columns exist
            dataGridView1.DataSource = table;

            // Basic appearance (after DataSource so columns exist)
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.Width = 150;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Wrap handling: check actual column name(s)
            if (dataGridView1.Columns.Contains("Result"))
            {
                dataGridView1.Columns["Result"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.Columns["Result"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else if (dataGridView1.Columns.Contains("Notes"))
            {
                dataGridView1.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridView1.Columns["Notes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            

            // Compute a comfortable header height from header font
            using (var g = dataGridView1.CreateGraphics())
            {
                var headerFont = dataGridView1.ColumnHeadersDefaultCellStyle.Font ?? dataGridView1.Font;
                var fm = g.MeasureString("Mg", headerFont);
                int headerHeight = (int)Math.Ceiling(fm.Height) + 12; // padding
                dataGridView1.ColumnHeadersHeight = Math.Max(dataGridView1.ColumnHeadersHeight, headerHeight);
            }

            


            // Add checkbox column only if not present
            AddCheckboxColumn();

            // Fill checkbox cells with thumbnails and default state
            FillCheckboxes();

            // Configure visuals and handlers once
            ConfigureCheckboxColumnAppearance();
            EnableHeaderImageCheckbox();
            EnableAdaptiveColumnSizing();

            // Double buffering for smoother painting
            EnableDoubleBuffering(dataGridView1);

            // Tooltips handlers (de-duplicate)
            dataGridView1.CellMouseEnter -= DataGridView1_CellMouseEnter;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            dataGridView1.CellMouseLeave -= DataGridView1_CellMouseLeave;
            dataGridView1.CellMouseLeave += DataGridView1_CellMouseLeave;

            // Final layout/refresh
            dataGridView1.PerformLayout();
            dataGridView1.Refresh();
        }

        #endregion

        #region Adaptive column sizing

        private void EnableAdaptiveColumnSizing()
        {
            // Wire events once
            dataGridView1.Resize -= DataGridView1_AdaptiveLayoutChanged;
            dataGridView1.Resize += DataGridView1_AdaptiveLayoutChanged;

            dataGridView1.ColumnWidthChanged -= DataGridView1_AdaptiveLayoutChanged;
            dataGridView1.ColumnWidthChanged += DataGridView1_AdaptiveLayoutChanged;

            dataGridView1.ColumnDisplayIndexChanged -= DataGridView1_AdaptiveLayoutChanged;
            dataGridView1.ColumnDisplayIndexChanged += DataGridView1_AdaptiveLayoutChanged;

            dataGridView1.ColumnAdded -= DataGridView1_AdaptiveLayoutChanged;
            dataGridView1.ColumnAdded += DataGridView1_AdaptiveLayoutChanged;

            dataGridView1.ColumnRemoved -= DataGridView1_AdaptiveLayoutChanged;
            dataGridView1.ColumnRemoved += DataGridView1_AdaptiveLayoutChanged;

            // initial layout
            AdjustColumnWidths();
        }

        private void DataGridView1_AdaptiveLayoutChanged(object sender, EventArgs e)
        {
            if (_isAdjustingColumns) return; // ignore re-entrant events
            AdjustColumnWidths();
        }


        // add this field to the class
        private bool _isAdjustingColumns = false;

        private void AdjustColumnWidths()
        {
            if (_isAdjustingColumns) return;
            _isAdjustingColumns = true;

            try
            {
                var visibleCols = dataGridView1.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
                if (visibleCols.Count == 0) return;

                DataGridViewColumn checkCol = dataGridView1.Columns.Contains("CheckCol") ? dataGridView1.Columns["CheckCol"] : null;
                var dataCols = visibleCols.Where(c => c != checkCol).ToList();

                // Compute available width (client width minus row header and vertical scrollbar)
                int clientWidth = dataGridView1.ClientSize.Width;
                int leftOffset = dataGridView1.RowHeadersVisible ? dataGridView1.RowHeadersWidth : 0;
                clientWidth -= leftOffset;

                bool vScrollVisible = dataGridView1.Controls.OfType<VScrollBar>().Any(v => v.Visible);
                if (vScrollVisible) clientWidth -= SystemInformation.VerticalScrollBarWidth;

                const int totalHorizontalPadding = 8;
                clientWidth -= totalHorizontalPadding;
                if (clientWidth < 0) clientWidth = 0;

                const int maxAutoColumns = 7;
                const int fixedColumnWidth = 140;
                const int minColumnWidth = 100; // raise min to avoid squashed headers
                const int checkboxWidth = 36;

                // Ensure checkbox column fixed width
                if (checkCol != null)
                {
                    checkCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    checkCol.MinimumWidth = Math.Max(28, checkCol.MinimumWidth);
                    checkCol.Width = Math.Max(checkboxWidth, checkCol.Width);
                }

                dataGridView1.SuspendLayout();
                try
                {
                    if (dataCols.Count == 0)
                    {
                        // Only checkbox visible: nothing else to do
                    }
                    else if (dataCols.Count <= maxAutoColumns)
                    {
                        // Distribute available width among data columns only
                        int availableForData = clientWidth - (checkCol != null ? checkCol.Width : 0);
                        availableForData = Math.Max(0, availableForData);

                        // Compute base width and ensure minimum
                        int baseWidth = Math.Max(minColumnWidth, availableForData / dataCols.Count);

                        foreach (var col in dataCols)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.MinimumWidth = Math.Max(minColumnWidth, col.MinimumWidth);
                            col.Width = baseWidth;
                        }

                        // If used width is less than clientWidth, expand the last data column to absorb remainder
                        int used = dataCols.Sum(c => c.Width) + (checkCol != null ? checkCol.Width : 0);
                        int remainder = clientWidth - used;
                        if (remainder > 0)
                        {
                            dataCols.Last().Width += remainder;
                        }
                        else if (remainder < 0)
                        {
                            // If we overshot (rare), shrink last column but not below minimum
                            int shrink = Math.Min(dataCols.Last().Width - dataCols.Last().MinimumWidth, -remainder);
                            if (shrink > 0) dataCols.Last().Width -= shrink;
                        }
                    }
                    else
                    {
                        // Many columns: fixed width for data columns, checkbox remains small
                        foreach (var col in dataCols)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            col.Width = Math.Max(fixedColumnWidth, minColumnWidth);
                        }

                        // If total width still less than clientWidth, expand the last data column
                        int used = dataCols.Sum(c => c.Width) + (checkCol != null ? checkCol.Width : 0);
                        int remainder = clientWidth - used;
                        if (remainder > 0 && dataCols.Count > 0)
                        {
                            dataCols.Last().Width += remainder;
                        }
                    }
                }
                finally
                {
                    dataGridView1.ResumeLayout();
                }

                // Reapply checkbox alignment/padding
                if (checkCol != null)
                {
                    checkCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    checkCol.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
                    checkCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    checkCol.HeaderCell.Style.Padding = new Padding(4, 0, 4, 0);
                }

                // Schedule a small refresh after the event stack unwinds to avoid reentry
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


        #endregion

        #region Header image checkbox and painting

        private void EnableHeaderImageCheckbox()
        {
            if (!dataGridView1.Columns.Contains("CheckCol")) return;
            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol == null || imgCol.Tag == null) return;

            // Configure appearance so header and cells align
            ConfigureCheckboxColumnAppearance();

            // Attach handlers
            dataGridView1.CellPainting -= DataGridView1_HeaderCellPainting;
            dataGridView1.CellPainting += DataGridView1_HeaderCellPainting;

            dataGridView1.ColumnHeaderMouseClick -= DataGridView1_ColumnHeaderMouseClick;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;

            // Keep header image state correct initially
            UpdateHeaderImageState();
        }

        private void ConfigureCheckboxColumnAppearance()
        {
            if (!dataGridView1.Columns.Contains("CheckCol")) return;
            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol == null) return;

            imgCol.ImageLayout = DataGridViewImageCellLayout.Normal;
            imgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            imgCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Small padding so column can be compact
            imgCol.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            imgCol.HeaderCell.Style.Padding = new Padding(4, 0, 4, 0);

            // Make checkbox column fixed and not part of Fill distribution
            const int checkboxPreferredWidth = 36;
            imgCol.MinimumWidth = Math.Max(28, imgCol.MinimumWidth);
            imgCol.Width = Math.Max(checkboxPreferredWidth, imgCol.Width);
            imgCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // keep it fixed
        }


        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Only handle header clicks on the checkbox column
            if (e.RowIndex != -1) return;
            if (!dataGridView1.Columns.Contains("CheckCol") || dataGridView1.Columns[e.ColumnIndex].Name != "CheckCol") return;

            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol == null) return;

            // Try to read header state as a bool; if not present compute from rows
            bool? headerState = null;
            if (imgCol.HeaderCell?.Tag is bool hb) headerState = hb;
            else
            {
                int total = 0, checkedCount = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    total++;
                    var cell = row.Cells["CheckCol"];
                    if (cell != null && cell.Tag is bool b && b) checkedCount++;
                }
                headerState = (total == 0) ? false : (checkedCount == 0 ? false : (checkedCount == total ? true : (bool?)null));
            }

            // Toggle: if currently checked -> uncheck all; otherwise check all
            bool target = !(headerState == true);

            // Set all rows (non-blocking)
            SetAllRowCheckboxes(target);

            // Update header cell tag and repaint header
            imgCol.HeaderCell.Tag = target;
            dataGridView1.InvalidateCell(e.ColumnIndex, -1);
        }

        private void DataGridView1_HeaderCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1) return;
                if (!dataGridView1.Columns.Contains("CheckCol") || dataGridView1.Columns[e.ColumnIndex].Name != "CheckCol") return;

                var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
                if (imgCol == null || imgCol.Tag == null) return;

                if (!TryExtractCheckImages(imgCol.Tag, out Image uncheckedThumb, out Image checkedThumb, out Image indeterminateThumb))
                    return;

                // Determine header state
                bool? headerState = null;
                if (imgCol.HeaderCell?.Tag is bool hb) headerState = hb;
                else
                {
                    int total = 0, checkedCount = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        total++;
                        var cell = row.Cells["CheckCol"];
                        if (cell != null && cell.Tag is bool b && b) checkedCount++;
                    }
                    headerState = (total == 0) ? false : (checkedCount == 0 ? false : (checkedCount == total ? true : (bool?)null));
                }

                Image headerImg = headerState == true ? checkedThumb : (headerState == false ? uncheckedThumb : (indeterminateThumb ?? uncheckedThumb));
                if (headerImg == null) return;

                e.PaintBackground(e.CellBounds, true);

                var pad = imgCol.HeaderCell?.Style?.Padding ?? Padding.Empty;
                int padLeft = pad.Left, padRight = pad.Right, padTop = pad.Top, padBottom = pad.Bottom;

                int availW = Math.Max(0, e.CellBounds.Width - (padLeft + padRight) - 4);
                int availH = Math.Max(0, e.CellBounds.Height - (padTop + padBottom) - 4);

                int imgW = Math.Min(headerImg.Width, availW);
                int imgH = Math.Min(headerImg.Height, availH);

                int x = e.CellBounds.X + padLeft + (availW - imgW) / 2;
                int y = e.CellBounds.Y + padTop + (availH - imgH) / 2;

                var g = e.Graphics;
                var oldMode = g.InterpolationMode;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(headerImg, new Rectangle(x, y, imgW, imgH));
                g.InterpolationMode = oldMode;

                e.Handled = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"HeaderCellPainting error: {ex}");
                // Let default painting proceed if something went wrong
            }
        }

        private void UpdateHeaderImageState()
        {
            if (!dataGridView1.Columns.Contains("CheckCol")) return;
            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol == null) return;

            int total = 0, checkedCount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                total++;
                var cell = row.Cells["CheckCol"];
                if (cell != null && cell.Tag is bool b && b) checkedCount++;
            }

            bool? newState;
            if (total == 0) newState = false;
            else if (checkedCount == 0) newState = false;
            else if (checkedCount == total) newState = true;
            else newState = null;

            imgCol.HeaderCell.Tag = newState;
            // repaint header cell
            int colIndex = imgCol.Index;
            dataGridView1.InvalidateCell(colIndex, -1);
        }

        #endregion

        #region Checkbox column, clicks, fill

        private void AddCheckboxColumn()
        {
            // Prevent duplicates
            if (dataGridView1.Columns.Contains("CheckCol"))
                return;

            // Load images from project resources (replace names if different)
            Image uncheckedImg = Properties.Resources.unselected_checkbox;
            Image checkedImg = Properties.Resources.selected_checkbox;

            // Fallback if resources are missing
            if (uncheckedImg == null) uncheckedImg = new Bitmap(1, 1);
            if (checkedImg == null) checkedImg = uncheckedImg;

            // Create small thumbnails for display (adjust size to taste)
            const int thumbSize = 18; // try 16, 18, or 20
            Image uncheckedThumb = ResizeImage(uncheckedImg, thumbSize, thumbSize);
            Image checkedThumb = ResizeImage(checkedImg, thumbSize, thumbSize);

            var imgCol = new DataGridViewImageColumn
            {
                Name = "CheckCol",
                HeaderText = "",
                Width = 36, // compact checkbox column width
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Image = uncheckedThumb,
                ValueType = typeof(Image)
            };

            // Center the image in the cell
            imgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns.Insert(0, imgCol);

            // Store typed ImageTag in the column Tag (do not dispose resource images)
            imgCol.Tag = new ImageTag(uncheckedImg, checkedImg, uncheckedThumb, checkedThumb, null);

            // Hook the CellClick and CellContentClick events (de-duplicate)
            dataGridView1.CellClick -= DataGridView1_CellClick;
            dataGridView1.CellClick += DataGridView1_CellClick;

            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }




        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleImageCellClick(e);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleImageCellClick(e);
        }

        private void HandleImageCellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col == null || col.Name != "CheckCol") return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell == null) return;

            // ensure the cell value is an Image (we display thumbnails)
            if (!(cell.Value is Image)) return;

            // current checked state stored in Tag (bool). Default false.
            bool isChecked = cell.Tag is bool b && b;

            // retrieve thumbnails from column tag using the safe extractor
            var imgCol = col as DataGridViewImageColumn;
            if (imgCol?.Tag == null) return;

            if (!TryExtractCheckImages(imgCol.Tag, out Image uncheckedThumb, out Image checkedThumb, out Image _))
                return;

            if (uncheckedThumb == null || checkedThumb == null) return;

            Image fromImg = isChecked ? checkedThumb : uncheckedThumb;
            Image toImg = isChecked ? uncheckedThumb : checkedThumb;

            // start animation (fire-and-forget)
            _ = AnimateCheckboxToggleAsync(e.RowIndex, fromImg, toImg, !isChecked);
        }

        private void FillCheckboxes()
        {
            if (!dataGridView1.Columns.Contains("CheckCol")) return;

            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol?.Tag == null) return;

            if (!TryExtractCheckImages(imgCol.Tag, out Image uncheckedThumb, out Image checkedThumb, out Image _)) return;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["CheckCol"];
                if (cell == null) continue;

                cell.Value = uncheckedThumb;
                cell.Tag = false;
                cell.ReadOnly = false;
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Ensure checkbox column cells use a compact font so they don't affect row height
                cell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, Math.Max(8f, dataGridView1.DefaultCellStyle.Font.Size - 1f));
            }
        }


        #endregion

        #region Set all rows (async + optional animation)

        private async Task SetAllRowCheckboxesAsync(bool check, bool animate = false)
        {
            if (!dataGridView1.Columns.Contains("CheckCol")) return;
            var imgCol = dataGridView1.Columns["CheckCol"] as DataGridViewImageColumn;
            if (imgCol == null || imgCol.Tag == null) return;

            if (!TryExtractCheckImages(imgCol.Tag, out Image uncheckedThumb, out Image checkedThumb, out Image _))
                return;

            // If animation requested, start animations for rows that need changing
            if (animate)
            {
                var tasks = new List<Task>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cell = row.Cells["CheckCol"];
                    if (cell == null) continue;

                    bool current = cell.Tag is bool b && b;
                    if (current == check) continue; // already in desired state

                    Image fromImg = current ? checkedThumb : uncheckedThumb;
                    Image toImg = check ? checkedThumb : uncheckedThumb;

                    // Start animation for this row (non-blocking)
                    tasks.Add(AnimateCheckboxToggleAsync(row.Index, fromImg, toImg, check));
                }

                if (tasks.Count > 0)
                    await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            else
            {
                // Immediate update without animation.
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke((Action)(() => ApplyImmediateCheckState(check, checkedThumb, uncheckedThumb)));
                }
                else
                {
                    ApplyImmediateCheckState(check, checkedThumb, uncheckedThumb);
                }
            }

            // Refresh visuals and update header image state on UI thread
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((Action)(() =>
                {
                    dataGridView1.Invalidate();
                    UpdateHeaderImageState();
                }));
            }
            else
            {
                dataGridView1.Invalidate();
                UpdateHeaderImageState();
            }
        }

        private void SetAllRowCheckboxes(bool check, bool animate = false)
        {
            _ = SetAllRowCheckboxesAsync(check, animate);
        }

        private void ApplyImmediateCheckState(bool check, Image checkedThumb, Image uncheckedThumb)
        {
            // We are on UI thread here
            dataGridView1.SuspendLayout();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cell = row.Cells["CheckCol"];
                    if (cell == null) continue;

                    bool current = cell.Tag is bool b && b;
                    if (current == check) continue;

                    // Use shared thumbnail images (do not dispose them here)
                    cell.Value = check ? checkedThumb : uncheckedThumb;
                    cell.Tag = check;
                }
            }
            finally
            {
                dataGridView1.ResumeLayout();
            }
        }

        #endregion

        #region Animation, blending, resizing helpers

        private async Task AnimateCheckboxToggleAsync(int rowIndex, Image fromImg, Image toImg, bool newCheckedState)
        {
            // per-row guard (non-blocking)
            if (!TryStartAnimating(rowIndex)) return;

            const int steps = 8;
            const int delayMs = 25;

            try
            {
                for (int i = 1; i <= steps; i++)
                {
                    float t = i / (float)steps;
                    using (Bitmap blended = BlendImages(fromImg, toImg, t))
                    {
                        // Clone so the grid owns its own Image instance
                        Image frame = (Image)blended.Clone();

                        if (dataGridView1.IsHandleCreated)
                        {
                            // Marshal to UI thread and assign the frame
                            dataGridView1.Invoke((Action)(() =>
                            {
                                if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                                {
                                    dataGridView1.Rows[rowIndex].Cells["CheckCol"].Value = frame;
                                }
                            }));
                        }
                    }

                    await Task.Delay(delayMs).ConfigureAwait(false);
                }

                // Set final image (use the cached thumbnail object) and update Tag on UI thread
                if (dataGridView1.IsHandleCreated)
                {
                    dataGridView1.Invoke((Action)(() =>
                    {
                        if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                        {
                            dataGridView1.Rows[rowIndex].Cells["CheckCol"].Value = toImg;
                            dataGridView1.Rows[rowIndex].Cells["CheckCol"].Tag = newCheckedState;
                        }
                    }));
                }

                // Notify header/other logic that a row checkbox changed
                OnRowCheckboxToggled(rowIndex);
            }
            finally
            {
                StopAnimating(rowIndex);
            }
        }

        // Call this after a row's checkbox state has been changed (rowIndex is optional)
        private void OnRowCheckboxToggled(int rowIndex = -1)
        {
            // Ensure UI thread when touching the grid
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.BeginInvoke((Action)(() => OnRowCheckboxToggled(rowIndex)));
                return;
            }

            // Update header image/checkbox state so header reflects current rows
            UpdateHeaderImageState();
        }

        private Bitmap BlendImages(Image a, Image b, float t)
        {
            // Use the size of the thumbnails (they should be same size)
            int width = Math.Max(a.Width, b.Width);
            int height = Math.Max(a.Height, b.Height);
            var bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                // Draw first image with alpha (1 - t)
                float alphaA = 1f - t;
                using (ImageAttributes ia = new ImageAttributes())
                {
                    var cmA = new ColorMatrix { Matrix33 = alphaA };
                    ia.SetColorMatrix(cmA, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(a, new Rectangle(0, 0, width, height), 0, 0, a.Width, a.Height, GraphicsUnit.Pixel, ia);
                }

                // Draw second image with alpha t
                float alphaB = t;
                using (ImageAttributes ib = new ImageAttributes())
                {
                    var cmB = new ColorMatrix { Matrix33 = alphaB };
                    ib.SetColorMatrix(cmB, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(b, new Rectangle(0, 0, width, height), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ib);
                }
            }
            return bmp;
        }

        private Image ResizeImage(Image src, int width, int height)
        {
            var dest = new Bitmap(width, height);
            dest.SetResolution(src.HorizontalResolution, src.VerticalResolution);
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var destRect = new Rectangle(0, 0, width, height);
                g.Clear(Color.Transparent);
                g.DrawImage(src, destRect, 0, 0, src.Width, src.Height, GraphicsUnit.Pixel);
            }
            return dest;
        }

        #endregion

        #region Tooltips

        // Show full note in tooltip on hover
        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!dataGridView1.Columns.Contains("Note") || dataGridView1.Columns[e.ColumnIndex].Name != "Note")
            {
                dataGridView1.ShowCellToolTips = false;
                return;
            }

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string text = cell?.FormattedValue?.ToString() ?? string.Empty;

            // Only show tooltip if text is longer than fits in the cell
            if (!string.IsNullOrEmpty(text))
            {
                dataGridView1.ShowCellToolTips = true;
                cell.ToolTipText = text;
            }
            else
            {
                dataGridView1.ShowCellToolTips = false;
            }
        }

        private void DataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns.Contains("Note"))
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell != null) cell.ToolTipText = string.Empty;
            }
            dataGridView1.ShowCellToolTips = false;
        }

        #endregion

        #region ImageTag and extractor

        // Typed container for images stored in column.Tag
        private class ImageTag
        {
            public Image UncheckedOriginal { get; set; }
            public Image CheckedOriginal { get; set; }
            public Image UncheckedThumb { get; set; }
            public Image CheckedThumb { get; set; }
            public Image IndeterminateThumb { get; set; }

            public ImageTag(Image uncheckedOriginal, Image checkedOriginal, Image uncheckedThumb, Image checkedThumb, Image indeterminateThumb = null)
            {
                UncheckedOriginal = uncheckedOriginal;
                CheckedOriginal = checkedOriginal;
                UncheckedThumb = uncheckedThumb;
                CheckedThumb = checkedThumb;
                IndeterminateThumb = indeterminateThumb;
            }
        }

        // Reflection-based extractor that works with ImageTag or dictionary/anonymous shapes
        private bool TryExtractCheckImages(object tagObj, out Image uncheckedThumb, out Image checkedThumb, out Image indeterminateThumb)
        {
            uncheckedThumb = checkedThumb = indeterminateThumb = null;
            if (tagObj == null) return false;

            if (tagObj is ImageTag typed)
            {
                uncheckedThumb = typed.UncheckedThumb;
                checkedThumb = typed.CheckedThumb;
                indeterminateThumb = typed.IndeterminateThumb;
                return uncheckedThumb != null && checkedThumb != null;
            }

            try
            {
                var t = tagObj.GetType();
                var pUnchecked = t.GetProperty("UncheckedThumb");
                var pChecked = t.GetProperty("CheckedThumb");
                var pIndeterminate = t.GetProperty("IndeterminateThumb");

                if (pUnchecked != null && pChecked != null)
                {
                    uncheckedThumb = pUnchecked.GetValue(tagObj) as Image;
                    checkedThumb = pChecked.GetValue(tagObj) as Image;
                    if (pIndeterminate != null) indeterminateThumb = pIndeterminate.GetValue(tagObj) as Image;
                    return uncheckedThumb != null && checkedThumb != null;
                }

                if (tagObj is System.Collections.IDictionary dict)
                {
                    if (dict.Contains("UncheckedThumb")) uncheckedThumb = dict["UncheckedThumb"] as Image;
                    if (dict.Contains("CheckedThumb")) checkedThumb = dict["CheckedThumb"] as Image;
                    if (dict.Contains("IndeterminateThumb")) indeterminateThumb = dict["IndeterminateThumb"] as Image;
                    return uncheckedThumb != null && checkedThumb != null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TryExtractCheckImages reflection error: {ex}");
            }

            return false;
        }

        #endregion

        #region Double buffering helper

        private void EnableDoubleBuffering(DataGridView dgv)
        {
            var prop = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            prop?.SetValue(dgv, true, null);
        }

        #endregion
    }
}
