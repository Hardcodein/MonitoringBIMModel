namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

public interface IParameterProvider
{
    internal string GetStringFromPropertiesJson(IEnumerable<Parameter> parameters);
}