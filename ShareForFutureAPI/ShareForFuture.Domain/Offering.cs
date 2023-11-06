namespace ShareForFuture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Offering
{
    public int Id { get; set; }

    public User? User { get; set; }

    public int UserId { get; set; }

    // Requirement: For each device, S4F must store basic description data including title,
    //  description, condition (like new, used, heavily used, to be repaired).
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DeviceCondition Condition { get; set; } = DeviceCondition.Used;

    // Requirement:  S4F wants to be able to send out regular (e.g. every month) reminder
    //  emails to people offering devices asking whether the data about the device is still valid.
    public DateTime? LastSuccessfullAvailabilityVarification { get; set; }

    // Requirement: S4F must store [...] 0..many images of the device.
    public List<DeviceImage> Images { get; set; } = new();

    // Requirement: Each device must be assigned to a subcategory.
    public DeviceSubCategory? SubCategory { get; set; }

    public int SubCategoryId { get; set; }

    public List<OfferingTag> Tags { get; set; } = new();

    // Requirement: Users can mark devices that they offer as currently available or currently unavailable.

    public DateTime? UnavailableSince { get; set; }

    public bool IsAvailable => UnavailableSince is null;

    public bool IsUnavailable => UnavailableSince is DateTime;

    // Requirement: Users can store periods of time through which a device will not be available.
    public List<UnavailabilityPeriod> UnavalabilityPeriods { get; set; } = new();

    public List<Sharing> Sharings { get; set; } = new();
}

