<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="CargaRespuestasUsr.aspx.cs" Inherits="CargaRespuestasUsr" Title="Macro SA - Edición de Claves" %>
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
                    <asp:Label ID="lblTitulo" runat="server" CssClass="tdTituloSub">Edición de Respuestas de Seguridad</asp:Label>
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
                <td style="width:1px">
                </td>
                <td style="width:85px">
                    <asp:Label ID="lblQuestion1" runat="server" CssClass="LabelNormal">Pregunta 1</asp:Label>
                 </td>
                <td style="width: 272px;">
                    <asp:DropDownList ID="ddlQuestion1" DataValueField="Id" 
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
                <td style="width:23px">
                </td>
                <td style="width: 81px">
                    <asp:Label ID="lblAnswer1" runat="server" CssClass="LabelNormal">Respuesta 1</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtQuestion1" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr1" runat="server">
                <td style="width:1px">
                </td>
                <td style="width:85px">
                    <asp:Label ID="lblQuestion2" runat="server" CssClass="LabelNormal">Pregunta 2</asp:Label>
                 </td>
                <td style="width: 272px;">
                    <asp:DropDownList ID="ddlQuestion2" DataValueField="Id" 
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
                <td style="width:23px">
                </td>
                <td style="width: 81px">
                    <asp:Label ID="lblAnswer2" runat="server" CssClass="LabelNormal">Respuesta 2</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtQuestion2" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td style="width:1px">
                </td>
                <td style="width:85px">
                    <asp:Label ID="lblQuestion3" runat="server" CssClass="LabelNormal">Pregunta 3</asp:Label>
                 </td>
                <td style="width: 272px;">
                    <asp:DropDownList ID="ddlQuestion3" DataValueField="Id" 
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
                <td style="width:23px">
                </td>
                <td style="width: 81px">
                    <asp:Label ID="lblAnswer3" runat="server" CssClass="LabelNormal">Respuesta 3</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtQuestion3" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td style="width:1px">
                </td>
                <td style="width:85px">
                    <asp:Label ID="lblQuestion4" runat="server" CssClass="LabelNormal">Pregunta 4</asp:Label>
                 </td>
                <td style="width: 272px;">
                    <asp:DropDownList ID="ddlQuestion4" DataValueField="Id" 
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
                <td style="width:23px">
                </td>
                <td style="width: 81px">
                    <asp:Label ID="lblAnswer4" runat="server" CssClass="LabelNormal">Respuesta 4</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtQuestion4" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr4" runat="server">
                <td style="width:1px">
                </td>
                <td style="width:85px">
                    <asp:Label ID="lblQuestion5" runat="server" CssClass="LabelNormal">Pregunta 5</asp:Label>
                 </td>
                <td style="width: 272px;">
                    <asp:DropDownList ID="ddlQuestion5" DataValueField="Id" 
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
                <td style="width:23px">
                </td>
                <td style="width: 81px">
                    <asp:Label ID="lblAnswer5" runat="server" CssClass="LabelNormal">Respuesta 5</asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="txtQuestion5" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="tblSolicPwd" runat="server" cellspacing="1" cellpadding="1" border="0"
            style="width: 100%; height: auto; background-color: #f0f8ff">
            <tr style="background-color: #b0e0e6; height: 5px">
                <td align="center" rowspan="1" style="width: 20%" valign="top">
                </td>
                <td colspan="2">
                    <asp:Label ID="lblInfo" runat="server" style="color: Red" CssClass="LabelNormal"></asp:Label> 
                </td>
            </tr>
        </table>
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
                        ToolTip="Volver" CausesValidation="False" PostBackUrl="~/ClavesAplicativos.aspx">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

