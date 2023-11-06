namespace ShareForFuture.Domain;

public class DeviceImage
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public byte[] ImageData { get; set; } = Array.Empty<byte>();

    public Offering? Offering { get; set; }

    public int? OfferingId { get; set; }
}
