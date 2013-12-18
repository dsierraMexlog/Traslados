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
    public partial class abcTipoQueja : System.Web.UI.Page
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
            }
        }

        protected void loadData(int id)
        {
            idC = id;
            TipoQueja queja = new TipoQueja();
            queja = api.TipoQueja.getTipoQuejaByID(idC);
            txtDescripcion.Text = queja.descripcion ;
            btnSave.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            api.TipoQueja.save(txtDescripcion.Text);
            Response.Redirect("~/listTipoQuejas");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.TipoQueja.update(id, txtDescripcion.Text);
            lblInfo.Text = "Informacion Actualizada";
            lblInfo.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.GetFriendlyUrlSegments()[0]);
            api.TipoQueja.delete(id);
            Response.Redirect("~/listTipoQuejas");
        }


    }
}