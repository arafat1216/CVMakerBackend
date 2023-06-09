﻿using CVServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Context
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

    }
}
