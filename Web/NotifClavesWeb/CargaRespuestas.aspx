<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CargaRespuestas.aspx.cs" Inherits="NotifClavesWeb.CargaRespuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="tituloSeccion">
        Cargar/Editar Preguntas de Seguridad
    </div>
    <br />
    <div style="text-align: center left">
        <table border="0" cellspacing="1" width="100%" cellpadding="1" style="background-color: White">
            <tr id="TrQuestion1" runat="server">
                <td style="width: 20%;"></td>
                <td style="width: 85px">
                    <asp:Label ID="lblQuestion1" runat="server" CssClass="LabelNormal">Pregunta 1</asp:Label>
                </td>
                <td style="">
                    <asp:DropDownList ID="ddlQuestion1" DataValueField="Id"
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
            </tr>
            <tr>
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblAnswer1" runat="server" CssClass="LabelNormal">Respuesta 1</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion1" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr1" runat="server">
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblQuestion2" runat="server" CssClass="LabelNormal">Pregunta 2</asp:Label>
                </td>
                <td style="">
                    <asp:DropDownList ID="ddlQuestion2" DataValueField="Id"
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
            </tr>
            <tr>
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblAnswer2" runat="server" CssClass="LabelNormal">Respuesta 2</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion2" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblQuestion3" runat="server" CssClass="LabelNormal">Pregunta 3</asp:Label>
                </td>
                <td style="">
                    <asp:DropDownList ID="ddlQuestion3" DataValueField="Id"
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
            </tr>
            <tr>
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblAnswer3" runat="server" CssClass="LabelNormal">Respuesta 3</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion3" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr3" runat="server">
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblQuestion4" runat="server" CssClass="LabelNormal">Pregunta 4</asp:Label>
                </td>
                <td style="">
                    <asp:DropDownList ID="ddlQuestion4" DataValueField="Id"
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
            </tr>
            <tr>
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblAnswer4" runat="server" CssClass="LabelNormal">Respuesta 4</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion4" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
            <tr id="Tr4" runat="server">
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblQuestion5" runat="server" CssClass="LabelNormal">Pregunta 5</asp:Label>
                </td>
                <td style="">
                    <asp:DropDownList ID="ddlQuestion5" DataValueField="Id"
                        DataTextField="Nombre" runat="server" Width="387px" />
                </td>
            </tr>
            <tr>
                <td style=""></td>
                <td style="">
                    <asp:Label ID="lblAnswer5" runat="server" CssClass="LabelNormal">Respuesta 5</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuestion5" runat="server" CssClass="labelCombo" Width="327px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div class="mensaje">
            <asp:Label ID="lblInfo" runat="server" Style="color: Red" CssClass="LabelNormal"></asp:Label>
        </div>
        <br />
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" rowspan="1" style="width: 50%" valign="top"></td>
            </tr>
            <tr id="trBotGuardar" runat="server">
                <td align="right" valign="middle">&nbsp;&nbsp;
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn" Text="Aceptar"
                        ToolTip="Aceptar" CausesValidation="False" OnClick="btnAceptar_Click"></asp:Button>
                </td>
                <td align="left" valign="middle">&nbsp;&nbsp;
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn" Text="Volver" Visible="false"
                        ToolTip="Volver" CausesValidation="False" OnClick="btnVolver_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
