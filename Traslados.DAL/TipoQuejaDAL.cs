using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Traslados.BE;

namespace Traslados.DAL
{
    public class TipoQuejaDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");

        public TipoQuejaDAL(){
        }

        public DataSet getTipoQuejasList()
        {
            string sqlCommand = "dbo.sp_getTipoQuejasList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public TipoQueja getTipoQuejaById(int id)
        {
            TipoQueja queja= new TipoQueja();
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getTipoQuejaById";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                queja.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                queja.descripcion  = ds.Tables[0].Rows[0]["descripcion"].ToString();
            }
            catch (Exception e)
            {
                queja.id = 0;
                queja.descripcion = null;
            }
            return queja;
        }

        public void save(string descripcion)
        {
            string sqlCommand = "dbo.sp_insertTipoQueja";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@descripcion", DbType.String, descripcion);
            db.ExecuteNonQuery(dbCommand);
        }

        public void update(int id, string descripcion)
        {
            string sqlCommand = "dbo.sp_updateTipoQueja";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.AddInParameter(dbCommand, "@descripcion", DbType.String,descripcion);
            db.ExecuteNonQuery(dbCommand);
        }

        public void delete(int id)
        {
            string sqlCommand = "dbo.sp_deleteTipoQueja";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}
