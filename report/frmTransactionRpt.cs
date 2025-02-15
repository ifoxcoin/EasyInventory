using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WinForms.Internal;
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
    public partial class frmTransactionRpt : Form
    {

        public string _ReportName = "";
        public string _LedgerType = "CUSTOMER";
        public string _ReportType = "Summary";
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
        public frmTransactionRpt()
        {
            InitializeComponent();
        }

        private void frmAddressPrint_Load(object sender, EventArgs e)
        {
            LoadTitle();
            LoadData();
            //  this.reportViewer1.RefreshReport();
        }
        AutoCompleteStringCollection partyautocompletelist = new AutoCompleteStringCollection();
        AutoCompleteStringCollection customerautocompletelist = new AutoCompleteStringCollection();
        private void LoadData()
        {
            //TimeSpan ts = new TimeSpan(10, 0, 0, 0);
            //dtpfdate.Value = dtpfdate.Value.Subtract(ts);
            DateTime todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


            if (todaydate.Date > new DateTime(DateTime.Now.Year, 04, 01))
                dtpfdate.Value = new DateTime(DateTime.Now.Year, 04, 01);

            else
                dtpfdate.Value = new DateTime(DateTime.Now.Year - 1, 04, 01);



            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {

                var sup = (from a in db.ledgermasters
                           where a.led_accounttype.ToUpper() == _LedgerType.ToUpper() || a.led_id == 0
                           select new { a.led_id, a.led_name, a.led_address2 });
                var cus = (from a in db.ledgermasters
                           where a.led_accounttype.ToUpper() == "CUSTOMER" || a.led_id == 0
                           select new { a.led_id, a.led_name, a.led_address2 });

                ledgermasterBindingSource.DataSource = sup.OrderBy(x => x.led_address2);
                uspledgermasterSelectResultBindingSource1.DataSource = db.usp_ledgermasterSelect(null, "Ledger", null, null, null);
                ledgermasterCityBindingSource.DataSource = sup.Select(x => x.led_address2).Distinct();
                uspledgermasterCustomerCityBindingSource.DataSource = cus.Select(x => x.led_address2).Distinct();
                uspledgermasterCustomerSelectResultBindingSource.DataSource = db.usp_ledgermasterSelect(null, "CUSTOMER", null, null, null);
                foreach (var li in sup)
                {
                    partyautocompletelist.Add(li.led_name);
                }
                cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboName.AutoCompleteCustomSource = partyautocompletelist;

                foreach (var li in sup)
                {
                    customerautocompletelist.Add(li.led_name);
                }
                cboCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboCustomer.AutoCompleteCustomSource = customerautocompletelist;

                //ledgermasterBindingSource.DataSource = sup;


            }
            if (_ReportName == "Receipt Report" || _ReportName == "Outstanding Report" || _ReportName == "Ledger Outstanding Report")
            {
                chkIsSummary.Visible = false;
                lblPartyType.Visible = false;
                cboPartyType.Visible = false;
                lblReference.Visible = false;
                cboReference.Visible = false;
                lblcityname.Visible = false;
                cboCustomer.Visible = false;
                lblCustomer.Visible = false;

                dtpfdate.Select();
            }
            else if (_ReportName == "Ledger Report")
            {
                chkIsSummary.Visible = false;
                dtpfdate.Visible = false;
                dtptdate.Visible = false;
                lblfdate.Visible = false;
                lblhyp.Visible = false;
                cboCity.Visible = false;
                cboName.Visible = false;
                lblLedger.Visible = false;
                lblCity.Visible = false;
                lblReference.Visible = false;
                cboReference.Visible = false;

                cboCustomer.Visible = false;
                lblCustomer.Visible = false;

            }
            else if (_ReportName == "AgentCommission Report" || _ReportName == "Agent Outstanding Report")
            {


                chkIsSummary.Visible = false;
                dtpfdate.Visible = false;
                dtptdate.Visible = false;
                lblfdate.Visible = false;
                lblhyp.Visible = false;
                //cboCity.Visible = false; //Arun
                //lblCity.Visible = false; //Arun

                cboCity.Visible = true;  //arun
                lblCity.Visible = true;  //arun
                cboCity.SelectedIndex = 1;
                lblPartyType.Visible = false;
                cboPartyType.Visible = false;
                lblReference.Visible = false;
                cboReference.Visible = false;

                cboName.Visible = true;
                lblLedger.Visible = true;
                

            }
            else
            {
                dtpfdate.Select();
                lblPartyType.Visible = false;
                cboPartyType.Visible = false;
                lblReference.Visible = false;
                cboReference.Visible = false;
                cboCustomer.Visible = false;
                lblCustomer.Visible = false;
            }

        }

        private void LoadTitle()
        {
            if (_ReportName == "Purchase Report")
            {
                this.Text = "Purchase Report";
                lbltitle.Text = "Purchase Report";
            }
            else if (_ReportName == "Sales Report")
            {
                this.Text = "Sales Report";
                lbltitle.Text = "Sales Report";
            }
            else if (_ReportName == "Receipt Report")
            {
                this.Text = "Receipt Report";
                lbltitle.Text = "Receipt Report";
            }
            else if (_ReportName == "Outstanding Report")
            {
                this.Text = "Outstanding Report";
                lbltitle.Text = "Outstanding Report";
            }
            else if (_ReportName == "Ledger Outstanding Report")
            {
                this.Text = "Ledger Outstanding Report";
                lbltitle.Text = "Ledger Outstanding Report";
            }
            else if (_ReportName == "Outstanding Report")
            {
                this.Text = "Ledger Report";
                lbltitle.Text = "Ledger Report";
            }
            else if (_ReportName == "AgentCommission Report")
            {
                this.Text = "Agent Commission Report";
                lbltitle.Text = "Agent Commission Report";
            }
            else if (_ReportName == "Ledgerwise Outstanding Report")
            {
                this.Text = "Ledgerwise Outstanding Report";
                lbltitle.Text = "Ledgerwise Outstanding Report";
            }
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
                int ledid = Convert.ToInt32(cboName.SelectedValue);
                int agledid = Convert.ToInt32(cboReference.SelectedValue);
                int partyid = Convert.ToInt32(cboCustomer.SelectedValue);
                //   var data = db.usp_ledgermasterSelect(id, null, null, null);

                if (_ReportName == "Purchase Report")
                {

                    if (_ReportType == "Summary")
                    {
                        //List<ReportParameter> rparam = new List<ReportParameter>();
                        //rparam.Add(new ReportParameter("city", cboCity.Text));
                        //rparam.Add(new ReportParameter("partyname", cboName.Text));
                        reportViewer1.RefreshReport();
                        var data = db.usp_purchasemasterSelect(null, ledid, dtpfdate.Value, dtptdate.Value, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptPurchaseSummary.rdlc";
                        //reportViewer1.LocalReport.SetParameters(rparam);
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);

                    }
                    else
                    {

                        var data = db.usp_purchasedetailsSelect(null, ledid, dtpfdate.Value, dtptdate.Value, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptPurchaseDetail.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);

                    }
                }
                else if (_ReportName == "Sales Report")
                {
                    if (_ReportType == "Summary")
                    {
                        var data = db.usp_salesmasterSelect(null, ledid, dtpfdate.Value, dtptdate.Value, null, null);
                        var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesSummary.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                        reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);

                    }
                    else
                    {
                        var data = db.usp_salesdetailsSelect(null, dtpfdate.Value, dtptdate.Value, ledid, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesDetail.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);

                    }
                }
                else if (_ReportName == "Receipt Report")
                {
                    var data = db.usp_receiptSelect(null, ledid, dtpfdate.Value, dtptdate.Value);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptReceipt.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }

                else if (_ReportName == "Ledger Outstanding Report")
                {

                    if (cboCity.Text == "" || cboName.Text == "")
                    {
                        MessageBox.Show("Please Select any PartyName...");
                        return;
                    }
                    //List<ReportParameter> rparam = new List<ReportParameter>();
                    //rparam.Add(new ReportParameter("city", cboCity.Text));
                    //rparam.Add(new ReportParameter("partyname", cboName.Text));
                    reportViewer1.RefreshReport();
                    var data = db.usp_LedgerOutstandingRpt(ledid, dtpfdate.Value, dtptdate.Value);
                    var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedgersOutstanding.rdlc";
                    //reportViewer1.LocalReport.SetParameters(rparam);
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                    reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);
                }
                else if (_ReportName == "AgentCommission Report")
                {
                    var data = db.usp_AgentComissionReport(ledid, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAgentCommission.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
                else if (_ReportName == "Agent Outstanding Report")
                {

                    var data = db.usp_OutstandingReport(null, ledid,partyid, dtpfdate.Value, dtptdate.Value);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptOutstanding.rdlc";
                    //var data = db.usp_LedgerwiseOutstandingReport(ledid);
                    //reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedgerwiseOutstanding.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
                else if (_ReportName == "Ledger Report")
                {
                    if (cboPartyType.SelectedIndex <= 0)
                    {
                        var data = db.usp_ledgermasterSelect(null, null, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedger.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                    }
                    else
                    {
                        if (cboPartyType.Text.Trim().ToUpper() != "CUSTOMER")
                            agledid = 0;
                        var data = db.usp_ledgermasterSelect(null, cboPartyType.Text, null, null, agledid);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedger.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                    }
                }
                // reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 150;
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void chkIsSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSummary.Checked == false)
            {
                _ReportType = "Detail";
                chkIsSummary.Text = "DETAILED";
                chkIsSummary.BackColor = Color.Green;
                chkIsSummary.ForeColor = Color.White;

            }
            else
            {
                _ReportType = "Summary";
                chkIsSummary.Text = "SUMMARY";
                chkIsSummary.BackColor = Color.Red;
                chkIsSummary.ForeColor = Color.White;
            }
        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCity_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboPartyType.Text.Trim().ToUpper() != "CUSTOMER")
            {
                lblReference.Visible = false;
                cboReference.Visible = false;

            }
            else
            {
                lblReference.Visible = true;
                cboReference.Visible = true;
            }
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            if (cboCity.SelectedItem == null)
                return;
            using (db)
            {

                if (_ReportName == "Agent Outstanding Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Agent"))
                              //orderby a.led_name
                              select new { a.led_id, a.led_name };
                    //var PartyList = (from a in db.ledgermasters
                    //           where (a.led_accounttype.ToUpper() == "CUSTOMER" 
                    //                  || a.led_id == 0)
                    //           select new { a.led_id, a.led_name, a.led_address2 });
                    cboName.DataSource = sup;
                    //cboCustomer.DataSource = PartyList;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else if (_ReportName == "Purchase Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Supplier"))
                              //orderby a.led_name
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else if (_ReportName == "Sales Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                                  //orderby a.led_name
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Customer"))
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                                  //orderby a.led_name
                              where a.led_address2 == cboCity.Text.ToString()
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                // ledgermasterBindingSource .DataSource = sup;

            }
        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboName.Focus();
        }

        private void cboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cboName.SelectedValue) > 0)
                    cmdList_Click(null, null);
                else
                {
                    MessageBox.Show("Please select valid Ledger...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboName.Focus();
                    return;
                }
            }
        }

        private void cboPartyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdList_Click(null, null);
        }

        private void dtpfdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtptdate.Focus();
        }

        private void dtptdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboCity.Focus();
        }

        private void cityname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                classes.InventoryDataContext db = new classes.InventoryDataContext();
                var cus = (from a in db.ledgermasters
                           where a.led_accounttype.ToUpper() == "CUSTOMER" ||  a.led_address2 ==cboCustomerCity.SelectedText.ToString()
                           select new { a.led_id, a.led_name, a.led_address2 });
                cboCustomer.DataSource = cus.Select(x => x.led_name).Distinct();
            }
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ReportName == "Agent Outstanding Report")
            { 
            if (cboName.SelectedValue == null)
                return; // Exit if no ledger is selected

            int? agentId = Convert.ToInt32(cboName.SelectedValue); // Get selected Ledger ID

            using (InventoryDataContext inventoryDataContext = new InventoryDataContext())
            {
                // Fetch only customers related to the selected ledger
                var customers = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, agentId)
                                .Select(c => new
                                {
                                    CustomerID = c.led_id,    // Replace with actual column name from DB
                            CustomerName = c.led_name // Replace with actual column name from DB
                        })
                                .ToList();

                // Bind filtered customers to cboCustomer
                cboCustomer.DataSource = customers;
                cboCustomer.DisplayMember = "CustomerName"; // Display Name
                cboCustomer.ValueMember = "CustomerID";     // Store ID as value
            }
            }

        }

    }
}
