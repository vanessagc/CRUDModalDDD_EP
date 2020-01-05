using System.Data.Entity.Migrations;
using EP.CrudModalDDD.Infra.CrossCutting.Logging.Data;

namespace EP.CrudModalDDD.Infra.CrossCutting.Logging.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LogginContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LogginContext context)
        {

        }
    }
}
