using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AtendimentoHospitalar.Repository.ADO;

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
        public IList<PlanoDeSaude> Buscar()
        {
            return new PlanoSaudeAdoRepository().BuscarTodos();
        } 
    }
}
