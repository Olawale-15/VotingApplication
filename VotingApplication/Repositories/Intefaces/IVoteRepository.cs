using VotingApplication.Entities;

namespace VotingApplication.Repositories.Intefaces
{
    public interface IVoteRepository
    {
        void CreateVote(Vote vote);
        void UpdateVote(Vote vote);
        void DeleteVote(Vote vote);
        Vote? GetVote(Func<Vote, bool> predicate);
        ICollection<Vote> GetAllVotes();
    }
}
