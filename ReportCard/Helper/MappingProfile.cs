using AutoMapper;
using DataModels;
using ReportCard.DTOModels;

namespace ReportCard.Helper
{
    /// <summary>
    /// Профили конвертации данных для AutoMapper из БД в DTO и обратно
    /// </summary>
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(to => to.Department, from => from.MapFrom(m => m.Dep.Name))
                .ForMember(to => to.DepId, from => from.MapFrom(m => m.Dep.DepId))
                .ReverseMap();
            CreateMap<Department, DepartmentDTO>()
                .ForMember(to => to.Employees, from => from.MapFrom(m => m.Fkempdeps))
                .ReverseMap();
            CreateMap<Report, ReportDTO.WorkDay>()
                .ForMember(to => to.WDay, from => from.MapFrom(m => m.WorkDate))
                .ForMember(to => to.DayCode, from => from.MapFrom(m => m.Code));
            CreateMap<Employee, ReportDTO>()
                .ForMember(to => to.EmpId, from => from.MapFrom(m => m.EmpID))
                .ForMember(to => to.FIO, from => from.MapFrom(m => $"{m.LastName} {m.FirstName}{(string.IsNullOrEmpty(m.MiddleName) ? "" : " " + m.MiddleName)}"))
                .ForMember(to => to.Post, from => from.MapFrom(m => m.Post))
                .ForMember(to => to.WorkDays, from => from.MapFrom(m => m.Fkremps));
            CreateMap<Calendar, CalendarDTO>().ReverseMap();
            CreateMap<DayCode, DayCodeDTO>()
                .ForMember(to => to.Description, from => from.MapFrom(m => m.Name))
                .ReverseMap();

        }
    }
}
