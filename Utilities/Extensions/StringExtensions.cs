using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrl(this string text)
        {
            string url = text.ToLower();
            url = url.Replace('ş', 's')
                     .Replace('ı', 'i')
                     .Replace('ü', 'u')
                     .Replace('ö', 'o')
                     .Replace('ğ', 'g')
                     .Replace('ç', 'c');
            url = Regex.Replace(url, @"[^\w\d\s]", "");
            url = url.Trim();
            url = Regex.Replace(url, @"[\s+]","-");
            return url;
        }
    }
}
