
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;
using Tiket_Penerbangan_n_Kereta.Services;

namespace Tiket_Penerbangan_n_Kereta.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {

        private readonly ApplicationDbContext _context;
        
        private string _email;
        
        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get => _email;
            set => TrySetProperty(ref _email, value, out _);
        }

        private string _password;

        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get => _password;
            set => TrySetProperty(ref _password, value, out _);
        }
        
        
        public LoginViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Penumpang?> LoginAsync(string email, string password)
        {
            var user = await _context.Penumpang.FirstOrDefaultAsync(u => u.Email == email);
            if(user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                AuthState.LoggedInUser = user;
            } 

            return null;
        }
        
        [RelayCommand]
        public async Task LoginAsync()
        {
            var result = await LoginAsync(Email, Password);
            ValidateAllProperties();
            
            if (!HasErrors)
            {
                if (result != null)
                {
                    if (Application.Current?.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime applicationLifetime)
                    {
                        Window? window = applicationLifetime.Windows.FirstOrDefault(
                            w => w.IsActive);
                        window?.Hide();
                        var windows = new WindowDashboardView();
                        windows.Show();
                    }
                }
            }
        }

        [RelayCommand]
        public void Register()
        {
            if (Application.Current?.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime applicationLifetime)
            {
                Window? window = applicationLifetime.Windows.FirstOrDefault(
                    w => w.IsActive);
                window?.Hide();
                var windows = new RegisterView();
                windows.Show();
            }
        }

    }

    public class CurrentUser
    {
        public static int Id { get; set; }
    }
    
}
