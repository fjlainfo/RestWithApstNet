using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithApstNet.Model
{
    public class Book
    {
        [Key]
        public String Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal price { get; set; }
        public DateTime LauncheDate { get; set; }
    }
}
