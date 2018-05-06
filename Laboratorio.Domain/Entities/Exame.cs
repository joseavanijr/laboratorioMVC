using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Domain.Entities
{
    public class Exame
    {
        public Exame()
        {
            ExameId = new Guid();
        }
        public Guid ExameId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}