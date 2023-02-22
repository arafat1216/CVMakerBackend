using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class SocialLinksService : ISocialLinksService
    {
        private readonly ISocialLinksRepository repository;
        private readonly IMapper mapper;

        public SocialLinksService(ISocialLinksRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<SocialLinkDto> GetSocialLinks(string userId)
        {
            var response = await repository.GetSocialLinksAsync(userId);

            if (response == null)
                throw new Exceptions.SocialLinkNotFoundException($"Social Links Not Found With User Id: {userId}");

            return mapper.Map<SocialLinkDto>(response);
        }

        public async Task<SocialLinkDto> UpdateSocialLinks(SocialLinkDto socialLinkDto)
        {
            //check if social links exists
            var socialLinksExists = await repository.SocialLinksExists(socialLinkDto.UserId);

            if (!socialLinksExists)
            {
                var socialLinksToCreate = mapper.Map<SocialLink>(socialLinkDto);

                var response = await repository.CreateSocialLinksAsync(socialLinksToCreate);

                return mapper.Map<SocialLinkDto>(response);
            }
            else
            {
                var socialLinkToUpdate = await repository.GetSocialLinksAsync(socialLinkDto.UserId);

                socialLinkToUpdate.LinkedinUrl = socialLinkDto.LinkedinUrl;

                socialLinkToUpdate.GithubUrl = socialLinkDto.GithubUrl;

                var response = await repository.UpdateSocialLinksAsync(socialLinkToUpdate);

                return mapper.Map<SocialLinkDto>(response);
            }
        }
    }
}
