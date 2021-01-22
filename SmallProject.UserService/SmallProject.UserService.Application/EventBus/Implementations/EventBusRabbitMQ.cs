using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SmallProject.UserService.Application.Configurations;
using SmallProject.UserService.Application.EventBus.Abstractions;
using SmallProject.UserService.Domain.Aggregates.Retailer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Application.EventBus.Implementations
{
    public class EventBusRabbitMQ : IEventBus
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _userName;
        private IConnection _connection;
        private readonly RabbitMQConfiguration _rabbitMQConfig;

        public EventBusRabbitMQ(IOptions<RabbitMQConfiguration> rabbitMQOptions)
        {
            // using IOptions to inject
            _rabbitMQConfig = rabbitMQOptions.Value;
            _hostName = _rabbitMQConfig.HostName;
            _password = _rabbitMQConfig.Password;
            _queueName = _rabbitMQConfig.QueueName;
            _userName = _rabbitMQConfig.UserName;
        }

        // Create connection to RabbitMQ
        private void CreateConnection()
        {
            try
            {
                // Convenience "factory" class to facilitate (thuận tiện/dễ dàng) opening a Connection to 
                // an AMQP broker (AMQP: Advanced Message Queuing Protocol)
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        // Check if connection exists
        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

        //// Implementation using RabbitMQ API
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Publish(IntegrationEvent @event)
        //{
        //    // Check if connection exists
        //    if (ConnectionExists())
        //    {
        //        using (var channel = _connection.CreateModel())
        //        {
        //            // Declare a queue
        //            channel.QueueDeclare(
        //                queue: _queueName,
        //                durable: false,
        //                exclusive: false,
        //                autoDelete: false,
        //                arguments: null);

        //            // Convert .NET object to JSON String
        //            var json = JsonConvert.SerializeObject(@event);

        //            // ???
        //            var body = Encoding.UTF8.GetBytes(json);

        //            // Publish message
        //            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        //        }
        //    }
        //}

        //public void Subscribe<T, TH>()
        //    where T : IntegrationEvent
        //    where TH : IIntegrationEventHandler<T>
        //{
        //    throw new NotImplementedException();
        //}

        //public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        //{
        //    throw new NotImplementedException();
        //}

        //public void Unsubscribe<T, TH>()
        //    where T : IntegrationEvent
        //    where TH : IIntegrationEventHandler<T>
        //{
        //    throw new NotImplementedException();
        //}

        //public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        //{
        //    throw new NotImplementedException();
        //}

        public void SendRetailer(Retailer retailer)
        {
            if (ConnectionExists())
            {
                try
                {
                    using (var channel = _connection.CreateModel())
                    {
                        // Declare a queue
                        channel.QueueDeclare(
                            queue: "HelloQueue",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        // Convert .NET object to JSON String
                        var json = JsonConvert.SerializeObject(retailer, Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });

                        // ???
                        var body = Encoding.UTF8.GetBytes(json);

                        // Publish message
                        channel.BasicPublish(exchange: "", routingKey: "HelloQueue", basicProperties: null, body: body);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
