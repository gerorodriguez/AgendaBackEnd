using System.Security.Claims;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
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
        public ContactRepository (AgendaContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
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

        public void Create(CreateContactDto dto)
        {
            _context.Contacts.Add(_mapper.Map<Contact>(dto));
        }

        public void Update(UpdateContactDto dto)
        {
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
        }
    }
    
}
