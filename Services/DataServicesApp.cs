using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services
{
    public class DataServicesApp
    {
        private readonly HttpClient _http;
    
        public DataServicesApp(HttpClient http)
        {
            _http = http;
        }
    
        public async Task<IEnumerable<Penumpang>> GetPenumpang()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Penumpang>>("api/Penumpang/GetPenumpang");
        }

        public async Task<Penumpang> GetPenumpangData(string username, string password)
        {
            var penumpang = await _http.GetFromJsonAsync<IEnumerable<Penumpang>>("api/Penumpang/GetPenumpang");
            return penumpang.FirstOrDefault(x => x.Username == username & BCrypt.Net.BCrypt.Verify(password, x.Password));
        }
    
        public async Task<Penumpang> GetPenumpangById(int id)
        {
            return await _http.GetFromJsonAsync<Penumpang>($"api/Penumpang/GetPenumpangs/{id}");
        }
    
        public async Task<Penumpang> CreatePenumpang(Penumpang penumpang)
        {
            var response = await _http.PostAsJsonAsync("api/Penumpang/PostPenumpang", penumpang);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Penumpang>();
        }

        public async Task UpdatePenumpangAsync(int id, Penumpang penumpang)
        {
            var response = await _http.PutAsJsonAsync($"api/Penumpang/PutPenumpang/{id}", penumpang);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePenumpang(int id)
        {
            var response = await _http.DeleteAsync($"api/Penumpang/DeletePenumpang/{id}");
        }
    }
}
