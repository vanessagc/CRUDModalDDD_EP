using System.Data.Common;
using System.Data.Entity;
using EP.CrudModalDDD.Infra.CrossCutting.Logging.Model;

namespace EP.CrudModalDDD.Infra.CrossCutting.Logging.Data
{
    public class LogginContext : DbContext  
    {
        public LogginContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Auditoria> LogAuditoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuditoriaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}