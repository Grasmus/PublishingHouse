using PublishingHouse.DTOs;
using PublishingHouse.Models.UserEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublishingHouse.Interfaces
{
    public interface IUserService
    {
        User GetUserByLogin(string login);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(string login);
        Task DeleteCurrentUserAsync();
        User GetCurrentUser();
        List<User> GetReaders();
        Task<User> BlockUserAsync(int userId);
        Task<User> UnblockUserAsync(int userId);
    }
}
