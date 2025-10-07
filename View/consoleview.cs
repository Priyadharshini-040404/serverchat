using System;

namespace ServerApp.Views
{
    public class ConsoleView
    {
        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        public string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
