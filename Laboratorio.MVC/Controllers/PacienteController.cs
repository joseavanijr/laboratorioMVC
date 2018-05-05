using System.Collections.Generic;
using System.Web.Mvc;

namespace Laboratorio.MVC.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Listar()
        {
            IList<Paciente> listaPacientes = new Paciente().FindAll();

            return View(listaPacientes);
        }

        public ActionResult Novo()
        {
            ViewBag.PlanoId = new SelectList(new PlanoDeSaude().Buscar(), "Id", "Descricao");
            return View();
        }

        //[HttpPost]
        //public ActionResult Novo(Paciente paciente, int PlanoId)
        //{
        //    paciente.ObjPlanoDeSaude.Id = PlanoId;
        //    pacienteRepository.Inserir(paciente);
        //    return RedirectToAction("Listar");
        //}

        [HttpPost]
        public ActionResult Novo(Paciente paciente)
        {      
            paciente.Save();
            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            ViewBag.PlanoId = new SelectList(new PlanoDeSaude().Buscar(), "Id", "Descricao");
            Paciente p = new Paciente().FindById(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            paciente.Save();
            return RedirectToAction("Listar");
        }

        public ActionResult ListarPorPlano()
        {
            ViewBag.PlanoId = new SelectList(new PlanoDeSaude().Buscar(), "Id", "Descricao");
            return View();
        }
        public ActionResult ListarPorPlanoResult(int planoId)
        {
            IList<Paciente> pacientes = new Paciente().FindByPlano(planoId);
            return PartialView("_ListarPacientes", pacientes);
        }

        public ActionResult ListarPorNome(string nome)
        {
            return View();
        }
        public ActionResult ListarPorNomeResult(string nome)
        {
            IList<Paciente> planos = new Paciente().FindByName(nome);
            return PartialView("_ListarPacientes", planos);
        }
    }
}