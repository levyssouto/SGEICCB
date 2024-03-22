using System;
using System.Data;
using System.Data.SqlClient;

namespace BaseSGEI
{
    public class Usuario
    {

        public Usuario()
        {
            BaseSGEI.Login.LogarYMS();
        }
        public DataTable GetUsuario(string ID_Localidade, string Tipo)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetUsuario]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Tipo != null) { cmd.Parameters.AddWithValue("@Tipo", Tipo); } else { cmd.Parameters.AddWithValue("@Tipo", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar membros: ", ex.Message));

            }
        }
        public DataTable GetUsuarioByID(string ID_Localidade, int ID)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetUsuario]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao localizar membro: ", ex.Message));

            }
        }
        public DataTable ListaUsuario(string ID_Localidade)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaUsuario]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
             
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar membros: ", ex.Message));

            }
        }
        public DataTable GetMembros(string ID_Localidade, int ID_Contacao)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[ListaPresencaMembros]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID_Contacao != null) { cmd.Parameters.AddWithValue("@ID_Contacao", ID_Contacao); } else { cmd.Parameters.AddWithValue("@ID_Contacao", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar presença dos membros: ", ex.Message));

            }
        }
        public DataTable GetEmail(string ID_Localidade, string Tipo)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetEmail]", Conexao._dbConnSQL);
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (Tipo != null) { cmd.Parameters.AddWithValue("@Tipo", Tipo); } else { cmd.Parameters.AddWithValue("@Tipo", DBNull.Value); }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Dr = new SqlDataAdapter(cmd);
                Dr.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Erro ao listar emails: ", ex.Message));

            }
        }

        public string IncluirMembro(
            string ID_Localidade,
            int? ID,
            string Nome,
            string Login,
            string Senha,
            string Contato,
            string Tipo,
            string Endereco,
            string email,
            string RG,
            string CPF,
            DateTime? InicioEspaco,
            DateTime? TerminoEspaco,
            string RespAtualiza,
            string PerfilAcesso)
        {
            string ret = "";
            try
            {

                SqlParameter[] colparam = new SqlParameter[16];
                SqlCommand cmd = new SqlCommand("[dbo].[UsuarioINS]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID != null) { cmd.Parameters.AddWithValue("@ID", ID); } else { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }
                if (Nome != null) { cmd.Parameters.AddWithValue("@Nome", Nome.ToUpper()); } else { cmd.Parameters.AddWithValue("@Nome", DBNull.Value); }
                if (Login != null) { cmd.Parameters.AddWithValue("@Login", Login); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }
                if (Senha != null) { cmd.Parameters.AddWithValue("@Senha", Senha.ToUpper()); } else { cmd.Parameters.AddWithValue("@Senha", DBNull.Value); }
                if (Contato != null) { cmd.Parameters.AddWithValue("@Contato", Contato); } else { cmd.Parameters.AddWithValue("@Contato", DBNull.Value); }
                if (Tipo != null) { cmd.Parameters.AddWithValue("@Tipo", Tipo); } else { cmd.Parameters.AddWithValue("@Tipo", DBNull.Value); }
                if (Endereco != null) { cmd.Parameters.AddWithValue("@Endereco", Endereco); } else { cmd.Parameters.AddWithValue("@Endereco", DBNull.Value); }
                if (email != null) { cmd.Parameters.AddWithValue("@email", email); } else { cmd.Parameters.AddWithValue("@email", DBNull.Value); }
                if (RG != null) { cmd.Parameters.AddWithValue("@RG", RG); } else { cmd.Parameters.AddWithValue("@RG", DBNull.Value); }
                if (CPF != null) { cmd.Parameters.AddWithValue("@CPF", CPF); } else { cmd.Parameters.AddWithValue("@CPF", DBNull.Value); }
                if (InicioEspaco != null) { cmd.Parameters.AddWithValue("@InicioEspaco", InicioEspaco); } else { cmd.Parameters.AddWithValue("@InicioEspaco", DBNull.Value); }
                if (TerminoEspaco != null) { cmd.Parameters.AddWithValue("@TerminoEspaco", TerminoEspaco); } else { cmd.Parameters.AddWithValue("@TerminoEspaco", DBNull.Value); }
                if (RespAtualiza != null) { cmd.Parameters.AddWithValue("@RespAtualiza", RespAtualiza); } else { cmd.Parameters.AddWithValue("@RespAtualiza", DBNull.Value); }
                if (PerfilAcesso != null) { cmd.Parameters.AddWithValue("@PerfilAcesso", PerfilAcesso); } else { cmd.Parameters.AddWithValue("@PerfilAcesso", DBNull.Value); }
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[15].Size = 1000;
                cmd.Parameters[15].Direction = ParameterDirection.Output;               

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[15].Value != null)
                {
                    ret= cmd.Parameters[15].Value.ToString();
                }
              
                return ret;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public string ExcluirMembro(
           string ID_Localidade,
           int ID,
           string RespAtualiza)
        {
            string ret = "";
            try
            {

                SqlParameter[] colparam = new SqlParameter[4];
                SqlCommand cmd = new SqlCommand("[dbo].[UsuarioDEL]", Conexao._dbConnSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ID_Localidade != null) { cmd.Parameters.AddWithValue("@ID_Localidade", ID_Localidade); } else { cmd.Parameters.AddWithValue("@ID_Localidade", DBNull.Value); }
                if (ID != null) { cmd.Parameters.AddWithValue("@ID", ID); } else { cmd.Parameters.AddWithValue("@ID", DBNull.Value); }              
                if (RespAtualiza != null) { cmd.Parameters.AddWithValue("@Login", RespAtualiza); } else { cmd.Parameters.AddWithValue("@Login", DBNull.Value); }
               
                cmd.Parameters.Add("@Retorno", SqlDbType.VarChar);
                cmd.Parameters[3].Size = 1000;
                cmd.Parameters[3].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters[3].Value != null)
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
    }
}
