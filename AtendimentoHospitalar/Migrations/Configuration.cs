using System.IO;
using AtendimentoHospitalar.Contexto;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AtendimentoHospitalar.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<AtendimentoHospitalarContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AtendimentoHospitalar.Contexto.AtendimentoHospitalarContexto context)
        {

            var sqlfiles = Directory.GetFiles(@"C:\Users\xxx\xxx\xxx\xxx\xxx\xxx\xxx\xxx\laboratoriomvc5\AtendimentoHospitalar\Migrations\DadosIniciais", "*.sql");
            sqlfiles.ToList().ForEach(x => context.Database.ExecuteSqlCommand(File.ReadAllText(x)));
        }
    }
}
