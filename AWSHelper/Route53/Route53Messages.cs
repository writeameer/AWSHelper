using System.Xml;

namespace AWSHelper.Route53
{
    public class Route53Messages
    {
        // Default namesapce for route53 messages
        public const string BaseUri = "https://route53.amazonaws.com/";
        public const string Route53Ns = BaseUri + "doc/2010-10-01/";
        public const string CreateHostedZoneUri = BaseUri + "2010-10-01/hostedzone";

        private static XmlDocument xmlDoc = new XmlDocument();
        

        public static string CreateHostedZoneRequestMessage(string domainName, string callerReference, string comment)
        {

            xmlDoc.InsertBefore(
                xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null),
                xmlDoc.DocumentElement);

            // Create Root node
            var rootNode = xmlDoc.CreateElement("CreateHostedZoneRequest", Route53Ns);
            xmlDoc.AppendChild(rootNode);

            // Add Name Element with Domain Name
            var nameNode = xmlDoc.CreateElement("Name", Route53Ns);
            nameNode.InnerText = domainName;
            rootNode.AppendChild(nameNode);

            // Add Caller Reference
            var callerReferenceNode = xmlDoc.CreateElement("CallerReference", Route53Ns);
            callerReferenceNode.InnerText = callerReference;
            rootNode.AppendChild(callerReferenceNode);

            // Add Hosted Config
            var hostedZoneconfig = xmlDoc.CreateElement("HostedZoneConfig", Route53Ns);
            rootNode.AppendChild(hostedZoneconfig);

            // Add Comment to hosted config
            var commentNode = xmlDoc.CreateElement("Comment", Route53Ns);
            commentNode.InnerText = comment;
            hostedZoneconfig.AppendChild(commentNode);

            return xmlDoc.OuterXml;
        }

        public static string ChangeResourceRecordSetsRequestMessage()
        {
            // Create Root node
            var rootNode = xmlDoc.CreateElement("ChangeResourceRecordSetsRequest", BaseUri);
            xmlDoc.AppendChild(rootNode);

            return null;
        }
    }
}
