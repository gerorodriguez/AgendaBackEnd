using System.Security.Claims;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        public ContactRepository (AgendaContext context)
        {
            _context = context;
        }

        public Contact GetById(int id)
        {
           return _context.Contacts.SingleOrDefault(c => c.Id == id);
        }
        public List<Contact> GetAllContactsByUserId(int userId)
        {
            return _context.Contacts.Where(c => c.UserId == userId).ToList();
        }

        public List<Contact> FindAllByUser(int userId)
        {
            return _context.Contacts.Where(c => c.UserId == userId).ToList();
        }
    }
    
}
