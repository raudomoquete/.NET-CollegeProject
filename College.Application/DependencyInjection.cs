using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using College.Application.Behaviors;
using College.Application.Features.Grade.Commands;
using College.Application.Features.Grade.Queries;
using College.Application.Features.GradeStudent.Command;
using College.Application.Features.GradeStudent.Queries;
using College.Application.Features.Student.Commands;
using College.Application.Features.Student.Queries;
using College.Application.Features.Student.Queries.GetAllStudents;
using College.Application.Features.Teacher.Command;
using College.Application.Features.Teacher.Commands;
using College.Application.Features.Teacher.Queries;

namespace College.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddAutoMapper(assembly);
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(assembly);

                //student Handlers
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllStudentsQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RemoveStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetStudentByIdQueryHandler).Assembly));

                //teacher Handlers
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddTeacherCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RemoveTeacherCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateTeacherCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetTeacherByIdQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetTeacherQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllTeachersQueryHandler).Assembly));

                //grade Handlers
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddGradeCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateGradeCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RemoveGradeCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetGradesQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllGradesQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetGradeByIdQueryHandler).Assembly));

                //gradeStudent Handlers
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddGradeStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RemoveGradeStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateGradeStudentCommandHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllGradeStudentsQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetGradeStudentQueryHandler).Assembly));

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetGradeStudentByIdQueryHandler).Assembly));


                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
