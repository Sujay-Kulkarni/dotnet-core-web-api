using my_books.Context;
using my_books.Interfaces;
using my_books.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _context;
        public AuthorService(LibraryContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM authorVM)
        {
            Author author = new()
            {
                FullName = authorVM.FullName
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                _context.Remove(author);
                _context.SaveChanges();
            }
        }

        public List<Author> GetAllAuthor() => _context.Authors.ToList();
        public Author GetAuthor(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

        public Author UpdateAuthor(int id, AuthorVM authorVM)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                author.FullName = authorVM.FullName;
                _context.SaveChanges();
            }
            return author;
        }
    }
}
