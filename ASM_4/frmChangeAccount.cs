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
    public partial class frmChangeAccount : Form
    {

        public Employee EmployeeAccount { get; set; }
        public frmChangeAccount()
        {
            InitializeComponent();
        }
        public frmChangeAccount(Employee e) : this()
        {
            EmployeeAccount = e;
            InitData();
        }

        private void frmChangeAccount_Load(object sender, EventArgs e)
        {

        }

        private void InitData()
        {
            txtEmpID.Text = EmployeeAccount.EmpID.ToString();
            txtEmpPass.Text = EmployeeAccount.EmpPass.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool flag;
            EmployeeAccount.EmpID = txtEmpID.Text;
            EmployeeAccount.EmpPass = txtNewPass.Text;

            EmployeeDB edb = new EmployeeDB();

            flag = edb.UpdateEmployeePassword(EmployeeAccount);

            //xuat thong bao
            if (flag == true && !txtEmpPass.Text.Equals(""))
            {
                MessageBox.Show("Change successful!");
            }
            else
            {
                MessageBox.Show("Change fail!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
