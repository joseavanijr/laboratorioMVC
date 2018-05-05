
using System;
using System.Collections;
using System.Collections.Generic;

namespace Laboratorio.Domain.Entities
{
    public class Cidade
    {
        public Cidade()
        {
            CidadeId = new Guid();
            ListPacientes=new List<Paciente>();
        }
        public Guid CidadeId { get; set; }
        public string Nome{ get; set; }
        public Estado Estado{ get; set; }
        public virtual ICollection<Paciente> ListPacientes { get; set; }


    }
}
