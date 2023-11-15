namespace ShareForFututre.Application.Features.Category.Queries.GetCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetCategoryQuery(int Id) : IRequest<DeviceCategoryDto>; 
