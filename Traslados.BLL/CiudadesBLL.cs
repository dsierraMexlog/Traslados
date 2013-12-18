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
    public class CiudadesBLL
    {
        API _api;
        CiudadesDAL ciudadesDal = new CiudadesDAL();

        public CiudadesBLL(API api)
        {
            _api = api;
        }
        public CiudadesBLL() {
        }
        public DataSet getCiudadesList()
        { 
            DataSet ds = new DataSet();
            ds = ciudadesDal.getCiudadesList();
            return ds;
        }

        #region CRUD Methods
        
        public Ciudades getCiudadeById(int id)
        {
            return ciudadesDal.getCiudadeById(id);        
        }

        public void save(string nombre, int estado)
        {
            ciudadesDal.save(nombre,estado);
        }

        public void update(int id, string nombre, int estado)
        {
            ciudadesDal.update(id, nombre, estado);
        }

        public void delete(int id)
        {
            ciudadesDal.delete(id);
        }

        #endregion 

        public DataSet getCiudadesListByEstado(int estado)
        {
            return ciudadesDal.getCiudadesListByEstado(estado);
        }
    }
}
