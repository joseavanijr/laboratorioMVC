using System;

namespace AtendimentoHospitalar.Models
{
    public class ExamesDaConsulta
    {
        public ExamesDaConsulta(Agendamento agen)
        {
            ExamesDaConsultaId = new Guid();
            this.Agendamento = agen;
        }

        public Guid ExamesDaConsultaId { get; set; }
        public DateTime DataRealizacaoExame { get; set; }
        public Guid ExameId { get; set; }
        public virtual Exame Exame { get; set; }
        public Guid AgendamentoId { get; set; }
        public virtual Agendamento Agendamento { get; set; }
    }
}
