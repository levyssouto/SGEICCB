using System;
using System.Data;
using System.Data.SqlClient;

namespace BaseSGEI
{
    public class Crianca
    {
        public Crianca()
        {
            BaseSGEI.Login.LogarYMS();
        }
        public DataTable ListarCrianca(string ID_Localidade,string Nome,int? ID_Crianca)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaCrianca]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Nome != null) { cmd.Parameters.AddWithValue("@Nome", Nome); } else { cmd.Parameters.AddWithValue("@Nome", DBNull.Value); }
                if (ID_Crianca != null) { cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca); } else { cmd.Parameters.AddWithValue("@ID_Crianca", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Criancas: ", ex.Message));

            }
        }
        public DataTable RelatorioFrequenciaCrianca(string ID_Localidade)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaCriancaFreqPresenca]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                 cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar ListaCriancaFreqPresenca: ", ex.Message));

            }
        }
        public DataTable ListarCriancaByCracha(string ID_Localidade, int Cracha, int ID_Contacao)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaCriancaByCracha]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Cracha != null) { cmd.Parameters.AddWithValue("@Cracha", Cracha); } else { cmd.Parameters.AddWithValue("@Cracha", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar Criancas por crachá: ", ex.Message));

            }
        }
        public DataTable GetDadosCracha(string ID_Localidade,int ID_Crianca)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetDadosCracha]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Crianca != null) { cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca); } else { cmd.Parameters.AddWithValue("@ID_Crianca", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar dados do cracha: ", ex.Message));

            }
        }
        public DataTable GetDadosEtiqueta(string ID_Localidade, string ID_Contacao, string ID_Crianca)
        {
            string ret="";
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[EmiteEtiqueta]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                if (ID_Crianca != null) { cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca); } else { cmd.Parameters.AddWithValue("@ID_Crianca", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[3].Size = 1000;
                cmd.Parameters[3].Direction = ParameterDirection.Output;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);
                
                if (!String.IsNullOrEmpty(cmd.Parameters[3].Value.ToString()))
                {
                    ret = cmd.Parameters[3].Value.ToString();
                    if (ret !="")                        
                    {
                        throw new Exception(ret.ToString());
                    }

                }
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar dados do cracha: ", ex.Message));

            }
        }
        public string[] IncluirCrianca(
                     string ID_Localidade ,
                     string Nome ,
                     string NomeCracha,
                     DateTime? Nascimento ,
                     int Idade ,                     
                     string RespAtualiza, 
                     string NomeResponsavel,
                     string Parentesco ,
                     string Contato,
                     string ComumCongregacao ,
                     int? Testemunhado ,
                     string Sexo,
                     int IDAltCrianca
                     )
        {
            string[] ret= new string[2];
            try
            {
                
                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[15];
                SqlCommand cmd = new SqlCommand("[dbo].[CriancaINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Nome != null) { cmd.Parameters.AddWithValue("@Nome", Nome.ToUpper()); } else { cmd.Parameters.AddWithValue("@Nome", DBNull.Value); }
                if (IDAltCrianca != null) { cmd.Parameters.AddWithValue("@IDAltCrianca", IDAltCrianca); } else { cmd.Parameters.AddWithValue("@IDAltCrianca", DBNull.Value); }
                if (NomeCracha != null) { cmd.Parameters.AddWithValue("@NomeCracha", NomeCracha.ToUpper()); } else { cmd.Parameters.AddWithValue("@NomeCracha", DBNull.Value); }
                if (Nascimento != null && Nascimento.ToString() != "01/01/0001 00:00:00") { cmd.Parameters.AddWithValue("@Nascimento", Nascimento); } else { cmd.Parameters.AddWithValue("@Nascimento", DBNull.Value); }
                if (Idade != null) { cmd.Parameters.AddWithValue("@Idade", Idade); } else { cmd.Parameters.AddWithValue("@Idade", DBNull.Value); }
                if (RespAtualiza != null) { cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza.ToUpper()); } else { cmd.Parameters.AddWithValue("@RespAtualiza", DBNull.Value); }
                if (NomeResponsavel != null) { cmd.Parameters.AddWithValue("@NomeResponsavel", NomeResponsavel.ToUpper()); } else { cmd.Parameters.AddWithValue("@NomeResponsavel", DBNull.Value); }
                if (Parentesco != null) { cmd.Parameters.AddWithValue("@Parentesco", Parentesco.ToUpper()); } else { cmd.Parameters.AddWithValue("@Parentesco", DBNull.Value); }
                if (Contato != null) { cmd.Parameters.AddWithValue("@Contato", Contato); } else { cmd.Parameters.AddWithValue("@Contato", DBNull.Value); }
                if (ComumCongregacao != null) { cmd.Parameters.AddWithValue("@ComumCongregacao", ComumCongregacao.ToUpper()); } else { cmd.Parameters.AddWithValue("@ComumCongregacao", DBNull.Value); }
                if (Testemunhado != null) { cmd.Parameters.AddWithValue("@Testemunhado", Testemunhado); } else { cmd.Parameters.AddWithValue("@Testemunhado", DBNull.Value); }
                if (Sexo != null) { cmd.Parameters.AddWithValue("@Sexo", Sexo); } else { cmd.Parameters.AddWithValue("@Sexo", DBNull.Value); }

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[13].Size = 1000;
                cmd.Parameters[13].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@IDCrianca", SqlDbType.Int);               
                cmd.Parameters[14].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters[13].Value.ToString()) )
                {
                    ret[0] = cmd.Parameters[13].Value.ToString();

                }
                else
                {
                    ret[1] = cmd.Parameters[14].Value.ToString();
                }
                return ret;
            }
            catch (Exception)
            {

                throw;
            }

           
        }
        public string AtualizaFoto(
                     string ID_Localidade,
                     int ID_Crianca,
                     byte[] Foto,
                     string RespAtualiza)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[15];
                SqlCommand cmd = new SqlCommand("[dbo].[CriancaUPDFoto]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca); 
                cmd.Parameters.AddWithValue("@Foto",Foto);
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
        public string ExcluiCrianca(
                     string ID_Localidade,
                     int ID_Crianca,
                     string MotivoExclusao,
                     string RespExclusao)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[15];
                SqlCommand cmd = new SqlCommand("[dbo].[CriancaDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca);
                cmd.Parameters.AddWithValue("@MotivoExclusao", MotivoExclusao);
                cmd.Parameters.AddWithValue("@Login", RespExclusao.ToUpper());

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
        public string EntradaCrianca(
                     int ID_Contacao,
                     string ID_Localidade,
                     int ID_Crianca,
                     int ID_ResponsavelEntrada,
                     DateTime DataEntrada,
                     string RespAtualiza)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[7];
                SqlCommand cmd = new SqlCommand("[dbo].[EntradaSaidaINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao);
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca);
                cmd.Parameters.AddWithValue("@ID_ResponsavelEntrada", ID_ResponsavelEntrada);
                cmd.Parameters.AddWithValue("@DataEntrada", DataEntrada);
                cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza.ToUpper());

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[6].Size = 1000;
                cmd.Parameters[6].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[6].Value != null)
                {
                    ret = cmd.Parameters[6].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string SaidaCrianca(
                     int ID_Contacao,
                     string ID_Localidade,
                     int ID_Crianca,
                     int ID_ResponsavelSaida,
                     DateTime DataSaida,
                     string RespAtualiza)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[7];
                SqlCommand cmd = new SqlCommand("[dbo].[EntradaSaidaUPD]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao);
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca);
                cmd.Parameters.AddWithValue("@ID_ResponsavelSaida", ID_ResponsavelSaida);
                cmd.Parameters.AddWithValue("@DataSaida", DataSaida);
                cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza.ToUpper());

                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[6].Size = 1000;
                cmd.Parameters[6].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[6].Value != null)
                {
                    ret = cmd.Parameters[6].Value.ToString();

                }

                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public string ExcluirEntrada(
                    int ID_Contacao,
                    string ID_Localidade,
                    int ID_Crianca,
                    string RespAtualiza)
        {
            string ret = "";
            try
            {

                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[7];
                SqlCommand cmd = new SqlCommand("[dbo].[EntradaSaidaDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao);
                cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade);
                cmd.Parameters.AddWithValue("@ID_Crianca", ID_Crianca);
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
        public void Dispose()
        {

            Conexao._dbConnSQL.Dispose();
            Conexao._dbConnSQL.Close();

            GC.SuppressFinalize(this);

        }
    }
}
