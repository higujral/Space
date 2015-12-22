using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using SpaceDataModelClasses;


namespace SpaceDataModel
{
    public class SpaceDBContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryType> StoryTypes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics {get;set;}
        public DbSet<StoryFeedback> StoryFeedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().Property(t => t.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UniqueIndex") { IsUnique = true}));
        }

    }
}
