using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Type = ConfigurationManager.Core.Models.Type;
using File = ConfigurationManager.Core.Models.File;
using ConfigurationManager.Core;

namespace ConfigurationManager.Repository
{
    public class AppDbContext : DbContext, IGenericContext<AppDbContext, DbSet<User>>
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<User> _dbset;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            _context = this;
            _dbset = _context.Set<User>();
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

        public AppDbContext CreateContext()
        {
            return _context;
        }

        public DbSet<User> CreateDbSet()
        {
            return _dbset;
        }

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
