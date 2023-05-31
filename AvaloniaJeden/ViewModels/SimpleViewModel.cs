using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AvaloniaJeden.ViewModels;



public class SimpleViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;



    private string? _Name;
    public string? Name
    {
        get
        {
            return _Name;
        }
        set
        {
            if (_Name != value)
            {
                _Name = value;
                NamePropertyChanged();
                NamePropertyChanged(nameof(Description));
            }
            _Name = value;
        }
    }
    public string Description
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "puste";
            }



            return $"Hello {Name}";
        }
    }

    private void NamePropertyChanged([CallerMemberName] string? propertyname = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }



}