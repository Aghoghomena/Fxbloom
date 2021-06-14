using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FXBLOOM.SharedKernel
{
    public static class Utility
    {
        public static readonly int DefaultPageSize = 20;
        public static readonly int DefaultPageNumber = 1;
        public static readonly int MaxPageSize = 100;

        public static byte[] Hash512(string s)
        {
            HashAlgorithm Hasher = new SHA512CryptoServiceProvider();
            var strBytes = Encoding.UTF8.GetBytes(s);
            var strHash = Hasher.ComputeHash(strBytes);
            return strHash;
        }
    }
}
