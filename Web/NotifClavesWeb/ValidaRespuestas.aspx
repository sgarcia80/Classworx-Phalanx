<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeBehind="ValidaRespuestas.aspx.cs" Inherits="NotifClavesWeb.ValidaRespuestas" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div style="text-align: left">
        <br />
        <table id="Table3" width="100%" cellspacing="1" cellpadding="1" border="0">
            <tr style="height: 5px">
                <td style="width: 98px; height: auto; background-color: #b0e0e6;">
                </td>
                <td style="background-color: #b0e0e6; height: auto; padding-left: 1">
                </td>
            </tr>
            <tr style="background-color: #f0f8ff">
                <td style="width: 98px; height: 19px;">
                </td>
                <td style="text-align: center left; width: auto; height: 19px;">
                    <asp:Label ID="lblTitulo" runat="server" CssClass="tdTituloSub">Responder las siguientes Preguntas de Seguridad</asp:Label>
                </td>
            </tr>
            <tr style="background-color: White;">
                <td style="width: auto; height: 19px;">
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center left">
        <table border="0" cellspacing="1" cellpadding="1" style="width: 100%; background-color: White">
            <tr id="TrQuestion1" runat="server">
                <td style="width:20%;">
                </td>
                <td style="width: ">
                    <asp:Label ID="lblQuestion1" runat="server" CssClass="leyenda"></asp:Label>
                </td>
            </tr>
            <tr style="padding-bottom: 10px;">
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer1" runat="server" CssClass="labelCombo" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 19px;" colspan="2">
                </td>
            </tr>
            <tr id="Tr1" runat="server">
                <td>
                </td>
                <td>
                    <asp:Label ID="lblQuestion2" runat="server" CssClass="leyenda" Width="387px"></asp:Label>
                </td>
            </tr>
            <tr style="padding-bottom: 10px;">
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer2" runat="server" CssClass="labelCombo" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 19px;" colspan="2">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td>
                </td>
                <td>
                    <asp:Label ID="lblQuestion3" runat="server" CssClass="leyenda"></asp:Label>
                 </td>
            </tr>
            <tr style="padding-bottom: 10px;">
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtAnswer3" runat="server" CssClass="labelCombo" Width="400px"></asp:TextBox>
                </td>
            </tr>
        </table>
    <br />
<div class="mensaje">
        <asp:Label ID="lblInfo" runat="server" style="color: Red" CssClass="LabelNormal"></asp:Label> 
    </div>
    <br />
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" rowspan="1" style="width: 50%" valign="top">
                    </td>
            </tr>
            <tr id="trBotGuardar" runat="server" >
                <td align="right" valign="middle">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn" Text="Aceptar"
                        ToolTip="Aceptar" CausesValidation="False" OnClick="btnAceptar_Click">
                    </asp:Button>
                </td>
                <td align="left" valign="middle">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn" Text="Volver"
                        ToolTip="Volver" CausesValidation="False" OnClick="btnVolver_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

