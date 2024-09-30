using SWP.KoiConsulting.Repository.Models;
using SWP.KoiConsulting.Repository;
using SWP.KoiConsulting.Service.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.KoiConsulting.Service.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Login Async 
        public async Task<UserModel?> LoginAsync(string email, string password)
        {
            var user = (await _unitOfWork.Users.GetAsync(u => u.Email == email && u.Password == password)).FirstOrDefault();
            if (user == null)
                return null;

            return new UserModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            };
        }

       

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAsync();
            return users.Select(user => new UserModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Yob = user.Yob,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            });
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Yob = user.Yob,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UserModel userModel)
        {
            var userToUpdate = await _unitOfWork.Users.GetByIdAsync(id);
            if(userToUpdate == null) return false;

            userToUpdate.FullName = userModel.FullName;
            userToUpdate.Email = userModel.Email;
            userToUpdate.Yob = userModel.Yob;
            userToUpdate.Password = userModel.Password;
            userToUpdate.PhoneNumber = userModel.PhoneNumber;
            userToUpdate.Gender = userModel.Gender;

            _unitOfWork.Users.Update(userToUpdate);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<int> InsertUserAsync(UserModel userModel)
        {
            var userEntity = new User
            {
                FullName = userModel.FullName,
                Email = userModel.Email,                
                Password = userModel.Password,
                PhoneNumber = userModel.PhoneNumber,
                Gender = userModel.Gender
            };

            await _unitOfWork.Users.InsertAsync(userEntity);
            await _unitOfWork.SaveAsync();
            return userEntity.Id;
        }

        

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if(user == null) return false;

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> UserExistAsync(int id)
        {
            return await _unitOfWork.Users.IsExist(id);
        }
    }
}
