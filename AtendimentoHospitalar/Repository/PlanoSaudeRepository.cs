using System.Web.UI.WebControls;
using AtendimentoHospitalar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace AtendimentoHospitalar.Repository
{
    public class PlanoSaudeRepository
    {
        public PlanoDeSaude BuscarPorId(int id)
        {
            PlanoDeSaude plano = new PlanoDeSaude();
            
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM PlanoDeSaude WHERE planoDeSaudeId=@planoId";
            comando.Parameters.AddWithValue("@planoId",id);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                dr.Read();
                plano.Id = (int)dr["planoDeSaudeId"];
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
            comando.CommandText = "SELECT * FROM PlanoDeSaude";

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PlanoDeSaude plano = new PlanoDeSaude();
                    plano.Id = (int) dr["planoDeSaudeId"];
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