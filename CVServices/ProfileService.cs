using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Exceptions;
using CVServices.ServiceModels;

namespace CVServices
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository repository;
        private readonly IMapper mapper;

        public ProfileService(IProfileRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ProfileDto> GetProfile(string userId)
        {
            var response = await repository.GetProfileAsync(userId);

            if (response == null)
                throw new ProfileNotFoundException($"No Profile Found With User Id:{userId}");

            return mapper.Map<ProfileDto>(response);
        }

        public async Task<ProfileDto> UpdateProfile(ProfileDto profile)
        {
            // check if profile exists
            var profileExists = await repository.ProfileExists(profile.UserId);

            if (!profileExists)
            {
                var profileToCreate = mapper.Map<CVServices.Entities.Profile>(profile);

                var response = await repository.CreateProfileAsync(profileToCreate);

                return mapper.Map<ProfileDto>(response);
            }
            else
            {
                var profileToUpdate = await repository.GetProfileAsync(profile.UserId);

                profileToUpdate.FullName = profile.FullName;
                profileToUpdate.Email = profile.Email;
                profileToUpdate.Address = profile.Address;
                profileToUpdate.PhoneNo = profile.PhoneNo;

                var response = await repository.UpdateProfileAsync(profileToUpdate);

                return mapper.Map<ProfileDto>(response);
            }
        }
    }
}
