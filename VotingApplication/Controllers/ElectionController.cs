using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApplication.DTOs.ElectionDTO;
using VotingApplication.Services.Interface;

namespace VotingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController(IElectionService electionService) : ControllerBase
    {
        [HttpPost("Create-election")]
        public IActionResult CreateElection(ElectionRequestModel electionRequest)
        {
            electionService.CreateElection(electionRequest);
            return Ok();
        }

        [HttpPost("Update-election")]
        public IActionResult UpdateElection(ElectionUpdateRequestModel electionRequest, Guid id)
        {
            electionService.UpdateElection(id, electionRequest);
            return Ok(); 
        }

        [HttpDelete("Delete-election")]
        public IActionResult DeleteElection(Guid id)
        {
            electionService.DeleteElection(id);
            return Ok();
        }

        [HttpGet("Get Election-{id}")]
        public IActionResult GetElection(Guid id)
        {
            var getElection = electionService.GetElection(id);
            return Ok(getElection);
        }

        [HttpGet("GetAll-election")]
        public IActionResult GetAllElection()
        {
           var getAllElection = electionService.GetAllElection();
            return Ok(getAllElection);
        }
    }
}
