using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traslados.BE;
using Traslados.DAL;

namespace Traslados.BLL
{
    public class TipoQuejaBLL
    {
        API _api;
        TipoQuejaDAL tipoQuejaDAl = new TipoQuejaDAL();


        public TipoQuejaBLL(API api) {
            _api = api;
        }

        public TipoQuejaBLL(){
        }

        public DataSet getTipoQuejasList()
        {
            return tipoQuejaDAl.getTipoQuejasList();
        }

        public TipoQueja getTipoQuejaByID(int id)
        {
            return tipoQuejaDAl.getTipoQuejaById(id);
        }

        public void save(string descripcion)
        {
            tipoQuejaDAl.save(descripcion);
        }

        public void update(int id, string descripcion)
        {
            tipoQuejaDAl.update(id, descripcion);
        }

        public void delete(int id)
        {
            tipoQuejaDAl.delete(id);
        }

    }
}
