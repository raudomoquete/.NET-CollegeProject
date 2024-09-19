using AutoMapper;
using College.Application.Features.Teacher.Command;
using College.Application.Features.Teacher.Commands;
using College.Application.Features.Teacher.Queries;
using College.Domain.Entities;

namespace College.Application.Mappings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<AddTeacherCommand, Teacher>()
               .ConstructUsing(src => new Teacher
               {
                   Name = src.Name,
                   LastName = src.LastName,
                   Gender = src.Gender,
               });

            CreateMap<Teacher, AddTeacherResult>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Teacher added successfully"));

            CreateMap<Teacher, GetAllTeachersQueryResult>()
                .ConstructUsing(
                    src =>
                        new GetAllTeachersQueryResult(
                            src.TeacherId,
                            src.Name,
                            src.LastName,
                            src.Gender,
                            src.AlternativeId,
                            src.CreatedDate,
                            src.ModifiedDate ?? DateTime.MinValue
                        )

                )
                .ReverseMap();

            CreateMap<UpdateTeacherCommand, Teacher>()
            .ForMember(dest => dest.TeacherId, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Teacher, UpdateTeacherResult>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Teacher updated successfully"));

        }
    }
}
