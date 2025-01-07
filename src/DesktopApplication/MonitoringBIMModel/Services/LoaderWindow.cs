

namespace MonitoringBIMModel.Services;

internal class LoaderWindow 
{
    public void LoadWindow(object viewModel)
    {
        string? searchView;
        Type? foundViewType;

        Type?  parameterViewModelType = viewModel.GetType();

        List<Type>? ViewsTypeInProjects = Assembly.GetExecutingAssembly().GetTypes().Where(t=>t.Namespace == "MonitoringBIMModel.Views").ToList();
        searchView = parameterViewModelType.Name.Replace("ViewModel", "View");
        foundViewType = ViewsTypeInProjects.Find(x => x.Name.Equals(searchView));


        if (foundViewType is not null)
        {
            var window  = Activator.CreateInstance(foundViewType);
            ((Window)window!).DataContext = viewModel;
            ((Window)window).Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window as Window;
        }
    }   
}
