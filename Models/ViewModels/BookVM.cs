using System;
using System.Collections.Generic;

namespace my_books.Models.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverURL { get; set; }
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
