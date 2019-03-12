using Newtonsoft.Json;
using System;
using System.Drawing;
using WebSocketSharp;

namespace Services.Classes
{
    public class WebSocketClient : IAnraSocketClient
    {
        private WebSocket socket = null;
        private string _anraServerUrl;
        private string _token;
        private bool _isDev;
        private Guid _gufi;
        private bool _isConnected;

       // private Action<string, Color> ConsoleLog;
        public event EventHandler onSocketStatusChange;


        public bool IsAlive
        {
            get
            {
                return socket != null && socket.IsAlive;
            }
        }

        public bool IsConnected => _isConnected;

        public WebSocketClient(Guid gufi)
        {
            _anraServerUrl = System.Configuration.ConfigurationManager.AppSettings["anraussserver"];

            _isDev = _anraServerUrl.IndexOf("localhost") >= 0;

            _gufi = gufi;
        }

        public void SendMessage(UGCSMessage msg)
        {
            if (_isConnected && socket.IsAlive)
            {
				//socket.SendAsync(JsonConvert.SerializeObject(msg), p =>
				//{
				//    ConsoleLog?.Invoke("Socket Response: " + p, Color.White);
				//});
				socket.SendAsync(JsonConvert.SerializeObject(msg), null);
			}
        }

        public void Init(string token)
        {
            _token = token;
        }

        public void Connect()
        {
            var url = $"ws://{ _anraServerUrl}/telemetry?gufi={_gufi}&token={_token}";

            socket = new WebSocket(url);
            socket.OnMessage += WebSocketClient_OnReceive;
            socket.OnOpen += WebSocketClient_OnOpen;
            socket.OnClose += WebSocketClient_OnClose;
            socket.OnError += Socket_OnError;
            socket.Connect();
            _isConnected = true;
        }

        public void Disconnect()
        {
            if (socket.IsAlive)
            {
                socket.Close();
            }

            _isConnected = false;
        }

        private void WebSocketClient_OnReceive(object sender, MessageEventArgs e)
        {
            var msg = JsonConvert.DeserializeObject<UTMResponse>(e.Data);
            //ConsoleLog?.Invoke("Telemetry Socket Error: " + msg.Message, Color.Red);
        }

        private void WebSocketClient_OnClose(object sender, CloseEventArgs e)
        {
            //ConsoleLog?.Invoke("Websocket closed:" + e.Reason, Color.White);
            _isConnected = false;
            onSocketStatusChange?.Invoke(sender, e);
        }

        private void Socket_OnError(object sender, ErrorEventArgs e)
        {
          //  ConsoleLog?.Invoke("Websocket closed:" + e.Message, Color.Red);
            _isConnected = false;
            onSocketStatusChange?.Invoke(sender, e);
        }

        private void WebSocketClient_OnOpen(object sender, EventArgs e)
        {
            //ConsoleLog?.Invoke("Socket Status: Connected", Color.White);
            _isConnected = false;
            onSocketStatusChange?.Invoke(sender, e);
        }
    }
}