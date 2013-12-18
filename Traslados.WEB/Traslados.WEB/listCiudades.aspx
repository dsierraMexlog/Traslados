<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listCiudades.aspx.cs" Inherits="Traslados.WEB.listCiudades" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <a href="../abcCiudades" >Agregar</a>
    <asp:GridView runat="server" ID="gvCiudades" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="../abcCiudades/<%# Eval("id") %>" ><%# Eval("nombre") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="estado" />
        </Columns>
    </asp:GridView>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
