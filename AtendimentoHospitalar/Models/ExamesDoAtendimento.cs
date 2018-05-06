using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtendimentoHospitalar.Models
{
    public class ExamesDoAtendimento
    {
        public ExamesDoAtendimento()
        {
            ExamesDoAtendimentoId = new Guid();
        }

        public Guid ExamesDoAtendimentoId { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public Guid AtendimentoId { get; set; }
        public virtual Atendimento Atendimento { get; set; }
    }
}