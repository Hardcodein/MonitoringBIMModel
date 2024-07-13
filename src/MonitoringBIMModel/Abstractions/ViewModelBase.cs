

namespace MonitoringBIMModel.Abstractions;

internal partial class ViewModelBase : ObservableObject
{
    public static DbProvider? _DbProvider { get; set; }
    internal static LoaderWindow? LoaderForWindow { get; set; }

    static ViewModelBase()
    {
        _DbProvider = new DbProvider();
        LoaderForWindow = new LoaderWindow();
    }

    [RelayCommand]
    public  void BackToMainWindow()
    {
        LoaderForWindow!.LoadWindow(new ChoiceProjectsViewModel());
    }
}
