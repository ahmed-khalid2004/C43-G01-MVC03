using AutoMapper;
using MVC03.BusinessLogic.DataTransferObjects;
using MVC03.DataAccess.Models.DepartmentModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatedDepartmentDto, Department>();
    }
}
