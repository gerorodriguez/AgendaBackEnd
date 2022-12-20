using AgendaApi.Entities;
using AgendaApi.Models.DTOs;

namespace AgendaApi.Data.Repository.Interfaces;

public interface IContactsBookRepository
{
    public ICollection<ContactsBook> GetContactsBooksByUserId(int userId);

    public ContactsBook GetContactsBookById(int contactsBookId);
    
    public void DeleteContactsBookById(int contactsBookId);

    public bool IsHaveAccess(int userId, int contactsBookId);

    public void SaveContactsBook(ContactsBook contactsBook, int userId);

    public void AddUserInContactsBook(long code, int userId);

    public void updateNameContactsBook(int contactsBookId, string name);

}