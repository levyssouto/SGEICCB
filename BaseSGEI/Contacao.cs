using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSGEI
{
    public class Contacao
    {

        
        public Contacao()
        {
            BaseSGEI.Login.LogarYMS();
        }
        public DataTable RelatorioDiarioFrequencia(string ID_Localidade, int ID_Contacao)
        {
           
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RelatorioDiarioFrequencia]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
               
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar r: ", ex.Message));

            }
        }

        public DataTable ResumoContacao(string ID_Localidade, int ID_Contacao,string Resumo)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[RelatorioDiarioContacao]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                if (Resumo != null) { cmd.Parameters.AddWithValue("@Resumo", Resumo); } else { cmd.Parameters.AddWithValue("@Resumo", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Resumo: ", ex.Message));

            }
        }

        public string IncluirContacao(
                    string ID_Localidade,
                    string DataCulto,
                    int? Contadora,
                    int? Auxiliar1,
                    int? Auxiliar2,
                    int? Auxiliar3,
                    int? Auxiliar4,
                    int? Ministerio,
                    string Historia,
                    string Livro,
                    string Capitulo,    
                    string RespAtualiza,
                    string Observacao,
                    
                    int? RespRevisao,
                    int? ID_Contacao
                    )
        {
            
            try
            {
                string ret="";
                
                SqlParameter[] colparam = new SqlParameter[16];
                SqlCommand cmd = new SqlCommand("[dbo].[ContacaoINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade",ID_Localidade); }
                if (DataCulto != null) { cmd.Parameters.AddWithValue("@DataCulto", DataCulto); } else { cmd.Parameters.AddWithValue("@DataCulto", DBNull.Value); }
                if (Contadora != null && Contadora !=0) { cmd.Parameters.AddWithValue("@Contadora", Contadora); } else { cmd.Parameters.AddWithValue("@Contadora", DBNull.Value); }
                if (Auxiliar1 != null && Auxiliar1 != 0) { cmd.Parameters.AddWithValue("@Auxiliar1", Auxiliar1); } else { cmd.Parameters.AddWithValue("@Auxiliar1", DBNull.Value); }
                if (Auxiliar2 != null && Auxiliar2 != 0) { cmd.Parameters.AddWithValue("@Auxiliar2", Auxiliar2); } else { cmd.Parameters.AddWithValue("@Auxiliar2", DBNull.Value); }
                if (Auxiliar3 != null && Auxiliar3 != 0) { cmd.Parameters.AddWithValue("@Auxiliar3", Auxiliar3); } else { cmd.Parameters.AddWithValue("@Auxiliar3", DBNull.Value); }
                if (Auxiliar4 != null && Auxiliar4 != 0) { cmd.Parameters.AddWithValue("@Auxiliar4", Auxiliar4); } else { cmd.Parameters.AddWithValue("@Auxiliar4", DBNull.Value); }
                if (Ministerio != null && Ministerio != 0) { cmd.Parameters.AddWithValue("@Ministerio", Ministerio); } else { cmd.Parameters.AddWithValue("@Ministerio", DBNull.Value); }
                if (Historia != null) { cmd.Parameters.AddWithValue("@Historia", Historia.ToUpper()); } else { cmd.Parameters.AddWithValue("@Historia", DBNull.Value); }
                if (Livro != null) { cmd.Parameters.AddWithValue("@Livro", Livro); } else { cmd.Parameters.AddWithValue("@Livro", DBNull.Value); }
                if (Capitulo != null) { cmd.Parameters.AddWithValue("@Capitulo", Capitulo.ToUpper()); } else { cmd.Parameters.AddWithValue("@Capitulo", DBNull.Value); }
                if (RespRevisao != null) { cmd.Parameters.AddWithValue("@RespRevisao", RespRevisao); } else { cmd.Parameters.AddWithValue("@RespRevisao", DBNull.Value); }
                if (RespAtualiza != null) { cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza); } else { cmd.Parameters.AddWithValue("@RespAtualiza", DBNull.Value); }
                if (Observacao != null) { cmd.Parameters.AddWithValue("@Observacao", Observacao); } else { cmd.Parameters.AddWithValue("@Observacao", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[15].Size = 1000;
                cmd.Parameters[15].Direction = ParameterDirection.Output;
               
                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[15].Value.ToString()))
                {
                    ret = cmd.Parameters[15].Value.ToString();

                }
               
                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string ExcluirContacao(
                   string ID_Localidade,                   
                   int ID_Contacao,                  
                   string MotivoExclusao,
                   string Login
                   )
        {

            try
            {
                string ret = "";
              
                SqlParameter[] colparam = new SqlParameter[15];
                SqlCommand cmd = new SqlCommand("[dbo].[ContacaoDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade",ID_Localidade); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                if (MotivoExclusao != null) { cmd.Parameters.AddWithValue("@MotivoExclusao", MotivoExclusao); } else { cmd.Parameters.AddWithValue("@MotivoExclusao", DBNull.Value); }
                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }
          
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[4].Size = 1000;
                cmd.Parameters[4].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[4].Value.ToString()))
                {
                    ret = cmd.Parameters[4].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataTable GetContacao(string ID_Localidade , DateTime? inicio, DateTime? fim)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetContacao]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (inicio != null) { cmd.Parameters.AddWithValue("@inicio", inicio); } else { cmd.Parameters.AddWithValue("@inicio", DBNull.Value); }
                if (fim != null) { cmd.Parameters.AddWithValue("@fim", fim); } else { cmd.Parameters.AddWithValue("@fim", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Contacao: ", ex.Message));

            }
        }

        public string IncluirMembrosContacao(
                   string ID_Localidade,
                   int ID_Contacao,
                   int ID_Usuario,
                   string Funcao,
                   string Login
                   )
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[6];
                SqlCommand cmd = new SqlCommand("[dbo].[PresencaMembrosUPD]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                if (ID_Usuario != null) { cmd.Parameters.AddWithValue("@ID_Usuario", ID_Usuario); } else { cmd.Parameters.AddWithValue("@ID_Usuario", DBNull.Value); }
                if (Funcao != null) { cmd.Parameters.AddWithValue("@Funcao", Funcao); } else { cmd.Parameters.AddWithValue("@Funcao", DBNull.Value); }
                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[5].Size = 1000;
                cmd.Parameters[5].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[5].Value.ToString()))
                {
                    ret = cmd.Parameters[5].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string IncluirMembrosContacaoAnterior(
                  string ID_Localidade,
                  int ID_Contacao,            
                  string Login
                  )
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[4];
                SqlCommand cmd = new SqlCommand("[dbo].[PresencaMembrosCopiaAnterior]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
               
                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[3].Size = 1000;
                cmd.Parameters[3].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[3].Value.ToString()))
                {
                    ret = cmd.Parameters[3].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string ExcluirMembrosContacao(
                  string ID_Localidade,
                  int ID_Contacao,
                  string Login
                  )
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[4];
                SqlCommand cmd = new SqlCommand("[dbo].[PresencaMembrosDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }

                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[3].Size = 1000;
                cmd.Parameters[3].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[3].Value.ToString()))
                {
                    ret = cmd.Parameters[3].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public string ArquivoPlano(
                 string ID_Localidade,
                 int ID_Contacao,
                 byte[] Arquivo,
                 string NomeArquivo,
                 string Login
                 )
        {

            try
            {
                string ret = "";

                SqlParameter[] colparam = new SqlParameter[6];
                SqlCommand cmd = new SqlCommand("[dbo].[ArquivoPlanoUPD]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                if (Arquivo != null) { cmd.Parameters.AddWithValue("@Arquivo",Arquivo); } else { cmd.Parameters.AddWithValue("@Arquivo", DBNull.Value); }
                if (NomeArquivo != null) { cmd.Parameters.AddWithValue("@NomeArquivo", NomeArquivo); } else { cmd.Parameters.AddWithValue("@NomeArquivo", DBNull.Value); }
                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[5].Size = 1000;
                cmd.Parameters[5].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[5].Value.ToString()))
                {
                    ret = cmd.Parameters[5].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public DataTable GetFuncao(string ID_Localidade)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetFuncao]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
              
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Funcao: ", ex.Message));

            }
        }

        public byte[] GetArquivo(string ID_Localidade, int ID_Contacao)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ArquivoPlanoGET]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
              

                var bytes = cmd.ExecuteScalar() as byte[];
               
                return bytes;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar arquivo: ", ex.Message));

            }
        }
        public DataTable GetBiblia()
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetBiblia]", Conexao._dbConnSQL);
              
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar livros da Biblia: ", ex.Message));

            }
        }
    }
}
