using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamerasDb.Model
{
    public interface IEncrypt
    {
        Task<string> HashPassword(string password, string salt);
        Task<bool> VerifyPassword(string enteredPassword, string storedHash, string storedSalt);
    }
}
