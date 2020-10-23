using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASM_4.DAO
{
    public class BookDB
    {
        string strConnection;

        public BookDB()
        {
            getConnectionString();
        }
        public string getConnectionString()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            return strConnection;
        }
        public DataTable getBooks()
        {
            string sql = "select * from Books";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBook);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBook;
        }

        public bool addNewBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Insert Books values(@Name,@Price)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool updateBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "update Books set BookName=@Name, " +
                "BookPrice=@Price " +
                "where BookName=@Name";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool deleteBook(string BookName)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "delete Books Where BookName=@Name";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", BookName);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
