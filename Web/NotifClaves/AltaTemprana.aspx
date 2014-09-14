<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AltaTemprana.aspx.cs" Inherits="AltaTemprana" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="mensaje">
        <asp:Label ID="lbMensaje" runat="server" />
    </div>
    <br />
    <table class="login">
        <tr>
            <td>
                Legajo
            </td>
            <td>
                <asp:TextBox ID="tbLegajo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Sociedad
            </td>
            <td>
                <asp:DropDownList ID="ddlSociedad" DataValueField="Id" DataTextField="Nombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn" runat="server" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

