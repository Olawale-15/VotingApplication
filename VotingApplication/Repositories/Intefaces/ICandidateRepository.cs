using VotingApplication.Entities;

namespace VotingApplication.Repositories.Intefaces
{
    public interface ICandidateRepository
    {
        void CreateCandidate(Candidate candidate);
        void UpdateCandidate(Candidate candidate);
        void DeleteCandidate(Candidate candidate);
        Candidate? GetCandidateById(Guid Id);
        ICollection<Candidate> GetAllCandidates();
        Candidate? GetCandidate(Func<Candidate, bool> predicate);
    }
}
