<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="IdentificacionPositiva.aspx.cs" Inherits="NotifClavesWeb.IdentificacionPositiva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="titulo">
        Ingrese los siguientes datos
        <br />
        <br />
    </div>
    <div class="mensaje">
        <asp:Label ID="lbMensaje" runat="server" />
    </div>
    <br />
    <asp:Panel ID="pnlIdentificacion" runat="server">
        <table class="login">
            <tr>
                <td class="choice">Direcci&oacute;n:
                </td>
                <td>
                    <br />
                    Domicilio particular:
                    <asp:RadioButtonList ID="rblCalle" runat="server" />
                    <br />
                    Numero:
                    <asp:RadioButtonList ID="rblNumero" runat="server" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="choice">Fecha Nacimiento:
                </td>
                <td>
                    <br />
                    <asp:RadioButtonList ID="rblFechas" runat="server" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="choice">Documento:
                </td>
                <td>
                    <br />
                    Tipo:
                    <asp:RadioButtonList ID="rblTipoDocumento" runat="server" />
                    <br />
                    Número:
                    <asp:RadioButtonList ID="rblDocumento" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table class="login">
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn" runat="server" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfIdLegajo" runat="server" />
</asp:Content>
