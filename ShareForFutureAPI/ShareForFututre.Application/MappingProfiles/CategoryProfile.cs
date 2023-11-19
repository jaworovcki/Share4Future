namespace ShareForFututre.Application.MappingProfiles;
using AutoMapper;
using ShareForFuture.Domain.DomainModels;
using ShareForFututre.Application.Features.Category.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<DeviceCategory, DeviceCategoryDto>().ReverseMap();
    }
}

