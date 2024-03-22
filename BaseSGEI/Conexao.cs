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
    public class Conexao
    {

        /// <summary>
        /// Nome Transação Atual
        /// </summary>
        static string _strNomeTransacaoAtual
        {
            get;
            set;
        }

        /// <summary>
        /// Conexão SQL
        /// </summary>
        public static SqlConnection _dbConnSQL
        {
            get;
            set;
        }

        /// <summary>
        /// Nome Transação Atual do SQL
        /// </summary>
        static SqlTransaction _dbTransSQL
        {
            get;
            set;
        }



        /// <summary>
        /// Nome Transação Atual do SQL
        /// </summary>
        static string _strNomeTransacaoAtualSQL
        {
            get;
            set;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        #region "SQL SERVER"

        public static void ConectarSQL(string strUsuario, string strSenha, string conexao)
        {
            try
            {

                //conexao = "DbYMSProduc";
                if (strUsuario == null || strSenha == null || conexao == null) { return; }

                StringBuilder sbConnect = new StringBuilder();


                ConnectionStringSettingsCollection connection = ConfigurationManager.ConnectionStrings;

                string connectionString = connection[conexao].ConnectionString;

                if (_dbConnSQL == null)
                {
                    sbConnect.Append(connectionString);
                    if (!(strUsuario == ""))
                    {
                        sbConnect.Append("User ID=");
                        sbConnect.Append(strUsuario);
                        sbConnect.Append(";Password=");
                        sbConnect.Append(strSenha);

                    }
                    _dbConnSQL = new SqlConnection(sbConnect.ToString());

                    _dbConnSQL.Open();

                }

                if (_dbConnSQL.State == ConnectionState.Closed)
                {
                    sbConnect.Append(connectionString);
                    if (_dbConnSQL == null)
                    {
                        sbConnect.Append(connectionString);
                        if (!(strUsuario == ""))
                        {
                            sbConnect.Append("User ID=");
                            sbConnect.Append(strUsuario);
                            sbConnect.Append(";Password=");
                            sbConnect.Append(strSenha);

                        }
                    }
                    _dbConnSQL = new SqlConnection(sbConnect.ToString());
                    if (_dbConnSQL.State == ConnectionState.Closed)
                    {
                        _dbConnSQL.Open();
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void DesconectarSQL()
        {
            if (_dbConnSQL != null)
            {
                if (!(_dbConnSQL.State == 0))
                {
                    _dbConnSQL.Close();
                    _dbConnSQL.Dispose();
                    _dbConnSQL = null;
                }
            }
        }

        public static DataTable ExecutarSPLocSQL(string pNomeSP, SqlParameter[] pInputPar)
        {

            DataTable dt;
            dt = new DataTable();
            SqlCommand dbCommand;
            dbCommand = _dbConnSQL.CreateCommand();
            dbCommand.CommandText = pNomeSP;
            dbCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dbCommand.Connection = _dbConnSQL;
                if (!(pInputPar == null))
                {
                    for (int i = 0; i <= pInputPar.Length - 1; i++)
                    {
                        dbCommand.Parameters.Add(pInputPar[i]);

                    }
                }
                //dbCommand.Parameters.Add(new SqlParameter("@RETORNO_OUT",SqlDbType.Udt,ParameterDirection.Output));
                SqlDataAdapter da;
                da = new SqlDataAdapter(dbCommand);
                da.Fill(dt);

            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
        public static void ExecutarSPSQL(string pNomeSP, SqlParameter[] pInputPar)
        {


            SqlCommand dbCommand = _dbConnSQL.CreateCommand();
            dbCommand.CommandText = pNomeSP;
            dbCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dbCommand.Connection = _dbConnSQL;
                if (!(pInputPar == null))
                {
                    for (int i = 0; i <= pInputPar.Length - 1; i++)
                    {
                        dbCommand.Parameters.Add(pInputPar[i]);

                    }
                }
                dbCommand.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void IniciarTransacaoSQL(string strNomeTransacao)
        {
            if (string.IsNullOrEmpty(_strNomeTransacaoAtual))
            {
                _strNomeTransacaoAtualSQL = strNomeTransacao;
                _dbTransSQL = _dbConnSQL.BeginTransaction();

            }
        }
        public static void EncerrarTransacaoSQL(string strNomeTransacao)
        {
            if (strNomeTransacao == _strNomeTransacaoAtualSQL)
            {
                _dbTransSQL.Commit();
                _dbTransSQL.Dispose();
                _strNomeTransacaoAtualSQL = null;
            }
        }
        public static void VoltarTransacaoSQL(string strNomeTransacao)
        {
            if (strNomeTransacao == _strNomeTransacaoAtualSQL)
            {
                _dbTransSQL.Rollback();
                _dbTransSQL.Dispose();
                _strNomeTransacaoAtualSQL = null;
            }
        }





        #endregion
    }
}
