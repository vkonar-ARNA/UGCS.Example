
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using Services.DTO;

namespace Services.Classes
{
    public class AnraUdpClient : IAnraSocketClient
    {
        private string Token;
        private UdpClient udpClient;

        private Action<string, Color> ConsoleLog;
        public event EventHandler onSocketStatusChange;

        public bool IsConnected { get { return udpClient != null; } }

        public void Connect()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient();
            }
            var port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["anraUdpPort"]);
            udpClient.Connect(System.Configuration.ConfigurationManager.AppSettings["anraUdpAddress"], port);
        }

        public void Disconnect()
        {
            udpClient.Dispose();
            udpClient = null;
        }

        public void Init(string token)
        {
            Token = token;
            //ConsoleLog = consoleLog;
            udpClient = new UdpClient();
        }

        public void SendMessage(UGCSMessage message)
        {
            try
            {
                var packet = new AnraUdpPacket(Token)
                {
                    Data = JsonConvert.SerializeObject(message)
                };

                var senddata = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(packet));
                udpClient.Send(senddata, senddata.Length);
            }
            catch (Exception ex)
            {
                ConsoleLog("UDP Error: " + ex.Message, Color.Red);
                Console.WriteLine(ex.GetType() + "\n" + ex.Message);
            }
        }
    }
}