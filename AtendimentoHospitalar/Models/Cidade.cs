
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AtendimentoHospitalar.Repository;

namespace AtendimentoHospitalar.Models
{
    public class Cidade
    {
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public string Nome{ get; set; }
        public Estado Estado{ get; set; }

        public void Salvar()
        {
            CidadeRepository cRepository = new CidadeRepository();
            if (CidadeId!=0)
            {
                cRepository.Update(this);
            }
            else
            {
                cRepository.Gravar(this);
            }
        }
        public void Apagar()
        {
            new CidadeRepository().Apagar(this);
        }
        public IList<Cidade> Buscar()
        {
            return new CidadeRepository().BuscarTodas();
        }
        public IList<Cidade> Buscar(Estado estado)
        {
            return new CidadeRepository().BuscarPorEstado(estado);
        }
        public Cidade Buscar(int id)
        {
            return new CidadeRepository().Buscar(id);
        }
    }
}
