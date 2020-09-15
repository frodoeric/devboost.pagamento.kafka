using Confluent.Kafka;
using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class KafkaProducer : IKafkaProducer
    {
        readonly string _host;
        readonly int _port;
        readonly string _topic;

        public KafkaProducer(string host, int port, string topic)
        {
            _host = host;
            _port = port;
            _topic = topic;
        }

        public async Task<DeliveryResult<Null, string>> RealizarPagamento(MethodRequestDto pedido)
        {
            if (pedido == null)
                return null;

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = $"{_host}:{_port}"
            };

            using IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(
                _topic,
                new Message<Null, string>
                {
                    Value = ConvertPedidoToJson(pedido)
                }
            );

            return result;
        }

        private string ConvertPedidoToJson(MethodRequestDto pedido) =>
            JsonConvert.SerializeObject(pedido);
    }
}
