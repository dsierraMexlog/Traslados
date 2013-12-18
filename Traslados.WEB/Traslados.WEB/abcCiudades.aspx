<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abcCiudades.aspx.cs" Inherits="Traslados.WEB.abcCiudades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       Ciudad :
         <asp:TextBox runat="server" ID="txtCiudad"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlEstados" DataTextField="nombre" DataValueField="id" ></asp:DropDownList>
         <asp:Button runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" />
         <asp:Button runat="server" ID="btnUpdate" Text="Actualizar" OnClick="btnUpdate_Click"  />
         <asp:Button runat="server" ID="btnDelete" Text="Borrar" OnClick="btnDelete_Click" />
         <asp:Label runat="server" ID="lblInfo" Visible="false"></asp:Label>
    </div>
    </form>
</body>
<%--</html>--%>
