namespace TrackingChangesBimModel.RevitPlugin.Extensions;

internal static class ElementExtension
{
    public static string GetState(this Element element)
    {
        var boundingBoxElement = element.get_BoundingBox(null);

        if (boundingBoxElement is not null)
        {
            var characteristics = new List<string>();
            
            characteristics.Add(element.GetDescription() +
                LocationString())

        }
    }
    public static string GetDescription(this Element element)
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
            
            if(!element.Name.Equals(familyInstance.Symbol.Name))
                sb.Append(familyInstance.Symbol.Name).Append(' ');
        }

        return sb.ToString();

    }
}
