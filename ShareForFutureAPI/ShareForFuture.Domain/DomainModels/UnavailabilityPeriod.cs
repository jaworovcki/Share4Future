using System.ComponentModel.DataAnnotations.Schema;

namespace ShareForFuture.Domain.DomainModels;

public class UnavailabilityPeriod
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }

    public DateTime From { get; set; }

    public DateTime? Until { get; set; }
}
