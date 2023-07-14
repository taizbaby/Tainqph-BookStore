using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface IProducerServices
    {
        public bool CreateProducer(Producer p);
        public bool DeleteProducer(Guid id);
        public bool UpdateProducer(Producer p);
        public List<Producer> GetAllProducer();
        public Producer GetProducerById(Guid id);
        public List<Producer> GetProducerByName(string name);
    }
}
