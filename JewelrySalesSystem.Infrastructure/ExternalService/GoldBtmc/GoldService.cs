using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.ExternalService.GoldBtmc
{
    public class GoldService : IGoldService
    {
        private readonly HttpClient _httpClient;

        public GoldService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

     

        public async Task<List<GoldEntity>> GetGoldPricesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("https://6663df16932baf9032a93456.mockapi.io/goldprice", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            List<GoldEntity> responseList = new List<GoldEntity>();
            try
            {
                JArray jsonArray = JArray.Parse(content);
                foreach (JObject item in jsonArray)
                {
                    GoldEntity goldEntity = item.ToObject<GoldEntity>();
                    goldEntity.CreatedAt = DateTime.Parse(item["date"].ToString());
                    responseList.Add(goldEntity);
                }
            }
            catch (JsonException ex)
            {
                // Log or handle the JSON deserialization error
                throw new Exception("Error deserializing JSON", ex);
            }
          

            if (responseList.Count == 0)
            {
                throw new NotFoundException("Nothing to response");
            }

            return responseList;
        }
        public async Task<bool> CheckIfGoldExistAsync(int? GoldId, CancellationToken cancellationToken)
        {
            var getGold = await GetGoldPricesAsync(cancellationToken);
            return getGold.Any(g => g.ID == GoldId);
        }
    }
}
