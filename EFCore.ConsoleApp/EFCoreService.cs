using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ConsoleApp
{
    public class EFCoreService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BookList> lst = db.BookList.ToList();

            foreach (BookList book in lst)
            {
                Console.WriteLine($"{book.BookName} - {book.MemberName}");
            }
        }
        public void Create()
        {
            AppDbContext app = new AppDbContext();
            BookList book = new BookList()
            {
                BookName = "Pride and Prejudice",
                Author = "Jane Austen",
                MemberName = "Liam",
                MemberEmail = "liam@gmail.com",
                Status = "Borrowed",
                Remark = "Late Return"
            };
            app.BookList.Add(book);
            int result = app.SaveChanges();
            Console.WriteLine(result > 0 ? "New Record Added" : "Failed to Add New Record");

        }
        public void Update()
        {
            AppDbContext app = new AppDbContext();
            BookList? editbook = app.BookList.Where(x=> x.BookName == "Harry Potter").FirstOrDefault();
            if (editbook != null)
            {
                editbook.Status="Returned";
                app.SaveChanges();
            }
        }
        public void Delete()
        {
            AppDbContext app = new AppDbContext();
            BookList? editbook = app.BookList.Where(x => x.BookName == "1984").FirstOrDefault();
            if(editbook != null)
            {
                editbook.DeleteFlag = true;
                app.SaveChanges();
            }
        }
    }
}
