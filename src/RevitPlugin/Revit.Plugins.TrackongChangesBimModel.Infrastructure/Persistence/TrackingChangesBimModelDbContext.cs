

namespace Revit.Plugins.TrackingChangesBimModel.Infrastructure.Persistence;

public class TrackingChangesBimModelDbContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public TrackingChangesBimModelDbContext()
    {

    }
    public TrackingChangesBimModelDbContext(DbContextOptions<TrackingChangesBimModelDbContext> options) : base(options)
    {

    }

}
