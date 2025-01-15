namespace Revit.Plugins.TrackingChangesBimModel.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(TrackingChangesBimModelDbContext dbContext) : base(dbContext)
    {
       
    }
}
