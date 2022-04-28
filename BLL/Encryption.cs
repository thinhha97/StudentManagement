using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public static class Encryption
    {
        /// <summary>
        /// Encrypt a string that cannot be later decrypt.
        /// </summary>
        /// <param name="_input">String to encrypt.</param>
        /// <returns>Encrypted string.</returns>
        public static string Encrypt(string _input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, _input);
                return CustomEncrypt(hash);
            }
        }
        /// <summary>
        /// Encrypt a string that can be decrypt later.
        /// </summary>
        /// <param name="_input">String to encrypt.</param>
        /// <returns>Encrypted string.</returns>
        public static string CustomEncrypt(string _input)
        {
            // Formula: abc -> 48+0+(49%2); 49+1+(50%2); 50+2

            // Convert input string into char array.
            char[] chars = _input.ToCharArray();
            // Select val + ind -> anonymous type
            var input_withIndex = chars.Select((val, ind) => new { val, ind }).ToArray();
            // Apply formula
            var char_input_encrypted = input_withIndex.Select(c => c.val + c.ind + (input_withIndex.Length > c.ind + 1 ? input_withIndex[c.ind + 1].val % 2 : 0)).Select(c => (char)c).ToArray();
            // Return encrypted char array as string
            string encrypted =  new string(char_input_encrypted);
            return ReverseString(encrypted);
        }
        private static string ReverseString(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }



        /// <summary>
        /// Decrypt a decryptable-encrypted string.
        /// </summary>
        /// <param name="input">String to decrypt.</param>
        /// <returns>Original String.</returns>
        public static string Decrypt(string input)
        {
            input = ReverseString(input);
            char[] char_input = input.ToCharArray();
            for (int i = char_input.Length - 1; i >= 0; i--)
            {
                char_input[i] = (char)(char_input[i] - i - (i == char_input.Length - 1 ? 0 : char_input[i + 1] % 2));
            }
            return new string(char_input);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new StringBuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
