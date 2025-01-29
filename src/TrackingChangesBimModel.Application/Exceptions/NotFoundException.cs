namespace TrackingChangesBimModel.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string nameObject, object key) : base($"Entity \"{nameObject}\"({key}) not found ")
    {
            
    }
}
