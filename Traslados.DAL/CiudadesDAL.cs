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
    public class CiudadesDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
        public CiudadesDAL(){
        }

        #region CRUD Methods

        public DataSet getCiudadesList()
        {
            string sqlCommand = "dbo.sp_getCiudadesList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public Ciudades getCiudadeById(int id)
        {
            Ciudades ciudad = new Ciudades();
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getCiudadById";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                ciudad.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                ciudad.nombre = ds.Tables[0].Rows[0]["nombre"].ToString();
                ciudad.estado = Convert.ToInt32(ds.Tables[0].Rows[0]["estado"].ToString());
            }
            catch(Exception e ) 
            {
                ciudad.id = 0;
                ciudad.nombre = null;
            }
            return ciudad;
        }

        public void save(string nombre, int estado)
        {
            string sqlCommand = "dbo.sp_insertCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@nombre", DbType.String, nombre );
            db.AddInParameter(dbCommand, "@estado", DbType.Int32, estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void update(int id, string nombre, int estado)
        {
            string sqlCommand = "dbo.sp_updateCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.AddInParameter(dbCommand, "@nombre", DbType.String, nombre);
            db.AddInParameter(dbCommand, "@estado", DbType.Int32, estado);
            db.ExecuteNonQuery(dbCommand);
        }

        public void delete( int id)
        {
            string sqlCommand = "dbo.sp_deleteCiudad";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);
        }


        #endregion

        public DataSet getCiudadesListByEstado(int estado)
        {
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getCiudadesListByEstado";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@estado", DbType.Int32, estado);
            ds = db.ExecuteDataSet(dbCommand);
        
            return ds;
        }
    }
}
