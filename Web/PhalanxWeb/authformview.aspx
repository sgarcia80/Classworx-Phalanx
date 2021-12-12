<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="authformview.aspx.cs" Inherits="PhalanxWeb.authformview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0">
        <tr>
            <td align="left" height="*">
                <div align="left">
                    <table id="Table1" style="height: 95%" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td style="width: 15%" rowspan="3" valign="top">
                                <p align="center">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="./image/req.gif"></asp:Image>
                                </p>
                            </td>
                            <td width="*">
                                <asp:Label ID="LFechaSol" runat="server" CssClass="LabelNormal">Fecha de Solicitud:</asp:Label>&nbsp;
											<asp:Label ID="LInFechaSol" runat="server" CssClass="LabelInInfo"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="*">
                                <asp:Label ID="LEstado" runat="server" CssClass="LabelNormal">Estado:</asp:Label>&nbsp;&nbsp;
											<asp:Label ID="LInEstado" runat="server" CssClass="LabelInInfo"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div align="left">
                    <br>
                    <table id="Table1SolTit" style="height: 95%" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td style="width: 15%" bgcolor="#b0e0e6" height="5"></td>
                            <td bgcolor="#b0e0e6" height="5"></td>
                        </tr>
                        <tr>
                            <td style="width: 15%" bgcolor="#f0f8ff"></td>
                            <td width="*" bgcolor="#f0f8ff">
                                <asp:Label ID="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="left">
                    <table id="TableSol" style="height: 95%" cellspacing="1" cellpadding="1" width="100%" border="0"
                        bgcolor="#f0f8ff">
                        <tr>
                            <td width="15%" rowspan="7" valign="top">
                                <p align="center">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="./image/usrreq.gif"></asp:Image>
                                </p>
                            </td>
                            <td width="140px">
                                <asp:Label ID="LContrasenia" runat="server" CssClass="LabelNormal"> Usuario</asp:Label></td>
                            <td width="*" style="height: 16px" align="left">
                                <asp:TextBox ID="TbUsuarioSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                    Width="266px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="*">
                                <asp:Label ID="Label1" runat="server" CssClass="LabelNormal">Contraseña</asp:Label></td>
                            <td width="*" align="left">
                                <asp:TextBox ID="TbContrasenia" runat="server" CssClass="LabelReadOnly" Width="266px" ReadOnly="True"
                                    BackColor="AntiqueWhite"></asp:TextBox>
                                <asp:Button ID="btnViewPwd" runat="server" Text="Ver" OnClick="btnViewPwd_Click" Width="48px" /></td>
                        </tr>
                        <tr>
                            <td width="140px">
                                <asp:Label ID="LServidor" runat="server" CssClass="LabelNormal"> Servidor</asp:Label></td>
                            <td width="*" align="left">
                                <asp:TextBox ID="TbServerSolic" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="266px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="LAux1" runat="server" CssClass="LabelNormal">LAux1</asp:Label></td>
                            <td width="*" align="left">
                                <asp:TextBox ID="TbAux1" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                    Width="266px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="LAux2" runat="server" CssClass="LabelNormal">LAux2</asp:Label></td>
                            <td width="*" align="left">
                                <asp:TextBox ID="TbAux2" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                    Width="266px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="LAux3" runat="server" CssClass="LabelNormal">LAux3</asp:Label></td>
                            <td width="*" align="left">
                                <asp:TextBox ID="TbAux3" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                    Width="266px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="width: 15%" valign="top" height="53">
                                <asp:Label ID="LDescripcion" runat="server" CssClass="LabelNormal">Descripción</asp:Label></td>
                            <td width="*" height="53" align="left">
                                <asp:TextBox ID="TbDesc" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="98%"
                                    Height="50px"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <div align="left">&nbsp;</div>
                <div align="left">
                    <table id="TableAutTit" style="height: 95%" cellspacing="0" cellpadding="0" width="100%"
                        border="0">
                        <tr>
                            <td style="width: 15%"></td>
                            <td width="*">
                                <asp:Label ID="Label3" runat="server" CssClass="tdTituloSub">Datos sobre Usuario Autorizador</asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="left">
                    <table id="TableAut" style="height: 95%" cellspacing="1" cellpadding="1" width="100%" border="0">
                        <tr>
                            <td width="15%" rowspan="3" valign="top">
                                <p align="center">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="./image/check.gif"></asp:Image>
                                </p>
                            </td>
                            <td style="width: 15%">
                                <asp:Label ID="Label2" runat="server" CssClass="LabelNormal">Usuario</asp:Label></td>
                            <td width="*">
                                <asp:TextBox ID="TbUsuarioAut" runat="server" CssClass="LabelReadOnly" Width="200px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="Label5" runat="server" CssClass="LabelNormal">Fecha</asp:Label></td>
                            <td width="*">
                                <asp:TextBox ID="TbFechaAut" runat="server" CssClass="LabelReadOnly" Width="200px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 15%" valign="top" height="53">
                                <asp:Label ID="Label6" runat="server" CssClass="LabelNormal">Observaciones</asp:Label></td>
                            <td width="*" height="53">
                                <asp:TextBox ID="TbObservacionesAut" runat="server" CssClass="LabelInInfo" Width="98%" Height="50px"
                                    ReadOnly="True"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                    <br>
                    <asp:Button ID="BDevolver" runat="server" CssClass="boton" Width="75px" Text="Cerrar" OnClick="BDevolver_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click"></asp:Button><br>
                </div>
                <div>
                    <asp:Literal ID="PasswordsRequestsID" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
