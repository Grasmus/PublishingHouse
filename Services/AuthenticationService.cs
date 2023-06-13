using PublishingHouse.Constats;
using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.UserEntity;
using PublishingHouse.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthenticationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task LogInAsync(UserLoginDTO userDTO)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            User? user = (await userRepository.GetAsync(u => u.Login == userDTO.Login)).SingleOrDefault();

            if (user is null)
            {
                throw new Exception("Incorrect login or password");
            }

            if(!BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash))
            {
                throw new Exception("Incorrect login or password");
            }

            Application.Current.Resources["UserLogin"] = user.Login;
            Application.Current.Resources["UserRole"] = user.Role;
        }

        public async Task RegistrationAsync(UserRegisterDTO userDTO)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            if(userRepository.Any(u => u.Login == userDTO.Login))
            {
                throw new Exception("Such login already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            User newUser = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Login = userDTO.Login,
                PasswordHash = passwordHash,
                Role = UserRole.Reader.ToString(),
                CreatedDate = DateTime.UtcNow,
            };

            await userRepository.AddAsync(newUser);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
