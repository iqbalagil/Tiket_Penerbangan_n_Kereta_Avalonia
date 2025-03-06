using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Tiket_Penerbangan_n_Kereta.Data;
using Tiket_Penerbangan_n_Kereta.ViewModel.Data;

namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public partial class RegisterViewModels : ViewModelBase
{
    private readonly ApplicationDbContext _context;

    private readonly Dictionary<string, List<ValidationResult>> _errors = new();

    public string _email;

    public string _password;

    private string _registerMessage;
    private string _username;

    private string _verifyPassword;


    public RegisterViewModels(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool HasErrors => _errors.Any();

    [Required]
    public string Username
    {
        get => _username;
        set
        {
            if (value != _username)
            {
                _username = value;
                ValidateProperty(value, nameof(Username));
            }
        }
    }

    [Required]
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

    [Required]
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

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Password and Confirmation Password must match.")]
    public string VerifyPassword
    {
        get => _verifyPassword;
        set
        {
            if (value != _verifyPassword)
            {
                _verifyPassword = value;
                ValidateProperty(value, nameof(VerifyPassword));
            }
        }
    }

    public string RegisterMessage
    {
        get => _registerMessage;
        set => SetProperty(ref _registerMessage, value);
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

    public async Task<bool> UsernameExists(string username)
    {
        return await _context.Penumpang.AnyAsync(u => u.Username == username);
    }

    public async Task<Penumpang> RegisterAsync(string username, string email, string password)
    {
        var userRole = _context.Role.FirstOrDefault(r => r.RoleName == "User");
        if (userRole == null)
        {
            userRole = new Roles { RoleName = "User" };
            _context.Role.Add(userRole);
        }

        if (await UsernameExists(username)) RegisterMessage = "Username already exists";

        var user = new Penumpang
        {
            Username = username,
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            Role = userRole
        };

        _context.Penumpang.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    [RelayCommand]
    public async Task RegisterAsync()
    {
        ValidateAllProperties();
        if (!HasErrors)
        {
            await RegisterAsync(Username, Email, Password);
            RegisterMessage = "Registration successful";
        }
    }
}