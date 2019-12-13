using Forum.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.DAL.Implementations
{
    public class ForumsDbContext : DbContext
    {
        public ForumsDbContext(DbContextOptions<ForumsDbContext> options) : base(options)
        {
        }
        public DbSet<Microsoft.AspNetCore.Identity.IdentityUserClaim<int>> IdentityUserClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SubForum> SubForums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
