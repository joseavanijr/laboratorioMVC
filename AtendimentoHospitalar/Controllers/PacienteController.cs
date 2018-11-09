using System;
using AtendimentoHospitalar.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AtendimentoHospitalar.Services;

namespace AtendimentoHospitalar.Controllers
{
    public class PacienteController : Controller
    {
        protected readonly PacienteService pacienteService = new PacienteService(); 
        protected readonly PlanoDeSaudeService planoDeSaudeService = new PlanoDeSaudeService(); 
       
                       
        public ActionResult Listar()
        {
            IEnumerable<Paciente> listaPacientes = pacienteService.GetAll();

            return View(listaPacientes);
        }

        public ActionResult Novo()
        {
            ViewBag.PlanoDeSaudeId = new SelectList(planoDeSaudeService.GetAll(), "PlanoDeSaudeId", "Descricao");
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                pacienteService.Save(paciente);
                return RedirectToAction("Listar");
            }

            ViewBag.PlanoDeSaudeId = new SelectList(planoDeSaudeService.GetAll(), "PlanoDeSaudeId", "Descricao", paciente.PlanoDeSaudeId);
            return View(paciente);
        }

        public ActionResult Editar(Guid id)
        {
            Paciente p = pacienteService.GetById(id);
            ViewBag.PlanoDeSaudeId = new SelectList(planoDeSaudeService.GetAll(), "PlanoDeSaudeId", "Descricao", p.PlanoDeSaudeId);           
            return View(p);
        }
        [HttpPost]
        public ActionResult Editar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                pacienteService.Update(paciente);
                return RedirectToAction("Listar");
            }
            ViewBag.PlanoDeSaudeId = new SelectList(planoDeSaudeService.GetAll(), "PlanoDeSaudeId", "Descricao", paciente.PacienteId);
            return View(paciente);
        }

        public ActionResult ListarPorPlano()
        {
            ViewBag.PlanoDeSaudeId = new SelectList(planoDeSaudeService.GetAll(), "PlanoDeSaudeId", "Descricao");
            return View();
        }
        public ActionResult ListarPorPlanoResult(Guid planoId)
        {
            IEnumerable<Paciente> pacientes = pacienteService.GetByPlano(planoId);
            return PartialView("_ListarPacientes", pacientes.ToList());
        }

        public ActionResult ListarPorNome(string nome)
        {
            return View();
        }
        public ActionResult ListarPorNomeResult(string nome)
        {
            IEnumerable<Paciente> planos = pacienteService.GetByName(nome);
            return PartialView("_ListarPacientes", planos);
        }
    }
}