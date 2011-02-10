using System;
using AWSHelper.Route53;
using AWSHelper.Rest;

namespace AWSHelper
{
    [Serializable]
    public class Foo
    {
        public string Bar { get; set; }
        public string Nested { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Authentication.AwsAccessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID", EnvironmentVariableTarget.User);
            Authentication.AwsSecretAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", EnvironmentVariableTarget.User);
       
            var output = Route53Actions.CreateHostedZone( "cloudoman.com", "create hosted zone", "testing");
            Console.WriteLine(output);
  
        }


    }


}
