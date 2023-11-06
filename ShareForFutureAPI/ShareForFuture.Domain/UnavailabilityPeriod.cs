namespace ShareForFuture.Domain;

public class UnavailabilityPeriod
{
    public int Id { get; set; }

    public DateTime From { get; set; }

    public DateTime? Until { get; set; }
}
