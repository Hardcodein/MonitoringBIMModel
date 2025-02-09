using TrackingChangesBimModel.Application.Contracts.Persistence;
using TrackingChangesBimModel.Domain.Entities;
using TrackingChangesBimModel.Infrastructure.Persistence;

namespace TrackingChangesBimModel.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(TrackingChangesBimModelDbContext dbContext) : base(dbContext)
    {

    }
}
