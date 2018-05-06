using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtendimentoHospitalar.Models
{
    public class Atendimento
    {
        public Atendimento()
        {
            AtendimentoId = new Guid();
            ListExamesDoAtendimentos = new List<ExamesDoAtendimento>();
        }
        public Guid AtendimentoId { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public ICollection<ExamesDoAtendimento> ListExamesDoAtendimentos { get; set; }
    }
}