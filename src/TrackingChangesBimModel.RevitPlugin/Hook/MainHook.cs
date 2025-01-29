namespace TrackingChangesBimModel.RevitPlugin.Hook;

[Transaction(TransactionMode.ReadOnly)]
public class MainHook : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var uiapp = commandData.Application;
        var uidoc = uiapp.ActiveUIDocument;
        var app = uiapp.Application;
        var doc = uidoc.Document;

        IEnumerable<Element> a = GetTrackedElements(doc);

        if (null == _start_state)
        {
            _start_state = GetSnapshot(a);
            TaskDialog.Show("Track Changes",
              "Started tracking changes now.");
        }
        else
        {
            Dictionary<int, string> end_state = GetSnapshot(a);
            ReportDifferences(doc, _start_state, end_state);
            _start_state = null;
        }
        return Result.Succeeded;
    }
}
