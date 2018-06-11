using System;
using System.Collections.Generic;

namespace AtendimentoHospitalar.Models
{
    public class Agendamento
    {
        public Agendamento()
        {
            AgendamentoId = Guid.NewGuid();
        }
        public Guid AgendamentoId { get; set; }
        public Guid PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<ExamesDaConsulta> ExamesDaConsultasList { get; set; }
    }
}
