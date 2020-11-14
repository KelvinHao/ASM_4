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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtEmID.Text;
            string pass = txtEmPass.Text;
            EmployeeDB edb = new EmployeeDB();
            Employee em = edb.Login(id, pass);
            if (em == null)
            {
                MessageBox.Show("Wrong ID or Password");
            }
            else
            {
                if (em.EmpRole == false)
                {
                    frmChangeAccount change = new frmChangeAccount(em);
                    this.Hide();
                    change.ShowDialog();
                    this.Show();
                }
                else
                {
                    frmMaintainBook main = new frmMaintainBook();
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
