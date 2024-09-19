using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;

namespace College.Application.Features.Teacher.Queries
{
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, GetTeacherQuery>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetTeacherQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetTeacherQueryHandler(
            IMapper mapper, 
            ILogger<GetTeacherQueryHandler> logger, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTeacherQuery> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Logged from GetTeachertQueryHandler");

                var steacherRepo = _unitOfWork.GetRepository<Domain.Entities.Teacher>();

                var teacherInfo = steacherRepo.GetAllAsync();
                if (teacherInfo is null)
                {
                    _logger.LogError("There is no information in the DB or connection could not be made. Try again.");
                    return new GetTeacherQuery();
                }

                var queryResults = _mapper.Map<List<GetTeacherQueryResult>>(teacherInfo);
                return new GetTeacherQuery
                {
                    TeacherQueryResults = queryResults,
                    Count = queryResults.Count
                };
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error ocurred fetching the informacion.");
                return new GetTeacherQuery();

            }
        }
    }
}
