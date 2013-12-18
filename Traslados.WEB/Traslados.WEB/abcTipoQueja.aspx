<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abcTipoQueja.aspx.cs" Inherits="Traslados.WEB.abcTipoQueja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          Descripcion :
         <asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox>
         <asp:Button runat="server" ID="btnSave" Text="Guardar" OnClick="btnSave_Click" />
         <asp:Button runat="server" ID="btnUpdate" Text="Actualizar" OnClick="btnUpdate_Click"    />
         <asp:Button runat="server" ID="btnDelete" Text="Borrar" OnClick="btnDelete_Click"   />
         <asp:Label runat="server" ID="lblInfo" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
