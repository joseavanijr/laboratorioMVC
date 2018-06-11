using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Services;

namespace AtendimentoHospitalar.Models
{
    public class Cidade
    {
        public Cidade()
        {
            CidadeId = new Guid();
        }
        public Guid CidadeId { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public virtual ICollection<Paciente> ListPacientes { get; set; }


        public void Salvar()
        {
            CidadeService cSerciveService = new CidadeService();
            if (CidadeId != new Guid())
            {
                cSerciveService.Update(this);
            }
            else
            {
                cSerciveService.Save(this);
            }
        }
        public void Apagar()
        {
            new CidadeService().Delete(this.CidadeId);
        }
        public IList<Cidade> Buscar()
        {
            return new CidadeService().FindAllReadOnly();
        }
        public IList<Cidade> Buscar(Estado estado)
        {
            return new CidadeService().FindByEstadoReadOnly(estado);
        }
        public Cidade Buscar(Guid id)
        {
            return new CidadeService().GetById(id);
        }
    }
}
