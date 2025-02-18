using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ReactiveUI;

namespace Tiket_Penerbangan_n_Kereta.ViewModel;

public class ValidationUsingDataAnnotationsViewModel : ViewModelBase, INotifyDataErrorInfo
{

        private readonly Dictionary<string, List<ValidationResult>> _errors = new();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errors.Any();

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return _errors.Values.SelectMany(static errors => errors);
            if (this._errors.TryGetValue(propertyName!, out List<ValidationResult>? results)) return results;
            return Array.Empty<ValidationResult>();
        }

        protected void ClearErrors(string? propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                _errors.Clear();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string errorMessage)
        {
            if (!_errors.TryGetValue(propertyName, out var propertyErrors))
            {
                propertyErrors = new List<ValidationResult>();
                _errors.Add(propertyName, propertyErrors);
            }

            propertyErrors.Add(new ValidationResult(errorMessage));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }

        private void ValidateEmail()
        {
            ClearErrors(nameof(Email));
            if(string.IsNullOrEmpty(Email)) AddError(nameof(Email), "This field is required");
            if(Email is null || !Email.Contains('@')) AddError(nameof(Email), "Email required @-");
        }
        private void ValidatePassword()
        {
            ClearErrors(nameof(Password));
            if(string.IsNullOrWhiteSpace(Password)) AddError(nameof(Password), "This field is required");
        }
        private void ValidateProperty(string propertyName, string? value)
        {
            ClearErrors(nameof(propertyName));
            if(string.IsNullOrWhiteSpace(value)) AddError(nameof(propertyName), "This field is required");
        }

        public ValidationUsingDataAnnotationsViewModel()
        {
            this.WhenAnyValue(x => x.Email)
                .Subscribe(_ => ValidateEmail());
            this.WhenAnyValue(p => p.Password)
                .Subscribe(_ => ValidatePassword());
        }

        private string? _password;
        private string? _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        
        
}
