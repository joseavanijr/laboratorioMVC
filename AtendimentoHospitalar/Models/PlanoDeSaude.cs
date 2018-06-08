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
        public PlanoDeSaude()
        {
            PlanoDeSaudeId = new Guid();
            ListPacientes = new List<Paciente>();
        }

        public Guid PlanoDeSaudeId { get; set; }

        public string Descricao { get; set; }
        public virtual ICollection<Paciente> ListPacientes { get; set; }


        public IList<PlanoDeSaude> Buscar()
        {
            return new PlanoSaudeAdoRepository().BuscarTodos();
        } 
    }
}
