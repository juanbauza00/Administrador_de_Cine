using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_Cine_Frontend.HTTP
{
    public class ClientSingleton
    {
        private static ClientSingleton instancia;
        private HttpClient client;
        private ClientSingleton()
        {
            client = new HttpClient();
        }
        public static ClientSingleton GetInstance()
        {
            if (instancia == null)
                instancia = new ClientSingleton();
            return instancia;
        }
        public async Task<string> GetAsync(string url)
        {
            var result = await client.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> PostAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8,
            "application/json");
            var result = await client.PostAsync(url, content);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }

        public async Task<string> DeleteAsyncV1(string url, int id)
        {
            string stringId = id.ToString();
            string stringError = "ERROR AL BORRAR";

            var result = await client.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return result.StatusCode.ToString();
            }
            else
            {
                return stringError;
            }
        }

        public async Task<string> PutAsync(string url, string data)
        { 
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, content);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }

        public async Task<string> DeleteAsync(string url)
        {
            //    try
            //    {
            //        HttpResponseMessage response = await client.DeleteAsync($"{url}?id={id}");

            //        if (response.IsSuccessStatusCode)
            //        {
            //            return "Se elimino correctamente";
            //        }
            //        else
            //        {
            //            return "No se pudo eliminar";
            //        }
            //    }
            //    catch (HttpRequestException ex)
            //    {
            //        // Handle exception (e.g., log, throw)
            //        return $"Error: {ex.Message}";
            //    }
            //}

            var result = await client.DeleteAsync(url);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }
    }
}
