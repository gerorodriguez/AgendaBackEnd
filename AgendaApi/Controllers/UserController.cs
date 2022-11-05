using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgendaApi.Entities;
using AgendaApi.Data.Repository.Interfaces;
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
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(UserForCreationDto dto)
        {
            try
            {
                _userRepository.CreateUser(dto);
            }

            catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Created("Created", dto);
        }

     
    }
}
