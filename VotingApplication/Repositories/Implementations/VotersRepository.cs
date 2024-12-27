using VotingApplication.DataBase;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;

namespace VotingApplication.Repositories.Implementations
{
    public class VotersRepository : IVotersRepository
    {
        public void CreateVoter(Voters voter)
        {
            ContextClass.Voters.Add(voter);
        }

        public void DeleteVoter(Voters voter)
        {
            ContextClass.Voters.Remove(voter);
        }

        public ICollection<Voters> GetAllVoters()
        {
            var getAllVoters = ContextClass.Voters.ToList();
            return getAllVoters;
        }

        public Voters? GetVoter(Func<Voters, bool> predicate)
        {
            var getVoters = ContextClass.Voters.FirstOrDefault(predicate);
            return getVoters;
        }

        public void UpdateVoter(Voters voter)
        {
            throw new NotImplementedException();
        }
    }
}
