namespace MonitoringBIMModel.Models;

public class DataObject
{
    public int Id { get; set; }
    public Guid guid { get; set; }
    public string? Name { get; set; }
    public string? Action { get; set; }
    public string? UserName { get; set; }

    public string?   Instance { get; set; }

}
