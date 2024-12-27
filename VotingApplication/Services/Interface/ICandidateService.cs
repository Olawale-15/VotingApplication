using VotingApplication.DTOs.CandidateDTO;
using VotingApplication.Response;

namespace VotingApplication.Services.Interface
{
    public interface ICandidateService
    {
        BaseResponse CreateCandidate(CandidateRequestModel candidateRequestModel);
        BaseResponse DeleteCandidate(Guid candidateId);
        BaseResponse<CandidateResponseModel> GetCandidate(Guid candidateId);
        BaseResponse<ICollection<CandidateResponseModel>> GetCandidates();
    }
}
