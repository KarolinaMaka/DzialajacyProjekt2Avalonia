using Avalonia.Controls;

namespace AvaloniaJeden.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        public SimpleViewModel SimpleViewModel { get; set; } = new SimpleViewModel();
    }
}
