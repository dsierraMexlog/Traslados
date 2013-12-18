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
    public class UsuarioBLL
    {
        API _api;
        UsuarioDAL usuarioDal = new UsuarioDAL();

        public UsuarioBLL() { }

        public UsuarioBLL(API api)
        {
            _api = api;
        }

        public DataSet getUsuariosList()
        {
            DataSet ds = new DataSet();
            ds = usuarioDal.getUsuariosList();
            return ds;
        }


        public Usuario getUsuarioById(int id)
        {
            Usuario _cliente = new Usuario();
            return usuarioDal.getUsuarioById(id);
        }

        public void save(string usuario, string password, int nivel)
        {
            usuarioDal.save(usuario, password, nivel);

        }

        public void update(int id, string usuario, string password, int nivel)
        {
            usuarioDal.update(id, usuario, password, nivel);
        }

        public void delete(int id)
        {
            usuarioDal.delete(id);
        }


    }
}
