﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Traslados.BLL;

namespace Traslados.WEB
{
    public partial class listUsuarios : System.Web.UI.Page
    {
        API api = new API();
        protected void Page_Load(object sender, EventArgs e)
        {
            Populate();
        }

        public void Populate()
        {
            DataSet ds = new DataSet();
            ds = api.Usuario.getUsuariosList();
            gvUsuarios.DataSource = ds;
            gvUsuarios.DataBind();
        }
    }
}