using ServerApp.Controllers;
using ServerApp.Models;
using ServerApp.Views;

namespace ServerApp
{
    internal class Program
    {
        static void Main()
        {
            string ip = "127.0.0.1";  // Change to your local IP
            int port = 8888;

            ChatModel model = new ChatModel();
            ConsoleView view = new ConsoleView();
            ChatController controller = new ChatController(model, view, ip, port);

            controller.Start();
        }
    }
}
