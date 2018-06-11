using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.Repositories.ADO
{
    public class CidadeAdoRepository
    {
        public void Gravar(Cidade obj)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Cidades (nome, estado) values (@nome, @estado)";
            comando.Parameters.AddWithValue("@nome", obj.Nome);
            comando.Parameters.AddWithValue("@estado", obj.Estado);

            Conexao.Crud(comando);
        }

        public void Update(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Cidades SET nome=@nome, estado=@estado WHERE cidadeID=@cidadeID";

            comando.Parameters.AddWithValue("@cidadeID", cidade.CidadeId);
            comando.Parameters.AddWithValue("@estado", cidade.Estado);
            comando.Parameters.AddWithValue("@nome", cidade.Nome);

            Conexao.Crud(comando);
        }

        public void Apagar(Cidade cidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE from Cidade WHERE cidadeID=@cidadeID";

            comando.Parameters.AddWithValue("@cidadeID", cidade.CidadeId);

            Conexao.Crud(comando);
        }

        public Cidade Buscar(Guid id)
        {
            Cidade objCidade = new Cidade();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Cidades Where cidadeID=@cidadeId";

            comando.Parameters.AddWithValue("@cidadeId", id);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                dr.Read();

                objCidade.CidadeId = new Guid(dr["cidadeID"].ToString());
                objCidade.Nome = dr["nome"].ToString();
                objCidade.Estado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                objCidade.Estado = (Estado)dr["estado"];
            }
            else
            {
                objCidade = null;
            }
            
            dr.Close();
            return objCidade;
        }

        public IList<Cidade> BuscarTodas()
        {
           
            IList<Cidade> listaCidade = new List<Cidade>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From cidades";

            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade objCidade = new Cidade();
                    objCidade.CidadeId = new Guid(dr["cidadeID"].ToString());
                    objCidade.Nome = dr["nome"].ToString();
                    objCidade.Estado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                   
                    listaCidade.Add(objCidade);
                }
            }
            else
            {
                listaCidade = null;
            }
            
            dr.Close();
            return listaCidade;
        }

        public IList<Cidade> BuscarPorEstado(Estado estado)
        {
            IList<Cidade> listaCidade = new List<Cidade>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From cidades Where estado=@estado";

            comando.Parameters.AddWithValue("@estado", estado);

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade objCidade = new Cidade();
                    objCidade.CidadeId = new Guid(dr["cidadeID"].ToString());
                    objCidade.Nome = dr["nome"].ToString();
                    objCidade.Estado = (Estado) dr["estado"];

                    listaCidade.Add(objCidade);
                }
            }
            else
            {
                listaCidade = null;
            }
            
            dr.Close();
            return listaCidade;
        }


    }
}
