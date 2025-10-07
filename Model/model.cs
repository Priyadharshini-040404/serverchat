using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp.Models
{
    public class ChatModel
    {
        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;

        public bool StartServer(string ip, int port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Parse(ip), port);
                _listener.Start();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Model Error] Starting server failed: {ex.Message}");
                return false;
            }
        }

        public bool AcceptConnection()
        {
            try
            {
                _client = _listener.AcceptTcpClient();
                _stream = _client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Model Error] Connection failed: {ex.Message}");
                return false;
            }
        }

        public string ReceiveMessage()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            catch
            {
                return null;
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                _stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Model Error] Send failed: {ex.Message}");
            }
        }
        public void Stop()
        {
            _stream?.Close();
            _client?.Close();
            _listener?.Stop();
        }
    }
}
