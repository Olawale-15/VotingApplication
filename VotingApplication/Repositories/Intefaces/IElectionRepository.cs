using VotingApplication.Entities;

namespace VotingApplication.Repositories.Intefaces
{
    public interface IElectionRepository
    {
        void CreateElection(Election election);
        void UpdateElection(Election election);
        void DeleteElection(Election election);
        Election? GetElectionById(Guid Id);
        ICollection<Election> GetAllElections();
        Election? GetElection(Func<Election, bool> predicate);
    }
}
