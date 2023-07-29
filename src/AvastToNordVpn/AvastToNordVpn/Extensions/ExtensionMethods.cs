using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using AvastToNordVpn.Models;

namespace AvastToNordVpn.Extensions
{
    static class ExtensionMethods
    {
        /// <summary>
        /// format of NordVpn pw is:
        ///     name
        ///     url
        ///     username
        ///     password
        ///     note
        ///     cardholdername  // unused
        ///     cardnumber      // unused
        ///     cvc             // unused
        ///     expirydate      // unused
        ///     zipcode         // unused
        ///     folder          // unused
        ///     full_name       // unused
        ///     phone_number    // unused
        ///     email           // unused
        ///     address1        // unused
        ///     address2        // unused
        ///     city            // unused
        ///     country         // unused
        ///     state           // unused
        /// </summary>
        /// <param name="pw"></param>
        /// <returns></returns>
        public static string ToNordCsv(this AvastPw pw )
        {
            var sb = new StringBuilder();
            sb.Append($"{pw.custName},");
            sb.Append($"{pw.url},");
            sb.Append($"{pw.loginName},");
            sb.Append($"{pw.pwd},");
            sb.Append($"{pw.note},");
            sb.Append(",,,,,,,,,,,,,");
            return sb.ToString();
        }
    }
}
