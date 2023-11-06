namespace ShareForFuture.Domain;

public class ComplaintNote
{
    public int Id { get; set; }

    public string? TextNote { get; set; }

    public byte[]? Picture { get; set; }

    public Complaint? Complait { get; set; }

    public int ComplaintId { get; set; }
}
