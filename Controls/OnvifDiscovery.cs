using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace MissionPlanner.Controls
{
    public static class OnvifDiscovery
    {
        private const string ProbeMessage = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<e:Envelope xmlns:e=""http://www.w3.org/2003/05/soap-envelope""
            xmlns:w=""http://schemas.xmlsoap.org/ws/2004/08/addressing""
            xmlns:d=""http://schemas.xmlsoap.org/ws/2005/04/discovery""
            xmlns:dn=""http://www.onvif.org/ver10/network/wsdl"">
    <e:Header>
        <w:MessageID>uuid:{0}</w:MessageID>
        <w:To>urn:schemas-xmlsoap-org:ws:2005:04:discovery</w:To>
        <w:Action>http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe</w:Action>
    </e:Header>
    <e:Body>
        <d:Probe>
            <d:Types>dn:NetworkVideoTransmitter</d:Types>
        </d:Probe>
    </e:Body>
</e:Envelope>";

        public static List<string> Discover(int timeoutMs = 3000)
        {
            var result = new List<string>();
            using (var udpClient = new UdpClient())
            {
                udpClient.Client.ReceiveTimeout = timeoutMs;
                udpClient.EnableBroadcast = true;

                var multicastEndpoint = new IPEndPoint(IPAddress.Parse("239.255.255.250"), 3702);
                string probe = string.Format(ProbeMessage, Guid.NewGuid());
                byte[] probeBytes = Encoding.UTF8.GetBytes(probe);

                udpClient.Send(probeBytes, probeBytes.Length, multicastEndpoint);

                DateTime start = DateTime.Now;
                while ((DateTime.Now - start).TotalMilliseconds < timeoutMs)
                {
                    try
                    {
                        var ep = new IPEndPoint(IPAddress.Any, 0);
                        byte[] responseBytes = udpClient.Receive(ref ep);
                        string response = Encoding.UTF8.GetString(responseBytes);

                        var xaddr = ParseXAddr(response);
                        if (!string.IsNullOrEmpty(xaddr) && !result.Contains(xaddr))
                            result.Add(xaddr);
                    }
                    catch (SocketException) { break; }
                }
            }
            return result;
        }

        private static string ParseXAddr(string xml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                var node = doc.GetElementsByTagName("XAddrs")[0];
                return node?.InnerText.Split(' ')[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
