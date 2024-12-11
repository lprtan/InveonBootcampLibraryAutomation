using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; } 

        public string? Title { get; set; } 
        public string? Author { get; set; } 
        public int PublicationYear { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }
        public string? Publisher { get; set; }
        public int PageCount { get; set; }
        public string? Language { get; set; }
        public string? Summary { get; set; }
        public int LanguageableCopies { get; set; }
    }
}
