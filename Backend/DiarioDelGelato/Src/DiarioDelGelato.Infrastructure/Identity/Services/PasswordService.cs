using DiarioDelGelato.Application.Interfaces.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiarioDelGelato.Infrastructure.Identity.Services
{
    public class PasswordService : IPasswordService
    {
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            // validate if password is null or empty
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password cannot be null or empty.", nameof(password));

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            // validate if password is null or empty
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password cannot be null or empty.", nameof(password));
            // validate storedHash size
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
            // validate storedSalt size
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));

            using (var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt)))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(Convert.FromBase64String(storedHash));
            }   
        }
    }
}
