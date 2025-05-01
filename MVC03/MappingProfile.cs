using AutoMapper;
using BusinessLogic.DataTransferObjects.DepartmentDtos;
using MVC03.DataAccess.Models.DepartmentModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatedDepartmentDto, Department>();
    }
}
