namespace TrackingChangesBimModel.RevitPlugin.Services;

internal class ExternalRevitManagerForString : IExternalRevitManagerForString
{
    public string GetLocationString(Location location)
    {
        var localPoint = location as LocationPoint;

        var localCurve = localPoint is not null ?
            location as LocationCurve
            : null;

        var sb = new StringBuilder();

        if (localCurve is not null)
            sb.Append(GetStringFromCurveTessellate(localCurve.Curve));

        if (localPoint is not null)
            sb.Append(GetStringFromPoint(localPoint.Point));

        return sb.ToString();
    }

    public string GetRealStringFromDouble(double value)
    {
        return value.ToString("0.##");
    }

    public string GetStringFromArrayPoint(IEnumerable<XYZ> points)
    {
        return string.Join(", ", points.Select(p => GetStringFromPoint(p)));
    }

    public string GetStringFromBoundingBox(BoundingBoxXYZ box)
    {
        return $"{GetStringFromPoint(box.Min)},{GetStringFromPoint(box.Min)}";
    }

    public string GetStringFromCurveTessellate(Curve curve)
    {
        return GetStringFromArrayPoint(curve.Tessellate());
    }

    public string GetStringFromPoint(XYZ point)
    {
        return
            $"{GetRealStringFromDouble(point.X)}," +
            $"{GetRealStringFromDouble(point.X)}," +
            $"{GetRealStringFromDouble(point.X)}";
    }

    public string GetStringFromPropertiesJson(IEnumerable<Parameter> parameters)
    {
        var parameterStrings = new List<string>();

        foreach (var param in parameters)
        {
            parameterStrings.Add($"\"{param.Definition.Name}\":\"{param.AsValueString()}\"");
        }

        parameterStrings.Sort();
        
        return string.Join (", ", parameterStrings);
    }
}