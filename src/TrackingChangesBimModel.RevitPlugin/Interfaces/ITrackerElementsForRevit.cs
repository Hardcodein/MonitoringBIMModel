namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface ITrackerElementsForRevit
{
     Task<IEnumerable<Element>> GetAllElements(Document document);
}
