using System;
using System.Collections.Generic;

namespace Laboratorio.Domain.Entities
{
    public class PlanoDeSaude
    {
        public PlanoDeSaude()
        {
            PlanoDeSaudeId = new Guid();
            ListPacientes = new List<Paciente>();
        }

        public Guid PlanoDeSaudeId { get; set; }

        public string Descricao { get; set; }
        public virtual ICollection<Paciente> ListPacientes { get; set; }


    }
}
