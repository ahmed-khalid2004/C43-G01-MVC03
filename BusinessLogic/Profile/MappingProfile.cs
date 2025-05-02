using AutoMapper;
using BusinessLogic.DataTransferObjects.DepartmentDtos;
using MVC03.BusinessLogic.DataTransferObjects.EmployeeDtos;
using MVC03.DataAccess.Models.DepartmentModel;
using MVC03.DataAccess.Models.EmployeeModel;

namespace MVC03.BusinessLogic.Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dist => dist.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmpType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}