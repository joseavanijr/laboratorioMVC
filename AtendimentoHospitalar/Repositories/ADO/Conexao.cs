﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AtendimentoHospitalar.Repositories.ADO
{
    public class Conexao
    {
        private static SqlConnection Conectar(){
            string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoAtendimentoHospitalar"].ConnectionString;
            SqlConnection conexao = new SqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }

        public static void Crud(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            comando.ExecuteNonQuery();
            con.Close();
        }

        public static SqlDataReader Selecionar(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}