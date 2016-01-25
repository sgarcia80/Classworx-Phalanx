<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="reqpwddetail.aspx.cs" Inherits="reqpwddetail" Title="Phalanx Security Manager" %>

<asp:Content ID="ContentPwdDetail" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <td style="text-align: right; width: auto; height: 19px;">
                    <asp:Label ID="lblPwdType" runat="server" CssClass="tdTituloSub">Contraseña de Aplicativo</asp:Label></td>
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
                <td id="colImage" align="center" rowspan="5" style="width: 20%; vertical-align: top; text-align: center;"
                    valign="top" runat="server">
                    <asp:Image ID="imgApplication" runat="server" ImageUrl="~/IMAGE/aplicacion_32.gif" /></td>
                <td style="height: 16px; width: auto; text-align: left; vertical-align: middle">
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
            <tr>
                <td align="center" rowspan="1" style="width: 20%; height: 21px;" valign="top">
                </td>
                <td align="left" style="width: auto; height: 21px;" valign="middle">
                    <asp:Label ID="Label2" runat="server" CssClass="tdTituloSub" Width="240px">Observaciones del Usuario Solicitante</asp:Label></td>
            </tr>
        </table>
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" rowspan="6" style="width: 20%" valign="top">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/IMAGE/autorizar.gif" /></td>
                <td valign="middle" align="left" style="width: 150px">
                    <asp:Label ID="lblDescription" runat="server" CssClass="LabelNormal">Descripci&oacute;n</asp:Label>
                    <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ErrorMessage="*" Display="Dynamic"
                        ToolTip="Debe Ingresar la descripción de la solicitud" ControlToValidate="txtDesc"
                        CssClass="TextoErrorValidators"></asp:RequiredFieldValidator></td>
                <td align="left" style="width: 476px;">
                    <asp:TextBox ID="txtDesc" runat="server" Width="251px" CssClass="labelCombo" Height="39px"
                        TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 150px">
                    <asp:Label ID="LTiempo" runat="server" CssClass="LabelNormal">Tiempo de utilización </asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="*" ToolTip="Debe Ingresar el tiempo de solicitud" ControlToValidate="txtHsRequested"
                        CssClass="TextoErrorValidators"></asp:RequiredFieldValidator></td>
                <td align="left" style="width: 476px">
                    <asp:TextBox ID="txtHsRequested" runat="server" CssClass="labelCombo" Width="45px"
                        Wrap="False" MaxLength="2"></asp:TextBox>&nbsp;&nbsp;<asp:DropDownList ID="cbUnitGiven"
                            runat="server" CssClass="labelCombo" DataSourceID="xdsUnitRqst" DataTextField="nombre"
                            DataValueField="valor" Width="85px">
                        </asp:DropDownList>&nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Debe ingresar el tiempo de utilización"
                        MaximumValue="50" MinimumValue="1" Type="Integer" ControlToValidate="txtHsRequested"
                        CssClass="TextoErrorValidators" Width="117px"></asp:RangeValidator>
                    <asp:XmlDataSource ID="xdsUnitRqst" runat="server" DataFile="~/App_Data/UnitRqst.xml">
                    </asp:XmlDataSource>
                </td>
            </tr>
            <tr>
                <td style="height: 5px; width: 150px;">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 13px">
                    <asp:Label ID="Label5" runat="server" CssClass="LabelNormal">Políticas de Seguridad y Confidencialidad</asp:Label></td>
            </tr>
            <tr>
                <td style="height: 70px" colspan="2">
                    <asp:TextBox ID="TBDescripcion" runat="server" CssClass="labelCombo" Width="62%"
                        Height="48px" ReadOnly="True" TextMode="MultiLine">El usuario solicitante de una Clave en Custodia es responsable de mantener la confidencialidad de la contrase&#241;a recibida</asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="chkAcceptPolicies" runat="server" AutoPostBack="true" CssClass="LabelNormal"
                        OnCheckedChanged="chkAcceptPolicies_CheckedChanged" Text="Acepto las políticas de Seguridad y Confidencialidad" /></td>
            </tr>
            <tr id="trTblPwdInUse" runat="server" visible="false">
                <td align="center" colspan="1" style="width: 20%; vertical-align: top; background-color: #f0f8ff;
                    text-align: center; height: 7px;">
                </td>
                <td colspan="2" align="center" style="height: 7px">
                    <asp:Label ID="lblPwdInUse" runat="server" CssClass="LabelNormal" Width="487px">La contraseña se encuentra en uso</asp:Label></td>
            </tr>
            <tr>
                <td style="height: 8px; width: 20%; vertical-align: top; background-color: #f0f8ff;
                    text-align: center;">
                </td>
                <td style="height: 8px; width: 151px;">
                </td>
            </tr>
            <tr>
                <td style="width: 20%; vertical-align: top; background-color: #f0f8ff; text-align: center;">
                </td>
                <td style="width: 151px"></td>
            </tr>
            <tr id="trBotGuardar" runat="server" >
                <td align="center" colspan="1" valign="middle" style="height:30; background-color: #f0f8ff; text-align: center;">
                </td>
                <td align="left" colspan="2" valign="middle" style="height:30">
                    <asp:Button ID="btnSolicitar" runat="server" CssClass="boton" Width="75px" Text="Solicitar"                    
                          UseSubmitBehavior="false"
                        Enabled="False" OnClick="btnSolicitar_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="boton" Width="75px" Text="Cancelar"
                          UseSubmitBehavior="false"
                        ToolTip="Solicitar Contraseña" CausesValidation="False" PostBackUrl="~/Default.aspx">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
