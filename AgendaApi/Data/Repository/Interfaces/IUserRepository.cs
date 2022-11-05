using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Models.DTOs;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(UserForCreationDto userDto);
        public User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}
