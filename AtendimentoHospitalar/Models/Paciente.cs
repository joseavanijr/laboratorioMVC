using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AtendimentoHospitalar.Repository;

namespace AtendimentoHospitalar.Models
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public Guid PlanoDeSaudeId { get; set; }
        public PlanoDeSaude PlanoDeSaude { get; set; }

        public TipoConveniado EnumTipoConveniado { get; set; }

        public Guid CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public Paciente()
        {
            PacienteId = new Guid();
            Cidade = new Cidade();
            PlanoDeSaude = new PlanoDeSaude();
        }
        public void Save()
        {
            PacienteRepository pr = new PacienteRepository();
            ValidarGravacao();
            //if (Id == 0)
            //{
            //    pr.Inserir(this);
            //}
            //else
            //{
            //    pr.Update(this);
            //}
        }

        public void Delete()
        {
            ValidarExclusao();
            new PacienteRepository().Delete(this);
        }

        public Paciente FindById(int id)
        {
            return new PacienteRepository().BuscarPorId(id);
        }
        public IList<Paciente> FindByName(string nome)
        {
            return new PacienteRepository().BuscarPorNome(nome);
        }
        public IList<Paciente> FindByPlano(int planoId)
        {
            return new PacienteRepository().BuscarPorPlano(planoId);
        }
        public IList<Paciente> FindAll()
        {
            return new PacienteRepository().BuscarTodos();
        }
        public void ValidarExclusao()
        {
            throw new Exception("Vou ver pq num exclui");
        }
        public void ValidarGravacao()
        {
            if (PlanoDeSaude.PlanoDeSaudeId == null)
                throw new Exception("Informe o plano de saúde");
        }
    }
}