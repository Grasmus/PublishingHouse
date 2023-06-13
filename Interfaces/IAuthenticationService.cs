using PublishingHouse.DTOs;
using System.Threading.Tasks;

namespace PublishingHouse.Interfaces
{
    public interface IAuthenticationService
    {
        Task LogInAsync(UserLoginDTO userDTO);
        Task RegistrationAsync(UserRegisterDTO user);
    }
}
