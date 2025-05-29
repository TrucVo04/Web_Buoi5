using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Buoi5.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
