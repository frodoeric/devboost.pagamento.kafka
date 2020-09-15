using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Drone.AzureFunction.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<HttpResponseMessage> AtualizaStatusPedido(string token, string jsonBody);
    }
}
