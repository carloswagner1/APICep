using ApiCep.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;


namespace ApiCep
{
    public static class ViaCepRequest
    {
        public static async Task<CepModel> CepRequest(string CEP)
        {
            //info request 
            var apiUrl = new Uri($"https://viacep.com.br/ws/{CEP}/json/");
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            var cepClient = httpClientFactory.CreateClient();
            var response = await cepClient.GetStringAsync(apiUrl);
            var result = JsonConvert.DeserializeObject<CepModel>(response);

            return result;
        }
    }
}
