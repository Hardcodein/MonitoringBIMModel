using TrackingChangesBimModel.Domain.Common;
using TrackingChangesBimModel.Domain.Entities;

namespace TrackingChangesBimModel.Infrastructure.Persistence;

public class TrackingChangesBimModelDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Change> Changes { get; set; }


    public TrackingChangesBimModelDbContext(DbContextOptions<TrackingChangesBimModelDbContext> options) : base(options)
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {

            entity.HasKey(x => x.Id)
            .HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(x => x.Id)
            .HasColumnName("id");

            entity.Property(x => x.CreatedDate)
            .HasDefaultValueSql("CURRENT_DATE")
            .HasColumnName("created_date");

            entity.Property(x => x.LastModificateDate)
            .HasColumnName("last_modificate_date");

            entity.Property(x => x.FirstName)
            .HasMaxLength(50)
            .HasColumnName("first_name");

            entity.Property(x => x.Email)
            .HasMaxLength(50)
            .HasColumnName("email");

            entity.Property(x => x.Password)
            .HasColumnName("password");


            entity.HasIndex(x => x.CreatedDate);

        });

        modelBuilder.Entity<Change>(entity =>
        {
            entity.HasKey(x => x.Id)
            .HasName("change_fkey");

            entity.ToTable("changes");

            entity.Property(x => x.CreatedDate)
            .HasDefaultValueSql("CURRENT_DATE")
            .HasColumnName("created_date");

            entity.Property(x => x.LastModificateDate)
            .HasColumnName("last_modificate_date");

            entity.Property(x => x.Title)
            .HasColumnName("title");

            entity.Property(x => x.Instance)
            .HasColumnName("instance");

            entity.Property(x => x.Action)
            .HasColumnName(@"action")
            .HasConversion(v => v.ToString(), v => (ChangeAction)Enum.Parse(typeof(ChangeAction), v));

            entity.HasIndex(x => x.LastModificateDate);

            entity.HasOne(x => x.User)
            .WithMany(x => x.Changes)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_user_changes");
        });
    }
    public override Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    }
                case EntityState.Modified:
                    {
                        entry.Entity.LastModificateDate = DateTime.UtcNow;
                        break;
                    }
            }
        }
        return base.SaveChangesAsync(token);

    }

}
