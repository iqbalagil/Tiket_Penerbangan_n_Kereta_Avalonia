using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using Microsoft.Extensions.DependencyInjection;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta
{
    public class ViewLocator : IDataTemplate
    {
        private readonly IServiceProvider _service;

        public ViewLocator(IServiceProvider service)
        {
            _service = service;
        }
        public Control Build(object data)
        {
            var name = data.GetType().AssemblyQualifiedName!.Replace("ViewModel","View");
            var type = Type.GetType(name);

            var view = ActivatorUtilities.CreateInstance(_service, type) as Control;
            if (view != null)
            {
                view.DataContext = data;
                return view;
            }
            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
