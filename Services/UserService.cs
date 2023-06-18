using PublishingHouse.Constats;
using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.UserEntity;
using PublishingHouse.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByLogin(string login)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            if (login is null)
            {
                throw new Exception("Login is null");
            }

            User user = userRepository.GetByLogin(login);

            if (user is null) 
            {
                throw new Exception("No user found");
            }

            return user;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            User user = GetCurrentUser();

            if (userDTO.Login != user.Login)
            {
                if (LoginExists(userDTO.Login))
                {
                    throw new Exception("Such login already exists");
                }
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Login = userDTO.Login;

            userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();
        }

        private bool LoginExists(string login) 
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            return userRepository.Any(u => u.Login == login);
        }

        public async Task DeleteUserAsync(string login) 
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            User user = userRepository.GetByLoginWithOrders(login);

            if (user == null) 
            {
                throw new Exception("User not found");
            }

            if(!CanUserBeDeleted(user))
            {
                throw new Exception("User cannot be deleted. There are unpaid orders");
            }

            if(user.Orders != null) 
            {
                foreach (var order in user.Orders)
                {
                    order.UserId = 0;
                }
            }

            userRepository.Remove(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCurrentUserAsync()
        {
            UserRepository userRepository = _unitOfWork.UserRepository;
            OrderRepository orderRepository = _unitOfWork.OrderRepository;

            User user = GetCurrentUserWithOrders();

            if (!CanUserBeDeleted(user))
            {
                throw new Exception("User cannot be deleted. There are unpaid orders");
            }

            if (user.Orders != null && user.Orders.Count != 0)
            {
                foreach (var order in user.Orders)
                {
                    order.UserId = null;

                    orderRepository.Update(order);
                }

                user.Orders.Clear();
            }

            userRepository.Remove(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public User GetCurrentUser()
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            string? userLogin = Application.Current.Resources["UserLogin"] as string;

            if (userLogin == null) 
            {
                throw new Exception("No user is authorized");
            }

            User user = userRepository.GetByLogin(userLogin);

            if(user == null)
            {
                throw new Exception("No user exists with such login");
            }

            return user;
        }

        public List<User> GetReaders()
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            List<User> readers = userRepository.GetReaders();

            return readers;
        }

        public async Task<User> BlockUserAsync(int userId)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            User user = userRepository.GetById(userId);

            if(user == null ) 
            {
                throw new Exception("User not found");
            }

            user.IsBlacklisted = true;

            userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User> UnblockUserAsync(int userId)
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            User user = userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.IsBlacklisted = false;

            userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        private User GetCurrentUserWithOrders()
        {
            UserRepository userRepository = _unitOfWork.UserRepository;

            string? userLogin = Application.Current.Resources["UserLogin"] as string;

            if (userLogin == null)
            {
                throw new Exception("No user is authorized");
            }

            User user = userRepository.GetByLoginWithOrders(userLogin);

            if (user == null)
            {
                throw new Exception("No user exists with such login");
            }

            return user;
        }

        private bool CanUserBeDeleted(User user)
        {
            if(user.IsBlacklisted)
            {
                return false;
            }

            if(user.Orders == null)
            {
                return true;
            }

            foreach(var order in user.Orders) 
            {
                if(order.Status == OrderStatus.NotPaid.ToString()) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
