using Consumer.Drone.AzureFunction.Services.Interfaces;
using DroneDelivery.Helper.HttpUtils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Drone.AzureFunction.Services
{
    public class PagamentoService : IPagamentoService
    {
        readonly string _url;

        public PagamentoService(string url)
        {
            _url = (string.IsNullOrEmpty(url))
                ? "https://localhost:44391/api/pay/atualizarstatuspagamento"
                : url;
        }

        public async Task<HttpResponseMessage> AtualizaStatusPedido(string token, string jsonBody)
        {
            var atualizaStatusPedidoJson = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var authentication = new AuthenticationHeaderValue("bearer", token);
            var result = HttpPostService.PostService(_url, atualizaStatusPedidoJson, authentication);
            return await Task.FromResult(result);
        }
    }
}
