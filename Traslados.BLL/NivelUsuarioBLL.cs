using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Traslados.BE;
using Traslados.DAL;

namespace Traslados.BLL
{
    public class NivelUsuarioBLL  :UsuarioBLL
    {
        API _api;
        NivelUsuarioDAL usuarioDal = new NivelUsuarioDAL();

        public NivelUsuarioBLL(API api)
        {
            _api = api;
        }

        public NivelUsuarioBLL() { }

        public DataSet getNivelesUsuariosList()
        {
            DataSet ds = new DataSet();
            ds = usuarioDal.getNivelesUsuariosList();
            return ds;
        }


    }
}
