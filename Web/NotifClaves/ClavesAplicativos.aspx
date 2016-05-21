<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="ClavesAplicativos.aspx.cs" Inherits="ClavesAplicativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="tituloSeccion">
        Claves de Aplicativos</div>
    <br />
    <table class="login" style="font-size: 10pt;">
        <tr>
            <td align="center" valign="top" style="width: 210px;">
                <asp:Button ID="btnCOBIS" Text="Autogestión COBIS" CssClass="btn"  Width="180px"
                    runat="server" OnClick="btnCOBIS_Click" Height="60px" BorderWidth="2" />
            </td>
            <td align="left" style="font-weight: normal;">
                Permite realizar el Desbloqueo o Cambiar la contraseña de COBIS
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 210px;">
                <asp:Button ID="btnNotifClaves" Text="Notificación de Claves" CssClass="btn" Width="180px"
                    runat="server" OnClick="btnNotifClaves_Click" Height="60px" BorderWidth="2" />
            </td>
            <td align="left" style="font-weight: normal;">Ingresando por esta opción, vas a poder acceder a:
                    <br /><asp:RadioButton ID="chkNotifAlta" runat="server" GroupName="TipoNotif" Checked="true" Text="Notificaciones de Claves de Alta de Usuario de Aplicación" />
                    <br /><asp:RadioButton ID="chkNotifBlanqueo" runat="server" GroupName="TipoNotif" Text="Notificaciones de blanqueo de Claves solicitadas por Remedy" />
            </td>
        </tr>
    </table>
    <br />
    <div class="division">
    </div>
    <br />
    <table class="login" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
