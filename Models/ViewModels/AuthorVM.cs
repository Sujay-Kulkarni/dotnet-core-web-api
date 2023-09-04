using System.Collections.Generic;

namespace my_books.Models.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBookVM
    {
        public string FullName { get; set; }
        public List<string> Books { get; set; }
    }
}
