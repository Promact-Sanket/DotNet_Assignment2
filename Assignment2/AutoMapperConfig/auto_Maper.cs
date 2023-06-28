using Assignment2.DTO;
using Assignment2.Model;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace Assignment2.AutoMapperConfig
{
    public class auto_Maper : Profile
    {
        public auto_Maper()
        {
            CreateMap<ResDepartmentDto, Department>()
                    .ReverseMap();

            CreateMap<DepartmentDto, Department>()
                   .ReverseMap();

            CreateMap<ResEmployeeDto, Employee>()
                .ReverseMap();

            CreateMap<EmployeeDto, Employee>()
                .ReverseMap();

        }

    }
}
