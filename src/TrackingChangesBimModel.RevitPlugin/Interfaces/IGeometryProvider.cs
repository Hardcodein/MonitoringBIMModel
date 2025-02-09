namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface IGeometryProvider
{
    public List<XYZ> GetCanonicVertices(Element element);
}
