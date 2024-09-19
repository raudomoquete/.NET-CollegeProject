using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using College.Application.Interfaces.Persistence;
using Entity = College.Domain.Entities;


namespace College.Application.Features.Grade.Queries
{
    public class GetAllGradesQueryHandler : IRequestHandler<GetAllGradesQuery, List<GetAllGradesQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllGradesQueryHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGradesQueryHandler(
            IMapper mapper,
            ILogger<GetAllGradesQueryHandler> logger,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllGradesQueryResult>> Handle(GetAllGradesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var gradeRepository = _unitOfWork.GetRepository<Entity.Grade>();
                var grades = await gradeRepository.GetAllAsync();

                var result = _mapper.Map<List<GetAllGradesQueryResult>>(grades);
                return result;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error retrieving grades for query: {@request}", request);
                throw;
            }
        }
    }
}
