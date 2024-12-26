namespace VotingApplication.Entities
{
    public class Election
    {
        public Guid ElectionId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
