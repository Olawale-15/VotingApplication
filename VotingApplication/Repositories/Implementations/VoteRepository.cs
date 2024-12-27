using VotingApplication.DataBase;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;

namespace VotingApplication.Repositories.Implementations
{
    public class VoteRepository : IVoteRepository
    {
        public void CreateVote(Vote vote)
        {
            ContextClass.Votes.Add(vote);
        }

        public void DeleteVote(Vote vote)
        {
            ContextClass.Votes.Remove(vote);
        }

        public Vote? GetVote(Func<Vote, bool> predicate)
        {
            var getVote = ContextClass.Votes.FirstOrDefault(predicate);
            return getVote;
        }

        public void UpdateVote(Vote vote)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vote> GetAllVotes()
        {
            var getAllVotes = ContextClass.Votes.ToList();
            return getAllVotes;
        }
    }
}
