using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HotelAddInApp
{
    internal static class Hash
    {
        #region Vars
        private static HashAlgorithm _hash = MD5.Create();
        #endregion

        #region Member
        public static string Compute(string value)
        {
            return BitConverter.ToString(
                _hash.ComputeHash(
                    Encoding.Default.GetBytes(value)
                )
            ).Replace("-", "");
        }
        #endregion
    }
}
