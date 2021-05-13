using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSotrAPIwithMVC.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public bool Available { get; set; }
    }
}
