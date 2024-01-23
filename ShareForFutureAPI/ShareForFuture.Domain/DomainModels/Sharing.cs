namespace ShareForFuture.Domain.DomainModels;
using System;   
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sharing
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }

    public Offering? Offering { get; set; }

    public string? OfferingId { get; set; }

    // Requirement: Borrower [is] the user who wants to borrow a device.
    public User? Borrower { get; set; }

    public string BorrowerId { get; set; } = string.Empty;

    // Requirement: If a user finds a device he/she wants to borrow, he/she can enter the
    //  period of time through which he/she would like to have the tool.
    public DateTime From { get; set; }

    public DateTime Until { get; set; }

    // Requirement: S4F will send a notification email about the borrow request to
    //  the lender of the device. S4F wants to be able to send reminder emails to
    //  lenders if they do not respond within 48 hours.
    public DateTime? LastShareNotificationSendTimestamp { get; set; }

    // Requirement: The lender can accept or decline the borrow request.
    public bool? LenderHasAccepted { get; set; }

    public DateTime? AcceptedDeclinedTimestamp { get; set; }

    // Requirement: In both cases, the lender can add a message (e.g. greeting, reason why declined).
    public string? AcceptDeclineMessage { get; set; }

    // Requirement: When the borrower returns the device, the lender marks the share as done.
    public DateTime? DoneTimestamp { get; set; }

    // Requirement: After a share has been done, the lender can rank the borrower with 0..5 stars.
    //  The borrower can rank the lender with 0..5 stars. The borrower can also rank the device
    //  with 0..5 stars. Both users can add a textual note to rankings (e.g. reason why to many stars).
    public int? BorrowerRating { get; set; }

    public string? BorrowerRatingNote { get; set; }

    public int? LenderRating { get; set; }

    public string? LenderRatingNote { get; set; }

    public int? DeviceRating { get; set; }

    public string? DeviceRatingNote { get; set; }
}