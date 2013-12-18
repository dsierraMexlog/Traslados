<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listTipoQuejas.aspx.cs" Inherits="Traslados.WEB.listTipoQuejas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <a href="../abcTipoQueja" >Agregar</a>
    <asp:GridView runat="server" ID="gvTipoQuejas" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="../abcTipoQueja/<%# Eval("id") %>" ><%# Eval("descripcion") %></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
