using VotingApplication.DTOs.VoteDTO;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;
using VotingApplication.Response;
using VotingApplication.Services.Interface;

namespace VotingApplication.Services.Implemetation
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IElectionRepository _electionRepository;
        private readonly IVotersRepository _votesRepository;

        public VoteService(IVoteRepository voteRepository, ICandidateRepository candidateRepository, IElectionRepository electionRepository, IVotersRepository votesRepository)
        {
            _voteRepository = voteRepository;
            _candidateRepository = candidateRepository;
            _electionRepository = electionRepository;
            _votesRepository = votesRepository;
        }

        public BaseResponse CreateVote(VoteRequestModel voteRequest)
        {
            var candidate = _candidateRepository.GetCandidateById(voteRequest.CandidateId);
            if (candidate == null)
            {
                return new BaseResponse
                {
                    Message = "Candidate not found",
                    Status = false,
                };
            }

            var election = _electionRepository.GetElectionById(voteRequest.ElectionId);
            if (election == null)
            {
                return new BaseResponse
                {
                    Message = "Election not found",
                    Status = false,
                };
            }

            var voter = _votesRepository.GetVoter(x => x.VotersId == voteRequest.VotersId);
            if (voter == null)
            {
                return new BaseResponse
                {
                    Message = "Voter not found",
                    Status = false,
                };
            }

            if (voter.HasVoted)
            {
                return new BaseResponse
                {
                    Message = "You've already voted",
                    Status = false,
                };
            }

            if (voter.FaceDate == voteRequest.FaceData.ToString())
            {
                return new BaseResponse
                {
                    Message = "You've cast a vote before",
                    Status = false,
                };
            }

            
            var vote = new Vote
            {
                VoteId = Guid.NewGuid(),
                CandidateId = candidate.CandidateId,
                ElectionId = election.ElectionId,
                VotedAt = DateTime.UtcNow,
                VotersId = voter.VotersId,
            };

            _voteRepository.CreateVote(vote);

            candidate.VoteCount += 1;
            _candidateRepository.UpdateCandidate(candidate);

            voter.HasVoted = true;
            _votesRepository.UpdateVoter(voter);

            return new BaseResponse
            {
                Message = "Vote added successfully",
                Status = true
            };
        }


        public BaseResponse DeleteVote(Guid voteId)
        {
            var vote = _voteRepository.GetVote(x => x.VoteId == voteId);
            if(vote == null)
            {
                return new BaseResponse
                {
                    Message = "vote not found",
                    Status = false,
                };
            }

            _voteRepository.DeleteVote(vote);

            return new BaseResponse
            {
                Message = "Vote deleted",
                Status = true
            };
        }

        public BaseResponse<VoteResponseModel> GetVote(Guid voteId)
        {
            var getVote = _voteRepository.GetVote(x => x.VoteId==voteId);
            if(getVote == null)
            {
                return new BaseResponse<VoteResponseModel>
                {
                    Message = "Vote not found",
                    Status = false,
                };
            }

            var vote = new VoteResponseModel
            {
                VoteId = getVote.VoteId,
                ElectionId = getVote.ElectionId,
                CandidateId = getVote.CandidateId,
                VotedAt = getVote.VotedAt,
                VotersId = getVote.VotersId
            };

            return new BaseResponse<VoteResponseModel>
            {
                Data = vote,
                Message = "Vote details",
                Status = true
            };

        }

        public BaseResponse<ICollection<VoteResponseModel>> GetVotes()
        {
            var getVotes = _voteRepository.GetAllVotes();
            if(getVotes == null)
            {
                return new BaseResponse<ICollection<VoteResponseModel>>
                {
                    Message = "Vote not found",
                    Status = false,
                };
            }

            var votes = getVotes.Select(x => new VoteResponseModel
            {
                VoteId = x.VoteId,
                ElectionId = x.ElectionId,
                CandidateId = x.CandidateId,
                VotedAt = x.VotedAt,
                VoteCount = x.VoteCount,
                VotersId = x.VotersId
            }).ToList();

            return new BaseResponse<ICollection<VoteResponseModel>>
            {
                Data = votes,
                Message = "List of votes",
                Status = true
            };
        }
    }
}
