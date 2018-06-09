using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repository;
using AtendimentoHospitalar.Repository.ADO;

namespace AtendimentoHospitalar.Service
{
    public class CidadeService
    {
        private readonly CidadeRepository cidadeRepository= new CidadeRepository();
        private readonly CidadeAdoRepository cidadeAdo = new CidadeAdoRepository();

        public void Save(Cidade cidade)
        {
            cidadeRepository.Add(cidade);            
        }
        public void Update(Cidade cidade)
        {
            cidadeRepository.Update(cidade);
        }
        public void Delete(Cidade cidade)
        {
            cidadeRepository.Remove(cidade);
        }
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