namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface IGeometryConverter
{
    internal string GetRealStringDouble(double value);
    internal string GetStringPoint(XYZ point);
    internal string GetStringBoundingBox(BoundingBoxXYZ box);
    internal string GetStringArrayPoint(IEnumerable<XYZ> points);
    internal string GetStringCurveTessellate(Curve curve);
}
