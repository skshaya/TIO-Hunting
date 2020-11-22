using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Application.Queries
{
    public class CandidateQueryHandler : IRequestHandler<CandidateQuery, IEnumerable<Candidates>>
    {
        private readonly ICandidateService candidateService;

        public CandidateQueryHandler(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }
        public async Task<IEnumerable<Candidates>> Handle(CandidateQuery request, CancellationToken cancellationToken)
        {
            return await candidateService.GetCandidateDetails();
        }
    }
}
