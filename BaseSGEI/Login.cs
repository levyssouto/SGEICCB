using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSGEI
{
    public class Login
    {
        #region "Propriedades"
        static public string LoginUserSGEI { get; set; }
        static public string SenhaSGEI { get; set; }
        static public string Ambiente { get; set; }
        public static string[] AutenticaUsuario(string login, string senha,string ID_Localidade)
        {
            string[] ret = new string[4];
            string senhaCrypt = senha = Cript(senha.Trim(), true);
            try
            {
                Login.LogarYMS();
                SqlParameter[] colparam = new SqlParameter[7];

                colparam[0] = new SqlParameter("@Login", login.Trim());
                colparam[1] = new SqlParameter("@SenhaCrypt", senha);
                colparam[2] = new SqlParameter("@ID_Localidade", ID_Localidade);
                colparam[3] = new SqlParameter("@Retorno", SqlDbType.VarChar,1000);
                colparam[3].Direction = ParameterDirection.Output;
                colparam[4] = new SqlParameter("@Perfil", SqlDbType.VarChar, 50);
                colparam[4].Direction = ParameterDirection.Output;
                colparam[5] = new SqlParameter("@Nome", SqlDbType.VarChar, 150);
                colparam[5].Direction = ParameterDirection.Output;
                colparam[6] = new SqlParameter("@LocalidadeNome", SqlDbType.VarChar, 150);
                colparam[6].Direction = ParameterDirection.Output;
                Conexao.ExecutarSPSQL("dbo.AutenticarUsuario", colparam);
                if (!(colparam[3].Value == DBNull.Value))
                {

                    try
                    {
                        ret[0] = colparam[3].Value.ToString();
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    ret[1] = colparam[4].Value.ToString();
                    ret[2] = colparam[5].Value.ToString();
                    ret[3] = colparam[6].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }
        #endregion

        private static int Asc(string letra)
        {
            return (int)(Convert.ToChar(letra));
        }

        private static char Chr(int codigo)
        {
            return (char)codigo;
        }
        public static void LogarYMS()
        {
            Login.Ambiente = ConfigurationManager.AppSettings["Ambiente"];
            try
            {
                if(Login.Ambiente == "DbGuaruja")
                {
                    Login.LoginUserSGEI = "sa";
                    Login.SenhaSGEI = "ccbei";
                }
              
                Conexao.ConectarSQL(Login.LoginUserSGEI, Login.SenhaSGEI, Login.Ambiente);
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                throw new Exception(sqlException.Message);
            }

            catch (Exception)
            {

                throw;
            }

        }
        public static string Cript(string senha, Boolean descript)
        {
            string SenhaDescriptografada = null;


            for (int i = 0; i < senha.Length; i++)
            {
                if (descript)
                    SenhaDescriptografada = SenhaDescriptografada + Chr(Asc(senha.Substring(i, 1)) + (i + 1));
                else
                    SenhaDescriptografada = SenhaDescriptografada + Chr(Asc(senha.Substring(i, 1)) + (i - 1));

            }
            return SenhaDescriptografada;
        }
        
    }
}
