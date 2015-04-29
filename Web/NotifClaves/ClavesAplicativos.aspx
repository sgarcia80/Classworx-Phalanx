<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ClavesAplicativos.aspx.cs" Inherits="ClavesAplicativos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="tituloSeccion">
        Claves de Aplicativos</div>
    <br />
    <table class="login">
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnCOBIS" Text="Autogestión COBIS" CssClass="btn" Width="180px" 
                    runat="server" onclick="btnCOBIS_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:Button ID="btnNotifClaves" Text="Notificación de Claves" CssClass="btn" 
                    Width="180px" runat="server" onclick="btnNotifClaves_Click" />
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

