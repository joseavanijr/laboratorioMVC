using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repositories.ADO;

namespace AtendimentoHospitalar.Services
{
    public class CidadeService: ServiceBase<Cidade>
    {
        private readonly CidadeAdoRepository cidadeAdo = new CidadeAdoRepository();
        
        public Cidade FindByIdReadOnly(Guid id)
        {
            return cidadeAdo.Buscar(id);
        }
        public IList<Cidade> FindAllReadOnly()
        {
            return cidadeAdo.BuscarTodas();
        }        
        public IList<Cidade> FindByEstadoReadOnly(Estado estado)
        {
            return cidadeAdo.BuscarPorEstado(estado);
        }
    }
}