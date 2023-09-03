using System.Collections.Generic;

namespace my_books.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Navigation property
        public List<Book> Book { get; set; }
    }
}
