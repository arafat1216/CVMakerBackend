using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface ICVService
    {
        Task<CVDto> GetCV(string userId);
    }
}
