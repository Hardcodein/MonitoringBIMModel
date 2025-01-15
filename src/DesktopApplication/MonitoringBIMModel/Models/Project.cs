
namespace MonitoringBIMModel.Models;

internal partial class Project :ObservableObject
{
    public int Id { get; set; }

    [ObservableProperty]    
    public string? name;

    public Project(string? name)
    {
        Name = name;
    }
}
