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