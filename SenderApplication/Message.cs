using System;
using System.Collections.Generic;
using System.Text;

namespace SenderApplication
{
    public class Message : IMessage
    {
        public string name { set; get; }

        public string responseRecieved { set; get; }
        public string message { set; get; } = "Hello my name is ";

        public string GetMessage()
        {
            Console.Write("Please Enter Your Name: ");
            name = Console.ReadLine();
            return message + name;
        }

        public void DisplayResponse()
        {
            Console.WriteLine(responseRecieved);
        }
    }
}
