using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAssesment.Web.Extensions
{
    public static class CommonExtension
    {
        public static string MaxLengthAs(this string str, int length) {
            if (string.IsNullOrEmpty(str) || str.Length <= length) { 
                return str; 
            }

            return str.Substring(0, length) + "...";
        }
    }
}