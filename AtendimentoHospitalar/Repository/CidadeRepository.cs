using System;
using System.Linq;
using AtendimentoHospitalar.Contexto;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.Repository
{
    public class CidadeRepository
    {
        private readonly AtendimentoHospitalarContexto Db = new AtendimentoHospitalarContexto();

        public void Insert(Cidade cidade)
        {
            Db.Cidades.Add(cidade);
            Db.SaveChanges();
        }
        public void Update(Cidade cidade)
        {
            var cidadeBanco = Db.Cidades.FirstOrDefault(c => c.CidadeId == cidade.CidadeId);
            Db.Entry(cidadeBanco).CurrentValues.SetValues(cidade);
        }
        public void Delete(Cidade cidade)
        {
            
        }
        public void Delete(Guid cidadeId)
        {
            var cidadeBanco = Db.Cidades.FirstOrDefault(c => c.CidadeId == cidadeId);
            Db.Cidades.Remove(cidadeBanco);
            Db.SaveChanges();
        }
    }
}