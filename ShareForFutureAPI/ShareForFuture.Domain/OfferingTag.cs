namespace ShareForFuture.Domain;

public class OfferingTag
{
    public int Id { get; set; }

    public string Tag { get; set; } = string.Empty;

    public List<Offering> Offerings { get; set; } = new();
}
