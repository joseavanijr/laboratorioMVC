using System;
using System.Collections.Generic;

namespace Laboratorio.Domain.Entities
{
    public class PlanoDeSaude
    {
        public Guid PlanoDeSaudeId { get; set; }
        
        public string Descricao { get; set; }
    }
}
