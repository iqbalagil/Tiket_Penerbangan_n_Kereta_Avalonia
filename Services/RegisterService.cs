using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Controls.Documents;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string email, string password);
        Task<bool> UsernameExists(string username);
    }
    internal class RegisterService : IRegisterService
    {
        private readonly HttpClient _http;

        public RegisterService(HttpClient http)
        {
            _http = http;
        }
        
        public async Task<bool> UsernameExists(string username)
        {
            var user = await _http.GetFromJsonAsync<IEnumerable<Penumpang>>("api/Penumpang/GetPenumpang");
            return user.Any(u => u.Username == username);
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            
            var user = new Penumpang
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            var response = await _http.PostAsJsonAsync("api/Penumpang/PostPenumpang", user);
            return response.IsSuccessStatusCode;
        }


    }
}
