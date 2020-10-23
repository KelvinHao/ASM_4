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
    public partial class frmMaintainBook : Form
    {
        BookDB b = new BookDB();
        DataTable dtBook;
        public frmMaintainBook()
        {
            InitializeComponent();
        }

        private void frmMaintainBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            dtBook = b.getBooks();
            bsBookList.DataSource = dtBook;

            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            txtBookPrice.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", dtBook, "BookID");
            txtBookName.DataBindings.Add("Text", dtBook, "BookName");
            txtBookPrice.DataBindings.Add("Text", dtBook, "BookPrice");

            dgvBookList.DataSource = bsBookList;
            bsBookList.Sort = "BookID ASC";
            bnBookList.BindingSource = bsBookList;

            lbFilter.Text = "Total Price: " + dtBook.Compute("SUM(BookPrice)", string.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtBookName.Text;
            float Price = float.Parse(txtBookPrice.Text);
            //Tao moi doi tuong product de truyen cho form frmProductDetails
            Book book = new Book
            {

                BookName = name,
                BookPrice = Price,

            };
            if (b.addNewBook(book))
            {
                LoadData();
                MessageBox.Show("Add successful!!");
            }
            else
            {
                MessageBox.Show("Add fail!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = txtBookName.Text;
            if (b.deleteBook(name))
            {
                LoadData();
                MessageBox.Show("Delete successful!!");
            }
            else
            {
                MessageBox.Show("Delete fail!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtBookName.Text;
            float Price = float.Parse(txtBookPrice.Text);
            //Tao moi doi tuong product de truyen cho form frmProductDetails
            Book book = new Book
            {

                BookName = name,
                BookPrice = Price,

            };
            if (b.updateBook(book))
            {
                LoadData();
                MessageBox.Show("Update successful!!");
            }
            else
            {
                MessageBox.Show("Update fail!");
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtBook.DefaultView;
            string filter = "BookName like '%" + txtFilter.Text + "%'";
            dv.RowFilter = filter;
            lbFilter.Text = "Total Price: " + dtBook.Compute("SUM(BookPrice)", filter);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport re = new frmReport();
            re.ShowDialog();
        }
    }
}
