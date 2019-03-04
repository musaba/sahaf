using Bussiness.Helpers;
using Entity.Models;
using Sahaf.Entity.Contexts;
using System;
using System.Linq;
using System.Text;

namespace Bussiness.Services
{
    public interface IUserService
    {
        User Authenticate(string Email, string password);
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private SahafContext _context;

        public UserService(SahafContext context)
        {
            _context = context;
        }

        public User Authenticate(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Name == Email);

            // check if Email exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, Encoding.ASCII.GetBytes(user.PasswordHash), Encoding.ASCII.GetBytes(user.PasswordSalt)))
                return null;

            // authentication successful
            return user;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Name == user.Name))
                throw new AppException("Email \"" + user.Name + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = Encoding.ASCII.GetString(passwordHash);
            user.PasswordSalt = Encoding.ASCII.GetString(passwordSalt);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        //İNCELE!!!!!
        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Name != user.Name)
            {
                // Email has changed so check if the new Email is already taken
                if (_context.Users.Any(x => x.Name == userParam.Name))
                    throw new AppException("Email " + userParam.Name + " is already taken");
            }

            // update user properties
            user.Name = userParam.Name;
            user.Surname = userParam.Surname;
            user.Name = userParam.Name;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = Encoding.ASCII.GetString(passwordHash);
                user.PasswordSalt = Encoding.ASCII.GetString(passwordSalt);
            }

           // _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}