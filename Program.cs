using ServerApp.Controllers;
using ServerApp.Models;
using ServerApp.Views;

namespace ServerApp
{
    internal class Program
    {
        static void Main()
        {
            string ip = "10.74.229.56";  // Change to your local IP
            int port = 8888;

            ChatModel model = new ChatModel();
            ConsoleView view = new ConsoleView();
            ChatController controller = new ChatController(model, view, ip, port);

            controller.Start();
        }
    }
}
