using VotingApplication.DTOs.ElectionDTO;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;
using VotingApplication.Response;
using VotingApplication.Services.Interface;

namespace VotingApplication.Services.Implemetation
{
    public class ElectionService:IElectionService
    {
        private readonly IElectionRepository _electionRepository;

        public ElectionService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public BaseResponse CreateElection(ElectionRequestModel electionRequest)
        {
            
            var election = new Election
            {
                Title = electionRequest.Title,
                Description = electionRequest.Description,
                StartDate = electionRequest.StartDate,
                EndDate = electionRequest.EndDate,
            };
            _electionRepository.CreateElection(election);
            return new BaseResponse
            {
                Message = "Election created successfully",
                Status = true
            };
        }

        public BaseResponse DeleteElection(Guid electionId)
        {
            var election = _electionRepository.GetElectionById(electionId);
            if(election == null)
            {
                return new BaseResponse
                {
                    Message = "Election not found",
                    Status = false
                };
            }

            _electionRepository.DeleteElection(election);
            return new BaseResponse
            {
                Message = "Election deleted successfully",
                Status = true
            };
        }

        public BaseResponse<ICollection<ElectionResponseModel>> GetAllElection()
        {
            var elections = _electionRepository.GetAllElections();
            if(elections == null)
            {
                return new BaseResponse<ICollection<ElectionResponseModel>>
                {
                    Message = "Elections not found",
                    Status = false
                };
            }

            var getElections = elections.Select(x => new ElectionResponseModel
            {
                ElectionId = x.ElectionId,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            }).ToList();

            return new BaseResponse<ICollection<ElectionResponseModel>>
            {
                Data = getElections,
                Message = "Elections",
                Status = true
            };
        }

        public BaseResponse<ElectionResponseModel> GetElection(Guid electionId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateElection(ElectionUpdateRequestModel electionUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
