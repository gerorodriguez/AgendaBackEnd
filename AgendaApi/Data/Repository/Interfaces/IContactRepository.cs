using AgendaApi.Entities;
using AgendaApi.Models;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contact GetById(int id);
        public List<Contact> GetAllContactsByUserId(int userId);

        public List<Contact> FindAllByUser(int userId);
        public void Create(CreateAndUpdateContact dto);
        public void Update(CreateAndUpdateContact dto);
        public void Delete(int id);

    }
}
