using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebAPI.Models;

namespace WebAPI.Application.Queries
{
    public class CandidateQuery: IRequest<IEnumerable<Candidates>>
    {
        public int Id { get; set; }
    }
}
