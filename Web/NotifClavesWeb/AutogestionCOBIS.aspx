<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeBehind="AutogestionCOBIS.aspx.cs" Inherits="NotifClavesWeb.AutogestionCOBIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="tituloSeccion">
        Autogestión de Usuario COBIS</div>
    <br />
    <table class="login">
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnDesbloqueoCOBIS" Text="Desbloqueo de Usuario" CssClass="btn" Width="180px" Height="60px" 
                    runat="server" onclick="btnDesbloqueoCOBIS_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:Button ID="btnCambioClave" Text="Cambio de Clave" CssClass="btn" Width="180px" Height="60px" 
                    runat="server" onclick="btnCambioClave_Click"/>
            </td>
        </tr>
    </table>
    <div class="mensaje">
        <br />
        <asp:Label ID="lbMensaje" Visible="false" runat="server" />
        <asp:Label ID="lblBloqueoCobis" runat="server" ForeColor="Red" Font-Bold="true" Text="La Autogestión Cobis está temporalmente deshabilitada.&nbsp;"></asp:Label>
    </div>
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

