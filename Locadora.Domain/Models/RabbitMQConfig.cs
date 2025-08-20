using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Models
{
    public class RabbitMQConfig
    {
        public string Port { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
        public string ExchangeName { get; set; }
      
    }
}
