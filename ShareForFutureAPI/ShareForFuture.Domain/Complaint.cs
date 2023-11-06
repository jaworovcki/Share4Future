namespace ShareForFuture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Complaint
{
    public int Id { get; set; }

    public User? Complainer { get; set; }

    public int ComplainerId { get; set; }

    public User? Complainee { get; set; }

    public int ComplaineeId { get; set; }

    // Requirement: S4F employees will try to settle the complaints.
    public User? AssignedTo { get; set; }

    public int AssignedToId { get; set; }

    // Requirement: The S4F employee can mark the complaint as done once it will have been settled.
    public DateTime? DoneTimestamp { get; set; }


    // Requirement: S4F wants to be able to generate statics about the duration of complaints.
    public DateTime CreatedTimestamp { get; set; }


    // Requirement: Both involved users and the assigned S4F employee can store notes (text, pictures) to the complaint.
    public List<ComplaintNote> Notes { get; set; } = new();
}


