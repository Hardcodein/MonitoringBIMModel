

namespace MonitoringBIMModel.ViewModels;
internal partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? login;

    [ObservableProperty]
    private string? password;   
  

    [RelayCommand]
    public async Task<bool> Autentification()
    {
        //// этот иф к чертям убираем
        //if ((Password! == "1111")&& (Login == "1111"))
        //{
        //    MainViewModel mainViewModel = new MainViewModel();
        //    MainView mainView = new MainView();
        //    mainView.DataContext = mainViewModel;
        //    mainView.Show();
        //    return true;
        //}

        
        int? perdonId = await _DbProvider!.GetDb(Login!, Password!.ToString()!);
        if (perdonId != 0)
        {
         
            var LoaderViewModel = new LoaderWindow();
            LoaderViewModel.LoadWindow(new ChoiceProjectsViewModel());
            
            return true;
        }
        else
        {
            MessageBox.Show("Такой пользователь не найден");
            return false;
        }
       

    }
   
    
}
