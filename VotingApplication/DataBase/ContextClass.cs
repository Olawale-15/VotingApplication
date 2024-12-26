using VotingApplication.Entities;

namespace VotingApplication.DataBase
{
    public static class ContextClass
    {
        public static ICollection<Candidate> Candidate = new List<Candidate>();
        public static ICollection<Election> Elections = new List<Election>();
        public static ICollection<Vote> Votes = new List<Vote>();
        public static ICollection<Voters> Voters = new HashSet<Voters>();
    }
}
