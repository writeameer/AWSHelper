using System;
using Microsoft.Http;
using AWSHelper.Rest;

namespace AWSHelper.Route53
{
    public class Route53Actions
    {


        public static string AddResourceRecordSetsRequest()
        {

            return null;
        }

        public static string CreateHostedZone(string domainName, string callerReference, string comment)
        {
            var httpClient = new HttpClient();
            var route53Uri = new Uri(Route53Messages.CreateHostedZoneUri); 

            // Create Request Messages
            var route53RequestMessage = Route53Messages.CreateHostedZoneRequestMessage(domainName, callerReference, comment);
            Console.WriteLine(route53RequestMessage);
            var route53Request = HttpContent.Create(route53RequestMessage);

            // Add Authorization Headers to request
            var amazonAuthHeader = string.Format("AWS3-HTTPS AWSAccessKeyId={0},Algorithm=HmacSHA1,Signature={1}", Authentication.AwsAccessKeyId,  Authentication.AwsAuthSignature);
            httpClient.DefaultHeaders.Add("X-Amzn-Authorization", amazonAuthHeader);
            httpClient.DefaultHeaders.Add("x-amz-date", Authentication.DateTimeRfc822);

            // Make CreateHostedZone request
            var output = httpClient.Post(route53Uri, route53Request);
            return output.Content.ReadAsString();

        }
    }
}
