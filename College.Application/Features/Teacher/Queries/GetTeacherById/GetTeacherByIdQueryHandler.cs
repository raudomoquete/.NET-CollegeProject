using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Teacher.Queries
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, GetTeacherQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetTeacherByIdQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetTeacherByIdQueryHandler(
            IMapper mapper,
            ILogger<GetTeacherByIdQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTeacherQueryResult> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacherRepository = _unitOfWork.GetRepository<Entity.Teacher>();
            var student = await teacherRepository.GetById(request.TeacherId);
            if (student == null)
            {
                return null;
            }

            return new GetTeacherQueryResult(
                student.TeacherId,
                student.Name,
                student.LastName,
                student.Gender
            );
        }
    }
}
