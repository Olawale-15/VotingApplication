using Microsoft.AspNetCore.Mvc;
using VotingApplication.DTOs.VotersDTO;
using VotingApplication.Services.Interface;

namespace VotingApplication.Controllers
{
    public class VotersController(IVotersService voters) : Controller
    {
        public IActionResult RegisterVoters()
        {
            return View();
        }

        [HttpPost("Register-voter")]
        public IActionResult RegisterVoters(RegisterVotersRequestModel requestModel)
        {
            voters.RegisterVoter(requestModel);
            return View();
        }
    }
}
