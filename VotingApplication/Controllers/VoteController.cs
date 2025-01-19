using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApplication.DTOs.VoteDTO;
using VotingApplication.Services.Interface;

namespace VotingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController(IVoteService votersService) : ControllerBase
    {
        [HttpPost("Create-vote")]
        public IActionResult CreateVote(VoteRequestModel voteRequestModel)
        {
            votersService.CreateVote(voteRequestModel);
            return Ok();
        }

        [HttpDelete("Delete-vote")]
        public IActionResult DeleteVote(Guid id)
        {
            votersService.DeleteVote(id);   
            return Ok();
        }

        [HttpGet("Get-{id}")]
        public IActionResult GetVote(Guid id)
        {
            var getVote = votersService.GetVote(id);
            return Ok(getVote);
        }

        [HttpGet("Get-votes")]
        public IActionResult GetVotes()
        {
            var getAllVotes = votersService.GetVotes(); 
            return Ok(getAllVotes);
        }
    }
}
