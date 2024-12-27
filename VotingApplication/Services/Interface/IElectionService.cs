using VotingApplication.DTOs.ElectionDTO;
using VotingApplication.Response;

namespace VotingApplication.Services.Interface
{
    public interface IElectionService
    {
       BaseResponse CreateElection(ElectionRequestModel electionRequest);
       BaseResponse UpdateElection(Guid electionId, ElectionUpdateRequestModel electionUpdateRequest);
        BaseResponse DeleteElection(Guid electionId);
        BaseResponse<ElectionResponseModel> GetElection(Guid electionId);
        BaseResponse<ICollection<ElectionResponseModel>> GetAllElection();
    }
}
