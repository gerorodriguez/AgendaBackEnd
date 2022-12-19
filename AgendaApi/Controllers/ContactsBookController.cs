using System.Security.Claims;
using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Exceptions;
using AgendaApi.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactsBookController : ControllerBase
{
    private IContactsBookRepository _contactsBookRepository;
    private readonly IMapper _mapper;

    public ContactsBookController(IContactsBookRepository contactsBookRepository, IMapper mapper)
    {
        _contactsBookRepository = contactsBookRepository;
        _mapper = mapper;
    }
    
    [HttpGet("{contactsBookId:int}")]
    public IActionResult GetContactsBookById(int contactsBookId)
    {
        try
        {
            return Ok(_mapper.Map<ContactsBookDto>(_contactsBookRepository.GetContactsBookById(contactsBookId)));
        }
        catch (NotFoundException notFoundException)
        {
            return NotFound($"contacts book with id = {contactsBookId} not found");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("user/{userId:int}")]
    public IActionResult GetContactsBooksByUserId(int userId)
    {
        try
        {
            var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (userId == null)
            {
                return BadRequest("User id not found");
            }

            if (userId != currentUserId)
            {
                return Forbid();
            }

            var contactsBooks = _contactsBookRepository.GetContactsBooksByUserId(userId);

            if (contactsBooks.Count == 0)
            {
                return Ok(new List<ContactsBookDto>());
            }

            var contactsBookDtos = _mapper.Map<ICollection<ContactsBook>, ICollection<ContactsBookDto>>(contactsBooks);

            return Ok(contactsBookDtos);
        }
        catch
        {
            return BadRequest();
        }
    }
}