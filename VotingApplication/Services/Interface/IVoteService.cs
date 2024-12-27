using VotingApplication.DTOs.VoteDTO;
using VotingApplication.Response;

namespace VotingApplication.Services.Interface
{
    public interface IVoteService
    {
        BaseResponse CreateVote(VoteRequestModel voteRequest);
        BaseResponse DeleteVote(Guid voteId);
        BaseResponse<VoteResponseModel> GetVote(Guid voteId);
        BaseResponse<ICollection<VoteResponseModel>> GetVotes();
    }
}
