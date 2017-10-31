using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AtendimentoHospitalar.Repository;

namespace AtendimentoHospitalar.Models
{
    public class PlanoDeSaude
    {
        public int Id { get; set; }
        
        [Required]
        public string Descricao { get; set; }

        public IList<PlanoDeSaude> Buscar()
        {
            return new PlanoSaudeRepository().BuscarTodos();
        } 
    }
}
