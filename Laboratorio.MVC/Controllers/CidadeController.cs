using System.Collections.Generic;
using System.Web.Mvc;
using AtendimentoHospitalar.Repository;
using AtendimentoHospitalar.Models;

namespace Laboratorio.MVC.Controllers
{
    public class CidadeController : Controller
    {
        public ActionResult Listar()
        {
            return View(new Cidade().Buscar());
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Salvar();
            }
            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            return View(new Cidade().Buscar(id));
        }

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Salvar();
            }
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(int id)
        {
            return View(new Cidade().Buscar(id));
        }

        [HttpPost]
        public ActionResult Excluir(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                cidade.Apagar();
            }
            return RedirectToAction("Listar");
        }

        #region Usando PARTVIEW
        //Faço com Cidade e Estado e os alunos com Plano e Paciente
        public ActionResult ListarComFiltroPorEstado()
        {
            return View();
        }









        public ActionResult ListarPorEstado(Estado estado)
        {
            IList<Cidade> cidades = new Cidade().Buscar(estado);
            return PartialView("_ListarCidades", cidades);
        }

        public ActionResult ListarPorEstadoPraCliente(Estado estado)
        {
            IList<Cidade> cidades = new Cidade().Buscar(estado);
            return PartialView("_ListarCidadesNoCLiente", cidades);
        }
        #endregion
    }
}