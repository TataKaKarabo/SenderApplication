using RabbitMQ.Client;
using System;
using System.Text;

namespace SenderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Message myMessage = new Message();
            FactoryConfig factory = new FactoryConfig();
            factory.SendMessage(myMessage.GetMessage());
            factory.RecieveRecieveResponce();
            Console.ReadLine();
        }
    }
}
