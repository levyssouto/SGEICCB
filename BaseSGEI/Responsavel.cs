using System;
using System.Data;
using System.Data.SqlClient;

namespace BaseSGEI
{
    public class Responsavel
    {
        public Responsavel()
        {
            BaseSGEI.Login.LogarYMS();
        }
        public DataTable ListaResponsavel(string ID_Localidade, int? ID_Crianca, int? ID_Responsavel)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaResponsavel]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Crianca != null) { cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca); } else { cmd.Parameters.AddWithValue("@ID_Crianca", DBNull.Value); }
                if (ID_Responsavel != null) { cmd.Parameters.AddWithValue("@ID_Responsavel", ID_Responsavel); } else { cmd.Parameters.AddWithValue("@ID_Responsavel", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Criancas x Responsaveis: ", ex.Message));

            }
        }

        public DataTable ListaCadastroResponsavel(string ID_Localidade,  int? ID_Responsavel)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaCadastroResponsavel]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Responsavel != null) { cmd.Parameters.AddWithValue("@ID_Responsavel", ID_Responsavel); } else { cmd.Parameters.AddWithValue("@ID_Responsavel", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Responsaveis: ", ex.Message));

            }
        }

        public string AtualizaFoto(
                     string ID_Localidade,
                     int ID_Responsavel,
                     byte[] Foto,
                     string RespAtualiza)
        {
            string ret="";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[15];
                SqlCommand cmd = new SqlCommand("[dbo].[ResponsavelUPDFoto]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Responsavel", ID_Responsavel);
                cmd.Parameters.AddWithValue("@Foto", Foto);
                cmd.Parameters[2].SqlDbType = SqlDbType.Image;
                cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza.ToUpper());

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[4].Size = 1000;
                cmd.Parameters[4].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[4].Value != null)
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

        public string[] IncluirResponsavel(
            string ID_Localidade ,
            int IDCrianca ,
            string NomeResponsavel ,
            string Parentesco,
            string Contato,
            string ComumCongregacao ,
            int Testemunhado ,
            string RespAtualiza ,
            int? IDResponsavel
            
            )
        {
            string[] ret =new string[2] ;
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[11];
                SqlCommand cmd = new SqlCommand("[dbo].[ResponsavelINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (IDCrianca != null) { cmd.Parameters.AddWithValue("@IDCrianca", IDCrianca); } else { cmd.Parameters.AddWithValue("@IDCrianca", DBNull.Value); }
                if (NomeResponsavel != null) { cmd.Parameters.AddWithValue("@NomeResponsavel", NomeResponsavel.ToUpper()); } else { cmd.Parameters.AddWithValue("@NomeResponsavel", DBNull.Value); }
                if (IDResponsavel != null) { cmd.Parameters.AddWithValue("@IDResponsavel", IDResponsavel); } else { cmd.Parameters.AddWithValue("@IDResponsavel", DBNull.Value); }
                if (Parentesco != null) { cmd.Parameters.AddWithValue("@Parentesco", Parentesco.ToUpper()); } else { cmd.Parameters.AddWithValue("@Parentesco", DBNull.Value); }
                if (Contato != null) { cmd.Parameters.AddWithValue("@Contato", Contato); } else { cmd.Parameters.AddWithValue("@Contato", DBNull.Value); }
                if (ComumCongregacao != null) { cmd.Parameters.AddWithValue("@ComumCongregacao", ComumCongregacao.ToUpper()); } else { cmd.Parameters.AddWithValue("@ComumCongregacao", DBNull.Value); }
                if (Testemunhado != null) { cmd.Parameters.AddWithValue("@Testemunhado", Testemunhado); } else { cmd.Parameters.AddWithValue("@Testemunhado", DBNull.Value); }
                if (RespAtualiza != null) { cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza); } else { cmd.Parameters.AddWithValue("@RespAtualiza", DBNull.Value); }
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[9].Size = 1000;
                cmd.Parameters[9].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IDResponsavelOUT", SqlDbType.Int);
                cmd.Parameters[10].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[9].Value != null)
                {
                    ret[0] = cmd.Parameters[9].Value.ToString();

                }
                if (cmd.Parameters[10].Value != null)
                {
                    ret[1] = cmd.Parameters[10].Value.ToString();

                }
                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string ExcluiResponsavel(
                     string ID_Localidade,
                     int ID_Responsavel,
                     int ID_Crianca,
                     string MotivoExclusao,
                     string RespExclusao)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[6];
                SqlCommand cmd = new SqlCommand("[dbo].[ResponsavelDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Responsavel", ID_Responsavel);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca);
                cmd.Parameters.AddWithValue("@MotivoExclusao", MotivoExclusao);
                cmd.Parameters.AddWithValue("@Login", RespExclusao.ToUpper());

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[5].Size = 1000;
                cmd.Parameters[5].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[5].Value != null)
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
        public void Dispose()
        {

            Conexao._dbConnSQL.Dispose();
            Conexao._dbConnSQL.Close();

            GC.SuppressFinalize(this);

        }
    }
}
