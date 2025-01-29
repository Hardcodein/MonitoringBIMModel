namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface IExternalRevitManagerForString
{
    public string GetRealStringFromDouble(double value);
    public string GetLocationString(Location location);
    public string GetStringFromPoint(XYZ point);
    public string GetStringFromBoundingBox(BoundingBoxXYZ box);
    public string GetStringFromArrayPoint(IEnumerable<XYZ> points);
    public string GetStringFromCurveTessellate(Curve curve);
    public string GetStringFromPropertiesJson(IEnumerable<Parameter> parameters);


}
