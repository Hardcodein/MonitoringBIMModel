namespace TrackingChangesBimModel.RevitPlugin.Interfaces;

internal interface IElementManager<T> where T : class
{
    public string GetDescriptionElement(T element);
    public string GetStateElement(T element);
}