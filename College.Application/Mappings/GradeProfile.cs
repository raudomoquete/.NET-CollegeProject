using AutoMapper;
using College.Application.Features.Grade.Commands;
using College.Application.Features.Grade.Queries;
using College.Domain.Entities;

namespace College.Application.Mappings
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<AddGradeCommand, Grade>()
                .ConstructUsing(src => new Grade
                {
                    Name = src.Name,
                });

            CreateMap<Grade, AddGradeResult>()
               .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
               .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Grade added successfully"));

            CreateMap<Grade, GetAllGradesQueryResult>()
                .ConstructUsing(
                    src =>
                        new GetAllGradesQueryResult(
                            src.GradeId,
                            src.Name,
                            src.TeacherId,
                            src.Teacher,
                            src.AlternativeId,
                            src.CreatedDate,
                            src.ModifiedDate ?? DateTime.MinValue
                        )

                )
                .ReverseMap();

            CreateMap<UpdateGradeCommand, Grade>()
            .ForMember(dest => dest.GradeId, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Grade, UpdateGradeResult>()
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Grade updated successfully"));
        }
    }
}
