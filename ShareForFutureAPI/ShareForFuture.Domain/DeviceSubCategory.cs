namespace ShareForFuture.Domain;

public class DeviceSubCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DeviceCategory? Category { get; set; }

    public int CategoryId { get; set; }

    public List<Offering> Offerings { get; set; } = new();
}
