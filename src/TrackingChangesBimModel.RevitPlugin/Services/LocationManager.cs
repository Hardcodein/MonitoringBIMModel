namespace TrackingChangesBimModel.RevitPlugin.Services;

internal class LocationManager : ILocationManager
{
    private readonly IGeometryConverter _geometryConverter;

    public LocationManager(IGeometryConverter geometryConverter)
    {
        _geometryConverter = geometryConverter;
    }

    public string GetLocationString(Location location)
    {
        var localPoint = location as LocationPoint;

        var localCurve = localPoint is not null ?
            location as LocationCurve
            : null;

        var sb = new StringBuilder();

        if (localCurve is not null)
            sb.Append(_geometryConverter.GetStringCurveTessellate(localCurve.Curve));

        if (localPoint is not null)
            sb.Append(_geometryConverter.GetStringPoint(localPoint.Point));

        return sb.ToString();
    }
}