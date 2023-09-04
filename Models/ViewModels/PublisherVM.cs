using System.Collections.Generic;

namespace my_books.Models.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherDetailsVM
    {
        public string PublisherName { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
