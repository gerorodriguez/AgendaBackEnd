using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data.Repository.Implementations;

public class ContactsBookRepository : IContactsBookRepository
{
    
    private readonly AgendaContext _context;
    private readonly IMapper _mapper;

    public ContactsBookRepository(AgendaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ICollection<ContactsBook> GetContactsBooksByUserId(int userId)
    {
        return _context.ContactsBooks.Where(cb => cb.Users.Any(u => u.Id == userId)).ToList();
    }

    public ContactsBook GetContactsBookById(int contactsBookId)
    {
        return _context.ContactsBooks.FirstOrDefault(cb => cb.Id == contactsBookId) ?? throw new NotFoundException();
    }

    public void DeleteContactsBookById(int contactsBookId)
    {
        throw new NotImplementedException();
    }

    public bool IsHaveAccess(int userId, int contactsBookId)
    {
        var contactsBook = _context.ContactsBooks.Include(cb => cb.Users).FirstOrDefault(cb => cb.Id == contactsBookId);

        bool userExists = false;

        if (contactsBook != null)
        {
            userExists = contactsBook.Users.Any(u => u.Id == userId);
        }

        return userExists;

    }

    public void SaveContactsBook(ContactsBook contactsBook, int userId)
    {
       
        contactsBook.Code =  DateTime.UtcNow.Ticks;
        var currentUser = _context.Users.Find(userId);
        if (currentUser == null)
        {
            throw new NotFoundException();
        };
        contactsBook.Users.Add(currentUser);
        _context.ContactsBooks.Add(contactsBook);
        _context.SaveChanges();
    }

    public void AddUserInContactsBook(long code, int userId)
    {

        ContactsBook contactsBook = _context.ContactsBooks.Include(cb => cb.Users).FirstOrDefault(cb => cb.Code == code) ??
                                    throw new NotFoundException();
        
        User newOwner = _context.Users.Find(userId);

        // Verifico si el usuario ya esta en la agenda Compartida si esta termino la ejecucion
        // Si no hago el update correspondiente
        
        bool isNewOwnerInContactsBook = contactsBook.Users.Contains(newOwner);

        if (isNewOwnerInContactsBook)
        {
            return;
        }
        
        contactsBook.Users.Add(newOwner);
        _context.ContactsBooks.Update(contactsBook);
        _context.SaveChanges();
    }
}