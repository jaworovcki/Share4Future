using System.ComponentModel.DataAnnotations.Schema;

namespace ShareForFuture.Domain.DomainModels;

public class DeviceSubCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DeviceCategory? Category { get; set; }

    public string CategoryId { get; set; } = string.Empty;

    public List<Offering> Offerings { get; set; } = new();
}
