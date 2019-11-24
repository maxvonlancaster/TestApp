using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicTracks.Models
{
    public class MusicTracksContext : IdentityDbContext
    {
        public MusicTracksContext (DbContextOptions<MusicTracksContext> options)
            : base(options)
        {
        }

        public DbSet<MusicTracks.Models.MusicTrack> MusicTrack { get; set; }
        public DbSet<UserIdentity> Identities { get; set; }
    }
}
