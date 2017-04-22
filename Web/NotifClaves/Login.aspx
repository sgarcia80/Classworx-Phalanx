<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" Title="Macro SA - Notificación de Claves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Panel ID="pnlAltaRed" runat="server"  DefaultButton="btnAlta">
    <div class="titulo">
        Obten&eacute; tu clave inicial de RED
    </div>
    <table class="login">
        <tr>
            <td align="center">
                <br />
                <asp:Button ID="btnAlta" Text="Alta Temprana" CssClass="btn" runat="server" OnClick="btnAlta_Click" />
                <br />
                <br />
            </td>
        </tr>
    </table>
    <div class="division">
    </div>
    <br />
    <div class="titulo">
        Obten&eacute; tu clave de RED
    </div>
    <table class="login">
        <tr>
            <td align="center">
                <br />
                <asp:Button ID="btnNotificacionClave" Text="Notificación de Clave" CssClass="btn" runat="server" OnClick="btnNotificacion_Click" />
            </td>
        </tr>
    </table>
    <br />
</asp:Panel>
    <div class="division">
    </div>
    <br />
    <div class="titulo">
        Acced&eacute; a tus claves de APLICATIVOS
    </div>
    <br />
    <div class="mensaje">
        <br />
        <asp:Label ID="lbMensaje" Visible="false" runat="server" />
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAceptar">
    <table class="login">
        <tr>
            <td>
                Usuario
            </td>
            <td>
                <asp:TextBox ID="tbUsuario" runat="server"  Width="160px"/>
            </td>
        </tr>
        <tr>
            <td>
                Dominio
            </td>
            <td>
                 <asp:DropDownList ID="ddlDominio" runat="server" DataSourceID="odsDominiosLogin"
                    DataTextField="Nombre" DataValueField="DireccionAD" Width="166px">
                </asp:DropDownList><asp:ObjectDataSource ID="odsDominiosLogin" runat="server" SelectMethod="GetAllParaCombo"
                    TypeName="NDCBL.DominioLoginBusiness"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" Width="160px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn" runat="server" 
                    OnClick="btnAceptar_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
