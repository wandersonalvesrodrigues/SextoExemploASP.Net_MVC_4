using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CadeMeuMedicoMVC.Models.WebAPI
{
    public class MedicoAPI
    {
        public static string Post(Medico medico, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PostAsJsonAsync(method, medico).Result;
                return result.Content.ToString();
            }
        }

        public static string Put(Medico medico, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PutAsJsonAsync(method, medico).Result;
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

        public static ICollection<Medico> Get(string url, int id = 0)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                if (id == 0)
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    Medico[] data = JsonConvert.DeserializeObject<Medico[]>(response.Content.ReadAsStringAsync().Result);
                    return data;
                }
                else
                {
                    HttpResponseMessage response = httpClient.GetAsync(url + "/" + id).Result;
                    Medico obj = JsonConvert.DeserializeObject<Medico>(response.Content.ReadAsStringAsync().Result);
                    Medico[] data = new Medico[1];
                    data[0] = obj;
                    return data;
                }
            }
        }
    }
}