using AtendimentoHospitalar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AtendimentoHospitalar.Repository.ADO
{
    public class PacienteAdoRepository
    {
        public void Inserir(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Paciente(nome, dtNascimento, tipoConveniado, planoDeSaudeId, cidadeId) VALUES(@nome, @dtNascimento, @tipoConveniado, @planoDeSaudeId, @cidadeId)";

            comando.Parameters.AddWithValue("@nome",paciente.Nome);
            comando.Parameters.AddWithValue("@dtNascimento",paciente.DataNascimento);
            comando.Parameters.AddWithValue("@tipoConveniado",paciente.EnumTipoConveniado);
            comando.Parameters.AddWithValue("@planoDeSaudeId",paciente.PlanoDeSaude.PlanoDeSaudeId);
            comando.Parameters.AddWithValue("@cidadeId", paciente.Cidade.CidadeId);
            Conexao.Crud(comando);
        }

        public void Update(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Paciente SET nome=@nome, dtNascimento=@dtNascimento, tipoConveniado=@tipoConveniado, planoDeSaudeId=@planoDeSaudeId, cidadeId=@cidadeId WHERE pacienteId=@pacienteId";

            comando.Parameters.AddWithValue("@nome", paciente.Nome);
            comando.Parameters.AddWithValue("@dtNascimento", paciente.DataNascimento);
            comando.Parameters.AddWithValue("@tipoConveniado", paciente.EnumTipoConveniado);
            comando.Parameters.AddWithValue("@planoDeSaudeId", paciente.PlanoDeSaude.PlanoDeSaudeId);
            comando.Parameters.AddWithValue("@cidadeId", paciente.Cidade.CidadeId);
            comando.Parameters.AddWithValue("@pacienteId", paciente.PacienteId);
            Conexao.Crud(comando);
        }

        public void Delete(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM Paciente WHERE pacienteId=@pacienteId";

            comando.Parameters.AddWithValue("@pacienteId", paciente.PacienteId);
            Conexao.Crud(comando);
        }

        public Paciente BuscarPorId(int id)
        {
            Paciente paciente = new Paciente();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente WHERE pacienteId=@pacienteId";
            comando.Parameters.AddWithValue("@pacienteId", id);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                dr.Read();

                paciente.PacienteId = new Guid(dr["pacienteId"].ToString());
                paciente.Nome = (string)dr["nome"];
                paciente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);                
                paciente.EnumTipoConveniado = (TipoConveniado)Enum.Parse(typeof (TipoConveniado),dr["tipoConveniado"].ToString());
                paciente.Cidade = new CidadeAdoRepository().Buscar(new Guid(dr["cidadeId"].ToString()));
                paciente.PlanoDeSaude = new PlanoSaudeAdoRepository().BuscarPorId((int)dr["planoDeSaudeId"]);
            }
            else
            {
                paciente = null;
            }
            return paciente;
        }

        public IList<Paciente> BuscarPorNome(string nome)
        {
            IList<Paciente> listaPaciente = new List<Paciente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente WHERE nome like @nome";
            comando.Parameters.AddWithValue("@nome", string.Format("%{0}%",nome));

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.PacienteId = new Guid(dr["pacienteId"].ToString());
                    paciente.Nome = (string)dr["nome"];
                    paciente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                    paciente.EnumTipoConveniado = (TipoConveniado)Enum.Parse(typeof(TipoConveniado), dr["tipoConveniado"].ToString());
                    paciente.Cidade = new CidadeAdoRepository().Buscar(new Guid(dr["cidadeId"].ToString()));
                    paciente.PlanoDeSaude = new PlanoSaudeAdoRepository().BuscarPorId((int)dr["planoDeSaudeId"]);

                    listaPaciente.Add(paciente);
                }
            }
            else
            {
                listaPaciente = null;
            }
            return listaPaciente;
        }

        public IList<Paciente> BuscarPorPlano(int planoId)
        {
            IList<Paciente> listaPaciente = new List<Paciente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente WHERE planoDeSaudeId=@planoDeSaudeId";
            comando.Parameters.AddWithValue("@planoDeSaudeId", planoId);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.PacienteId = new Guid(dr["pacienteId"].ToString());
                    paciente.Nome = (string)dr["nome"];
                    paciente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                    paciente.EnumTipoConveniado = (TipoConveniado)Enum.Parse(typeof(TipoConveniado), dr["tipoConveniado"].ToString());
                    paciente.Cidade = new CidadeAdoRepository().Buscar(new Guid(dr["cidadeId"].ToString()));
                    paciente.PlanoDeSaude = new PlanoSaudeAdoRepository().BuscarPorId((int)dr["planoDeSaudeId"]);

                    listaPaciente.Add(paciente);
                }
            }
            else
            {
                listaPaciente = null;
            }
            return listaPaciente;
        }

        public IList<Paciente> BuscarTodos()
        {
            IList<Paciente> listaPaciente = new List<Paciente>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente";

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.PacienteId = new Guid(dr["pacienteId"].ToString());
                    paciente.Nome = (string)dr["nome"];
                    paciente.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                    paciente.EnumTipoConveniado = (TipoConveniado)Enum.Parse(typeof(TipoConveniado), dr["tipoConveniado"].ToString());
                    paciente.Cidade = new CidadeAdoRepository().Buscar(new Guid(dr["cidadeId"].ToString()));
                    paciente.PlanoDeSaude = new PlanoSaudeAdoRepository().BuscarPorId((int)dr["planoDeSaudeId"]);

                    listaPaciente.Add(paciente);
                }
            }
            else
            {
                listaPaciente = null;
            }
            return listaPaciente;
        }
    }
}