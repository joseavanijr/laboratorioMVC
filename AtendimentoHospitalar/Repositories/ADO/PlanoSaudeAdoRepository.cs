using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.Repositories.ADO
{
    public class PlanoSaudeAdoRepository
    {
        public PlanoDeSaude BuscarPorId(Guid id)
        {
            PlanoDeSaude plano = new PlanoDeSaude();
            
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM PlanosDeSaude WHERE planoDeSaudeId=@planoId";
            comando.Parameters.AddWithValue("@planoId",id);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                dr.Read();
                plano.PlanoDeSaudeId = new Guid(dr["planoDeSaudeId"].ToString());
                plano.Descricao = (string)dr["descricao"];
            }
            else
            {
                plano = null;
            }
            return plano;
        }
        public IList<PlanoDeSaude> BuscarTodos()
        {
            IList<PlanoDeSaude> listaDePlano = new List<PlanoDeSaude>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM PlanosDeSaude";

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PlanoDeSaude plano = new PlanoDeSaude();
                    plano.PlanoDeSaudeId = new Guid(dr["planoDeSaudeId"].ToString());
                    plano.Descricao = (string) dr["descricao"];
                    listaDePlano.Add(plano);
                }
            }
            else
            {
                listaDePlano = null;
            }
            return listaDePlano;
        }
    }
}