using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.ExternalService.Diamond
{
    public class DiamondService : IDiamondService
    {

        private readonly HttpClient _httpClient;
 
        public DiamondService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<List<DiamondEntity>> GetDiamondPricesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("https://667a1e4918a459f6395263f0.mockapi.io/diamond", cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            List<DiamondEntity> responseList = new List<DiamondEntity>();
            try
            {
                JArray jsonArray = JArray.Parse(content);
                foreach (JObject item in jsonArray)
                {
                    DiamondEntity diamondEntity = item.ToObject<DiamondEntity>();
                    diamondEntity.Name = item["Type"].ToString();
                    diamondEntity.CreatedAt = DateTime.ParseExact(item["Date"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    responseList.Add(diamondEntity);
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

        
    }
}
