namespace VotingApplication.DTOs.VoteDTO
{
    public class VoteRequestModel
    {
        public Guid VotersId { get; set; }
        public Guid ElectionId { get; set; }
        public Guid CandidateId { get; set; }
        public DateTime VotedAt { get; set; }
        public int VoteCount { get; set; }
    }
}
