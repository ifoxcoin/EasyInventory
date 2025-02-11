using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
    public class frmItems : Form
    {
        private int id = 0;

        private IContainer components = null;

        private a1panel a1Paneltitle;

        private Label lbltitle;

        private TableLayoutPanel tblMain;

        private TableLayoutPanel tblEntry;

        private Label label1;

        private Label label2;

        private Label label3;

        private Label label4;

        private Label label5;

        private Label label6;

        private Label label7;

        private Label label8;

        private Label label9;

        private lightbutton cmdclose;

        private TextBox txtMRP;

        private TextBox txtItemName;

        private TextBox txtItemCode;

        private TextBox txtPRate;

        private TextBox txtCostRate;

        private TextBox txtWholeSaleRate;

        private TextBox txtSpecialRate;

        private TextBox txtSuperSplRate;

        private ComboBox cboCategory;

        private DataGridView dgview;

        private TableLayoutPanel tblSearch;

        private TextBox txtSearch;

        private Label label10;

        private TableLayoutPanel tblCommand;

        private lightbutton btnClear;

        private lightbutton btnDelete;

        private lightbutton btnSave;

        private Label lblSearch;

        private BindingSource categoryBindingSource;

        private BindingSource uspitemSelectResultBindingSource;

        private Label label11;

        private ComboBox cboSearchCategory;
        private Label label12;
        private TextBox txtSerial;
        private Label label13;
        private TextBox txtBatchSearch;
        private DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn item_serial;
        private DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itempurchaserateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemcostrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemmrpDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemwholesalerateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemspecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemsupersepecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemudateDataGridViewTextBoxColumn;
        private BindingSource searchcategoryBindingSource;

        public frmItems()
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
            id = 0;
            txtItemCode.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtPRate.Text = "0";
            txtCostRate.Text = "0";
            txtMRP.Text = "0";
            txtWholeSaleRate.Text = "0";
            txtSpecialRate.Text = "0";
            txtSuperSplRate.Text = "0";
            txtSearch.Text = string.Empty;
            LoadData();
            cboCategory.SelectedValue = 0;
            cboSearchCategory.SelectedValue = 0;
        }

        private void LoadData()
        {
            txtItemName.Focus();
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, null, null,null);
            searchcategoryBindingSource.Clear();
            searchcategoryBindingSource.DataSource = inventoryDataContext.categories.Select((category li) => li);
            categoryBindingSource.DataSource = inventoryDataContext.categories.Select((category li) => li);
        }

        private void EditData()
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            if (dgview.CurrentCell != null)
            {
                int rowIndex = dgview.CurrentCell.RowIndex;
                id = Convert.ToInt32(dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                ISingleResult<usp_itemSelectResult> singleResult = inventoryDataContext.usp_itemSelect(id, null, null,null);
                foreach (usp_itemSelectResult item in singleResult)
                {
                    txtItemCode.Text = item.item_code;
                    txtSerial.Text = item.item_serial.ToString(); ;
                    txtItemName.Text = item.item_name;
                    cboCategory.SelectedValue = item.cat_id;
                    txtPRate.Text = item.item_purchaserate.ToString("N2");
                    txtCostRate.Text = item.item_costrate.ToString("N2");
                    txtMRP.Text = item.item_mrp.ToString("N2");
                    txtWholeSaleRate.Text = item.item_wholesalerate.ToString("N2");
                    txtSpecialRate.Text = item.item_specialrate.ToString("N2");
                    txtSuperSplRate.Text = item.item_supersepecialrate.ToString("N2");
                    txtItemName.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0 && MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    inventoryDataContext.usp_itemDelete(id);
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
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            item it = new item();
            try
            {
                it.item_code = txtItemCode.Text.Trim();
                it.item_serial = Convert.ToInt32(txtSerial.Text.Trim());
                it.item_name = txtItemName.Text.Trim();
                it.cat_id = Convert.ToInt32(cboCategory.SelectedValue);
                it.item_purchaserate = Convert.ToDecimal(txtPRate.Text.Trim());
                it.item_costrate = Convert.ToDecimal(txtCostRate.Text.Trim());
                it.item_mrp = Convert.ToDecimal(txtMRP.Text.Trim());
                it.item_wholesalerate = Convert.ToDecimal(txtWholeSaleRate.Text.Trim());
                it.item_specialrate = Convert.ToDecimal(txtSpecialRate.Text.Trim());
                it.item_supersepecialrate = Convert.ToDecimal(txtSuperSplRate.Text.Trim());
                if (it.item_name == string.Empty)
                {
                    MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtItemName.Focus();
                }
                else if (it.cat_id <= 0)
                {
                    MessageBox.Show("Invalid 'Category'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtItemName.Focus();
                }
                else if (it.item_purchaserate <= 0m)
                {
                    MessageBox.Show("Invalid 'Purchaserate'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPRate.Focus();
                }
                else if (it.item_costrate <= 0m)
                {
                    MessageBox.Show("Invalid 'Costrate'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtCostRate.Focus();
                }
                else
                {
                    var source = from b in inventoryDataContext.items
                                 where b.item_name == it.item_name && b.item_id != (long)id
                                 select new
                                 {
                                     b.cat_id
                                 };
                    if (source.Count() != 0)
                    {
                        MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtItemName.Focus();
                    }
                    else if (id == 0)
                    {
                        if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            inventoryDataContext.usp_itemInsert(it.item_code, it.item_serial, it.item_name, it.cat_id, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate, global.ucode, global.comid, global.sysdate);
                            MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            goto IL_0602;
                        }
                    }
                    else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_itemUpdate(id, it.item_code, it.item_serial, it.item_name, it.cat_id, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate, global.ucode, global.comid, global.sysdate);
                        MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        goto IL_0602;
                    }
                }
                goto end_IL_0022;
                IL_0602:
                Clear();
                end_IL_0022:;
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
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, txtSearch.Text, Convert.ToInt32(cboSearchCategory.SelectedValue),txtBatchSearch.Text);
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboSearchCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSearchCategory = new System.Windows.Forms.ComboBox();
            this.searchcategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtBatchSearch = new System.Windows.Forms.TextBox();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.uspitemSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntry = new System.Windows.Forms.TableLayoutPanel();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWholeSaleRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSpecialRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuperSplRate = new System.Windows.Forms.TextBox();
            this.txtCostRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.tblCommand = new System.Windows.Forms.TableLayoutPanel();
            this.cmdclose = new mylib.lightbutton();
            this.btnClear = new mylib.lightbutton();
            this.btnDelete = new mylib.lightbutton();
            this.btnSave = new mylib.lightbutton();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itempurchaserateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcostrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemmrpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemwholesalerateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemspecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsupersepecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1Paneltitle.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchcategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource)).BeginInit();
            this.tblEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.tblCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Paneltitle
            // 
            this.a1Paneltitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
            this.a1Paneltitle.Controls.Add(this.lbltitle);
            this.a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
            this.a1Paneltitle.Image = null;
            this.a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Location = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1293, 29);
            this.a1Paneltitle.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(25, 5);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(46, 18);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "ITEM";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblMain
            // 
            this.tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblSearch, 0, 2);
            this.tblMain.Controls.Add(this.dgview, 0, 3);
            this.tblMain.Controls.Add(this.a1Paneltitle, 0, 0);
            this.tblMain.Controls.Add(this.tblEntry, 0, 1);
            this.tblMain.Controls.Add(this.tblCommand, 0, 4);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblMain.Size = new System.Drawing.Size(1301, 499);
            this.tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Controls.Add(this.lblSearch, 2, 0);
            this.tblSearch.Controls.Add(this.label11, 0, 0);
            this.tblSearch.Controls.Add(this.cboSearchCategory, 1, 0);
            this.tblSearch.Controls.Add(this.label13, 4, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 5, 0);
            this.tblSearch.Controls.Add(this.txtBatchSearch, 3, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(4, 225);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1293, 39);
            this.tblSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearch.Location = new System.Drawing.Point(360, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(129, 18);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By Batch";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Search By Category";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSearchCategory
            // 
            this.cboSearchCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearchCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearchCategory.DataSource = this.searchcategoryBindingSource;
            this.cboSearchCategory.DisplayMember = "cat_name";
            this.cboSearchCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSearchCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchCategory.FormattingEnabled = true;
            this.cboSearchCategory.Location = new System.Drawing.Point(167, 3);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(187, 26);
            this.cboSearchCategory.TabIndex = 0;
            this.cboSearchCategory.ValueMember = "cat_id";
            this.cboSearchCategory.SelectedValueChanged += new System.EventHandler(this.cboSearchCategory_SelectedValueChanged);
            this.cboSearchCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // searchcategoryBindingSource
            // 
            this.searchcategoryBindingSource.DataSource = typeof(standard.classes.category);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label13.Location = new System.Drawing.Point(638, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Search By Item";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(777, 3);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 25);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtBatchSearch
            // 
            this.txtBatchSearch.BackColor = System.Drawing.Color.White;
            this.txtBatchSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSearch.Location = new System.Drawing.Point(497, 3);
            this.txtBatchSearch.MaxLength = 50;
            this.txtBatchSearch.Name = "txtBatchSearch";
            this.txtBatchSearch.Size = new System.Drawing.Size(134, 25);
            this.txtBatchSearch.TabIndex = 1;
            this.txtBatchSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.AutoGenerateColumns = false;
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgview.ColumnHeadersHeight = 28;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemidDataGridViewTextBoxColumn,
            this.catidDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.item_serial,
            this.itemnameDataGridViewTextBoxColumn,
            this.itempurchaserateDataGridViewTextBoxColumn,
            this.itemcostrateDataGridViewTextBoxColumn,
            this.itemmrpDataGridViewTextBoxColumn,
            this.itemwholesalerateDataGridViewTextBoxColumn,
            this.itemspecialrateDataGridViewTextBoxColumn,
            this.itemsupersepecialrateDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.itemudateDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspitemSelectResultBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(4, 271);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgview.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(1293, 178);
            this.dgview.TabIndex = 0;
            this.dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgview_CellDoubleClick);
            // 
            // uspitemSelectResultBindingSource
            // 
            this.uspitemSelectResultBindingSource.DataSource = typeof(standard.classes.usp_itemSelectResult);
            // 
            // tblEntry
            // 
            this.tblEntry.ColumnCount = 5;
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEntry.Controls.Add(this.txtItemName, 1, 0);
            this.tblEntry.Controls.Add(this.label1, 0, 0);
            this.tblEntry.Controls.Add(this.label2, 0, 1);
            this.tblEntry.Controls.Add(this.txtItemCode, 1, 1);
            this.tblEntry.Controls.Add(this.txtMRP, 3, 4);
            this.tblEntry.Controls.Add(this.label6, 2, 4);
            this.tblEntry.Controls.Add(this.label7, 2, 3);
            this.tblEntry.Controls.Add(this.txtWholeSaleRate, 3, 3);
            this.tblEntry.Controls.Add(this.label8, 2, 2);
            this.tblEntry.Controls.Add(this.txtSpecialRate, 3, 2);
            this.tblEntry.Controls.Add(this.label9, 2, 1);
            this.tblEntry.Controls.Add(this.txtSuperSplRate, 3, 1);
            this.tblEntry.Controls.Add(this.txtCostRate, 3, 0);
            this.tblEntry.Controls.Add(this.label5, 2, 0);
            this.tblEntry.Controls.Add(this.txtPRate, 1, 4);
            this.tblEntry.Controls.Add(this.label4, 0, 4);
            this.tblEntry.Controls.Add(this.label3, 0, 3);
            this.tblEntry.Controls.Add(this.cboCategory, 1, 3);
            this.tblEntry.Controls.Add(this.label12, 0, 2);
            this.tblEntry.Controls.Add(this.txtSerial, 1, 2);
            this.tblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEntry.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblEntry.Location = new System.Drawing.Point(4, 40);
            this.tblEntry.Name = "tblEntry";
            this.tblEntry.RowCount = 6;
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Size = new System.Drawing.Size(1293, 178);
            this.tblEntry.TabIndex = 2;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(203, 3);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(194, 26);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(203, 38);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(194, 26);
            this.txtItemCode.TabIndex = 1;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // txtMRP
            // 
            this.txtMRP.BackColor = System.Drawing.Color.White;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRP.Location = new System.Drawing.Point(603, 143);
            this.txtMRP.MaxLength = 50;
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(194, 26);
            this.txtMRP.TabIndex = 9;
            this.txtMRP.Text = "0";
            this.txtMRP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(403, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "MRP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(403, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Whole Sale Rate";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWholeSaleRate
            // 
            this.txtWholeSaleRate.BackColor = System.Drawing.Color.White;
            this.txtWholeSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWholeSaleRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWholeSaleRate.Location = new System.Drawing.Point(603, 108);
            this.txtWholeSaleRate.MaxLength = 50;
            this.txtWholeSaleRate.Name = "txtWholeSaleRate";
            this.txtWholeSaleRate.Size = new System.Drawing.Size(194, 26);
            this.txtWholeSaleRate.TabIndex = 8;
            this.txtWholeSaleRate.Text = "0";
            this.txtWholeSaleRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(403, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Special Rate";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSpecialRate
            // 
            this.txtSpecialRate.BackColor = System.Drawing.Color.White;
            this.txtSpecialRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialRate.Location = new System.Drawing.Point(603, 73);
            this.txtSpecialRate.MaxLength = 50;
            this.txtSpecialRate.Name = "txtSpecialRate";
            this.txtSpecialRate.Size = new System.Drawing.Size(194, 26);
            this.txtSpecialRate.TabIndex = 7;
            this.txtSpecialRate.Text = "0";
            this.txtSpecialRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label9.Location = new System.Drawing.Point(403, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Super Special Rate";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSuperSplRate
            // 
            this.txtSuperSplRate.BackColor = System.Drawing.Color.White;
            this.txtSuperSplRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuperSplRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperSplRate.Location = new System.Drawing.Point(603, 38);
            this.txtSuperSplRate.MaxLength = 50;
            this.txtSuperSplRate.Name = "txtSuperSplRate";
            this.txtSuperSplRate.Size = new System.Drawing.Size(194, 26);
            this.txtSuperSplRate.TabIndex = 6;
            this.txtSuperSplRate.Text = "0";
            this.txtSuperSplRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // txtCostRate
            // 
            this.txtCostRate.BackColor = System.Drawing.Color.White;
            this.txtCostRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostRate.Location = new System.Drawing.Point(603, 3);
            this.txtCostRate.MaxLength = 50;
            this.txtCostRate.Name = "txtCostRate";
            this.txtCostRate.Size = new System.Drawing.Size(194, 26);
            this.txtCostRate.TabIndex = 5;
            this.txtCostRate.Text = "0";
            this.txtCostRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(403, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cost Rate";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPRate
            // 
            this.txtPRate.BackColor = System.Drawing.Color.White;
            this.txtPRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRate.Location = new System.Drawing.Point(203, 143);
            this.txtPRate.MaxLength = 50;
            this.txtPRate.Name = "txtPRate";
            this.txtPRate.Size = new System.Drawing.Size(194, 26);
            this.txtPRate.TabIndex = 4;
            this.txtPRate.Text = "0";
            this.txtPRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(3, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchase Rate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(3, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCategory
            // 
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.DataSource = this.categoryBindingSource;
            this.cboCategory.DisplayMember = "cat_name";
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(203, 108);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(194, 26);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.ValueMember = "cat_id";
            this.cboCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(standard.classes.category);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label12.Location = new System.Drawing.Point(3, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Serial Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.Color.White;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(203, 73);
            this.txtSerial.MaxLength = 50;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(194, 26);
            this.txtSerial.TabIndex = 2;
            this.txtSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // tblCommand
            // 
            this.tblCommand.ColumnCount = 5;
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.Controls.Add(this.cmdclose, 4, 0);
            this.tblCommand.Controls.Add(this.btnClear, 3, 0);
            this.tblCommand.Controls.Add(this.btnDelete, 2, 0);
            this.tblCommand.Controls.Add(this.btnSave, 1, 0);
            this.tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCommand.Location = new System.Drawing.Point(4, 456);
            this.tblCommand.Name = "tblCommand";
            this.tblCommand.RowCount = 1;
            this.tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.Size = new System.Drawing.Size(1293, 39);
            this.tblCommand.TabIndex = 3;
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1196, 3);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(90, 30);
            this.cmdclose.TabIndex = 3;
            this.cmdclose.Text = "&Close";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = false;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1096, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnDelete.Location = new System.Drawing.Point(996, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSave.Location = new System.Drawing.Point(896, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "item_id";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Visible = false;
            // 
            // catidDataGridViewTextBoxColumn
            // 
            this.catidDataGridViewTextBoxColumn.DataPropertyName = "cat_name";
            this.catidDataGridViewTextBoxColumn.HeaderText = "Category";
            this.catidDataGridViewTextBoxColumn.Name = "catidDataGridViewTextBoxColumn";
            this.catidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "item_code";
            this.itemcodeDataGridViewTextBoxColumn.FillWeight = 26.78707F;
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "Batch";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // item_serial
            // 
            this.item_serial.DataPropertyName = "item_serial";
            this.item_serial.HeaderText = "Serial";
            this.item_serial.Name = "item_serial";
            this.item_serial.ReadOnly = true;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.FillWeight = 236.4322F;
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 350;
            // 
            // itempurchaserateDataGridViewTextBoxColumn
            // 
            this.itempurchaserateDataGridViewTextBoxColumn.DataPropertyName = "item_purchaserate";
            this.itempurchaserateDataGridViewTextBoxColumn.FillWeight = 0.6333332F;
            this.itempurchaserateDataGridViewTextBoxColumn.HeaderText = "Purchaserate";
            this.itempurchaserateDataGridViewTextBoxColumn.Name = "itempurchaserateDataGridViewTextBoxColumn";
            this.itempurchaserateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itempurchaserateDataGridViewTextBoxColumn.Visible = false;
            this.itempurchaserateDataGridViewTextBoxColumn.Width = 8;
            // 
            // itemcostrateDataGridViewTextBoxColumn
            // 
            this.itemcostrateDataGridViewTextBoxColumn.DataPropertyName = "item_costrate";
            this.itemcostrateDataGridViewTextBoxColumn.FillWeight = 12.69035F;
            this.itemcostrateDataGridViewTextBoxColumn.HeaderText = "Costrate";
            this.itemcostrateDataGridViewTextBoxColumn.Name = "itemcostrateDataGridViewTextBoxColumn";
            this.itemcostrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcostrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemmrpDataGridViewTextBoxColumn
            // 
            this.itemmrpDataGridViewTextBoxColumn.DataPropertyName = "item_mrp";
            this.itemmrpDataGridViewTextBoxColumn.FillWeight = 12.69035F;
            this.itemmrpDataGridViewTextBoxColumn.HeaderText = "Mrp";
            this.itemmrpDataGridViewTextBoxColumn.Name = "itemmrpDataGridViewTextBoxColumn";
            this.itemmrpDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemmrpDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemwholesalerateDataGridViewTextBoxColumn
            // 
            this.itemwholesalerateDataGridViewTextBoxColumn.DataPropertyName = "item_wholesalerate";
            this.itemwholesalerateDataGridViewTextBoxColumn.HeaderText = "Wholesalerate";
            this.itemwholesalerateDataGridViewTextBoxColumn.Name = "itemwholesalerateDataGridViewTextBoxColumn";
            this.itemwholesalerateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemwholesalerateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemspecialrateDataGridViewTextBoxColumn
            // 
            this.itemspecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_specialrate";
            this.itemspecialrateDataGridViewTextBoxColumn.HeaderText = "Specialrate";
            this.itemspecialrateDataGridViewTextBoxColumn.Name = "itemspecialrateDataGridViewTextBoxColumn";
            this.itemspecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemspecialrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsupersepecialrateDataGridViewTextBoxColumn
            // 
            this.itemsupersepecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_supersepecialrate";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.HeaderText = "Supersepecialrate";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Name = "itemsupersepecialrateDataGridViewTextBoxColumn";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // usersuidDataGridViewTextBoxColumn
            // 
            this.usersuidDataGridViewTextBoxColumn.DataPropertyName = "users_uid";
            this.usersuidDataGridViewTextBoxColumn.HeaderText = "users_uid";
            this.usersuidDataGridViewTextBoxColumn.Name = "usersuidDataGridViewTextBoxColumn";
            this.usersuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemudateDataGridViewTextBoxColumn
            // 
            this.itemudateDataGridViewTextBoxColumn.DataPropertyName = "item_udate";
            this.itemudateDataGridViewTextBoxColumn.HeaderText = "item_udate";
            this.itemudateDataGridViewTextBoxColumn.Name = "itemudateDataGridViewTextBoxColumn";
            this.itemudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemudateDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1301, 499);
            this.Controls.Add(this.tblMain);
            this.Name = "frmItems";
            this.ShowIcon = false;
            this.Text = "ITEMS";
            this.Load += new System.EventHandler(this.frmItems_Load);
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchcategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource)).EndInit();
            this.tblEntry.ResumeLayout(false);
            this.tblEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.tblCommand.ResumeLayout(false);
            this.tblCommand.PerformLayout();
            this.ResumeLayout(false);

        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }           
        }
    }
}
