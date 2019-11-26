using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicTracks.Models;

namespace MusicTracks.Models
{
    public class MusicTracksContext : IdentityDbContext<UserIdentity, IdentityRole<string>, string>
    {
        public MusicTracksContext (DbContextOptions<MusicTracksContext> options)
            : base(options)
        {
        }

        public DbSet<MusicTracks.Models.MusicTrack> MusicTrack { get; set; }
        public DbSet<UserIdentity> Identities { get; set; }
        //public DbSet<MusicTracks.Models.LoginViewModel> LoginViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserIdentity>().ToTable("AspNetUsers");
            base.OnModelCreating(builder);
        }
    }

}
