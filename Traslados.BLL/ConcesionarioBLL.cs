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
    public class ConcesionarioBLL
    {
        API _api;
        ConcesionarioDAL clienteDal = new ConcesionarioDAL();

        public ConcesionarioBLL(API api)
        {
            _api = api;
        }
        public ConcesionarioBLL() {
        }

        #region CRUD Methods

        public DataSet getClientesList()
        {
            DataSet ds = new DataSet();
            ds = clienteDal.getClientesList();
            return ds;
        }

        public Concesionario getClienteById(int id)
        {
            Concesionario _cliente = new Concesionario();
            return clienteDal.getClienteById(id);
        }

        public void save(string nombre, string direccion, int ciudad, string contacto, string telefono, string email)
        {
            clienteDal.save(nombre, direccion, ciudad, contacto, telefono, email);
        }

        public void update(int id, string nombre, string direccion, int ciudad, string contacto, string telefono, string email)
        {
            clienteDal.update(id, nombre, direccion, ciudad, contacto, telefono, email);
        }

        public void delete(int id)
        {
            clienteDal.delete(id);
        }

        #endregion 
    }
}
