using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenderApplication
{
    public class FactoryConfig
    {
        Message myMessage;
        public FactoryConfig()
        {
            myMessage = new Message();
        }

        #region Send messagen Factory Settings
        public bool SendMessage(string msg)
        {
            bool sent = false;

            if (string.IsNullOrEmpty(msg))
            {
                sent = false;
            }
            else
            {
                try
                {
                    ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "IQBusinessQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                        var body = Encoding.UTF8.GetBytes(msg);
                        channel.BasicPublish(exchange: "", routingKey: "IQBusinessQueue", basicProperties: null, body: body);
                        sent = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops, something went wrong, please try again: " + Environment.NewLine + "More Information: " + ex.ToString());
                }

            }
            
            return sent;

        }
        #endregion

        #region RecieveResponse
        public void RecieveRecieveResponce()
        {

            try
            {
                ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "IQBusinessQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    EventingBasicConsumer reciver = new EventingBasicConsumer(channel);
                    reciver.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        myMessage.responseRecieved = Encoding.UTF8.GetString(body);
                        myMessage.DisplayResponse();

                    };
                    channel.BasicConsume("IQBusinessQueue", autoAck: true, consumer: reciver);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops, something went wrong trying to retrieve the message, please try again: " + Environment.NewLine + "More Information: " + ex.ToString());
            }
        }
        #endregion
    }
}
