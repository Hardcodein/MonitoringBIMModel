namespace MonitoringBIMModel;

public static class Constants
{ 
    public static readonly List<string> Developers = ["Бондаренко Денис","Малыгин Вячеслав","Черкашин Юрий","Тормосин Станислав"];
    public  static IEnumerable<KeyValuePair<FilterType, string>> ConstantEnumValues = Enum.GetValues(typeof(FilterType)).Cast<FilterType>().Select(x => new KeyValuePair<FilterType, string>(x, x.GetDescription()));
}
