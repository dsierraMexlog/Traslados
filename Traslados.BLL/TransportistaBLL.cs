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
    public class TransportistaBLL
    {
        API _api;
        TransportistaDAL transportistaDal = new TransportistaDAL();

        public TransportistaBLL(API api)
        {
            _api = api;
        }
        public TransportistaBLL()
        {
        }

        #region CRUD Methods

        public DataSet getTransportistasList()
        {
            DataSet ds = new DataSet();
            ds = transportistaDal.getTransportistasList();
            return ds;
        }

        public Transportista getTransportistaById(int id)
        {
            Transportista _transportista = new Transportista();
            return transportistaDal.getTransportistaById(id);
        }

        public void save(string nombre, string direccion, int ciudad, string contacto, string telefono, string email)
        {
            transportistaDal.save(nombre, direccion, ciudad, contacto, telefono, email);
        }

        public void update(int id, string nombre, string direccion, int ciudad, string contacto, string telefono, string email)
        {
            transportistaDal.update(id, nombre, direccion, ciudad, contacto, telefono, email);
        }

        public void delete(int id)
        {
            transportistaDal.delete(id);
        }

        #endregion 
    }
}
