﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AtendimentoHospitalar.Models
{
    public class PlanoDeSaude
    {
        public int Id { get; set; }
        
        [Required]
        public string Descricao { get; set; }
    }
}
