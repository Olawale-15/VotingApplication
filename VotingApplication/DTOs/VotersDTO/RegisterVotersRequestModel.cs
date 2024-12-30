namespace VotingApplication.DTOs.VotersDTO
{
    public class RegisterVotersRequestModel
    {
        public required string VotersCardNumber { get; set; }
        public bool HasVoted { get; set; }
        public DateTime VotedAt { get; set; }
        public required IFormFile FaceData { get; set; }
    }
}
