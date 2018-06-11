using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repositories.ADO;

namespace AtendimentoHospitalar.Services
{
    public class PacienteService: ServiceBase<Paciente>
    {
        private readonly PacienteAdoRepository pacienteAdo = new PacienteAdoRepository();

        public IEnumerable<Paciente> GetByPlano(Guid planoId)
        {
            return pacienteAdo.BuscarPorPlano(planoId);
        }
        public IEnumerable<Paciente> GetByName(string nome)
        {
            return pacienteAdo.BuscarPorNome(nome);
        }
    }
}