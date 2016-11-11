using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AtendimentoHospitalar.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteRepository pacienteRepository = new PacienteRepository();
        private readonly PlanoSaudeRepository planoRepository = new PlanoSaudeRepository();

        public ActionResult Listar()
        {
            IList<Paciente> listaPacientes = pacienteRepository.BuscarTodos();

            return View(listaPacientes);
        }

        public ActionResult Novo()
        {
            ViewBag.PlanoId = new SelectList(planoRepository.BuscarTodos(), "Id", "Descricao");
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
            pacienteRepository.Inserir(paciente);
            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            ViewBag.PlanoId = new SelectList(planoRepository.BuscarTodos(), "Id", "Descricao");
            Paciente p = pacienteRepository.BuscarPorId(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            pacienteRepository.Update(paciente);
            return RedirectToAction("Listar");
        }

        public ActionResult ListarPorPlano()
        {
            ViewBag.PlanoId = new SelectList(planoRepository.BuscarTodos(), "Id", "Descricao");
            return View();
        }
        public ActionResult ListarPorPlanoResult(int planoId)
        {
            IList<Paciente> planos = new Paciente().BuscarPorPlano(planoId);
            return PartialView("_ListarPacientes", planos);
        }
    }
}