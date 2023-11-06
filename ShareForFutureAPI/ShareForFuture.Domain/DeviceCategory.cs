namespace ShareForFuture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DeviceCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    // Requirement: Each category consists of a list of subcategories.
    public List<DeviceSubCategory> SubCategories { get; set; } = new();
}

