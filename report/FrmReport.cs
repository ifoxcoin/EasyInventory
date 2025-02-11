using Microsoft.Reporting.WinForms;
using standard.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace standard.report
{
    public partial class FrmReport : Form
    {
        public string _ReportName = "";
        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }
        public FrmReport()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            dtpfdate.Focus();
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            uspledgermasterSelectResultBindingSource.DataSource = inventoryDataContext.ledgermasters.Select((ledgermaster li) => li);
        }

        private void LoadReport()
        {

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                //if (Convert.ToInt32(cboName.SelectedValue) <= 0)
                //{

                //    MessageBox.Show("select valid ledger to print...");
                //}
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.DataSources.Clear();
                int ledid = Convert.ToInt32(cmbLedgName.SelectedValue);

                    if (cmbLedgName.SelectedIndex >= 0)
                    {
                        var data = db.usp_ledgermasterSelect(ledid, CompanyName, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.Report1.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                    }
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 150;
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
        }

        private void cmbLedgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cmbLedgName.SelectedValue) > 0)
                    LoadReport();
                else
                {
                    MessageBox.Show("Please select valid Ledger...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLedgName.Focus();
                    return;
                }
            }
        }
    }
}
