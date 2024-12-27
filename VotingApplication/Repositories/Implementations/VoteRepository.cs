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
            var existingVote = ContextClass.Votes.FirstOrDefault(x => x.VoteId == vote.VoteId);
            if (existingVote != null)
            {
                existingVote.VoteCount = vote.VoteCount;
                
            }
            else
            {
                throw new KeyNotFoundException("Vote not found");
            }
        }

        public ICollection<Vote> GetAllVotes()
        {
            var getAllVotes = ContextClass.Votes.ToList();
            return getAllVotes;
        }
    }
}
