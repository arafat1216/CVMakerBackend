using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class SummaryService : ISummaryService
    {
        private readonly ISummaryRepository repository;
        private readonly IMapper mapper;

        public SummaryService(ISummaryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<SummaryDto> GetSummary(string userId)
        {
            var response = await repository.GetSummaryAsync(userId);

            if (response == null)
                throw new Exceptions.SummaryNotFoundException($"Summary Not Found With User Id: {userId}");

            return mapper.Map<SummaryDto>(response);
        }

        public async Task<SummaryDto> UpdateSummary(SummaryDto summary)
        {
            var summaryExists = await repository.SummaryExists(summary.UserId);

            if (!summaryExists)
            {
                var summaryToCreate = mapper.Map<Summary>(summary);

                var response = await repository.CreateSummaryAsync(summaryToCreate);

                return mapper.Map<SummaryDto>(response);
            }
            else
            {
                var summaryToUpdate = await repository.GetSummaryAsync(summary.UserId);

                summaryToUpdate.Description = summary.Description;

                var response = await repository.UpdateSummaryAsync(summaryToUpdate);

                return mapper.Map<SummaryDto>(response);
            }
        }
    }
}
