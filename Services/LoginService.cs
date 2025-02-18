
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.Services
{
    public interface ILoginService
    {
        Task<AuthenticationResult> Auth(string username, string password);
    }
    public class LoginService : ILoginService
    {
        private readonly DataServicesApp _data;

        public LoginService(DataServicesApp data)
        {
            _data = data;
        }

        public async Task<AuthenticationResult> Auth(string username, string password)
        {
            var user = await _data.LoginAsync(username, password);
            if (user != null)
            {
                return new AuthenticationResult
                {
                    IsAuthenticated = true,
                    User = user
                };
            }
            return new AuthenticationResult
            {
                IsAuthenticated = false
            };
        }
    }

        public class AuthenticationResult
        {
            public bool IsAuthenticated { get; set; }
            public Penumpang User { get; set; }
        }
 
}
