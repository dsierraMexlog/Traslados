using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using Traslados.BLL;
using Traslados.BE;

namespace Traslados.WEB
{
    public partial class abcCiudades : System.Web.UI.Page
    {
        API api = new API();
        int idC = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<string> urlSEgments = Request.GetFriendlyUrlSegments();
                if (urlSEgments.Count > 0)
                    loadData(Convert.ToInt32(urlSEgments[0]));
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
                PopulateEStados();
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
            Ciudades ciudad = new Ciudades();
            ciudad = api.Ciudades.getCiudadeById(id);
            txtCiudad.Text = ciudad.nombre;
            ddlEstados.SelectedValue  = ciudad.estado.ToString();
            btnSave.Visible = false;
        }

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            api.Ciudades.save(txtCiudad.Text, Convert.ToInt32( ddlEstados.SelectedValue));
            Response.Redirect("~/listCiudades/");
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.Ciudades.update(id, txtCiudad.Text,Convert.ToInt32(ddlEstados.SelectedValue));
            lblInfo.Text = "Informacion Actualizada";
            lblInfo.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
                int id= Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
                api.Ciudades.delete(id);
                Response.Redirect("~/listCiudades/");
        }

        #endregion

    }
}