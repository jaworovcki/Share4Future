using System.ComponentModel.DataAnnotations.Schema;

namespace ShareForFuture.Domain.DomainModels;

public class OfferingTag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = string.Empty;

    public string Tag { get; set; } = string.Empty;

    public List<Offering> Offerings { get; set; } = new();
}
