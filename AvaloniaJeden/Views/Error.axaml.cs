using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaJeden.Views
{
    public partial class Error : Window
    {
        public Error()
        {
            InitializeComponent();
        }

        public void error_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }
    }
}
