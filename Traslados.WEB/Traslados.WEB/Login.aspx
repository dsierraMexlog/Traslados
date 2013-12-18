<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Traslados.WEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="Images/Logo-BraNix.png" style="height: 86px; width: 101px" />
        
            <div>Administracion de Traslados </div>
            <div>DAIMLER</div>
        <br />
        Username :<br />
&nbsp;<asp:TextBox runat="server" ID="txtusernmae" ></asp:TextBox>
        <br />
    Password :<br />
&nbsp;<asp:TextBox runat="server" ID="txtPassword" ></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btnLogin" Text="Entrar" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
