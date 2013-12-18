<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abcTransportista.aspx.cs" Inherits="Traslados.WEB.abcTransportista" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script src="scripts/jquery-1.8.2.min.js"></script>
    <script src="scripts/jquery.validate.min.js"></script>
    <script src="scripts/jquery.maskedinput.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Nombre : <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
        <br />
        Direccion : <asp:TextBox runat="server" ID="txtdireccion"></asp:TextBox>
        <br />
        Estado : <asp:DropDownList runat="server" ID="ddlEstados" DataTextField="nombre" DataValueField="id" onchange="populateCiudades()"></asp:DropDownList>
        <br />
        Ciudad : <asp:DropDownList runat="server" ID="ddlCiudades" DataTextField="nombre" DataValueField="id" EnableViewState="true"></asp:DropDownList>
        <br />
        Contacto : <asp:TextBox runat="server" ID="txtContacto"></asp:TextBox>
        <br />
        Telefono : <asp:TextBox runat="server" ID="txtTelefono"></asp:TextBox>
        <br />
        Email : <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click"     />
          <asp:Button runat="server" ID="btnUpdate" Text="Actualizar" OnClick="btnUpdate_Click"   />
          <asp:Button runat="server" ID="btnDelete" Text="Borrar" OnClick="btnDelete_Click"  />
          <asp:Label runat="server" ID="lblInfo" Visible="false"></asp:Label>
    </div>
    </form>
</body>
     <script>
         jQuery(function ($) {
             $("#txtTelefono").mask("(999) 999-9999");

         });
         function populateCiudades() {
             $("#ddlCiudades").empty();
             $.ajax({
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 url: "abcTransportista.aspx/GetResultset",
                 data: "{'estado': '" + $('#ddlEstados').val() + "'}",
                 dataType: "json",
                 success: function (Result) {

                     $.each(Result.d, function (key, value) {
                         $("#ddlCiudades").append($("<option></option>").val
                         (value.id).html(value.nombre));
                     });
                 },
                 error: function (Result) {
                     alert("Error");
                 }
             });
         }

         $("#form1").validate({
             rules: {
                 txtNombre: {
                     required: true
                 },
                 txtdireccion: {
                     required: true
                 },
                 ddlCiudades: {
                     required: true,
                     min: 1
                 }
             },
             messages: {
                 txtNombre: {
                     required: 'Campo Obligatorio'
                 },
                 txtdireccion: {
                     required: 'Campo Obligatorio'
                 },
                 ddlCiudades: {
                     required: 'Campo Obligatorio',
                     min: 'Campo Obligatorio'
                 }
             }
         });
    </script>
</html>
