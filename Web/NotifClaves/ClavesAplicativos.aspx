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
                <asp:Button ID="btnCOBIS" Text="Autogestión COBIS" CssClass="btn" Width="180px" runat="server"
                    OnClick="btnCOBIS_Click" Height="60px" BorderWidth="2" />
            </td>
            <td align="left" style="font-weight: normal;">
                Permite realizar el Desbloqueo o Cambiar la contraseña de COBIS<br />
                <asp:Label ID="lblBloqueoCobis" runat="server" ForeColor="Red" Font-Bold="true" Text="La Autogestión Cobis está temporalmente deshabilitada."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="width: 210px;">
                <asp:Button ID="btnNotifClaves" Text="Notificación de Claves" CssClass="btn" Width="180px"
                    runat="server" OnClick="btnNotifClaves_Click" Height="60px" BorderWidth="2" />
            </td>
            <td align="left" style="font-weight: normal;">
                Ingresando por esta opción, vas a poder acceder a:<ul>
                    <li>Notificaciones de Claves de Alta de Usuario de Aplicación</li>
                    <li>Notificaciones de Blanqueo de Claves solicitadas por Remedy</li>
                    <li>Notificaciones de Blanqueo de Claves de Tarjetas de Crédito</li>
                </ul>
            </td>
        </tr>
    </table>
    <div class="tituloSeccion">
    </div>
    <asp:Panel ID="panelTarjetas" runat="server">
        <br />
        <table class="login" style="font-size: 10pt;">
            <tr>
                <td align="center" valign="top" style="width: 210px;">
                    <asp:Button ID="btnTarjetas" Text="Blanqueo Usuario Tarj." CssClass="btn" Width="180px"
                        runat="server" OnClick="btnTarjetas_Click" Height="60px" BorderWidth="2" />
                </td>
                <td align="left" style="font-weight: normal; width: 387px;">
                    Permite solicitar un Blanqueo de Usuario de Tarjetas de Crédito
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="panelPreguntas" runat="server">
        <br />
        <div class="division">
        </div>
        <br />
        <table class="login" style="font-size: 10pt;">
            <tr>
                <td align="center" valign="top" style="width: 210px;">
                    <asp:Button ID="btnPreguntas" Text="Cargar/Editar Preguntas" CssClass="btn" Width="180px"
                        runat="server" OnClick="btnPreguntas_Click" Height="60px" BorderWidth="2" />
                </td>
                <td align="left" style="font-weight: normal; width: 387px;">
                    Permite dar de alta o modificar preguntas de seguridad
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
