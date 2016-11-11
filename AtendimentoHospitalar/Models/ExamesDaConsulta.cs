using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoDeSaude.Model
{
    public class ExamesDaConsulta
    {
        private int id;
        private DateTime dataDaRealizacaoDoExame;
        
        Exame objExame = new Exame();
        private Agendamento objAgendamento;

        public ExamesDaConsulta(Agendamento agen)
        {
            objAgendamento = agen;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DataDaRealizacaoDoExame
        {
            get { return dataDaRealizacaoDoExame; }
            set { dataDaRealizacaoDoExame = value; }
        }
    }
}
