using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Pbkdf2;

namespace CamerasDb.Model
{
    public class Encrypt : IEncrypt
    {
        string res = "";
        public async Task<string> HashPassword(string password, string salt)
        {          
            await Task.Run(() =>
            {
                res = Convert.ToBase64String(Pbkdf2.Pbkdf2.HashData("SHA512", Encoding.ASCII.GetBytes(password), Encoding.ASCII.GetBytes(salt), 350000, 64));
            });         
            return res;
        }

        public async Task<bool> VerifyPassword(string enteredPassword, string hashPassword, string hashSalt)
        {
            await Task.Run(() =>
            {
                res = Convert.ToBase64String(Pbkdf2.Pbkdf2.HashData("SHA512", Encoding.ASCII.GetBytes(enteredPassword), Encoding.ASCII.GetBytes(hashSalt), 350000, 64));

            });
            return res == hashPassword;
        }        
    }
}
