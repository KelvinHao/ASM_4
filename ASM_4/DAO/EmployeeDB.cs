using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ASM_4.DAO
{
    public class EmployeeDB
    {
        string strConnection;
        public EmployeeDB()
        {
            getConnectionString();

        }
        public string getConnectionString()
        {
            strConnection = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
            return strConnection;
        }
        public bool UpdateEmployeePassword(Employee e)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Update Employee set EmpPassword=@pass where EmpID=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", e.EmpID);
            cmd.Parameters.AddWithValue("@pass", e.EmpPass);

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);

            }
            finally { cnn.Close(); }
            return result;
        }

        public Employee Login(string ID, string PWD)
        {

            SqlDataReader reader;
            Employee em = null;
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Select * from Employee where EmpID=@id and EmpPassword=@pass";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@pass", PWD);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string id = (string)reader["EmpID"];
                    string pwd = (string)reader["EmpPassword"];
                    Boolean role = (Boolean)reader["EmpRole"];
                    em = new Employee
                    {
                        EmpID = id,
                        EmpPass = pwd,
                        EmpRole = role
                    };
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);

            }
            finally { cnn.Close(); }
            return em;
        }

    }
}
