using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;

namespace College.Application.Features.Student.Queries
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, GetStudentQuery>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetStudentQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentQueryHandler(IMapper mapper, ILogger<GetStudentQueryHandler> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStudentQuery> Handle(GetStudentQuery request, CancellationToken cancellation)
        {
            try
            {
                _logger.LogInformation($"Logged from GetStudentQueryHandler");

                var studentsRepo = _unitOfWork.GetRepository<Domain.Entities.Student>();

                var studentInfo = studentsRepo.GetAllAsync();
                if (studentInfo is null)
                {
                    _logger.LogError("There is no information in the DB or connection could not be made. Try again.");
                    return new GetStudentQuery();
                }

                var queryResults = _mapper.Map<List<StudentQueryResult>>(studentInfo);
                return new GetStudentQuery
                {
                    StudentQueryResults = queryResults,
                    Count = queryResults.Count
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred fetching the informacion.");
                return new GetStudentQuery();
            }
        }
    }
}
