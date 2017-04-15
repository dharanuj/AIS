using System;
using AIS.Database;
using AIS.Entity;

namespace AIS.BL
{
    public class UserValidation
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public bool ValidateUser(string username, string password)
        {
            try
            {
                return _userRepo.ValidateUser(username, password);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                return _userRepo.CreateUser(user);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
