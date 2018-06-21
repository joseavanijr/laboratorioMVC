using System;
using AtendimentoHospitalar.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AtendimentoHospitalar.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Listar()
        {
            IEnumerable<Paciente> listaPacientes = new Paciente().FindAll();

            return View(listaPacientes);
        }

        public ActionResult Novo()
        {
            ViewBag.PlanoDeSaudeId = new SelectList(new PlanoDeSaude().Buscar(), "PlanoDeSaudeId", "Descricao");
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
            if (ModelState.IsValid)
            {
                paciente.Save();
                return RedirectToAction("Listar");
            }
            return View(paciente);
        }

        public ActionResult Editar(Guid id)
        {
            Paciente p = new Paciente().FindById(id);
            ViewBag.PlanoDeSaudeId = new SelectList(new PlanoDeSaude().Buscar(), "PlanoDeSaudeId", "Descricao", p.PlanoDeSaudeId);           
            return View(p);
        }
        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.Update();
                return RedirectToAction("Listar");
            }
            ViewBag.PlanoDeSaudeId = new SelectList(new PlanoDeSaude().Buscar(), "PlanoDeSaudeId", "Descricao", paciente.PacienteId);
            return View(paciente);
        }

        public ActionResult ListarPorPlano()
        {
            ViewBag.PlanoId = new SelectList(new PlanoDeSaude().Buscar(), "Id", "Descricao");
            return View();
        }
        public ActionResult ListarPorPlanoResult(Guid planoId)
        {
            IEnumerable<Paciente> pacientes = new Paciente().FindByPlano(planoId);
            return PartialView("_ListarPacientes", pacientes);
        }

        public ActionResult ListarPorNome(string nome)
        {
            return View();
        }
        public ActionResult ListarPorNomeResult(string nome)
        {
            IEnumerable<Paciente> planos = new Paciente().FindByName(nome);
            return PartialView("_ListarPacientes", planos);
        }
    }
}