using System.Security.Claims;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Exceptions;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        private readonly IContactsBookRepository _contactsBookRepository;

        private readonly IMapper _mapper;

        public ContactController(IContactRepository contactRepository, IContactsBookRepository contactsBookRepository,
            IMapper autoMapper)
        {
            _contactRepository = contactRepository;
            _contactsBookRepository = contactsBookRepository;
            _mapper = autoMapper;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_contactRepository.GetById(id));
            }
            catch (NotFoundException notFoundException)
            {
                return NotFound($"Contact with id {id} not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [HttpGet]
        // [Authorize]
        // [Route("all")]
        // public IActionResult GetAllByUser()
        // {
        //     var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //     var contacts = _contactRepository.FindAllByUser(currentUserId);
        //     return Ok(contacts);
        // }
        //
        //
        // [HttpPost]
        // public IActionResult CreateContact(CreateContactDto createContactDto)
        // {
        //     var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //    
        //     try
        //     {
        //         _contactRepository.Create(createContactDto,currentUserId);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //     return Created("Created", createContactDto);
        // }

        [HttpGet("ContactsBook/{contactsBookId:int}")]
        public IActionResult GetContactsByContactsBookId(int contactsBookId)
        {
            try
            {
                var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                bool isHaveAccess = _contactsBookRepository.IsHaveAccess(currentUserId, contactsBookId);

                if (!isHaveAccess)
                {
                    return Unauthorized();
                }

                var contacts = _contactRepository.GetContactsByContactsBookId(contactsBookId);

                return Ok(contacts.Count == 0
                    ? new List<ContactDto>()
                    : _mapper.Map<ICollection<Contact>, ICollection<ContactDto>>(contacts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, UpdateContactDto dto)
        {
            try
            {
        
                if (!dto.Id.Equals(id))
                {
                    return BadRequest();
                }

                if (!(_contactRepository.IsExistsContact(id)))
                {
                    return NotFound();
                }
                
                var contact = _mapper.Map<Contact>(dto);
                
                _contactRepository.Update(contact);

                var updatedContact = _contactRepository.GetById(id);
        
                return Ok(_mapper.Map<ContactDto>(updatedContact));
        
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteContactById (int id)
        {
            try
            {
                var contactToDelete =  _contactRepository.GetById(id);
        
                if (contactToDelete == null)
                {
                    return NotFound($"Contact with Id = {id} not found");
                }
                _contactRepository.Delete(id);
                return Ok("contact deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}