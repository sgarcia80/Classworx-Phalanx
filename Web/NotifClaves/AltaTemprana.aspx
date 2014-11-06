<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AltaTemprana.aspx.cs" Inherits="AltaTemprana" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="titulo">
        Recursos Internos
    </div>
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
            </td>
        </tr>
    </table>
    <br />
    <div class="division">
    </div>
    <br />
    <div class="titulo">
        Recursos Externos
    </div>
        <br />
    <div class="mensaje">
        <asp:Label ID="lbMensajeToken" runat="server" />
    </div>
    <br />
    <table class="login">
        <tr>
            <td>
                Token
            </td>
            <td>
                <asp:TextBox ID="tbToken" Width="270px" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:Button ID="btnAceptarToken" Text="Aceptar" CssClass="btn" runat="server" 
                    onclick="btnAceptarToken_Click" />
                
            </td>
        </tr>
    </table>
    <br />
    <div class="division">
    </div>

    <br />

    <table class="login">
        <tr>
            <td align="center">
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

