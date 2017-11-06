using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AtendimentoHospitalar.Controllers
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
            IList<Paciente> planos = new Paciente().FindByPlano(planoId);
            return PartialView("_ListarPacientes", planos);
        }

        public ActionResult ListarPorNome(string nome)
        {
            ViewBag.PlanoId = new SelectList(new Paciente().FindByName(nome), "Id", "Descricao");
            return View();
        }
    }
}