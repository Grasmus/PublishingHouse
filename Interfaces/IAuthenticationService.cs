using PublishingHouse.DTOs;
using System.Threading.Tasks;

namespace PublishingHouse.Interfaces
{
    public interface IAuthenticationService
    {
        void LogIn(UserLoginDTO userDTO);
        Task RegistrationAsync(UserRegisterDTO user);
    }
}
