using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.Hashing;

public static class HashingHelper
{
    public static void CreatePasswordHash(string password,out byte[] passwordhash,out byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new();
        passwordSalt = hmac.Key;
        passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new(passwordSalt);

        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return computedHash.SequenceEqual(passwordhash);
    }
}
