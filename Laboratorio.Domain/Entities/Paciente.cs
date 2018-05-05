using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Laboratorio.Domain.Entities
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
        
    }
}