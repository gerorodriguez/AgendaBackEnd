using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contact GetById(int id);

        public ICollection<Contact> GetContactsByContactsBookId(int contactsBookId);
        // public List<Contact> GetAllContactsByUserId(int userId);
        //
        // public List<Contact> FindAllByUser(int userId);
        // public void Create(CreateContactDto dto, int userId);
        public void Update(Contact contact);
        public void Delete(int id);

        // public bool IsExistsContact(int id);

    }
}
