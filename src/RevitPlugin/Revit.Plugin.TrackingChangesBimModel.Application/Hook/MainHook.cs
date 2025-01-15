namespace Revit.Plugin.TrackingChangesBimModel.Hook;

internal class MainHook : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        return Result.Cancelled;
    }
}
