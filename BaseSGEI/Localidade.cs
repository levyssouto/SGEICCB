using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSGEI
{
    public class Localidade
    {

        public Localidade()
        {
            BaseSGEI.Login.LogarYMS();
        }
        public DataTable ListaLocalidade(string ID, string Nome)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaLocalidade]", Conexao._dbConnSQL);
                if (ID != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Nome != null) { cmd.Parameters.AddWithValue("@Nome", Nome); } else { cmd.Parameters.AddWithValue("@Nome", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;                
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar localidades: ", ex.Message));

            }
        }
        public DataTable ListaContacao(string IDLocalidade)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaContacao]", Conexao._dbConnSQL);
                if (IDLocalidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", IDLocalidade); } else { cmd.Parameters.AddWithValue("@IDLocalidade", DBNull.Value); }
                
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar contação: ", ex.Message));

            }
        }

        public DataTable TotalDiario(string ID_Localidade, int ID_Contacao)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TotalDiario]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar total diario: ", ex.Message));

            }
        }
        public DataTable TotalDiarioSaida(string ID_Localidade, int ID_Contacao)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[TotalDiarioSaida]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar total diario: ", ex.Message));

            }
        }
        public DataTable GetEstatistica(string ID_Localidade, DateTime? inicio, DateTime? fim, string tipo, string FrequenciaOuCrianca)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetChart]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (inicio != null) { cmd.Parameters.AddWithValue("@inicio", inicio); } else { cmd.Parameters.AddWithValue("@inicio", DBNull.Value); }
                if (fim != null) { cmd.Parameters.AddWithValue("@fim", fim); } else { cmd.Parameters.AddWithValue("@fim", DBNull.Value); }
                if (tipo != null) { cmd.Parameters.AddWithValue("@tipo", tipo); } else { cmd.Parameters.AddWithValue("@tipo", DBNull.Value); }
                if (FrequenciaOuCrianca != null) { cmd.Parameters.AddWithValue("@FrequenciaOuCrianca", FrequenciaOuCrianca); } else { cmd.Parameters.AddWithValue("@FrequenciaOuCrianca", DBNull.Value); }

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar estatísticas: ", ex.Message));

            }
        }

        public DataTable GetDadosLocalidade(string ID_Localidade)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LocalidadeDados]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
             
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar dados da localidade: ", ex.Message));

            }
        }
        public string IncluirLocalidade(
                    string ID_Localidade,
                    string Nome,
                    string CEP,
                    string Endereco,
                    string Bairro,
                    string Cidade,
                    string UF,
                    string Pais
                    )
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[9];
                SqlCommand cmd = new SqlCommand("[dbo].[LocalidadeINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
                if (Nome != null) { cmd.Parameters.AddWithValue("@Nome", Nome); } else { cmd.Parameters.AddWithValue("@Nome", DBNull.Value); }
                if (CEP != null) { cmd.Parameters.AddWithValue("@CEP", CEP); } else { cmd.Parameters.AddWithValue("@CEP", DBNull.Value); }
                if (Endereco != null) { cmd.Parameters.AddWithValue("@Endereco", Endereco); } else { cmd.Parameters.AddWithValue("@Endereco", DBNull.Value); }
                if (Bairro != null) { cmd.Parameters.AddWithValue("@Bairro", Bairro); } else { cmd.Parameters.AddWithValue("@Bairro", DBNull.Value); }
                if (Cidade != null) { cmd.Parameters.AddWithValue("@Cidade", Cidade); } else { cmd.Parameters.AddWithValue("@Cidade", DBNull.Value); }
                if (UF != null) { cmd.Parameters.AddWithValue("@UF", UF); } else { cmd.Parameters.AddWithValue("@UF", DBNull.Value); }
                if (Pais != null) { cmd.Parameters.AddWithValue("@Pais", Pais); } else { cmd.Parameters.AddWithValue("@Pais", DBNull.Value); }
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[8].Size = 1000;
                cmd.Parameters[8].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[8].Value.ToString()))
                {
                    ret = cmd.Parameters[8].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string ExcluirLocalidade(string ID_Localidade)
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[2];
                SqlCommand cmd = new SqlCommand("[dbo].[LocalidadeDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
         
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[1].Size = 1000;
                cmd.Parameters[1].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[1].Value.ToString()))
                {
                    ret = cmd.Parameters[1].Value.ToString();
                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public string[] BACKUP(string ID_Localidade)
        {

            try
            {
                string[] ret = new string[2];

                SqlParameter[] colparam = new SqlParameter[2];
                SqlCommand cmd = new SqlCommand("[dbo].[BACKUP_SGEI]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }

                cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar);
                cmd.Parameters[1].Size = 1000;
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RETORNO", SqlDbType.VarChar);
                cmd.Parameters[2].Size = 1000;
                cmd.Parameters[2].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(cmd.Parameters[1].Value.ToString()))
                {
                    ret[0] = cmd.Parameters[1].Value.ToString();
                }

                if (!String.IsNullOrEmpty(cmd.Parameters[2].Value.ToString()))
                {
                    ret[1] = cmd.Parameters[2].Value.ToString();
                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public void Dispose()
        {

            Conexao._dbConnSQL.Dispose();
            Conexao._dbConnSQL.Close();

            GC.SuppressFinalize(this);

        }
    }
}
