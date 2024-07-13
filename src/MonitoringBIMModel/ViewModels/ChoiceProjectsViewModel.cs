

using System.Diagnostics;
using System.Windows;

namespace MonitoringBIMModel.ViewModels;

internal partial class ChoiceProjectsViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Project>? projects;
    [ObservableProperty]
    private Project? selectedProject;

    // public static FilterDbDataForUI? FilterDbDataForUI;
    public ChoiceProjectsViewModel()
    {
        _ = GetProjectsFromDBAsync();
    }

    [RelayCommand]
    private async Task GetProjectsFromDBAsync()
    {
        var Filter = new FilterDbDataForUI();
        Projects = new ObservableCollection<Project>(await Filter!.GetListAllProjectsFormDatabaseAsync());

    }
    [RelayCommand]
    private void LoadInformationWindow()
    {
        LoaderForWindow!.LoadWindow(new InformationProgramViewModel());
    }

    [RelayCommand]
    private void LoadActivityUserWindow()
    {
        LoaderForWindow!.LoadWindow(new ActivityUserViewModel());
    }
    [RelayCommand]
    private void LoadMainWindow(Project project)
    {
        if (SelectedProject is  not null)
        {
            var MainViewModel = new MainWindowViewModel() { selectedProject = SelectedProject! };
            MainViewModel.GetInformationToCurrentProject();
            var MainView = new MainWindowView();
            MainView.DataContext = MainViewModel;
            MainView.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = MainView as Window;
        }
        else
        {
            MessageBox.Show("Выберите проект");
        }

    }
}
