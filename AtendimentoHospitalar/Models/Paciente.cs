using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AtendimentoHospitalar.Services;

namespace AtendimentoHospitalar.Models
{
    public class Paciente
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name="Tipo do Conveniado")]
        public TipoConveniado EnumTipoConveniado { get; set; }
        public Guid PlanoDeSaudeId { get; set; }
        [Display(Name="Plano de Saúde")]
        public virtual PlanoDeSaude PlanoDeSaude { get; set; }
        [Display(Name="Cidade")]
        public Guid CidadeId { get; set; }
        [Display(Name = "Cidade")]
        public virtual Cidade Cidade { get; set; }

        public Paciente()
        {
            PacienteId = Guid.NewGuid();
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