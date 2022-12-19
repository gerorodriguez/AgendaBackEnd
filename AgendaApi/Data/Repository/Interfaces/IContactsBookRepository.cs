using AgendaApi.Entities;

namespace AgendaApi.Data.Repository.Interfaces;

public interface IContactsBookRepository
{
    public ICollection<ContactsBook> GetContactsBooksByUserId(int userId);

    public ContactsBook GetContactsBookById(int contactsBookId);
    
    public void DeleteContactsBookById(int contactsBookId);

    public bool IsHaveAccess(int userId, int contactsBookId);

}