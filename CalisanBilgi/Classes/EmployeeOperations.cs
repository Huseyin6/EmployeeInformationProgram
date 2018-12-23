using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanBilgi.Classes
{
#region "Base Class(Include properties)"
        abstract class EmployeeProperties
        {
        public int registrationNumber;
        public string name;
        public string surname;
        public string mailAddress;
        public string phoneNumber;
        public string homePhoneNumber;
        public int departmanId;
        public int sex;
        public DateTime startingDate;
        public DateTime endingDate;
        }
    #endregion
#region "Operations Class"
    class EmployeeOperations : EmployeeProperties
    {

        enum Operations
        {
            addUser = 1,
            deleteUser,
            editUser,
            informationUser
        }
        public DataTable GetEmployeeTable()
        {
        /// You can use Store Procedure instead of sql string. 
            string sqlQuery = "select e.EmpName,e.EmpSurname,replace(e.Sex,1,'Male') As Sex,e.MailAddress,d.DepartmanName,p.PhoneNumber,p.ExtansionNumber,e.StartedDate,e.EndedDate " +
                "from Employees e,Departmans d, PhoneNumbers p " +
                "where e.DepartmanId = d.DepartmanId and e.RegistrationNumber = p.RegistrationNumber ";
            return SQLOperations.GetDatatable(sqlQuery);
        }
    }
    #endregion
#region "Database Operations Class"
    class SQLOperations
    {
        private static SqlConnection GetSqlConnection()
        {   
            /// You can write own sql connection string. xxxxxx= your computer sql name 
            SqlConnection conn = new SqlConnection("Data Source=xxxxx; Initial Catalog=EmployeeDB; Integrated Security=True;");
            conn.Open();
            return conn;
        } 
        public static object ExecuteScalar(string sqlString)
        {
            SqlCommand command = new SqlCommand(sqlString, GetSqlConnection());
            return command.ExecuteScalar();
        }
        public void ExecuteNonQuery(string sqlString)
        {
            SqlCommand command = new SqlCommand(sqlString,GetSqlConnection());
            command.ExecuteNonQuery();
        }
        public static DataTable GetDatatable(string sqlString) {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlString,GetSqlConnection());
            adapter.Fill(ds);
            return ds.Tables[0];
        }

    }
#endregion
}
