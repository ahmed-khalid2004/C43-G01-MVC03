using AutoMapper;
using MVC03.DataTransferObjects;
using MVC03.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatedDepartmentDto, Department>();
    }
}
