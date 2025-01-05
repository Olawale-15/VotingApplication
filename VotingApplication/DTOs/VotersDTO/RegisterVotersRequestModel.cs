namespace VotingApplication.DTOs.VotersDTO
{
    public class RegisterVotersRequestModel
    {
        public required string VotersCardNumber { get; set; }
        public bool HasVoted { get; set; }
        public DateTime VotedAt { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public required IFormFile FaceData { get; set; }
    }
}
