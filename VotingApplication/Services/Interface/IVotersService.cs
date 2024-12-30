using VotingApplication.DTOs.VotersDTO;
using VotingApplication.Response;

namespace VotingApplication.Services.Interface
{
    public interface IVotersService
    {
        void RegisterVoter(RegisterVotersRequestModel request);
    }
}
