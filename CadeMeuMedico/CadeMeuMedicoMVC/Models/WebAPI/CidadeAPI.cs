using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CadeMeuMedicoMVC.Models.WebAPI
{
    public class CidadeAPI
    {
        public static string Post(Cidade cidade, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PostAsJsonAsync(method, cidade).Result;
                return result.Content.ToString();
            }
        }

        public static string Put(Cidade cidade, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PutAsJsonAsync(method, cidade).Result;
                return result.Content.ToString();
            }
        }

        public static string Delete(int id, string url)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = httpClient.DeleteAsync(url + "/" + id).Result;
                return response.Content.ToString();
            }
        }

        public static ICollection<Cidade> Get(string url, int id = 0)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);

                if (id == 0)
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    Cidade[] data = JsonConvert.DeserializeObject<Cidade[]>(response.Content.ReadAsStringAsync().Result);
                    return data;
                }
                else
                {
                    HttpResponseMessage response = httpClient.GetAsync(url + "/" + id).Result;
                    Cidade obj = JsonConvert.DeserializeObject<Cidade>(response.Content.ReadAsStringAsync().Result);
                    Cidade[] data = new Cidade[1];
                    data[0] = obj;
                    return data;
                }
            }
        }
    }
}