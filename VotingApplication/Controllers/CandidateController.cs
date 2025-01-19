using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApplication.DTOs.CandidateDTO;
using VotingApplication.Services.Interface;

namespace VotingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController(ICandidateService candidateService) : ControllerBase
    {
        [HttpPost("Register-candidate")]
        public IActionResult RegisterCandidate(CandidateRequestModel candidateRequestModel)
        {
            candidateService.CreateCandidate(candidateRequestModel);
            return Ok();
        }

        [HttpPost("Update-candidate")]
        public IActionResult UpdateCandidate(Guid id, UpdateCandidateRequestModel updateCandidateRequest)
        {
            candidateService.UpdateCandidate(id, updateCandidateRequest);
            return Ok();
        }

        [HttpDelete("Delete-candidate")]
        public IActionResult DeleteCandidate(Guid id)
        {
            candidateService.DeleteCandidate(id);
            return Ok();
        }

        [HttpGet("Get Candidate-{id}")]
        public IActionResult GetCandidate(Guid id)
        {
            var getCandidate = candidateService.GetCandidate(id);
            return Ok(getCandidate);
        }

        [HttpGet("GetAll-candidate")]
        public IActionResult GetAllCandidate()
        {
            var getAllCandidate = candidateService.GetCandidates();
            return Ok(getAllCandidate);
        }
    }
}
