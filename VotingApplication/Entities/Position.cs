namespace VotingApplication.Entities
{
    public class Position
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsDeleted { get; set; }
        public bool IsAvailable {  get; set; }
        public Guid ElectionId { get; set; }

    }
}
