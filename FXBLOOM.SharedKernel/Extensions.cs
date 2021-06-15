using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FXBLOOM.SharedKernel
{
    public static class Extensions
    {
        public static string ToJson(this object value)
        {
            if (value == null) return "{ }";
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }

        public static string HashPassword(this string plainPassword)
        {
            plainPassword = plainPassword.ToLower();
            byte[] pwd = Utility.Hash512($"PWD{plainPassword.Substring(0, plainPassword.Length / 2)}@40)!{plainPassword.Substring(plainPassword.Length / 2)}");
            string hashedPassword = BitConverter.ToString(pwd).Replace("-", "").ToLowerInvariant().Trim();
            return hashedPassword;
        }

        public static string ToSentenceCase(this string phrase)
        {
            if (!string.IsNullOrEmpty(phrase))
            {
                var convertedString = phrase.Split(new char[0]).ToList().Select(e => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(e.ToLower()));
                return string.Join(" ", convertedString);
            }
            return string.Empty;
        }
    }
}
