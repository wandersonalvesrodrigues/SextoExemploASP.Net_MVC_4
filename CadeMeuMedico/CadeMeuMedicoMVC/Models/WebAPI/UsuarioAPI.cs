using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CadeMeuMedicoMVC.Models.WebAPI
{
    public class UsuarioAPI
    {
        public static string Post(Usuario usuario, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PostAsJsonAsync(method, usuario).Result;
                return result.Content.ToString();
            }
        }

        public static string Put(Usuario usuario, string method)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                var result = httpClient.PutAsJsonAsync(method, usuario).Result;
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

        public static ICollection<Usuario> Get(string url, int id = 0)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                if (id == 0)
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    Usuario[] data = JsonConvert.DeserializeObject<Usuario[]>(response.Content.ReadAsStringAsync().Result);
                    return data;
                }
                else
                {
                    HttpResponseMessage response = httpClient.GetAsync(url + "/" + id).Result;
                    Usuario obj = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                    Usuario[] data = new Usuario[1];
                    data[0] = obj;
                    return data;
                }
            }
        }

        public static ICollection<Usuario> Get(string url, string login, string senha)
        {
            using (var httpClient = new HttpClient())
            {
                string baseUrl = "http://localhost:51186/";
                httpClient.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = httpClient.GetAsync(url + "?login="+login+"&senha="+senha).Result;
                Usuario obj = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                Usuario[] data = new Usuario[1];
                data[0] = obj;
                return data;
            }
        }
    }
}