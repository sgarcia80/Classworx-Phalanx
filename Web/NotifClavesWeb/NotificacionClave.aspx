<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeBehind="NotificacionClave.aspx.cs" Inherits="NotifClavesWeb.NotificacionClave" Title="Macro SA - Notificación de Claves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="tituloSeccion">
        Notificación de Claves</div>
    <br />
    <div class="titulo">
        Recursos Internos y Externos
    </div>
    <br />
    <div class="mensaje">
        <asp:Label ID="lblMensajeNotif" runat="server" />
    </div>
    <br />
    <table class="login">
        <tr>
            <td>
                Dominio
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlDominio" runat="server"
                    DataTextField="NtName" DataValueField="Id" Width="166px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Usuario
            </td>
            <td colspan="3">
                <asp:TextBox ID="tbLegajo" runat="server" Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <br />
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn" runat="server" OnClick="btnAceptar_Click" />
            </td>
            <td>
            </td>
            <td align="center" style="width: 71px">
                <br />
                <br />
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click"
                    Width="69px" />
            </td>
        </tr>
    </table>
    <br />
    <div class="division">
    </div>
</asp:Content>
