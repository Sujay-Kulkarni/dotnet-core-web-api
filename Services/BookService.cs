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
        public BookWithAuthorVM AddBook(BookVM bookVM)
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

            return GetBookWithAuthor(bookObj.Id);
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

        public List<Book> GetAllBooks() => _context.Books.Where(b => b.Id == 0).ToList();
        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public BookWithAuthorVM GetBookWithAuthor(int bookId)
        {
            var bookWithAuthor = _context.Books.Where(b => b.Id == bookId)
                .Select(book => new BookWithAuthorVM()
                {
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead : null,
                    Rate = book.IsRead ? book.Rate : null,
                    Genre = book.Genre,
                    CoverURL = book.CoverURL,
                    PublisherName = book.Publisher.Name,
                    Authors = book.Book_Authors.Select(a => a.Author.FullName).ToList()
                }).FirstOrDefault();

            return bookWithAuthor;
        }

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
                bookObj.PublisherId = bookVM.PublisherId;

                _context.SaveChanges();
            }

            return bookObj;
        }
    }
}
