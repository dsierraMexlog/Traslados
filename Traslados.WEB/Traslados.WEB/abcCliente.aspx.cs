using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;
using Traslados.BLL;
using Traslados.BE;

namespace Traslados.WEB
{
    public partial class abcCliente : System.Web.UI.Page
    {
        API api = new API();
        public List<Estado> Estados{ get; set; }
        int idC = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<string> urlSEgments = Request.GetFriendlyUrlSegments();
                if (urlSEgments.Count > 0)
                {
                    loadData(Convert.ToInt32(urlSEgments[0]));
                }
                else
                {
                    PopulateEStados();
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
                
            }
           
        }


        protected void PopulateEStados()
        {
            ddlEstados.DataSource = api.Estado.getEstadosList();
            ddlEstados.DataBind();
        }

        protected void loadData(int id)
        {
            idC = id;
            Concesionario _cliente = new Concesionario();
            _cliente = api.Cliente.getClienteById(id);
            txtNombre.Text = _cliente.nombre;
            txtdireccion.Text = _cliente.direccion;
            txtContacto.Text = _cliente.contacto;
            txtTelefono.Text = _cliente.telefono;
            txtEmail.Text = _cliente.email;
            //estado y ciudad
            Estado estado = new Estado();
            estado = api.Estado.getEstadosByCiudad(_cliente.ciudad);
            ddlEstados.DataSource = api.Estado.getEstadosList();
            ddlEstados.DataBind();
            ddlCiudades.DataSource = api.Ciudades.getCiudadesList();
            ddlCiudades.DataBind();

            ddlCiudades.SelectedValue = _cliente.ciudad.ToString();
            ddlEstados.SelectedValue = estado.id.ToString();

            btnSave.Visible = false;

        }


        [WebMethod]
        public static List<Estado> GetResultset(int estado)
        {
            API api = new API();
            List<Estado> estados = new List<Estado>();
            DataSet ds = new DataSet();
            ds = api.Ciudades.getCiudadesListByEstado(estado);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        estados.Add(new Estado()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString()
                        });
                    }
                }
                else
                {
                    estados.Add(new Estado()
                    {
                        id = 0,
                        nombre = "-"
                    });
                }
            }

            return  estados;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ciudadValue = Request.Form[ddlCiudades.UniqueID];
            api.Cliente.save(txtNombre.Text, txtdireccion.Text, Convert.ToInt32( ciudadValue), txtContacto.Text, txtTelefono.Text, txtEmail.Text);
            Response.Redirect("~/listClientes/");
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.Cliente.update(id, txtNombre.Text, txtdireccion.Text, Convert.ToInt32(ddlCiudades.SelectedValue), txtContacto.Text, txtTelefono.Text, txtEmail.Text);
            lblInfo.Text = "Informacion Actualizada";
            lblInfo.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.Cliente.delete(id);
            Response.Redirect("~/listClientes/");
        }
    }
}