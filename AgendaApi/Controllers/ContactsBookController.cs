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
    
    [HttpGet]
    public IActionResult GetContactsBooksByUserId()
    {
        try
        {
            var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            // if (userId == null)
            // {
            //     return Unauthorized();
            // }

            // if (userId != currentUserId)
            // {
            //     return Forbid();
            // }

            var contactsBooks = _contactsBookRepository.GetContactsBooksByUserId(currentUserId);

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

    
    [HttpPut]
    public IActionResult updateNameContactsBook(int contactsBookId, string name)
    {
        try
        {
            _contactsBookRepository.updateNameContactsBook(contactsBookId, name);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound($"ContactsBook with Id = {contactsBookId} not found");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Por request param "url"?code=14353225
    [HttpPut("share")]
    public IActionResult AddUserInContactsBook(long code)
    {
        try
        {
            var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (currentUserId == null)
            {
                return Unauthorized();
            }

            _contactsBookRepository.AddUserInContactsBook(code, currentUserId);

            return Ok();

        }
        
        catch (NotFoundException ex)
        {
            return NotFound($"Contacts book with code = {code} not exists");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateContactsBook(CreateContactsBookDto createContactsBookDto)
    {
        try
        {
            var currentUserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var contactsBook = _mapper.Map<ContactsBook>(createContactsBookDto);

            _contactsBookRepository.SaveContactsBook(contactsBook, currentUserId);

            return Ok();
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
       
    }
}