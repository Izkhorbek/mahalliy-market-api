using System;
using System.Security.Cryptography;
using System.Text;

namespace MahalliyMarket.CommonUtils
{
      // Provides methods for creating and verifying password hashes using HMACSHMA512
      public static class PasswordHasher
      {
            // Creates a hashed version of the provided password along with a unique salt;
            // password: The plainText password to be hashed
            // passwordHash : Outputs the resulting password has as a byte array
            // passswordSalt: Outputs the unique salt used in hashing as a byte array

            public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                  //Instantiate HMACSHA512 to generate a scyptographic hash and a unique key (salt)
                  // The 'using' statement ensures that the HMACSHA512 instance is disposed of correctly after use

                  using (var hmac = new HMACSHA512())
                  {
                        // The Key property of HMACSHA512 provides a randomly generated salt.
                        passwordSalt = hmac.Key; // Assign the generated salt to the output parameter

                        //Convert the plaintext password into a byte array using UTF-8 encoding
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                        //Compute the hash of the password bytes using the HMACSHA512 instance.
                        passwordHash = hmac.ComputeHash(passwordBytes); // Assign the computed hash to the output parameter
                  }
            }

            public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
            {
                  // Instantiate HMACSHA512 with the stored salt as the key to ensure the same hashing parameters
                  // The 'using' statement ensures that the HMACSHA512 instance is disposed of correctly after use.
                  using (var hmac = new HMACSHA512(storedSalt))
                  {
                        // Convert the plaintext password into a byte array using UTF-8 encoding.
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        // Compute the hash of the password bytes using the HMACSHA512 instance initialized with the stored salt.
                        byte[] computedHash = hmac.ComputeHash(passwordBytes);
                        // Compare the computed hash with the stored hash byte by byte.
                        // SequenceEqual ensures that both byte arrays are identical in sequence and value.
                        bool hashesMatch = computedHash.SequenceEqual(storedHash);
                        // Return the result of the comparison.
                        return hashesMatch;
                  }
            }
      }
}