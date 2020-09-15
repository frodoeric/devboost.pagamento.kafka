using Confluent.Kafka;
using Integration.Pay.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Pay.Interfaces
{
    public interface IKafkaProducer
    {
        Task<DeliveryResult<Confluent.Kafka.Null, string>> RealizarPagamento(MethodRequestDto pedido);
    }
}
