using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;
using WebCons.Data;

namespace WebCons.WebUI.Utils
{
    public class UtilsDAO
    {
        public string stringaConnessione = ConfigurationManager.AppSettings["DATI_DB"];

        public bool UserIsAutenticato(string username, string password)
        {
            SessionData sessionData = SessionUtil.GetSessionObject_DATA(System.Web.HttpContext.Current);
            UserParametersDTO utente = new UserParametersDTO();
            utente.User = username ?? "";
            utente.Pass = password ?? "";

            string sql = "SELECT * FROM [Utenti] WHERE [User] = @User AND [Pass] = @Pass;";

            OleDbConnection conn = new OleDbConnection(stringaConnessione);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add("@User", OleDbType.VarChar).Value = utente.User;
            cmd.Parameters.Add("@Pass", OleDbType.VarChar).Value = utente.Pass;
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            try
            {
                #region DB
                if (reader.HasRows)
                {
                    reader.Read();
                    utente.Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0;
                    utente.Nome = reader["Nome"] != DBNull.Value ? reader["Nome"].ToString() : "";
                    utente.Cognome = reader["Cognome"] != DBNull.Value ? reader["Cognome"].ToString() : "";
                    utente.IsAdmin = reader["IsAdmin"] != DBNull.Value && (bool)reader["IsAdmin"];
                    sessionData.UserParameters = utente;
                }
                #endregion
            }
            catch (Exception)
            {
                conn.Close();
                conn.Dispose();
            }
            finally
            {
                reader.Close();
                conn.Close();
                conn.Dispose();    
            }
            return utente.Id != 0;
        }
    }
}