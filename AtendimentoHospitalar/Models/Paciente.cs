using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtendimentoHospitalar.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento"), DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Plano de Saúde")]
        public PlanoDeSaude ObjPlanoDeSaude { get; set; }

        [DisplayName("Tipo do conveniado")]
        public TipoConveniado EnumTipoConveniado { get; set; }

        [DisplayName("Cidade")]
        public Cidade ObjCidade { get; set; }
    }
}