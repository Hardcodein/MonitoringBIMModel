
namespace MonitoringBIMModel.ViewModels;

internal partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private FilterType _selectedFilter;

    public Project? selectedProject { get; set; }
    

    
    [ObservableProperty]
    private string? finderValue;
    [ObservableProperty]
    private IEnumerable<KeyValuePair<FilterType, string>>? enumValues ;
    [ObservableProperty]
    private ObservableCollection<DataObject> changeCollection = [];
    
    public MainWindowViewModel()
    {
        enumValues = Constants.ConstantEnumValues;
       
        
    
    }
    public async Task GetInformationToCurrentProject()
    {
        if (selectedProject is not null)
        {
            if (ChangeCollection.Any())
            {
                ChangeCollection.Clear();
            }
            else
            {
                ObservableCollection<DataObject> UsersList = new(await _DbProvider!.GetDbDataOnProject(selectedProject.Name!));

                foreach (DataObject User in UsersList)
                {
                    ChangeCollection.Add(User);
                }
            }
        }
    }
}


