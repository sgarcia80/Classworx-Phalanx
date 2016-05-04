<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ClavesAplicativos.aspx.cs" Inherits="ClavesAplicativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="tituloSeccion">
        Claves de Aplicativos</div>
    <br />
    <table class="login">
        <tr>
            <td align="center">
                <asp:Button ID="btnCOBIS" Text="Autogestión COBIS" CssClass="btn" Width="180px" 
                    runat="server" OnClick="btnCOBIS_Click"/>
            </td>
            <td align="left" style="width: 250px;">
                Permite realizar el Desbloqueo o Cambiar la contraseña de COBIS
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Button ID="btnNotifClaves" Text="Notificación de Claves" CssClass="btn" 
                    Width="180px" runat="server" onclick="btnNotifClaves_Click" />
            </td>
            <td align="left">
                Lista las notificaciones de Alta de usuario y Notificación de Blanqueo
            </td>
        </tr>
    </table>
    <br />
    <div class="division">
    </div>
    <br />

    <table class="login" style="width:100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

