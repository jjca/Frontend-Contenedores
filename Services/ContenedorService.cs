using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Frontend_Contenedores.Models;

namespace Frontend_Contenedores.Services
{
    public class ContenedorService
    {
        private readonly HttpClient _httpClient;
        public ContenedorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Contenedor>> GetContenedoresAsync()
        {
            var url = "http://backend:5198/Contenedor";
            var contenedores = await _httpClient.GetFromJsonAsync<List<Contenedor>>(url);
            return contenedores ?? new List<Contenedor>();
        }
    }
}
