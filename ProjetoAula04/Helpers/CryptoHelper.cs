using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoAula04.Helpers
{
    /// <summary>
    /// Classe para rotinas de criptografia
    /// </summary>
    public class CryptoHelper
    {
        public string SHA256Encrypt(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash from the input string
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}


