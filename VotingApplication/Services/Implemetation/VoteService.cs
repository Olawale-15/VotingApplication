using VotingApplication.DTOs.VoteDTO;
using VotingApplication.Repositories.Intefaces;
using VotingApplication.Response;
using VotingApplication.Services.Interface;

namespace VotingApplication.Services.Implemetation
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public BaseResponse CreateVote(VoteRequestModel voteRequest)
        {
            throw new NotImplementedException();
        }

        public BaseResponse DeleteVote(Guid voteId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<VoteResponseModel> GetVote(Guid voteId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<ICollection<VoteResponseModel>> GetVotes()
        {
            throw new NotImplementedException();
        }
    }
}
