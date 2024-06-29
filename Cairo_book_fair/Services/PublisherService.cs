using Cairo_book_fair.Models;
using Cairo_book_fair.Repositories;

namespace Cairo_book_fair.Services
{
    public class PublisherServicem : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherServicem(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public void Delete(Publisher item)
        {
            publisherRepository.Delete(item);
        }

        public Publisher Get(int id)
        {
            return publisherRepository.Get(id);
        }

        public List<Publisher> Get(Func<Publisher, bool> where)
        {
            return publisherRepository.Get(where);
        }

        public List<Publisher> GetAll(string include = null)
        {
            return publisherRepository.GetAll(include);
        }

        public void Insert(Publisher item)
        {
            publisherRepository.Insert(item);
        }

        public void Save()
        {
            publisherRepository.Save();
        }

        public void Update(Publisher item)
        {
            publisherRepository.Update(item);
        }
    }
}
