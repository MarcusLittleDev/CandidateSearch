using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CandidateSearch.Models.Candidates;

namespace CandidateSearch.Models
{
    public class CandidateSearchContext : DbContext
    {
        public CandidateSearchContext()
        {
        }

        public CandidateSearchContext(DbContextOptions<CandidateSearchContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateSearch.Models.Candidates.Candidate> Candidate { get; set; }
        public DbSet<CandidateSearch.Models.Candidates.Qualification> Qualification { get; set; }
    }
}
