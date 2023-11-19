namespace ShareForFuture.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Requirement: S4F must store a list of users
public class User : IdentityUser
{
    // Requirement: For each user, S4F must store basic personal data like name fields and physical address.
    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string? Street { get; set; } = string.Empty;

    public string? City { get; set; } = string.Empty;

    public string? ZipCode { get; set; } = string.Empty;

    public string? Country { get; set; } = string.Empty;

    // Requirement: S4F must store when the contact data was last verified.
    public DateTime? LastSuccessfullEmailVarification { get; set; }

    // Requirement: S4F wants to be able to send reminder emails to users who have not
    //  logged in to S4F for a long time. The S4F database must be able to store the
    //  necessary data to enable that feature.
    public DateTime? LastSuccessfullLogin { get; set; }

    // Requirement: Every user can offer 0..many devices for sharing.
    public List<Offering> Offerings { get; set; } = new();

    public List<Sharing> Lendings { get; set; } = new();
}