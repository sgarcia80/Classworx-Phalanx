<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="DetalleTicket.aspx.cs" Inherits="DetalleTicket" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div style="text-align: left">
        <br />
        <table id="Table3" width="100%" cellspacing="1" cellpadding="1" border="0">
            <tr style="height: 5px">
                <td style="width: 20%; height: auto; background-color: #b0e0e6;">
                </td>
                <td style="background-color: #b0e0e6; height: auto; padding-left: 1">
                </td>
            </tr>
            <tr style="background-color: #f0f8ff">
                <td style="width: 7px; height: 19px;">
                </td>
                <td style="text-align: left; width: auto; height: 19px;">
                    <asp:Label ID="lblPwdType" runat="server" CssClass="tdTituloSub">Ticket</asp:Label></td>
            </tr>
            <tr style="background-color: White;">
                <td style="width: 7px; height: 19px;">
                </td>
                <td style="width: auto; height: 19px;">
                    <asp:Label ID="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:Label></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center left">
        <table border="0" cellspacing="1" cellpadding="1" style="width: 100%; background-color: White">
            <tr id="row_Data_1" runat="server">
                <td id="colImage" align="center" rowspan="6" style="width: 20%; vertical-align: top; text-align: center;"
                    valign="top" runat="server">
                    &nbsp;</td>
                <td style="height: 16px; width: auto; text-align: left; vertical-align: middle">
                    <asp:Label ID="lblField1" runat="server" CssClass="LabelNormal">Fecha</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="tbFecha" runat="server" ReadOnly="True" Width="210px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr id="Tr1" runat="server">
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="LabelNormal">Tipo Solicitud</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbTipoSolicitud" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="210px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_2" runat="server">
                <td>
                    <asp:Label ID="lblField2" runat="server" CssClass="LabelNormal">Nro Solicitud</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbNroSolicitud" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="210px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_3" runat="server">
                <td>
                    <asp:Label ID="lblField3" runat="server" CssClass="LabelNormal">Aplicaci&oacute;n</asp:Label></td>
                <td>
                    <asp:TextBox ID="tbApp" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="210px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_4" runat="server">
                <td>
                    <asp:Label ID="lblField4" runat="server" CssClass="LabelNormal">Usuario</asp:Label></td>
                <td style="width: auto; height: auto;">
                    <asp:TextBox ID="tbUsuario" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="210px"></asp:TextBox></td>
            </tr>
            <tr id="trContra" visible="false" runat="server">
                <td>
                    <asp:Label ID="lblField5" runat="server" CssClass="LabelNormal">Contraseña</asp:Label></td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="tbContra" runat="server" ReadOnly="True" Width="210px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr id="trUsaContraRed" visible="false" runat="server">
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="LabelNormal">Usa Contraseña de Red</asp:Label> 
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" Enabled="false" Checked="true"  runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="vertical-align: top; width: 20%; text-align: center">
                </td>
                <td align="left" colspan="2" style="height:10px">
                </td>
            </tr>
        </table>
        <table id="tblSolicPwd" runat="server" cellspacing="1" cellpadding="1" border="0"
            style="width: 100%; height: auto; background-color: #f0f8ff">
            <tr style="background-color: #b0e0e6; height: 5px">
                <td align="center" rowspan="1" style="width: 20%" valign="top">
                </td>
                <td align="left">
                </td>
            </tr>
        </table>
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" rowspan="1" style="width: 20%" valign="top">
                    </td>
            </tr>
            <tr id="trBotGuardar" runat="server" >
                <td align="center" colspan="1" valign="middle" style="height:30; background-color: #f0f8ff; text-align: center;">
                </td>
                <td align="left" colspan="2" valign="middle" style="height:30">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn" Width="75px" Text="Volver"
                        ToolTip="Volver" CausesValidation="False" OnClientClick="window.history.back(1)">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

