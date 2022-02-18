using MobileApp.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.API
{
    public class GetCatalog
    {
        private string Url { get; set; } = "https://localhost:7224/api/Products";

        public GetCatalog()
        {

        }

        public async Task<List<Catalog>> GetCatalogAsync()
        {
            List<Catalog> catalogs = new List<Catalog>();
            string content;
            try
            {
                var response = await GetResponseByPageAsync();
                content = response.Content;
                catalogs = JsonConvert.DeserializeObject<List<Catalog>>(response.Content);
            }
            catch (Exception ex)
            {

            }
            return catalogs;
        }


        private async Task<IRestResponse> GetResponseByPageAsync()
        {
            var client = new RestClient(Url);
            var request = new RestRequest(Method.GET);
   
            try
            {
                var response = await client.ExecuteAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
