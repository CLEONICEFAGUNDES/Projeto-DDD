using System.Data.Entity.Migrations;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoContext context)
        {
            
        }
    }
}
