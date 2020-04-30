using System;
using System.Text;

namespace ConsoleShopper.Domain
{
    // Link: https://stackoverflow.com/questions/11743160/how-do-i-encode-and-decode-a-base64-string
    // Author:  https://stackoverflow.com/users/9587/kevin-driedger

    /// <summary>
    /// This extention provides a way to base64 encode and decode the string. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Wrapper method around Built-in String object to base64 encode a value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(this String str, string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            //var data1 = Encoding.UTF8.GetString(plainText);
            var data = Convert.ToBase64String(plainTextBytes);
            return data;
        }
        /// <summary>
        /// Wrapper method around Build-in String object to base64 decode a value
        /// </summary>
        /// <param name="str"></param>
        /// <param name="plainText"></param>
        public static string Base64Decode(this String str, string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            var data = Encoding.UTF8.GetString(base64EncodedBytes);
            return data;
        }
    }
}
