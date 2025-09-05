using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmoHomeWork
{
    public class AdoDotNet
    {
        SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "BookLoan",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            using (SqlConnection con = new SqlConnection(sql.ConnectionString))
            {
                con.Open();
                string queryRead = @"SELECT [LoanId]
      ,[BookName]
      ,[Author]
      ,[MemberName]
      ,[MemberEmail]
      ,[Status]
      ,[Remark]
      ,[DeleteFlag]
  FROM [dbo].[book]
";
                SqlCommand cmd = new SqlCommand(queryRead, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable tb = new DataTable();
                adapter.Fill(tb);
            }
        }
        public void Create()
        {
            using (SqlConnection con = new SqlConnection(sql.ConnectionString))
            {
                con.Open();
                string queryCreate = @"INSERT INTO [dbo].[book]
           ([BookName]
           ,[Author]
           ,[MemberName]
           ,[MemberEmail]
           ,[Status]
           ,[Remark]
           ,[DeleteFlag])
     VALUES
           ('To Kill a MockingBird',
		   'Harper Lee',
		   'Ethan',
		   'ethan@gmail.com',
		   'Borrowed',
		   'New Member',
		   0);";

                SqlCommand cmd = new SqlCommand(@queryCreate, con);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Saving Successful" : "Saving Failed";
                Console.WriteLine(message);
            }
        }
        public void Update()
        {
            using (SqlConnection con = new SqlConnection(sql.ConnectionString))
            {
                con.Open();
                string queryUpdate = @"UPDATE [dbo].[book]
   SET[Remark] = 'Regular Customer'
      
 WHERE [LoanId] = 2";

                SqlCommand cmd = new SqlCommand(queryUpdate, con);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Update Successful" : "Upate Failed";
                Console.WriteLine(message);
            }
        }
        public void Delete()
        {
            using (SqlConnection con = new SqlConnection(sql.ConnectionString))
            {
                con.Open();
                string queryDelete = @"UPDATE [dbo].[book]
   SET[DeleteFlag] = 'Regular Customer'
      
 WHERE [LoanId] = 5";

                SqlCommand cmd = new SqlCommand(queryDelete, con);
                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Delete Successful" : " Delete Failed";
                Console.WriteLine(message);
            }
        }
    }

}
