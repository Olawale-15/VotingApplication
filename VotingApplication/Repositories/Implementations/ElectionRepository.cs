using VotingApplication.DataBase;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;

namespace VotingApplication.Repositories.Implementations
{
    public class ElectionRepository : IElectionRepository
    {
        public void CreateElection(Election election)
        {
            ContextClass.Elections.Add(election);
        }

        public void DeleteElection(Election election)
        {
            ContextClass.Elections.Remove(election);
        }

        public ICollection<Election> GetAllElections()
        {
            var getAllElections = ContextClass.Elections.ToList();
            return getAllElections;
        }

        public Election? GetElection(Func<Election, bool> predicate)
        {
            var getElection = ContextClass.Elections.FirstOrDefault(predicate);
            return getElection;
        }

        public Election? GetElectionById(Guid Id)
        {
            var getElection = ContextClass.Elections.FirstOrDefault(x => x.ElectionId == Id);
            return getElection;
        }

        public void UpdateElection(Election election)
        {
            throw new NotImplementedException();
        }
    }
}
