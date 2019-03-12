//using MavelinkLibrary;
using System;
using System.Drawing;

namespace Services.Classes
{
    public interface IAnraSocketClient
    {
        bool IsConnected { get; }

        void Init(string token);

        void Connect();

        void Disconnect();

        void SendMessage(UGCSMessage message);

        event EventHandler onSocketStatusChange;
    }
}