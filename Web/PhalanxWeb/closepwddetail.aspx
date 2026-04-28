<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="closepwddetail.aspx.cs" Inherits="PhalanxWeb.closepwddetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: left">
        <br />
        <table id="Table3" width="100%" cellspacing="1" cellpadding="1" border="0">
            <tr style="height: 5px">
                <td colspan="2" style="height: auto; background-color: #b0e0e6;"></td>
            </tr>
            <tr style="background-color: #f0f8ff">
                <td colspan="2" style="text-align: left; height: 19px;">
                    <asp:Label ID="lblPwdType" runat="server" CssClass="tdTituloSub">Contraseña de Aplicativo</asp:Label></td>
            </tr>
            <tr style="background-color: White;">
                <td align="center" rowspan="1" style="width: 20%; height: 21px;" valign="top"></td>
                <td style="width: auto; height: 19px;">
                    <asp:Label ID="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:Label></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center left">
        <table border="0" cellspacing="1" cellpadding="1" style="width: 100%; background-color: White">
            <tr id="Tr1" runat="server">
                <td id="colImage" align="center" rowspan="9" style="width: 20%; vertical-align: top; text-align: center;"
                    valign="top" runat="server">
                    <asp:Image ID="imgApplication" runat="server" ImageUrl="~/IMAGE/aplicacion_32.gif" /></td>
                <td style="height: 16px; width: 20%; text-align: left; vertical-align: middle">
                    <asp:Label ID="Label3" runat="server" CssClass="LabelNormal">Fecha de Solicitud</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="txtFechaSol" runat="server" ReadOnly="True" Width="160px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_1" runat="server">
                <td style="height: 16px; width: 20%; text-align: left; vertical-align: middle">
                    <asp:Label ID="lblField1" runat="server" CssClass="LabelNormal">Aplicación</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="txtField1" runat="server" ReadOnly="True" Width="160px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_2" runat="server">
                <td>
                    <asp:Label ID="lblField2" runat="server" CssClass="LabelNormal">CustomField1</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtField2" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="160px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_3" runat="server">
                <td>
                    <asp:Label ID="lblField3" runat="server" CssClass="LabelNormal">CustomField2</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtField3" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="160px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_4" runat="server">
                <td>
                    <asp:Label ID="lblField4" runat="server" CssClass="LabelNormal">CustomField3</asp:Label></td>
                <td style="width: auto; height: auto;">
                    <asp:TextBox ID="txtField4" runat="server" CssClass="labelCombo" ReadOnly="True"
                        Width="160px"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_5" runat="server">
                <td>
                    <asp:Label ID="lblField5" runat="server" CssClass="LabelNormal">Usuario</asp:Label></td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="txtField5" runat="server" ReadOnly="True" Width="160px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr id="row_Data_6" runat="server">
                <td>
                    <asp:Label ID="lblDesactPwd" runat="server" CssClass="LabelNormal">Desactivar Contraseña</asp:Label></td>
                <td style="height: auto; width: auto;">
                    <asp:CheckBox ID="chkDesactivarContrasenia" runat="server" Checked="true" Width="160px" CssClass="labelCombo" AutoPostBack="True" OnCheckedChanged="chkDesactivarContrasenia_CheckedChanged"></asp:CheckBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblField6" runat="server" CssClass="LabelNormal">Ult. Modificación</asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtFechaUltModif" runat="server" ReadOnly="True" Width="160px"
                        CssClass="labelCombo"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="tblClosePwd" runat="server" cellspacing="1" cellpadding="1" border="0"
            style="width: 100%; height: auto; background-color: #f0f8ff">
            <tr style="background-color: #b0e0e6; height: 5px">
                <td align="center" rowspan="1" colspan="2" valign="top"></td>
            </tr>
            <tr>
                <td align="center" rowspan="1" style="width: 20%; height: 21px;" valign="top"></td>
                <td align="left" style="width: auto; height: 21px;" valign="middle">
                    <asp:Label ID="Label2" runat="server" CssClass="tdTituloSub">Observaciones del Cierre</asp:Label></td>
            </tr>
        </table>
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" style="width: 20%" valign="top" rowspan="2">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/IMAGE/autorizar.gif" /></td>
                <td valign="middle" align="left" colspan="2">
                    <asp:Label ID="lblPwdCritical" runat="server" CssClass="LabelInError">La contraseña es CRITICA</asp:Label><br />
                    <asp:Label ID="lblTxtCambioCritical" runat="server" CssClass="LabelNormal">Recuerde que para claves críticas solo podrá proceder al Cierre una vez que la haya Cambiado</asp:Label></td>
            </tr>
            <tr>
                <td valign="middle" align="left" style="width: 150px">
                    <asp:Label ID="lblDescription" runat="server" CssClass="LabelNormal">Descripci&oacute;n</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ErrorMessage="*" Display="Dynamic"
                        ToolTip="Debe Ingresar la descripción del cierre" ControlToValidate="txtDesc"
                        CssClass="TextoErrorValidators"></asp:RequiredFieldValidator></td>
                <td align="left" style="width: 476px;">
                    <asp:TextBox ID="txtDesc" runat="server" Width="251px" CssClass="labelCombo" Height="39px"
                        TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr id="trBotGuardar" runat="server">
                <td align="center" colspan="1" style="width: 20%; vertical-align: top; background-color: #f0f8ff; text-align: center;"></td>
                <td align="left" colspan="2">
                    <asp:Button ID="btnClose" runat="server" CssClass="boton" Width="75px" Text="Cierre" OnClick="btnClose_Click" UseSubmitBehavior="False" CausesValidation="False"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="boton" Width="75px" Text="Cancelar"
                        ToolTip="Cierre de Contraseña" CausesValidation="False" PostBackUrl="~/Default.aspx" UseSubmitBehavior="False"></asp:Button></td>
            </tr>
        </table>
    </div>
</asp:Content>
