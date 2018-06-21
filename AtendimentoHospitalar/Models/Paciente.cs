using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Services;

namespace AtendimentoHospitalar.Models
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public TipoConveniado EnumTipoConveniado { get; set; }
        public Guid PlanoDeSaudeId { get; set; }
        public virtual PlanoDeSaude PlanoDeSaude { get; set; }
        public Guid CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        public Paciente()
        {
            PacienteId = Guid.NewGuid();
        }
        public void Save()
        {
            PacienteService ps = new PacienteService();
            ValidarGravacao();
            ps.Save(this);
        }
        public void Update()
        {
            PacienteService ps = new PacienteService();
            ValidarGravacao();
            ps.Update(this);
        }
        public void Delete()
        {
            ValidarExclusao();
            new PacienteService().Delete(this);
        }
        public Paciente FindById(Guid id)
        {
            return new PacienteService().GetById(id);
        }
        public IEnumerable<Paciente> FindByName(string nome)
        {
            return new PacienteService().GetByName(nome);
        }
        public IEnumerable<Paciente> FindByPlano(Guid planoId)
        {
            return new PacienteService().GetByPlano(planoId);
        }
        public IEnumerable<Paciente> FindAll()
        {
            return new PacienteService().GetAll();
        }
        public void ValidarExclusao()
        {
            throw new Exception("Vou ver pq num exclui");
        }
        public void ValidarGravacao()
        {
            if (PlanoDeSaudeId == null)
                throw new Exception("Informe o plano de saúde");
        }
    }
}