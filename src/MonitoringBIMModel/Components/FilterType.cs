

namespace MonitoringBIMModel.Components;


public enum FilterType
{
    [Description("Имени пользователя")]
    ForUserName,
    [Description("GUID")]
    ForGuid,
    [Description("Действию")]
    ForAction,

}

public static class FilterTypeExtenstions
{
    public static string GetDescription(this Enum enumObj)
    {
        FieldInfo fieldInfo =
            enumObj.GetType().GetField(enumObj.ToString());

        object[] attribArray = fieldInfo.GetCustomAttributes(false);

        if (attribArray.Length == 0)
        {
            return enumObj.ToString();
        }
        else
        {
            DescriptionAttribute attrib =
                attribArray[0] as DescriptionAttribute;
            return attrib.Description;
        }
    }
}
