using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repository.ADO;

namespace AtendimentoHospitalar.Service
{
    public class CidadeService: ServiceBase<Cidade>
    {
        private readonly CidadeAdoRepository cidadeAdo = new CidadeAdoRepository();
        
        public Cidade FindById(Guid id)
        {
            return cidadeAdo.Buscar(id);
        }
        public IList<Cidade> FindAll()
        {
            return cidadeAdo.BuscarTodas();
        }        
        public IList<Cidade> FindByEstado(Estado estado)
        {
            return cidadeAdo.BuscarPorEstado(estado);
        }
    }
}