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
    public class NivelUsuarioDAL
    {
        Database db = DatabaseFactory.CreateDatabase("DefaultConnection");
        public NivelUsuarioDAL(){
        }

        public DataSet getNivelesUsuariosList()
        {
            string sqlCommand = "dbo.sp_getUsuariosNivelesList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
