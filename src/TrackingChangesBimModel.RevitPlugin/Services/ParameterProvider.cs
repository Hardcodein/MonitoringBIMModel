namespace TrackingChangesBimModel.RevitPlugin.Services;

internal class ParameterProvider : IParameterProvider
{
    public string GetStringFromPropertiesJson(IEnumerable<Parameter> parameters)
    {
        var parameterStrings = new List<string>();

        foreach (var param in parameters)
        {
            parameterStrings.Add($"\"{param.Definition.Name}\":\"{param.AsValueString()}\"");
        }

        parameterStrings.Sort();

        return string.Join(", ", parameterStrings);

    }
}
