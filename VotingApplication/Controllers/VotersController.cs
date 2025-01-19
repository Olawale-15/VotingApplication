using Microsoft.AspNetCore.Mvc;
using VotingApplication.DTOs.VotersDTO;
using VotingApplication.Services.Interface;

namespace VotingApplication.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VotersController(IVotersService voters) : ControllerBase
    {
        [HttpPost("Register-voter")]
        public IActionResult RegisterVoters(RegisterVotersRequestModel requestModel)
        {
            voters.RegisterVoter(requestModel);
            return Ok();
        }
    }
}
