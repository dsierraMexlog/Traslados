using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Traslados.BE;

namespace Traslados.DAL
{
    public class UsuarioDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
        public UsuarioDAL(){
        }

        #region CRUD Methods

        public DataSet getUsuariosList()
        {
            string sqlCommand = "dbo.sp_getUsuariosList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public Usuario getUsuarioById(int id)
        {
            Usuario _usuario = new Usuario();
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getUsuarioById";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                _usuario.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                _usuario.usuario = ds.Tables[0].Rows[0]["usuario"].ToString();
                _usuario.password = ds.Tables[0].Rows[0]["password"].ToString();
                _usuario.nivel = Convert.ToInt32(ds.Tables[0].Rows[0]["nivel"].ToString());
            }
            catch (Exception e)
            {
                _usuario.id = 0;
                _usuario.usuario = null;
            }
            return _usuario;
        }

        public void save(string usuario, string  password, int nivel)
        {
            string sqlCommand = "dbo.sp_insertUsuario";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@usuario", DbType.String, usuario);
            db.AddInParameter(dbCommand, "@password", DbType.String, password);
            db.AddInParameter(dbCommand, "@nivel", DbType.Int32, nivel);
            db.ExecuteNonQuery(dbCommand);
        }

        public void update(int id, string usuario, string password, int nivel)
        {
            string sqlCommand = "dbo.sp_updateCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.AddInParameter(dbCommand, "@usuario", DbType.String, usuario);
            db.AddInParameter(dbCommand, "@password", DbType.String, password);
            db.AddInParameter(dbCommand, "@nivel", DbType.Int32, nivel);
            db.ExecuteNonQuery(dbCommand);
        }

        public void delete(int id)
        {
            string sqlCommand = "dbo.sp_deleteCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);
        }

        #endregion

    }
}
