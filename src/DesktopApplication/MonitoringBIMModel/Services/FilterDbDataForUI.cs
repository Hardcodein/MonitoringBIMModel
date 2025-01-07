

namespace MonitoringBIMModel.Services;

class FilterDbDataForUI
{
    public static DbProvider? ProviderDataBase { get; set; }
    static FilterDbDataForUI()
    {
        ProviderDataBase = new DbProvider();
    }
    public async Task<List<Project>> GetListAllProjectsFormDatabaseAsync()
    {
        var DirtyList = await ProviderDataBase!.GetDbDataProject();

        return DirtyList.ToHashSet().Select(x=> new Project(x)).ToList();
       
    }
}
