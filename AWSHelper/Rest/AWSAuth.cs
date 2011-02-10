using System;
using System.Security.Cryptography;
using System.Text;

namespace AWSHelper.Rest
{
    public class Authentication
    {
        public static string AwsAccessKeyId { get; set; }
        public static string AwsSecretAccessKey { get; set; }

        
        public static string AwsAuthSignature {
            get {
                var authSignature = GenerateAwsAuthSignature(GetDateTimeRfc822(), AwsSecretAccessKey);
                return authSignature;
            }
        }

        public static string DateTimeRfc822
        {
            get
            {
                return GetDateTimeRfc822();
            }
        }
        public static string GenerateAwsAuthSignature (string message, string key)
        {
            var encoding = new ASCIIEncoding();

            // Encode key and message into bytes
            var keyBytes = encoding.GetBytes(key);
            var messageBytes = encoding.GetBytes(message);

            // Create an HMAC  object using the given key
            var myhash = new HMACSHA1(keyBytes,false);
    
            // Compute the hash for the given message
            var hashmessage = myhash.ComputeHash(messageBytes);

            // Convert message to string and return
            return Convert.ToBase64String(hashmessage);
        }


        public static string GetDateTimeRfc822()
        {
            // Get date time in GMT
            var dateTime = DateTime.Now.ToUniversalTime();

            // Format to RFC 822 string
            var rfcdateTime = dateTime.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'");

            return rfcdateTime;
        }

    }
}
