using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Tiket_Penerbangan_n_Kereta.ViewModel;

namespace Tiket_Penerbangan_n_Kereta;

public class ViewLocator : IDataTemplate
{
    private readonly IServiceProvider _service;

    public ViewLocator(IServiceProvider service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public Control Build(object data)
    {
        var name = data.GetType().AssemblyQualifiedName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null) return (Control)Activator.CreateInstance(type);

        return new TextBlock { Text = "Not Found" + name };
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }
}