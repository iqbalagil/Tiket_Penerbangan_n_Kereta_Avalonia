using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard
{
    public partial class DashboardViewModel : ViewModelBase
    {
        [ObservableProperty] private bool _isOpenPane = true;

        [ObservableProperty] private ViewModelBase _currentPage = new PemesananPesawatViewModel();

        public ObservableCollection<ListViewTemplate> Items { get; } = new()
        {
            new ListViewTemplate(typeof(PemesananPesawatViewModel)),
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
            public ListViewTemplate(Type type)
            {
                ModelType = type;
                Label = type.Name.Replace("ViewModel",AddSpaceToSentence("") );
            }

            public string Label { get; }
            public Type ModelType { get; }

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
