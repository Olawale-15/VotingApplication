using VotingApplication.DataBase;
using VotingApplication.Entities;
using VotingApplication.Repositories.Intefaces;

namespace VotingApplication.Repositories.Implementations
{
    public class CandidateRepository : ICandidateRepository
    {
     

        public void CreateCandidate(Candidate candidate)
        {
            ContextClass.Candidate.Add(candidate);
            
        }

        public void DeleteCandidate(Candidate candidate)
        {
            ContextClass.Candidate.Remove(candidate);
        }

        public ICollection<Candidate> GetAllCandidates()
        {
            return ContextClass.Candidate.ToList();
            
        }

        public Candidate? GetCandidate(Func<Candidate, bool> predicate)
        {
            var getCandidate = ContextClass.Candidate.FirstOrDefault(predicate);
            return getCandidate;
        }

        public Candidate? GetCandidateById(Guid Id)
        {
            var getCandidateById = ContextClass.Candidate.FirstOrDefault(c => c.CandidateId  == Id);
            return getCandidateById;
        }

        public void UpdateCandidate(Candidate candidate)
        {
            var existingCandidate = ContextClass.Candidate.FirstOrDefault(x => x.CandidateId == candidate.CandidateId);
            if (existingCandidate != null)
            {
                existingCandidate.Name = candidate.Name;
                existingCandidate.Party = candidate.Party;
                existingCandidate.VoteCount = candidate.VoteCount;
            }
            else
            {
                throw new KeyNotFoundException("Candidate not found");
            }
        }
    }
}
