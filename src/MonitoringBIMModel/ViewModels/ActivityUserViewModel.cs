

namespace MonitoringBIMModel.ViewModels;

internal partial class ActivityUserViewModel : ViewModelBase
{

    public ActivityUserViewModel()
    {
        _ = GetInformationForUsersFromDatabase();

    }

    [ObservableProperty]
    private ObservableCollection<DataObject> usersColletion = [];

    private async Task GetInformationForUsersFromDatabase()
    {

        if (UsersColletion.Any())
        {
            UsersColletion.Clear();
        }
        else
        {
            ObservableCollection<DataObject> UsersList = new (await _DbProvider!.GetDbData());    

            foreach (DataObject User in UsersList) 
            {
                UsersColletion.Add(User);
            }
        }
        //if (CurrentDataObjectList.Any())
        //{
        //    CurrentDataObjectList.Clear();
        //}
        //else
        //{
        //    ObservableCollection<DataObject> mas = new(await _DbProvider!.GetDbData());
        //    foreach (DataObject obj in mas)
        //    {
        //        CurrentDataObjectList.Add(obj);
        //    }
        //}
    }
    
}
