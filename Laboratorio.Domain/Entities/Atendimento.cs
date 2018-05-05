using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Domain.Entities
{
    public class Atendimento
    {
        public Atendimento()
        {
            AtendimentoId = new Guid();
            ListExamesDoAtendimentos = new List<ExamesDoAtendimento>();
        }
        public Guid AtendimentoId { get; set; }
        public ICollection<ExamesDoAtendimento> ListExamesDoAtendimentos { get; set; }
    }
}