namespace TrackingChangesBimModel.RevitPlugin.Services;

internal class ElementManager : IElementManager<Element>
{
    private readonly IGeometryConverter GeometryConverter;

    private readonly ILocationManager LocationManager;

    private readonly IGeometryProvider GeometryProvider;

    private readonly IParameterProvider ParameterProvider;

    public ElementManager(
       IGeometryConverter stringProvider,
       ILocationManager locationManager,
       IGeometryProvider geometryProvider,
       IParameterProvider parameterProvider)
    {
        GeometryConverter = stringProvider;
        LocationManager = locationManager;
        GeometryProvider = geometryProvider;
        ParameterProvider = parameterProvider;
    }

    public string GetDescriptionElement(Element element)
    {
        if (element is null)
            return "null";

        var familyInstance = element as FamilyInstance;

        var sb = new StringBuilder();

        sb.Append(element.GetType().Name).Append(' ');

        if (element.Category is not null)
            sb.Append(element.Category.Name).Append(' '); ;

        if (familyInstance is not null)
        {
            sb.Append(familyInstance.Symbol.Family.Name).Append(' ');

            if (!element.Name.Equals(familyInstance.Symbol.Name))
                sb.Append(familyInstance.Symbol.Name).Append(' ');
        }

        return sb.ToString();

    }

    public string GetStateElement(Element element)
    {
        var boundingBoxElement = element.get_BoundingBox(null);

        if (boundingBoxElement is null)
        {
            return string.Empty;
        }
        var characteristics = new List<string>();

        characteristics.Add(GetDescriptionElement(element) +
            LocationManager.GetLocationString(element.Location));

        if (element is not FamilyInstance)
        {
            characteristics.Add("Box=" + GeometryConverter.GetStringBoundingBox(boundingBoxElement));

            characteristics.Add("Verticles=" + GeometryConverter.GetStringArrayPoint(GeometryProvider.GetCanonicVertices(element)));

        }
        characteristics.Add("Parameters="
          + ParameterProvider.GetStringFromPropertiesJson(element.GetOrderedParameters()));

        s = string.Join(", ", characteristics);

        return "";
    }
}
