using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ISCSBase;
using WebAPI.Models;

namespace WebAPI.Contracts
{
    public interface ICandidateService  : ISCSBaseDetails
    {
        Task<IEnumerable<Candidates>> GetCandidateDetails();

        Task<Candidates> GetCandidateInformationAsync(int Id);

        Task<Response> AddCandidateAsync(Candidates candidates);
        Task<Response> UpdateCandidateAsync(Candidates candidates, int Id);

        Task<Response> DelateCandidateAsync(int Id);
    }
}
