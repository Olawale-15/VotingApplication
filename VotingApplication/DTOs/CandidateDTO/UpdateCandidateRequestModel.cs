namespace VotingApplication.DTOs.CandidateDTO
{
    public class UpdateCandidateRequestModel
    {
        public string Name { get; set; } = default!;
        public string Party { get; set; } = default!;
        public int VoteCount { get; set; }
    }
}
