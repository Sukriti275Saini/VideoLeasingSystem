using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoLeasingSystem.Core;

namespace VideoLeasingSystem.Data
{
    public class VideoSystemDbContext : DbContext
    {

        public VideoSystemDbContext(DbContextOptions<VideoSystemDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<UserMovieRecord> Records { get; set; }
    }
}
