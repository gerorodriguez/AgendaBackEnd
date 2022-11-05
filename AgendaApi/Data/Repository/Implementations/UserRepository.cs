using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;


namespace AgendaApi.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaContext _context;

        public UserRepository(AgendaContext context)
        {
            _context = context;
        }

        public void CreateUser(UserForCreationDto userDTO)
        {
            User user = new User();
            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            _context.Add(user);
            _context.SaveChanges();
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(u =>
                u.UserName == authRequestBody.UserName && u.Password == authRequestBody.Password);
        }
    }
}