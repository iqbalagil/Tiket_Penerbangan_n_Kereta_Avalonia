using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.Services;
using Tiket_Penerbangan_n_Kereta.View.Dashboard;

namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public partial class LoginViewModel : ViewModelBase
{
    private readonly AuthState _authState;

    private readonly ApplicationDbContext _context;

    private readonly Dictionary<string, List<ValidationResult>> _errors = new();

    private string _email;

    private string _password;


    public LoginViewModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool HasErrors => _errors.Any();

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email
    {
        get => _email;
        set
        {
            if (value != _email)
            {
                _email = value;
                ValidateProperty(value, nameof(Email));
            }
        }
    }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password
    {
        get => _password;
        set
        {
            if (value != _password)
            {
                _password = value;
                ValidateProperty(value, nameof(Password));
            }
        }
    }

    protected void ValidateProperty(object value, string propertyName)
    {
        var validationContext = new ValidationContext(this) { MemberName = propertyName };
        var validationResults = new List<ValidationResult>();

        ClearErrors();

        if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            foreach (var validationResult in validationResults)
                AddErrors(propertyName, validationResult.ErrorMessage);
    }

    protected void ClearErrors(string propertyName)
    {
        if (_errors.ContainsKey(propertyName)) _errors.Remove(propertyName);
    }

    protected void AddErrors(string propertyName, string errorMessage)
    {
        if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<ValidationResult>();
        _errors[propertyName].Add(new ValidationResult(errorMessage));
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var penumpang = await _context.Penumpang
            .Include(p => p.Role)
            .FirstOrDefaultAsync(p => p.Email == email);

        if (penumpang == null)
            if (BCrypt.Net.BCrypt.Verify(password, penumpang.Password))
            {
                var token = _authState.GenerateToken(penumpang.IdPenumpang.ToString(), penumpang.Email,
                    penumpang.Role.RoleName);
                return token;
            }

        var petugas = await _context.Petugas
            .Include(p => p.Roles)
            .FirstOrDefaultAsync(p => p.Email == email);

        if (petugas == null)
            if (BCrypt.Net.BCrypt.Verify(password, petugas.Password))
            {
                var token = _authState.GenerateToken(petugas.idPetugas.ToString(), petugas.Email,
                    petugas.Roles.RoleName);
                return token;
            }

        return null;
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        var result = await LoginAsync(Email, Password);
        ValidateAllProperties();

        if (!HasErrors)
            if (result != null)
                if (Application.Current?.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime
                    applicationLifetime)
                {
                    var window = applicationLifetime.Windows.FirstOrDefault(
                        w => w.IsActive);
                    window?.Hide();
                    var windows = new WindowDashboardView();
                    windows.Show();
                }
    }

    [RelayCommand]
    public void Register()
    {
        if (Application.Current?.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime applicationLifetime)
        {
            var window = applicationLifetime.Windows.FirstOrDefault(
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