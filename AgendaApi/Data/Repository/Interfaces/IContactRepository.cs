using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contact GetById(int id);
        public List<Contact> GetAllContactsByUserId(int userId);

        public List<Contact> FindAllByUser(int userId);
        public void Create(CreateContactDto dto);
        public void Update(UpdateContactDto dto);
        public void Delete(int id);

    }
}
