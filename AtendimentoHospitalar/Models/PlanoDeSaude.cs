using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Services;

namespace AtendimentoHospitalar.Models
{
    public class PlanoDeSaude
    {
        public Guid PlanoDeSaudeId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Paciente> ListPacientes { get; set; }

        public PlanoDeSaude()
        {
            PlanoDeSaudeId = Guid.NewGuid();
        }
    }
}
