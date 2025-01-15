namespace Revit.Plugins.TrackingChangesBimModel.Infrastructure.Repositories;

public class ChangeResository : RepositoryBase<Change>, IChangeRepository
{
    public ChangeResository(TrackingChangesBimModelDbContext dbContext) : base(dbContext)
    {
    }
}
