using AutoMapper;
using College.Application.Features.Student.Commands;
using College.Application.Features.Student.Queries;
using College.Domain.Entities;

namespace College.Application.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<AddStudentCommand, Student>()
                .ConstructUsing(src => new Student
                {
                    Name = src.Name,
                    LastName = src.LastName,
                    Gender = src.Gender,
                    BirthDate = src.BirthDate.Date
                });

            CreateMap<Student, AddStudentResult>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Student added successfully"));

            CreateMap<Student, GetAllStudentsQueryResult>()
                .ConstructUsing(
                    src =>
                        new GetAllStudentsQueryResult(
                            src.StudentId,
                            src.Name,
                            src.LastName,
                            src.Gender,
                            src.BirthDate,
                            src.AlternativeId,
                            src.CreatedDate,
                            src.ModifiedDate ?? DateTime.MinValue
                        )

                )
                .ReverseMap();

            CreateMap<UpdateStudentCommand, Student>()
            .ForMember(dest => dest.StudentId, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Student, UpdateStudentResult>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Student updated successfully"));

        }
    }
}
