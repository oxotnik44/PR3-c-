using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPasword
{
    public class Hash
    {
        public string Hashing(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                byte[] hashSourceBytePassword = sha256Hash.ComputeHash(sourceBytePassword);
                string hashPassword = BitConverter.ToString(hashSourceBytePassword).Replace("-", String.Empty);
                return hashPassword;
            }
        }
    }
}
