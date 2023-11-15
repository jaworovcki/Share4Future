namespace ShareForFututre.Application.Features.Category.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeviceSubCategoryDto
{
    public string Title { get; set; } = string.Empty;

    public List<DeviceCategoryDto> Categories { get; set; } = new();
}

