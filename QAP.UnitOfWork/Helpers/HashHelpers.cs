using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.Json;

namespace QAP.UnitOfWork.Helpers
{
    public static class HashHelpers
    {
        public static byte[] GetSHA256(byte[] source)
        {
            using var sha256 = SHA256.Create();

            return sha256.ComputeHash(source);
        }

        public static bool CompareSHA256(byte[] actual, byte[] expected)
        {
            if (actual.Length != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < actual.Length; ++i)
            {
                if (actual[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
