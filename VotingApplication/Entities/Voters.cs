namespace VotingApplication.Entities
{
    public class Voters
    {
        public Guid VotersId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public required string VotersCardNumber { get; set; }
        public string Password { get; set; } = default!;
        public bool HasVoted { get; set; }
        public DateTime VotedAt { get; set; }
        public required string FaceDate { get; set; }    
    }
}
