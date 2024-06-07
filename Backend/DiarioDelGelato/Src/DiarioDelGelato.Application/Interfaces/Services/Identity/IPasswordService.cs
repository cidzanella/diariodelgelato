using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Identity
{
    public interface IPasswordService
    {
        void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);

        bool VerifyPasswordHash(string password, string storedHash, string storedSalt);

    }
}
