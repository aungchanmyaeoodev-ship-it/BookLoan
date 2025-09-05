using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ConsoleApp
{
    [Table("book")]
    public class BookList
    {
        [Key]
        public int LoanId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string Status { get; set; }
        public string? Remark { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
