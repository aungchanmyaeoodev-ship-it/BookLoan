using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.ConsoleApp
{
    public class DapperService
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
            using IDbConnection db = new SqlConnection(sql.ConnectionString);
            db.Open();
            List<BookList> list = db.Query<BookList>("select * from book where DeleteFlag = 0").ToList();
            foreach (BookList book in list)
            {
                Console.WriteLine($"{book.BookName} - {book.Author} - {book.MemberName} - {book.Status}");
            }
        }
        public void Create()
        {
            using IDbConnection db = new SqlConnection(sql.ConnectionString);
            db.Open();
            int result = db.Execute(@"INSERT INTO [dbo].[book] (BookName, Author, MemberName, MemberEmail, Status, Remark, DeleteFlag)
VALUES ('The Great Gatsby', 'F. Scott Fitzgerald', 'Sophia', 'sophia@mail.com', 'Borrowed', 'VIP member', 0);
");
            Console.WriteLine(result > 0 ? "Successfully Created" : "Failed to Create");
        }
        public void Update()
        {
            using IDbConnection db = new SqlConnection(sql.ConnectionString);
            db.Open();
            int result = db.Execute(@"UPDATE [dbo].[book]
SET Remark = 'Extended loan period'
WHERE LoanId = 4;
");
            Console.WriteLine(result > 0 ? "Update Successful" : "Update Failed");
        }
        public void Delete() {
            using IDbConnection db = new SqlConnection(sql.ConnectionString);
            db.Open();
            int result = db.Execute(@"UPDATE [dbo].[book]
SET DeleteFlag = 0
WHERE LoanId = 1;
");
            Console.WriteLine(result > 0 ? "Successfully Deleted" : "Failed to Delete");

        }
    }
}
