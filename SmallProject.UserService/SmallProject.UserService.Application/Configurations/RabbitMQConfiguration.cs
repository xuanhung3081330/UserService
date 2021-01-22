using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.UserService.Application.Configurations
{
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
