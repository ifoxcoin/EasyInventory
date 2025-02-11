
namespace standard.report
{
    partial class FrmReport
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
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.cmbLedgName = new System.Windows.Forms.ComboBox();
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpfdate
            // 
            this.dtpfdate.Location = new System.Drawing.Point(3, 3);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(145, 20);
            this.dtpfdate.TabIndex = 0;
            // 
            // cmbLedgName
            // 
            this.cmbLedgName.DataSource = this.uspledgermasterSelectResultBindingSource;
            this.cmbLedgName.DisplayMember = "led_name";
            this.cmbLedgName.FormattingEnabled = true;
            this.cmbLedgName.Location = new System.Drawing.Point(231, 3);
            this.cmbLedgName.Name = "cmbLedgName";
            this.cmbLedgName.Size = new System.Drawing.Size(162, 21);
            this.cmbLedgName.TabIndex = 1;
            this.cmbLedgName.ValueMember = "led_id";
            this.cmbLedgName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLedgName_KeyDown);
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // View
            // 
            this.View.Location = new System.Drawing.Point(459, 3);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(123, 38);
            this.View.TabIndex = 2;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = true;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(693, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(140, 38);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.Controls.Add(this.cmbLedgName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.View, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Exit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(881, 115);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpfdate;
        private System.Windows.Forms.ComboBox cmbLedgName;
        private System.Windows.Forms.Button View;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}