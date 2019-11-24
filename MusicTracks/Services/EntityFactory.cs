using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicTracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Services
{
    public class EntityFactory : IDesignTimeDbContextFactory<MusicTracksContext>
    {
        public MusicTracksContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicTracksContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusicTracksContext;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new MusicTracksContext(optionsBuilder.Options);
        }
    }
}
