using System.Security.Claims;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Exceptions;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace AgendaApi.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.SingleOrDefault(c => c.Id == id) ?? throw new NotFoundException();
        }

        public ICollection<Contact> GetContactsByContactsBookId(int contactsBookId)
        {
            // var contactsBook = _context.ContactsBooks.FirstOrDefault(cb => cb.Id == contactsBookId) ??
            //                    throw new NotFoundException();

            return _context.Contacts.Where(c => c.ContactsBookId == contactsBookId).ToList();
        }
        // public List<Contact> GetAllContactsByUserId(int userId)
        // {
        //     return _context.Contacts.Where(c => c.UserId == userId).ToList();
        // }
        //
        // public List<Contact> FindAllByUser(int userId)
        // {
        //     return _context.Contacts.Where(c => c.UserId == userId).ToList();
        // }
        //
        public void Create(CreateContactDto dto)
        {
            var c = _mapper.Map<Contact>(dto);
            _context.Contacts.Add(c);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }

        public bool IsExistsContact(int id)
        {
            return (_context.Contacts.Any(c => c.Id.Equals(id)));
        }
    }
}