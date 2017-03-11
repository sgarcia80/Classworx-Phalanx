<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DesbloqueoUsuarioCOBIS.aspx.cs" Inherits="NotifClavesWeb.DesbloqueoUsuarioCOBIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="tituloSeccion">
        Desbloqueo de Usuario COBIS
    </div>
    <br />
    <table class="login" style="width: 500px">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label">Se solicitará desbloqueo de su usuario de COBIS </asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <asp:Button ID="btnDesbloquear" Text="Desbloquear" CssClass="btn"
                    runat="server" OnClick="btnDesbloquear_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server"
                    OnClick="btnVolver_Click" />
            </td>
        </tr>
        <tr runat="server" id="trTitRespuesta">
            <td>
                <br />
                Respuesta
            </td>
        </tr>
        <tr id="trRespuesta" runat="server" class="tdTituloSub">
            <td align="left">
                <br />
                <br />
                <asp:Label ID="lblResp1" runat="server" Text="Tu usuario COBIS"></asp:Label>&nbsp;
                <asp:Label ID="lblUsrName" runat="server" Text="nnnn" Font-Bold="True"></asp:Label>&nbsp;
                <asp:Label ID="lblResp2" runat="server" Text="no se ha podido desbloquear. Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!"></asp:Label><br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Equipo de Seguridad Informatica
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
