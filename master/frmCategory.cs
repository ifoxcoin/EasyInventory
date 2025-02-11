using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmCategory : Form
	{
		private int id = 0;

		private IContainer components = null;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private TableLayoutPanel tblMain;

		private TableLayoutPanel tblEntry;

		private Label label1;

		private lightbutton cmdclose;

		private TextBox txtCategory;

		private DataGridView dgview;

		private TableLayoutPanel tblSearch;

		private TextBox txtSearch;

		private Label lblSearch;

		private TableLayoutPanel tblCommand;

		private lightbutton btnClear;

		private lightbutton btnDelete;

		private lightbutton btnSave;

		private DataGridViewTextBoxColumn cCategory;

		private DataGridViewTextBoxColumn cat_udate;

		private DataGridViewTextBoxColumn users_uid;

		private DataGridViewTextBoxColumn ccat_id;

		private DataGridViewTextBoxColumn ccom_id;

		public frmCategory()
		{
			InitializeComponent();
		}

		private void frmItems_Load(object sender, EventArgs e)
		{
			try
			{
				LoadData();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdclose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void Clear()
		{
			txtCategory.Text = string.Empty;
			id = 0;
			LoadData();
		}

		private void LoadData()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			dgview.DataSource = inventoryDataContext.usp_categorySelect(null, null);
		}

		private void EditData()
		{
			if (dgview.CurrentCell != null)
			{
				int rowIndex = dgview.CurrentCell.RowIndex;
				id = Convert.ToInt32(dgview["ccat_id", rowIndex].Value);
				txtCategory.Text = Convert.ToString(dgview["cCategory", rowIndex].Value);
				txtCategory.Focus();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (id != 0 && MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					inventoryDataContext.usp_categoryDelete(id);
					Clear();
					MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				category at = new category();
				at.cat_name = txtCategory.Text.Trim();
				if (at.cat_name == string.Empty)
				{
					MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					txtCategory.Focus();
				}
				else
				{
					var source = from b in inventoryDataContext.categories
						where b.cat_name == at.cat_name && b.cat_id != (long)id
						select new
						{
							b.cat_id
						};
					if (source.Count() != 0)
					{
						MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtCategory.Focus();
					}
					else if (id == 0)
					{
						if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
						{
							inventoryDataContext.usp_categoryInsert(at.cat_name, global.comid, global.ucode, global.sysdate);
							MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							goto IL_0315;
						}
					}
					else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_categoryUpdate(id, at.cat_name, global.comid, global.ucode, global.sysdate);
						MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_0315;
					}
				}
				goto end_IL_0010;
				IL_0315:
				Clear();
				end_IL_0010:;
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void dgview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditData();
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			dgview.DataSource = inventoryDataContext.usp_categorySelect(null, txtSearch.Text);
		}

		private void txtCategory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return)
			{
				SendKeys.Send("{TAB}");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			a1Paneltitle = new mylib.a1panel();
			lbltitle = new System.Windows.Forms.Label();
			tblMain = new System.Windows.Forms.TableLayoutPanel();
			tblSearch = new System.Windows.Forms.TableLayoutPanel();
			txtSearch = new System.Windows.Forms.TextBox();
			lblSearch = new System.Windows.Forms.Label();
			dgview = new System.Windows.Forms.DataGridView();
			tblEntry = new System.Windows.Forms.TableLayoutPanel();
			txtCategory = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			tblCommand = new System.Windows.Forms.TableLayoutPanel();
			cmdclose = new mylib.lightbutton();
			btnClear = new mylib.lightbutton();
			btnDelete = new mylib.lightbutton();
			btnSave = new mylib.lightbutton();
			cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cat_udate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			users_uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ccat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ccom_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			a1Paneltitle.SuspendLayout();
			tblMain.SuspendLayout();
			tblSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgview).BeginInit();
			tblEntry.SuspendLayout();
			tblCommand.SuspendLayout();
			SuspendLayout();
			a1Paneltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
			a1Paneltitle.Controls.Add(lbltitle);
			a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
			a1Paneltitle.Image = null;
			a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
			a1Paneltitle.Location = new System.Drawing.Point(4, 4);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(878, 29);
			a1Paneltitle.TabIndex = 0;
			lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(25, 5);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(76, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "Category";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tblMain.ColumnCount = 1;
			tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblMain.Controls.Add(tblSearch, 0, 2);
			tblMain.Controls.Add(dgview, 0, 3);
			tblMain.Controls.Add(a1Paneltitle, 0, 0);
			tblMain.Controls.Add(tblEntry, 0, 1);
			tblMain.Controls.Add(tblCommand, 0, 4);
			tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
			tblMain.Location = new System.Drawing.Point(0, 0);
			tblMain.Name = "tblMain";
			tblMain.RowCount = 5;
			tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45f));
			tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75f));
			tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45f));
			tblMain.Size = new System.Drawing.Size(886, 499);
			tblMain.TabIndex = 2;
			tblSearch.ColumnCount = 6;
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236f));
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245f));
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139f));
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220f));
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblSearch.Controls.Add(txtSearch, 1, 0);
			tblSearch.Controls.Add(lblSearch, 0, 0);
			tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			tblSearch.Location = new System.Drawing.Point(4, 133);
			tblSearch.Name = "tblSearch";
			tblSearch.RowCount = 1;
			tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblSearch.Size = new System.Drawing.Size(878, 39);
			tblSearch.TabIndex = 3;
			txtSearch.BackColor = System.Drawing.Color.White;
			txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSearch.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtSearch.Location = new System.Drawing.Point(239, 3);
			txtSearch.MaxLength = 50;
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new System.Drawing.Size(239, 26);
			txtSearch.TabIndex = 1;
			txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged);
			lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblSearch.AutoSize = true;
			lblSearch.BackColor = System.Drawing.Color.Transparent;
			lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblSearch.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblSearch.Location = new System.Drawing.Point(3, 10);
			lblSearch.Name = "lblSearch";
			lblSearch.Size = new System.Drawing.Size(202, 18);
			lblSearch.TabIndex = 0;
			lblSearch.Text = "Search By Category Name";
			lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			dgview.AllowUserToAddRows = false;
			dgview.AllowUserToDeleteRows = false;
			dgview.AllowUserToResizeRows = false;
			dgview.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dgview.BackgroundColor = System.Drawing.Color.White;
			dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgview.ColumnHeadersHeight = 25;
			dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgview.Columns.AddRange(cCategory, cat_udate, users_uid, ccat_id, ccom_id);
			dgview.Cursor = System.Windows.Forms.Cursors.Default;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dgview.DefaultCellStyle = dataGridViewCellStyle2;
			dgview.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold);
			dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			dgview.Location = new System.Drawing.Point(4, 179);
			dgview.MultiSelect = false;
			dgview.Name = "dgview";
			dgview.ReadOnly = true;
			dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgview.RowHeadersVisible = false;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dgview.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgview.Size = new System.Drawing.Size(878, 270);
			dgview.TabIndex = 4;
			dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgview_CellDoubleClick);
			tblEntry.ColumnCount = 5;
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236f));
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247f));
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117f));
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200f));
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tblEntry.Controls.Add(txtCategory, 1, 0);
			tblEntry.Controls.Add(label1, 0, 0);
			tblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
			tblEntry.Location = new System.Drawing.Point(4, 40);
			tblEntry.Name = "tblEntry";
			tblEntry.RowCount = 6;
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblEntry.Size = new System.Drawing.Size(878, 86);
			tblEntry.TabIndex = 2;
			txtCategory.BackColor = System.Drawing.Color.White;
			txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtCategory.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			txtCategory.Location = new System.Drawing.Point(239, 3);
			txtCategory.MaxLength = 50;
			txtCategory.Name = "txtCategory";
			txtCategory.Size = new System.Drawing.Size(241, 26);
			txtCategory.TabIndex = 1;
			txtCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(txtCategory_KeyDown);
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label1.Location = new System.Drawing.Point(3, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(123, 18);
			label1.TabIndex = 0;
			label1.Text = "Category Name";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			tblCommand.ColumnCount = 5;
			tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			tblCommand.Controls.Add(cmdclose, 4, 0);
			tblCommand.Controls.Add(btnClear, 3, 0);
			tblCommand.Controls.Add(btnDelete, 2, 0);
			tblCommand.Controls.Add(btnSave, 1, 0);
			tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			tblCommand.Location = new System.Drawing.Point(4, 456);
			tblCommand.Name = "tblCommand";
			tblCommand.RowCount = 1;
			tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tblCommand.Size = new System.Drawing.Size(878, 39);
			tblCommand.TabIndex = 5;
			cmdclose.AutoSize = true;
			cmdclose.BackColor = System.Drawing.Color.Transparent;
			cmdclose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclose.Location = new System.Drawing.Point(781, 3);
			cmdclose.Name = "cmdclose";
			cmdclose.Size = new System.Drawing.Size(90, 30);
			cmdclose.TabIndex = 3;
			cmdclose.Text = "&Close";
			cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdclose.UseVisualStyleBackColor = false;
			cmdclose.Click += new System.EventHandler(cmdclose_Click);
			btnClear.AutoSize = true;
			btnClear.BackColor = System.Drawing.Color.Transparent;
			btnClear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnClear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			btnClear.Location = new System.Drawing.Point(681, 3);
			btnClear.Name = "btnClear";
			btnClear.Size = new System.Drawing.Size(90, 30);
			btnClear.TabIndex = 2;
			btnClear.Text = "&Clear";
			btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnClear.UseVisualStyleBackColor = false;
			btnClear.Click += new System.EventHandler(btnClear_Click);
			btnDelete.AutoSize = true;
			btnDelete.BackColor = System.Drawing.Color.Transparent;
			btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnDelete.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			btnDelete.Location = new System.Drawing.Point(581, 3);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new System.Drawing.Size(90, 30);
			btnDelete.TabIndex = 1;
			btnDelete.Text = "&Delete";
			btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnDelete.UseVisualStyleBackColor = false;
			btnDelete.Click += new System.EventHandler(btnDelete_Click);
			btnSave.AutoSize = true;
			btnSave.BackColor = System.Drawing.Color.Transparent;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			btnSave.Location = new System.Drawing.Point(481, 3);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(90, 30);
			btnSave.TabIndex = 0;
			btnSave.Text = "&Save";
			btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			cCategory.DataPropertyName = "cat_name";
			cCategory.HeaderText = "Category";
			cCategory.Name = "cCategory";
			cCategory.ReadOnly = true;
			cCategory.Width = 500;
			cat_udate.DataPropertyName = "cat_udate";
			cat_udate.HeaderText = "cat_udate";
			cat_udate.Name = "cat_udate";
			cat_udate.ReadOnly = true;
			cat_udate.Visible = false;
			users_uid.DataPropertyName = "users_uid";
			users_uid.HeaderText = "uid";
			users_uid.Name = "users_uid";
			users_uid.ReadOnly = true;
			users_uid.Visible = false;
			ccat_id.DataPropertyName = "cat_id";
			ccat_id.HeaderText = "cat_id";
			ccat_id.Name = "ccat_id";
			ccat_id.ReadOnly = true;
			ccat_id.Visible = false;
			ccom_id.DataPropertyName = "com_id";
			ccom_id.HeaderText = "com_id";
			ccom_id.Name = "ccom_id";
			ccom_id.ReadOnly = true;
			ccom_id.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(886, 499);
			base.Controls.Add(tblMain);
			base.Name = "frmCategory";
			base.ShowIcon = false;
			Text = "Category";
			base.Load += new System.EventHandler(frmItems_Load);
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			tblMain.ResumeLayout(false);
			tblSearch.ResumeLayout(false);
			tblSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgview).EndInit();
			tblEntry.ResumeLayout(false);
			tblEntry.PerformLayout();
			tblCommand.ResumeLayout(false);
			tblCommand.PerformLayout();
			ResumeLayout(false);
		}
	}
}
