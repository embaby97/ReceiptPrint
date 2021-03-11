using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptStar
{
    public partial class frmPrint : Form
    {
        List<Receipt> _list;
        string _total, _cash, _change, _date;

        public frmPrint(List<Receipt> dataSource, string total , string cash , string change , string date)
        {

            InitializeComponent();
            _list = dataSource;
            _cash = cash;
            _change = change;
            _total = total;
            _date = date;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            
            ReportDataSource source = new ReportDataSource("ds", _list);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);

            Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal" , _total),
                new Microsoft.Reporting.WinForms.ReportParameter("pCash" , _cash),
                new Microsoft.Reporting.WinForms.ReportParameter("pChange" , _change),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate" , _date)

            };

            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
