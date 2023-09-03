using my_books.Models;
using my_books.Models.ViewModels;
using System.Collections.Generic;

namespace my_books.Interfaces
{
    public interface IPublisherService
    {
        public void AddPulisher(PublisherVM publisherVM);
        public List<Publisher> GetAllPulishers();
        public Publisher GetPublisher(int id);
        public Publisher UpdatePublisher(int id, PublisherVM publisherVM);
        public void DeletePublisher(int id);
    }
}
