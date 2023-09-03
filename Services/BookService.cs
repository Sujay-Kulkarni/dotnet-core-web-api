using my_books.Context;
using my_books.Interfaces;
using my_books.Models;
using my_books.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public void AddBook(BookVM bookVM)
        {
            Book bookObj = new()
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.IsRead ? bookVM.DateRead : null,
                Rate = bookVM.IsRead ? bookVM.Rate : null,
                Genre = bookVM.Genre,
                CoverURL = bookVM.CoverURL,
                DateAdded = DateTime.Now,
                PublisherId = bookVM.PublisherId
            };

            _context.Books.Add(bookObj);
            _context.SaveChanges();

            foreach (var id in bookVM.AuthorIds)
            {
                var _book_authors = new Book_Author()
                {
                    BookId = bookObj.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_authors);
                _context.SaveChanges();
            }
        }

        public void DeleteBookById(int bookId)
        {
            var bookObj = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (bookObj != null)
            {
                _context.Remove(bookObj);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId, BookVM bookVM)
        {
            var bookObj = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (bookObj != null)
            {
                bookObj.Title = bookVM.Title;
                bookObj.Description = bookVM.Description;
                bookObj.IsRead = bookVM.IsRead;
                bookObj.DateRead = bookVM.IsRead ? bookVM.DateRead : null;
                bookObj.Rate = bookVM.IsRead ? bookVM.Rate : null;
                bookObj.Genre = bookVM.Genre;
                bookObj.CoverURL = bookVM.CoverURL;

                _context.SaveChanges();
            }

            return bookObj;
        }
    }
}
