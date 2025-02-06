using System;
using System.Collections.ObjectModel;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard
{
    public partial class DashboardViewModel : ViewModelBase
    {
        private IServiceProvider _service;

        public DashboardViewModel(IServiceProvider service)
        {
            _service = service;
        } 
        
        [ObservableProperty] private bool _isOpenPane = true;

        [ObservableProperty] private ViewModelBase _currentPage = new PemesananPesawatViewModel();

        [ObservableProperty] private ListViewTemplate? _selectedListItem;
        partial void OnSelectedListItemChanged(ListViewTemplate? value)
        {
            if (value?.ModelType is Type modelType)
            {
                var viewModel = _service.GetRequiredService(modelType) as ViewModelBase;
                if (viewModel != null) CurrentPage = viewModel;
            }
        }
        public ObservableCollection<ListViewTemplate> Items { get; } = new()
        {
            new ListViewTemplate(typeof(MaskapaiViewModel), "Maskapai", "Airplane"),
            new ListViewTemplate(typeof(PemesananPesawatViewModel), "Pemesanan Pesawat", "Ticket"),
            new ListViewTemplate(typeof(UserInterfaceViewModel), "User Interface", "Person"),
            new ListViewTemplate(typeof(DataAnalyticalViewModel), "Data Analytical", "DataUsage")
        };

        [RelayCommand]
        private void MinimizeWindow(Window window)
        {
          if(window !=null )  window.WindowState = WindowState.Minimized;
        } 

        [RelayCommand]
        private void MaximizedWindow(Window window) => window.WindowState =
            window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

        [RelayCommand]
        private void CloseWindow(Window window) => window.Close();

        [RelayCommand]
        private void IsTogglePane()
        {
            IsOpenPane = !IsOpenPane;

        }
    }

    public class ListViewTemplate
        {
            public ListViewTemplate(Type type, string label, string icon)
            {
                ModelType = type;
                Label = type.Name.Replace(type.Name,label);
                ListItemIcon = (MaterialIconKind)Enum.Parse(typeof(MaterialIconKind),icon);
            }

            public string Label { get; }
            public Type ModelType { get; }
            public MaterialIconKind ListItemIcon { get; }

            private string AddSpaceToSentence(string text)
            {
                if (string.IsNullOrEmpty(text)) return text;

                StringBuilder newText = new StringBuilder();
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    {
                        newText.Append(' ');
                    }
                    newText.Append(text[i]);
                }

                return newText.ToString();
            }
        }
}
