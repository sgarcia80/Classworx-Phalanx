<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AutogestionCOBIS.aspx.cs" Inherits="AutogestionCOBIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="tituloSeccion">
        Autogestión de Usuario COBIS</div>
    <br />
    <table class="login">
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnDesbloqueoCOBIS" Text="Desbloqueo de Usuario" CssClass="btn" Width="180px" 
                    runat="server" onclick="btnDesbloqueoCOBIS_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:Button ID="btnCambioClave" Text="Cambio de Clave" CssClass="btn" 
                    Width="180px" runat="server" onclick="btnCambioClave_Click"/>
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

