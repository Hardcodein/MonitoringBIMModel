namespace TrackingChangesBimModel.RevitPlugin.Comparers;

internal class XyzEqualityComparer : IEqualityComparer<XYZ>
{
    private readonly IGeometryConverter GeometryConverter;
    public XyzEqualityComparer(IGeometryConverter geometryConverter)
    {
        GeometryConverter = geometryConverter;
    }
    public bool Equals(XYZ p, XYZ q)
    {
        return p.IsAlmostEqualTo(q);
    }

    public int GetHashCode(XYZ p)
    {
        return GeometryConverter.GetStringPoint(p).GetHashCode();
    }
}
