using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.DTOs;
using AgendaApi.Entities;


namespace AgendaApi.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AgendaContext _context;

        public UserRepository (AgendaContext context)
        {
            _context = context;
        }

        public void CreateUser(UserForCreationDTO userDTO)
        {
            User user = new User(); 
            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            _context.Add(user);
        }
    }
}
