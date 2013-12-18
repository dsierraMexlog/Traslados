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
    public partial class abcUsuario : System.Web.UI.Page
    {
        API api = new API();
        int idC = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
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
                    PopulateNiveles();
                }
            }
            else
            {
                Response.Redirect("./login.aspx");
            }

        }

        protected void PopulateNiveles()
        {
            ddlNiveles.DataSource = api.NivelUsuario.getNivelesUsuariosList();
            ddlNiveles.Items.Insert(0,"-Seleccione-");
            ddlNiveles.SelectedIndex = 0;
            ddlNiveles.DataBind();
        }

        protected void loadData(int id)
        {
            idC = id;
            Usuario _usuario = new Usuario();
            _usuario = api.Usuario.getUsuarioById(id);
            txtusuario.Text = _usuario.usuario;
            txtPassword.Text = _usuario.password;
            ddlNiveles.SelectedValue =  _usuario.nivel.ToString();
            btnSave.Visible = false;
        }

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            api.Usuario.save(txtusuario.Text, txtPassword.Text , Convert.ToInt32(ddlNiveles.SelectedValue));
            Response.Redirect("~/listUsuarios/");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.Usuario.update(id, txtusuario.Text, txtPassword.Text , Convert.ToInt32(ddlNiveles.SelectedValue));
            lblInfo.Text = "Informacion Actualizada";
            lblInfo.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.Usuario.delete(id);
            Response.Redirect("~/listCiudades/");
        }

        #endregion
    }
}