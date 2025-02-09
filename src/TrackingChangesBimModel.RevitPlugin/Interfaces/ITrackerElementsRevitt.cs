namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface ITrackerElementsRevitt
{
     Task<IEnumerable<Element>> GetAllElements(Document document);
}
