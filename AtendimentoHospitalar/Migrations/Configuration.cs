using System.IO;

namespace AtendimentoHospitalar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AtendimentoHospitalar.Contexto.AtendimentoHospitalarContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AtendimentoHospitalar.Contexto.AtendimentoHospitalarContexto context)
        {

            var sqlfiles = Directory.GetFiles(@"C:\Users\josea\Google Drive\UNIRON\2018-1\5 - PWA\PROJETOS\MVC\2BI\laboratoriomvc5\AtendimentoHospitalar\Migrations\DadosIniciais", "*.sql");
            sqlfiles.ToList().ForEach(x => context.Database.ExecuteSqlCommand(File.ReadAllText(x)));
        }
    }
}
