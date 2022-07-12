using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackingApi.Models;

    public class PoliticalCandidateContext : DbContext
    {
        public PoliticalCandidateContext (DbContextOptions<PoliticalCandidateContext> options)
            : base(options)
        {
        }

        public DbSet<TrackingApi.Models.PoliticalCandidate> PoliticalCandidate { get; set; } = default!;
    }
