using VotingApplication.DTOs.CandidateDTO;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;
using VotingApplication.Response;
using VotingApplication.Services.Interface;

namespace VotingApplication.Services.Implemetation
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IElectionRepository _electionRepository;

        public CandidateService(ICandidateRepository candidateRepository, IElectionRepository electionRepository)
        {
            _candidateRepository = candidateRepository;
            _electionRepository = electionRepository;
        }

        public BaseResponse CreateCandidate(CandidateRequestModel candidateRequestModel)
        {
            var getElection = _electionRepository.GetElectionById(candidateRequestModel.ElectionId);
            if (getElection == null)
            {
                return new BaseResponse
                {
                    Message = "Election not found",
                    Status = false,
                };
            }

            var candidate = new Candidate
            {
                CandidateId = Guid.NewGuid(),
                Name = candidateRequestModel.Name,
                Party = candidateRequestModel.Party,
                Email = candidateRequestModel.Email,
                PhoneNumber = candidateRequestModel.PhoneNumber,
                Password = candidateRequestModel.Password,
                ElectionId = getElection.ElectionId,
                VoteCount = 0
            };
            _candidateRepository.CreateCandidate(candidate);
            return new BaseResponse
            {
                Message = "Candidate created",
                Status = true,
            };
        }

        public BaseResponse DeleteCandidate(Guid candidateId)
        {
            var getCandidate = _candidateRepository.GetCandidateById(candidateId);
            if(getCandidate == null)
            {
                return new BaseResponse
                {
                    Message = "Candidate not found",
                    Status = false,
                };
            }

            _candidateRepository.DeleteCandidate(getCandidate);
            return new BaseResponse
            {
                Message = "Candidate deleted sucessful",
                Status = true,
            };
        }

        public BaseResponse<CandidateResponseModel> GetCandidate(Guid candidateId)
        {
            var getCandidate = _candidateRepository.GetCandidateById(candidateId);
            if(getCandidate == null)
            {
                return new BaseResponse<CandidateResponseModel>
                {
                    Message = "Candidate not found",
                    Status = false,
                };
            }

            var candidate = new CandidateResponseModel
            {
                CandidateId = getCandidate.CandidateId,
                Name = getCandidate.Name,
                Party = getCandidate.Party,
                ElectionId = getCandidate.ElectionId,
                VoteCount = getCandidate.VoteCount,
            };

            return new BaseResponse<CandidateResponseModel>
            {
                Data = candidate,
                Message = "Candidate found",
                Status = true,
            };
        }

        public BaseResponse<ICollection<CandidateResponseModel>> GetCandidates()
        {
            var getCandidates = _candidateRepository.GetAllCandidates();
            if(getCandidates == null)
            {
                return new BaseResponse<ICollection<CandidateResponseModel>>
                {
                    Message = "candidates not found",
                    Status = false,
                };
            }

            var candidates = getCandidates.Select(x => new CandidateResponseModel
            {
                CandidateId = x.CandidateId,
                Name = x.Name,
                Party = x.Party,
                ElectionId = x.ElectionId,
                VoteCount= x.VoteCount,
            }).ToList();

            return new BaseResponse<ICollection<CandidateResponseModel>>
            {
                Data = candidates,
                Message = "List of all candidate",
                Status = true,
            };
        }

        public BaseResponse UpdateCandidate(Guid candidateId, UpdateCandidateRequestModel candidateRequestModel)
        {
            var candidate = _candidateRepository.GetCandidateById(candidateId);
            if(candidate == null)
            {
                return new BaseResponse
                {
                    Message = "Candidate not found",
                    Status = false,
                };
            }

            candidate.Name = candidateRequestModel.Name;
            candidate.Party = candidateRequestModel.Party;
            candidate.VoteCount = candidateRequestModel.VoteCount;

            _candidateRepository.UpdateCandidate(candidate);

            return new BaseResponse
            {
                Message = "Candidate updated successfully",
                Status = true,
            };
        }
    }
}
