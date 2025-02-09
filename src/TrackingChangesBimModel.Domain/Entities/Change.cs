using TrackingChangesBimModel.Domain.Common;

namespace TrackingChangesBimModel.Domain.Entities;

public class Change : EntityBase
{
    public Guid UserId { get; protected set; }
    public string? Title { get; set; }
    public ChangeAction Action { get; set; }
    public string? Instance { get; set; }
    public virtual User? User { get; set; }
}
public enum ChangeAction
{
    Add,
    Update,
    Delete
}
