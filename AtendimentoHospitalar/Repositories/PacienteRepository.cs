using System;
using System.Collections.Generic;
using System.Linq;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>
    {
        public IEnumerable<Paciente> GetByPlano(Guid planoId)
        {
            return Db.Pacientes.Where(p => p.PlanoDeSaudeId == planoId);
        }
        public IEnumerable<Paciente> GetByName(string nome)
        {
            return Db.Pacientes.Where(p => p.Nome == nome);
        }
    }
}