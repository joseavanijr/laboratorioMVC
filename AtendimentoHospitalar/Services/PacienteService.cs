using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Models;
using AtendimentoHospitalar.Repositories;
using AtendimentoHospitalar.Repositories.ADO;

namespace AtendimentoHospitalar.Services
{
    public class PacienteService: ServiceBase<Paciente>
    {
        private readonly PacienteAdoRepository pacienteAdo = new PacienteAdoRepository();
        private readonly PacienteRepository pacienteRepository = new PacienteRepository();

        public IEnumerable<Paciente> GetByPlano(Guid planoId)
        {    
            return pacienteRepository.GetByPlano(planoId);
            //return pacienteAdo.BuscarPorPlano(planoId);
        }
        public IEnumerable<Paciente> GetByName(string nome)
        {
            //return pacienteAdo.BuscarPorNome(nome);
            return pacienteRepository.GetByName(nome);
        }
        
    }
}