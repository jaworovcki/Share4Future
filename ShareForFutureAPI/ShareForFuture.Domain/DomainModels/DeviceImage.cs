using System.ComponentModel.DataAnnotations.Schema;

namespace ShareForFuture.Domain.DomainModels;

public class DeviceImage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public byte[] ImageData { get; set; } = Array.Empty<byte>();

    public Offering? Offering { get; set; }

    public string? OfferingId { get; set; }
}
