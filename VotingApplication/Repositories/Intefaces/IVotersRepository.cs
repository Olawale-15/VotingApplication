using VotingApplication.Entities;

namespace VotingApplication.Repositories.Intefaces
{
    public interface IVotersRepository
    {
        void CreateVoter(Voters voter);
        void UpdateVoter(Voters voter);
        void DeleteVoter(Voters voter);
        Voters? GetVoter(Func<Voters, bool> predicate);
        ICollection<Voters> GetAllVoters();
    }
}
