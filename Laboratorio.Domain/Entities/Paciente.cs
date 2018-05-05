using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Laboratorio.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public PlanoDeSaude ObjPlanoDeSaude { get; set; }

        public TipoConveniado EnumTipoConveniado { get; set; }

        public Cidade ObjCidade { get; set; }

        public Paciente()
        {
            ObjCidade = new Cidade();
            ObjPlanoDeSaude = new PlanoDeSaude();
        }
        
    }
}