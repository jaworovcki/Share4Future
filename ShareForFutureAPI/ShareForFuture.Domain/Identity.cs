namespace ShareForFuture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Requirement: S4F does not store user names and passwords. The system relies on external identity providers.
public class Identity
{
    public int Id { get; set; }

    // Requirement: For each identity, S4F needs to store the identity provider
    //  and the technical user ID of the corresponding identity provider.
    public IdentityProvider Provider { get; set; }

    public string SubjectId { get; set; } = string.Empty;

    public User? User { get; set; }

    public int UserId { get; set; }
}
