namespace standard.report
{
    partial class frmTransactionRpt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tablelist = new System.Windows.Forms.TableLayoutPanel();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.lblhyp = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblfdate = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCity = new System.Windows.Forms.Label();
            this.lblLedger = new System.Windows.Forms.Label();
            this.chkIsSummary = new System.Windows.Forms.CheckBox();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.lblPartyType = new System.Windows.Forms.Label();
            this.cboPartyType = new System.Windows.Forms.ComboBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.cboReference = new System.Windows.Forms.ComboBox();
            this.uspledgermasterSelectResultBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblReference = new System.Windows.Forms.Label();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tablelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource1)).BeginInit();
            this.a1Paneltitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tablelist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.a1Paneltitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tablelist
            // 
            this.tablelist.ColumnCount = 11;
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.Controls.Add(this.dtptdate, 3, 0);
            this.tablelist.Controls.Add(this.lblhyp, 2, 0);
            this.tablelist.Controls.Add(this.dtpfdate, 1, 0);
            this.tablelist.Controls.Add(this.lblfdate, 0, 0);
            this.tablelist.Controls.Add(this.cboCity, 5, 0);
            this.tablelist.Controls.Add(this.lblCity, 4, 0);
            this.tablelist.Controls.Add(this.lblLedger, 6, 0);
            this.tablelist.Controls.Add(this.chkIsSummary, 1, 1);
            this.tablelist.Controls.Add(this.cmdList, 9, 1);
            this.tablelist.Controls.Add(this.cmdexit, 10, 1);
            this.tablelist.Controls.Add(this.lblPartyType, 3, 1);
            this.tablelist.Controls.Add(this.cboPartyType, 4, 1);
            this.tablelist.Controls.Add(this.cboName, 7, 0);
            this.tablelist.Controls.Add(this.cboReference, 7, 1);
            this.tablelist.Controls.Add(this.lblReference, 6, 1);
            this.tablelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelist.Location = new System.Drawing.Point(5, 47);
            this.tablelist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tablelist.Name = "tablelist";
            this.tablelist.RowCount = 2;
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablelist.Size = new System.Drawing.Size(1221, 78);
            this.tablelist.TabIndex = 4;
            // 
            // dtptdate
            // 
            this.dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtptdate.CustomFormat = "dd-MM-yyyy";
            this.dtptdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptdate.Location = new System.Drawing.Point(247, 6);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(5);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(132, 26);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(217, 11);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(14, 16);
            this.lblhyp.TabIndex = 1;
            this.lblhyp.Text = "-";
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(70, 6);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(132, 26);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(5, 10);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(43, 18);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            // 
            // cboCity
            // 
            this.cboCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(459, 6);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(165, 26);
            this.cboCity.TabIndex = 25;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged_1);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblCity
            // 
            this.lblCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCity.Location = new System.Drawing.Point(389, 10);
            this.lblCity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(38, 18);
            this.lblCity.TabIndex = 24;
            this.lblCity.Text = "City";
            // 
            // lblLedger
            // 
            this.lblLedger.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLedger.AutoSize = true;
            this.lblLedger.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLedger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblLedger.Location = new System.Drawing.Point(634, 10);
            this.lblLedger.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLedger.Name = "lblLedger";
            this.lblLedger.Size = new System.Drawing.Size(60, 18);
            this.lblLedger.TabIndex = 24;
            this.lblLedger.Text = "Ledger";
            // 
            // chkIsSummary
            // 
            this.chkIsSummary.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsSummary.BackColor = System.Drawing.Color.Red;
            this.chkIsSummary.Checked = true;
            this.chkIsSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tablelist.SetColumnSpan(this.chkIsSummary, 2);
            this.chkIsSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSummary.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkIsSummary.Location = new System.Drawing.Point(68, 42);
            this.chkIsSummary.Name = "chkIsSummary";
            this.chkIsSummary.Size = new System.Drawing.Size(134, 32);
            this.chkIsSummary.TabIndex = 27;
            this.chkIsSummary.Text = "SUMMARY";
            this.chkIsSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsSummary.UseVisualStyleBackColor = false;
            this.chkIsSummary.CheckedChanged += new System.EventHandler(this.chkIsSummary_CheckedChanged);
            // 
            // cmdList
            // 
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(988, 40);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(114, 36);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(1105, 40);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(114, 36);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // lblPartyType
            // 
            this.lblPartyType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPartyType.AutoSize = true;
            this.lblPartyType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPartyType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblPartyType.Location = new System.Drawing.Point(247, 49);
            this.lblPartyType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPartyType.Name = "lblPartyType";
            this.lblPartyType.Size = new System.Drawing.Size(85, 18);
            this.lblPartyType.TabIndex = 24;
            this.lblPartyType.Text = "PartyType";
            // 
            // cboPartyType
            // 
            this.cboPartyType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboPartyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPartyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tablelist.SetColumnSpan(this.cboPartyType, 2);
            this.cboPartyType.DisplayMember = "led_address2";
            this.cboPartyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPartyType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPartyType.FormattingEnabled = true;
            this.cboPartyType.Items.AddRange(new object[] {
            "---Select---",
            "Customer",
            "Supplier",
            "Agent"});
            this.cboPartyType.Location = new System.Drawing.Point(389, 45);
            this.cboPartyType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboPartyType.Name = "cboPartyType";
            this.cboPartyType.Size = new System.Drawing.Size(222, 26);
            this.cboPartyType.TabIndex = 25;
            this.cboPartyType.ValueMember = "led_id";
            this.cboPartyType.SelectedIndexChanged += new System.EventHandler(this.cboCity_SelectedValueChanged_1);
            this.cboPartyType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPartyType_KeyDown);
            // 
            // cboName
            // 
            this.cboName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(735, 6);
            this.cboName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(212, 26);
            this.cboName.TabIndex = 25;
            this.cboName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboName_KeyDown);
            // 
            // cboReference
            // 
            this.cboReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReference.DataSource = this.uspledgermasterSelectResultBindingSource1;
            this.cboReference.DisplayMember = "led_name";
            this.cboReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReference.FormattingEnabled = true;
            this.cboReference.Location = new System.Drawing.Point(735, 45);
            this.cboReference.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboReference.Name = "cboReference";
            this.cboReference.Size = new System.Drawing.Size(212, 26);
            this.cboReference.TabIndex = 28;
            this.cboReference.ValueMember = "led_id";
            this.cboReference.Visible = false;
            // 
            // uspledgermasterSelectResultBindingSource1
            // 
            this.uspledgermasterSelectResultBindingSource1.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // lblReference
            // 
            this.lblReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblReference.Location = new System.Drawing.Point(634, 49);
            this.lblReference.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(85, 18);
            this.lblReference.TabIndex = 24;
            this.lblReference.Text = "Reference";
            this.lblReference.Visible = false;
            // 
            // a1Paneltitle
            // 
            this.a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
            this.a1Paneltitle.Controls.Add(this.lbltitle);
            this.a1Paneltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
            this.a1Paneltitle.Image = null;
            this.a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Location = new System.Drawing.Point(3, 3);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1225, 37);
            this.a1Paneltitle.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(10, 6);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(77, 19);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "REPORT";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 132);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1225, 341);
            this.reportViewer1.TabIndex = 3;
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // frmTransactionRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1231, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "frmTransactionRpt";
            this.ShowIcon = false;
            this.Text = " PRINT";
            this.Load += new System.EventHandler(this.frmAddressPrint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tablelist.ResumeLayout(false);
            this.tablelist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource1)).EndInit();
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private mylib.a1panel a1Paneltitle;
        private System.Windows.Forms.Label lbltitle;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource;
        private System.Windows.Forms.BindingSource ledgermasterCityBindingSource;
        private System.Windows.Forms.BindingSource ledgermasterBindingSource;
        private System.Windows.Forms.TableLayoutPanel tablelist;
        private System.Windows.Forms.DateTimePicker dtptdate;
        private mylib.lightbutton cmdList;
        private mylib.lightbutton cmdexit;
        private System.Windows.Forms.Label lblhyp;
        private System.Windows.Forms.DateTimePicker dtpfdate;
        private System.Windows.Forms.Label lblfdate;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblLedger;
        private System.Windows.Forms.CheckBox chkIsSummary;
        private System.Windows.Forms.ComboBox cboPartyType;
        private System.Windows.Forms.Label lblPartyType;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.ComboBox cboReference;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource1;
    }
}