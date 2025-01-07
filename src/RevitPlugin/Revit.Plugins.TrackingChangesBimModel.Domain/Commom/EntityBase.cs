namespace Revit.Plugins.TrackingChangesBimModel.Domain.Commom;

public  class EntityBase
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModificateDate { get; set; }
}
