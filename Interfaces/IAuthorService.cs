using my_books.Models.ViewModels;
using System.Collections.Generic;

namespace my_books.Interfaces
{
    public interface IAuthorService
    {
        public void AddAuthor(AuthorVM authorVM);
        public List<Author> GetAllAuthor();
        public Author GetAuthor(int id);
        public Author UpdateAuthor(int id, AuthorVM authorVM);
        public void DeleteAuthor(int id);
    }
}
