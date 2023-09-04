using my_books.Context;
using my_books.Interfaces;
using my_books.Models;
using my_books.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly LibraryContext _context;
        public PublisherService(LibraryContext context)
        {
            _context = context;
        }
        public void AddPulisher(PublisherVM publisherVM)
        {
            _context.Publishers.Add(new Publisher() { Name = publisherVM.Name });
            _context.SaveChanges();
        }

        public void DeletePublisher(int id)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher != null)
            {
                _context.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public List<Publisher> GetAllPulishers() => _context.Publishers.ToList();

        public Publisher GetPublisher(int id) => _context.Publishers.FirstOrDefault(p => p.Id == id);

        public PublisherDetailsVM GetPublisherDetails(int id)
        {
            var publisherDetails = _context.Publishers.Where(p => p.Id == id)
                                   .Select(publisher => new PublisherDetailsVM()
                                   {
                                       PublisherName = publisher.Name,
                                       BookAuthors = publisher.Book.Select(books => new BookAuthorVM()
                                       {
                                           BookName = books.Title,
                                           BookAuthors = books.Book_Authors.Select(author => author.Author.FullName).ToList()
                                       }).ToList()
                                   }).FirstOrDefault();

            return publisherDetails;
        }

        public Publisher UpdatePublisher(int id, PublisherVM publisherVM)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher != null)
            {
                publisher.Name = publisherVM.Name;
                _context.SaveChanges();
            }
            return publisher;
        }
    }
}
