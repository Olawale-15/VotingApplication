namespace VotingApplication.Entities
{
    public class Vote
    {
        public Guid VoteId { get; set; }
        public Guid VotersId { get; set; }
        public Guid ElectionId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid PositionId { get; set; }
        public DateTime VotedAt { get; set; }
        public int VoteCount { get; set; }
    }
}
