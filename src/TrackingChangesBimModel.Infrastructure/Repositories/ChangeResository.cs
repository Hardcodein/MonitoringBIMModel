using TrackingChangesBimModel.Application.Contracts.Persistence;
using TrackingChangesBimModel.Domain.Entities;
using TrackingChangesBimModel.Infrastructure.Persistence;

namespace TrackingChangesBimModel.Infrastructure.Repositories;

public class ChangeResository : RepositoryBase<Change>, IChangeRepository
{
    public ChangeResository(TrackingChangesBimModelDbContext dbContext) : base(dbContext)
    {
    }
}
