using FinalExamWeb.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinalExamWeb
{
    public class WebService
    {

        public WebService()
        {
        }

        private IConfigurationRoot GetConfiguration()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return config.Build();
        }

        public async Task<Comic> GetDataService(string _endpoint, string _search)
        {
            Comic comic = new Comic();

            try
            {
                string url = "";

                if (!string.IsNullOrWhiteSpace(_search))
                {
                    url = GetConfiguration().GetSection("URL_SERVICE").Value + _endpoint + "?api_key=" 
                        + GetConfiguration().GetSection("API_KEY").Value 
                        + "&format=json&filter=name:" + _search;
                }
                else
                {
                    url = GetConfiguration().GetSection("URL_SERVICE").Value + _endpoint + "?api_key=" 
                        + GetConfiguration().GetSection("API_KEY").Value 
                        + "&format=json";
                }

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.28.4");
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        comic = JsonConvert.DeserializeObject<Comic>(apiResponse);
                        comic.results.RemoveAll(x => x.name == null);
                        comic.results.RemoveAll(x => x.description == null);
                        return comic;
                    }
                }
            }
            catch (Exception ex)
            {
                return comic;
            }
        }
    }
}
