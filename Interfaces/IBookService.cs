using my_books.Models;
using my_books.Models.ViewModels;
using System.Collections.Generic;

namespace my_books.Interfaces
{
    public interface IBookService
    {
        public void AddBook(BookVM bookVM);
        public List<Book> GetAllBooks();
        public Book GetBookById(int bookId);
        public Book UpdateBookById(int bookId, BookVM bookVM);
        public void DeleteBookById(int bookId);
        public BookWithAuthorVM GetBookWithAuthor(int bookId);
    }
}
