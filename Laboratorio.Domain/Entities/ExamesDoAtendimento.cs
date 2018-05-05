using System;

namespace Laboratorio.Domain.Entities
{
    public class ExamesDoAtendimento
    {
        public ExamesDoAtendimento()
        {
            ExamesDoAtendimentoId = new Guid();
        }

        public Guid ExamesDoAtendimentoId { get; set; }
        public virtual Atendimento Atendimento { get; set; }
    }
}