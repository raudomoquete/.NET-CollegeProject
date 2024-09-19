using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;

namespace College.Application.Features.Student.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<GetAllStudentsQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllStudentsQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStudentsQueryHandler(
            IMapper mapper,
            ILogger<GetAllStudentsQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllStudentsQueryResult>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var studentRepository = _unitOfWork.GetRepository<Entity.Student>();
                var students = await studentRepository.GetAllAsync();

                var result = _mapper.Map<List<GetAllStudentsQueryResult>>(students);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students for query: {@request}", request);
                throw;
            }
        }
    }
}
