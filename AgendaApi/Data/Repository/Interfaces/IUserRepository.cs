using AgendaApi.DTOs;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(UserForCreationDTO userDTO);
    }
}
