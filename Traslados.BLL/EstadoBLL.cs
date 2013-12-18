using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Traslados.DAL;
using Traslados.BE;

namespace Traslados.BLL
{
    public class EstadoBLL
    {
        API _api;
        EstadoDAL estadoDal = new EstadoDAL();

        public EstadoBLL(API api)
        {
            _api = api;
        }
        public EstadoBLL() {
        }
        public DataSet getEstadosList()
        { 
            DataSet ds = new DataSet();
            ds = estadoDal.getEstadosList();
            return ds;
        }

        public Estado getEstadosByCiudad(int ciudad)
        {
            return estadoDal.getEstadosByCiudad(ciudad);
        }
    }
}
