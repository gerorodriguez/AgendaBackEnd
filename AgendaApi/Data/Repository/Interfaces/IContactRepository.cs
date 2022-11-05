using AgendaApi.Entities;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contact GetById(int id);
        public List<Contact> GetAllContactsByUserId(int userId);

        public List<Contact> FindAllByUser(int userId);

    }
}
