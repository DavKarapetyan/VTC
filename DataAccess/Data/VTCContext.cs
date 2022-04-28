using VTC.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTC.DataAccess.Data
{
    public class VTCContext : IdentityDbContext<User>
    {
        public VTCContext(DbContextOptions<VTCContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingParticipant> TrainingParticipants { get; set; }
        public DbSet<TrainingLevel> TrainingLevels { get; set; }
        public DbSet<TrainingTopic> TrainingTopics { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
    }
}
