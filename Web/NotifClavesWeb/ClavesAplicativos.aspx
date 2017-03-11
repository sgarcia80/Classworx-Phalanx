<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ClavesAplicativos.aspx.cs" Inherits="NotifClavesWeb.ClavesAplicativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="tituloSeccion">
        Claves de Aplicativos
    </div>
    <br />
    <table class="login" style="font-size: 10pt;">
        <tr>
            <td align="center" valign="top" style="width: 210px;">
                <asp:Button ID="btnCOBIS" Text="Autogestión COBIS" CssClass="btn" Width="180px" runat="server"
                    OnClick="btnCOBIS_Click" Height="60px" BorderWidth="2" />
            </td>
            <td align="left" style="font-weight: normal;">Permite realizar el Desbloqueo o Cambiar la contraseña de COBIS
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
            <td align="left" style="font-weight: normal;">Ingresando por esta opción, vas a poder acceder a:<ul>
                <li>Notificaciones de Claves de Alta de Usuario de Aplicación</li>
                <li>Notificaciones de blanqueo de Claves solicitadas por Remedy</li>
            </ul>
            </td>
        </tr>
    </table>
    <div class="tituloSeccion">
    </div>
    <br />
    <asp:Panel ID="panelPreguntas" runat="server">
        <table class="login" style="font-size: 10pt;">
            <tr>
                <td align="center" valign="top" style="width: 210px;">
                    <asp:Button ID="btnPreguntas" Text="Cargar/Editar Preguntas" CssClass="btn" Width="180px"
                        runat="server" OnClick="btnPreguntas_Click" Height="60px" BorderWidth="2" />
                </td>
                <td align="left" style="font-weight: normal; width: 387px;">Permite dar de alta o modificar preguntas de seguridad
                </td>
            </tr>
        </table>
    </asp:Panel>
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
