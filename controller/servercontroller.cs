using ServerApp.Models;
using ServerApp.Views;
using System;

namespace ServerApp.Controllers
{
    public class ChatController
    {
        private readonly ChatModel _model;
        private readonly ConsoleView _view;
        private readonly string _ip;
        private readonly int _port;

        public ChatController(ChatModel model, ConsoleView view, string ip, int port)
        {
            _model = model;
            _view = view;
            _ip = ip;
            _port = port;
        }

        public void Start()
        {
            _view.ShowMessage($"Starting server on {_ip}:{_port}...");

            if (!_model.StartServer(_ip, _port))
            {
                _view.ShowMessage("Server failed to start. Exiting...");
                return;
            }

            _view.ShowMessage("Waiting for client to connect...");
            if (!_model.AcceptConnection())
            {
                _view.ShowMessage("Client connection failed. Exiting...");
                return;
            }

            _view.ShowMessage("Client connected successfully!");
            RunChat();
        }

        private void RunChat()
        {
            while (true)
            {
                string received = _model.ReceiveMessage();
                if (string.IsNullOrEmpty(received))
                {
                    _view.ShowMessage("Client disconnected.");
                    break;
                }
                _view.ShowMessage($"\nClient: {received}");
                string reply = _view.GetUserInput("Server: ");
                _model.SendMessage(reply);
            }

            _model.Stop();
        }
    }
}
