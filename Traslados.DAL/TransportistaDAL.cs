using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Traslados.BE;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Traslados.DAL
{
    public class TransportistaDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
        public TransportistaDAL(){
        }

        #region CRUD Methods

        public DataSet getTransportistasList()
        {
            string sqlCommand = "dbo.sp_getTransportistasList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public Transportista getTransportistaById(int id)
        {
            Transportista _cliente = new Transportista();
            DataSet ds = new DataSet();
            string sqlCommand = "dbo.sp_getTransportistaById";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            try
            {
                ds = db.ExecuteDataSet(dbCommand);
                _cliente.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                _cliente.nombre = ds.Tables[0].Rows[0]["nombre"].ToString();
                _cliente.direccion = ds.Tables[0].Rows[0]["direccion"].ToString();
                _cliente.ciudad = Convert.ToInt32(ds.Tables[0].Rows[0]["ciudad"].ToString());
                _cliente.contacto = ds.Tables[0].Rows[0]["contacto"].ToString();
                _cliente.telefono = ds.Tables[0].Rows[0]["telefono"].ToString();
                _cliente.email = ds.Tables[0].Rows[0]["email"].ToString();
            }
            catch (Exception e)
            {
      
            }
            return _cliente;
        }

        public void save(string nombre, string direccion , int ciudad, string contacto, string telefono , string email )
        {
            string sqlCommand = "dbo.sp_insertTransportista";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@nombre", DbType.String, nombre);
            db.AddInParameter(dbCommand, "@direccion", DbType.String, direccion);
            db.AddInParameter(dbCommand, "@ciudad", DbType.Int32, ciudad);
            db.AddInParameter(dbCommand, "@contacto", DbType.String, contacto);
            db.AddInParameter(dbCommand, "@telefono", DbType.String, telefono);
            db.AddInParameter(dbCommand, "@email", DbType.String, email);
            db.ExecuteNonQuery(dbCommand);
        }

        public void update(int id, string nombre, string direccion, int ciudad, string contacto, string telefono, string email)
        {
            string sqlCommand = "dbo.sp_updateTransportista";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.AddInParameter(dbCommand, "@nombre", DbType.String, nombre);
            db.AddInParameter(dbCommand, "@direccion", DbType.String, direccion);
            db.AddInParameter(dbCommand, "@ciudad", DbType.Int32, ciudad);
            db.AddInParameter(dbCommand, "@contacto", DbType.String, contacto);
            db.AddInParameter(dbCommand, "@telefono", DbType.String, telefono);
            db.AddInParameter(dbCommand, "@email", DbType.String, email);
            db.ExecuteNonQuery(dbCommand);
        }

        public void delete(int id)
        {
            string sqlCommand = "dbo.sp_deleteCliente";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);
        } 
    
        #endregion
    }
}
