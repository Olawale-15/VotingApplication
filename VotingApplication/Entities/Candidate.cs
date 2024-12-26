namespace VotingApplication.Entities
{
    public class Candidate
    {
        public Guid CandidateId { get; set; }
        public string Name { get; set; } = default!;
        public string Party { get; set; } = default!;
        public Guid ElectionId { get; set; }
        public int VoteCount { get; set; }
    }
}
