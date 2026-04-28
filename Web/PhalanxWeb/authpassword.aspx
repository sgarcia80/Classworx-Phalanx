<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="authpassword.aspx.cs" Inherits="PhalanxWeb.authpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" style="height: 100%">
        <tr>
            <td align="left" style="width: 100%">

                <table id="Table5" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr>
                        <td style="width: 15%; height: 5px;" bgcolor="#b0e0e6"></td>
                        <td bgcolor="#b0e0e6"></td>
                    </tr>
                    <tr>
                        <td style="width: 15%" bgcolor="#f0f8ff" align="center">
                            <asp:Image ID="InformationImage" runat="server" ImageUrl=".\image\info.gif" Visible="False" /></td>
                        <td width="*" bgcolor="#f0f8ff">
                            <asp:Label ID="LabelInfo" runat="server" CssClass="LabelInInfo" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px;" colspan="2"></td>
                    </tr>
                </table>

                <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr>
                        <td style="width: 15%"></td>
                        <td width="*">
                            <asp:Label ID="Label1" runat="server" CssClass="tdTituloSub">Información del Solicitante</asp:Label></td>
                    </tr>
                </table>
                <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr>
                        <td style="width: 15%" rowspan="3" valign="top">
                            <p align="left" style="text-align: center">
                                <asp:Image ID="Image1" runat="server" ImageUrl="./image/doc.gif"></asp:Image>
                            </p>
                        </td>
                        <td width="*">
                            <asp:Label ID="LFechaSol" runat="server" CssClass="LabelNormal">Fecha de Solicitud:</asp:Label>&nbsp;
											<asp:Label ID="LInFechaSol" runat="server" CssClass="LabelInInfo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="*" style="width: 609px">
                            <asp:Label ID="LUsuario" runat="server" CssClass="LabelNormal">Usuario:</asp:Label>&nbsp;
											<asp:Label ID="LInUsuario" runat="server" CssClass="LabelInInfo"></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="*" style="width: 609px"></td>
                    </tr>
                </table>

                <div align="left">
                    <br>
                    <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0"
                        bgcolor="#f0f8ff">
                        <tr>
                            <td style="width: 15%" bgcolor="#b0e0e6" height="5"></td>
                            <td bgcolor="#b0e0e6" height="5"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px;" colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="width: 15%"></td>
                            <td width="*">
                                <asp:Label ID="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div align="left">
                    <table id="Table4" cellspacing="1" cellpadding="1" width="100%" border="0"
                        bgcolor="#f0f8ff">
                        <tr>
                            <td style="width: 15%" rowspan="7" valign="top">
                                <p align="left" style="text-align: center">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="./image/usrreq.gif"></asp:Image>
                                </p>
                            </td>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="LContrasenia" runat="server" CssClass="LabelNormal">Contraseña del Usuario</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="TbUsuarioSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                    Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="LServidor" runat="server" CssClass="LabelNormal">Servidor</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="TbServerSolic" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="LAux1" runat="server" CssClass="LabelNormal">LAux1</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="TbAux1" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="LAux2" runat="server" CssClass="LabelNormal">LAux2</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="TbAux2" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="LAux3" runat="server" CssClass="LabelNormal">LAux2</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="TbAux3" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td valign="top" style="width: 161px">
                                <asp:Label ID="LDescripcion" runat="server" CssClass="LabelNormal">Descripción</asp:Label></td>
                            <td>
                                <asp:TextBox ID="TbDesc" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="97%"
                                    Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*" style="width: 161px">
                                <asp:Label ID="Label3" runat="server" CssClass="LabelNormal">Tiempo</asp:Label></td>
                            <td width="*" style="width: 391px">
                                <asp:TextBox ID="tbTiempoSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <br>
                    <table id="TableObserv" style="height: 95%" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tr>
                            <td style="width: 15%"></td>
                            <td width="*">
                                <asp:Label ID="Label2" runat="server" CssClass="tdTituloSub">Observaciones del Usuario Autorizador</asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 15%; height: 60px;" valign="top">
                                <p align="left" style="text-align: center">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="./image/write.gif"></asp:Image>
                                </p>
                            </td>
                            <td style="height: 60px" align="left">
                                <asp:TextBox ID="TbObservaciones" runat="server" CssClass="LabelInInfo" Width="98%" Height="50px" MaxLength="500" TextMode="MultiLine" ValidationGroup="ValidaAcept"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TbObservaciones"
                                    CssClass="TextoErrorValidators" ErrorMessage="Debe Ingresar las Observaciones de la Autorización o Rechazo"
                                    ValidationGroup="ValidaTodo" Width="379px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 140px" valign="top" align="center">
                                <asp:Label ID="LTiempo" runat="server" CssClass="LabelNormal">Tiempo de utilización </asp:Label></td>
                            <td style="width: 311px" align="left">
                                <asp:TextBox ID="txtHsGiven" runat="server" CssClass="labelCombo"
                                    Width="45px" Wrap="False" MaxLength="2" ValidationGroup="ValidaAcept"></asp:TextBox>&nbsp;&nbsp;<asp:DropDownList
                                        ID="cbUnitGiven" runat="server" CssClass="labelCombo" DataSourceID="xdsUnitRqst"
                                        DataTextField="nombre" DataValueField="valor" Width="85px">
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ErrorMessage="*" ToolTip="Debe Ingresar el tiempo de solicitud" ControlToValidate="txtHsGiven" CssClass="TextoErrorValidators" ValidationGroup="ValidaAcept"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Debe ingresar el tiempo de utilización"
                                    MaximumValue="50" MinimumValue="1" Type="Integer" ControlToValidate="txtHsGiven" CssClass="TextoErrorValidators" Width="220px" ValidationGroup="ValidaAcept"></asp:RangeValidator>
                                <asp:XmlDataSource ID="xdsUnitRqst" runat="server" DataFile="~/Datos/UnitRqst.xml"></asp:XmlDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                    <br />
                    <br />
                    <asp:Button ID="BAprobar" runat="server" CssClass="boton" Width="75px" Text="Aprobar" OnClick="BAprobar_Click" UseSubmitBehavior="false"></asp:Button>&nbsp;&nbsp;
								<asp:Button ID="BRechazar" runat="server" CssClass="boton" OnClick="BRechazar_Click"
                                    Text="Rechazar" UseSubmitBehavior="false" Width="75px" /><br />
                </div>
                <div align="center">
                    <br>
                    <asp:Button ID="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click" CausesValidation="False"></asp:Button><br>
                </div>
                <div>
                    <asp:Literal ID="PasswordsRequestsID" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
