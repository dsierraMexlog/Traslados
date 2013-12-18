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
    public class EstadoDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
        
        public EstadoDAL(){
        }

        public DataSet getEstadosList()
        {
            string sqlCommand = "dbo.sp_getEstadosList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public Estado getEstadosByCiudad(int ciudad)
        {
            Estado estado = new Estado();
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getEstadosByCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@ciudad", DbType.Int32, ciudad);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                estado.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                estado.nombre = ds.Tables[0].Rows[0]["nombre"].ToString();
            }
            catch (Exception e)
            {
                estado.id = 0;
                estado.nombre = null;
            }
            return estado;
        }
    }
}
