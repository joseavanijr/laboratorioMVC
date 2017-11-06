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
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento"), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Plano de Saúde")]
        public PlanoDeSaude ObjPlanoDeSaude { get; set; }

        [DisplayName("Tipo do conveniado")]
        public TipoConveniado EnumTipoConveniado { get; set; }

        [DisplayName("Cidade")]
        public Cidade ObjCidade { get; set; }

        public Paciente()
        {
            ObjCidade = new Cidade();
            ObjPlanoDeSaude = new PlanoDeSaude();
        }
        public void Save()
        {
            PacienteRepository pr = new PacienteRepository();
            ValidarGravacao();
            if (Id == 0)
            {
                pr.Inserir(this);
            }
            else
            {
                pr.Update(this);
            }
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
            if (ObjPlanoDeSaude.Id == 0)
                throw new Exception("Informe o plano de saúde");
        }
    }
}