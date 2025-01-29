
namespace MonitoringBIMModel.Views;

/// <summary>
/// Логика взаимодействия для LoginView.xaml
/// </summary>
public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
 
    }
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext != null)
        { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
    }
}
