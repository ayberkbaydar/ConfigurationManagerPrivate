using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Type = ConfigurationManager.Core.Models.Type;
using File = ConfigurationManager.Core.Models.File;
//using Environment = ConfigurationManager.Core.Models.Environment;
//using ConfigurationManager.Core.Models.ParameterObjects;

namespace ConfigurationManager.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Type> Types { get; set; }
        //public DbSet<Template> Templates { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ParameterValue> ParameterValues { get; set; }
        //public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<FileVersion> FileVersions { get; set; }
        public DbSet<File> Files { get; set; }
        //public DbSet<Environment> Environments { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        //public DbSet<Cluster> Clusters { get; set; }
        //public DbSet<AuditLog> AuditLogs { get; set; }
        //public DbSet<TextBox> TextBoxes { get; set; }
        //public DbSet<TextArea> TextAreas { get; set; }
        //public DbSet<NumberBox> NumberBoxes { get; set; }
        //public DbSet<Date> Dates { get; set; }
        //public DbSet<Json> Jsons { get; set; }
        //public DbSet<ComboBox> ComboBoxes { get; set; }
        //public DbSet<CheckBox> CheckBoxes { get; set; }
        //public DbSet<Switch> Switches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
