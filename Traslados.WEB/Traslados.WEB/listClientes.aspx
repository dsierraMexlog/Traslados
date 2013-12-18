<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listClientes.aspx.cs" Inherits="Traslados.WEB.listClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <a href="../abcClientes" >Agregar</a>
    <asp:GridView runat="server" ID="gvClientes" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="../abcClientes/<%# Eval("id") %>" ><%# Eval("nombre") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="direccion" />
            <asp:BoundField DataField="contacto" />
            <asp:BoundField DataField="telefono" />
            <asp:BoundField DataField="email" />
        </Columns>
    </asp:GridView>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
