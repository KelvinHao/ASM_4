using ASM_4.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_4
{
    public partial class frmReport : Form
    {
        BookDB b = new BookDB();
        DataTable dtBook;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            dtBook = b.getBooks();
            bsReport.DataSource = dtBook;
            dgvReport.DataSource = bsReport;
            bsReport.Sort = "BookPrice DESC";
            bnReport.BindingSource = bsReport;
        }
    }
}
