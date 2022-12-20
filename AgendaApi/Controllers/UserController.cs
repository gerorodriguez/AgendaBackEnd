using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgendaApi.Entities;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Exceptions;
using AgendaApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private IUserRepository _userRepository { get; set; }

        private readonly IContactsBookRepository _contactsBookRepository;
        public UserController(IUserRepository userRepository, IContactsBookRepository contactsBookRepository)
        {
            _userRepository = userRepository;
            _contactsBookRepository = contactsBookRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(UserForCreationDto dto)
        {
            try
            {
                _userRepository.CreateUser(dto);
                int lastUserId = _userRepository.GetLastUserId();

                ContactsBook contactsBook = new ContactsBook();
                _contactsBookRepository.SaveContactsBook(contactsBook, lastUserId);
            }

            catch (NotFoundException ex)
            {
                return NotFound();
            }

            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Created("Created", dto);
        }

     
    }
}
