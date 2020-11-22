using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contracts;
using WebAPI.ISCSBase;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AuthenticationContext _context;

        public CandidateService(AuthenticationContext context)
        {
            _context = context;
        }


        public Task<Response> AddCandidateAsync(Candidates candidates)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DelateCandidateAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Candidates>> GetCandidateDetails()
        {
            var candidateResult = _context.Candidates.ToList();
            return (Task<IEnumerable<Candidates>>)candidateResult.AsEnumerable();
        }

        public Task<Candidates> GetCandidateInformationAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateCandidateAsync(Candidates candidates, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
