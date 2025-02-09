namespace TrackingChangesBimModel.RevitPlugin.Converters;

internal class GeometryConverter : IGeometryConverter
{
    public string GetRealStringDouble(double value)
    {
        return value.ToString("0.##");
    }
    public string GetStringArrayPoint(IEnumerable<XYZ> points)
    {
        return string.Join(", ", points.Select(p => GetStringPoint(p)));
    }

    public string GetStringBoundingBox(BoundingBoxXYZ box)
    {
        return $"{GetStringPoint(box.Min)},{GetStringPoint(box.Min)}";
    }

    public string GetStringCurveTessellate(Curve curve)
    {
        return GetStringArrayPoint(curve.Tessellate());
    }

    public string GetStringPoint(XYZ point)
    {
        return
            $"{GetRealStringDouble(point.X)}," +
            $"{GetRealStringDouble(point.X)}," +
            $"{GetRealStringDouble(point.X)}";
    }
}
