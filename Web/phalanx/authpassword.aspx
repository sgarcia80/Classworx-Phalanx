<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="authpassword.aspx.cs" Inherits="authwinpassword" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
				<table width="100%" border="0" style="height: 100%">
					<tr>
						<td align="left" height="*" style="width: 100%">
							
								<TABLE id="Table5" style="HEIGHT: 100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
                                    <TR>
										<TD style="WIDTH: 15%; height: 5px;" bgColor="#b0e0e6"></TD>
										<TD bgColor="#b0e0e6"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%" bgColor="#f0f8ff" align="center">
                                            <asp:Image ID="InformationImage" runat="server" ImageUrl=".\image\info.gif" Visible="False" /></TD>
										<TD width="*" bgColor="#f0f8ff"><asp:label id="LabelInfo" runat="server" CssClass="LabelInInfo" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD style="width: 100%; height: 10px;" colspan=2></TD>
									</TR>
								</TABLE>

								<TABLE id="Table2" style="HEIGHT: 100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 15%"></TD>
										<TD width="*"><asp:label id="Label1" runat="server" CssClass="tdTituloSub">Información del Solicitante</asp:label></TD>
									</TR>
								</TABLE>
								<TABLE id="Table1" style="HEIGHT: 100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 15%" rowSpan="3" valign="top">
											<P align="left" style="text-align: center">
												<asp:Image id="Image1" runat="server" ImageUrl="./image/doc.gif"></asp:Image></P>
										</TD>
										<TD width="*"><asp:label id="LFechaSol" runat="server" CssClass="LabelNormal">Fecha de Solicitud:</asp:label>&nbsp;
											<asp:label id="LInFechaSol" runat="server" CssClass="LabelInInfo"></asp:label>
										</TD>
									</TR>
									<TR>
										<TD width="*" style="width: 609px"><asp:label id="LUsuario" runat="server" CssClass="LabelNormal">Usuario:</asp:label>&nbsp;
											<asp:label id="LInUsuario" runat="server" CssClass="LabelInInfo"></asp:label></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 609px"></TD>
									</TR>
								</TABLE>
							
							<DIV align="left"><br>
								<TABLE id="Table3" style="HEIGHT: 95%" cellSpacing="0" cellPadding="0" width="100%" border="0"
									bgColor="#f0f8ff">
									<TR>
										<TD style="WIDTH: 15%" bgColor="#b0e0e6" height="5"></TD>
										<TD bgColor="#b0e0e6" height="5"></TD>
									</TR>
									<TR>
										<TD style="width: 100%; height: 10px;"colspan=2></TD>
									</TR>
    								<TR>
										<TD style="WIDTH: 15%"></TD>
										<TD width="*"><asp:label id="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:label></TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="left">
								<TABLE id="Table4" style="HEIGHT: 95%" cellSpacing="1" cellPadding="1" width="100%" border="0"
									bgColor="#f0f8ff">
									<TR>
										<TD style="WIDTH: 15%" rowSpan="7" valign="top">
											<P align="left" style="text-align: center">
												<asp:Image id="Image2" runat="server" ImageUrl="./image/usrreq.gif"></asp:Image></P>
										</TD>
										<TD width="*" style="width: 161px"><asp:label id="LContrasenia" runat="server" CssClass="LabelNormal">Contraseña del Usuario</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="TbUsuarioSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
												Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 161px"><asp:label id="LServidor" runat="server" CssClass="LabelNormal">Servidor</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="TbServerSolic" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 161px"><asp:label id="LAux1" runat="server" CssClass="LabelNormal">LAux1</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="TbAux1" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 161px"><asp:label id="LAux2" runat="server" CssClass="LabelNormal">LAux2</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="TbAux2" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 161px"><asp:label id="LAux3" runat="server" CssClass="LabelNormal">LAux2</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="TbAux3" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:textbox></TD>
									</TR>

									<TR>
										<TD vAlign="top" style="width: 161px"><asp:label id="LDescripcion" runat="server" CssClass="LabelNormal">Descripción</asp:label></TD>
										<TD ><asp:textbox id="TbDesc" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="97%"
												Height="50px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*" style="width: 161px"><asp:label id="Label3" runat="server" CssClass="LabelNormal">Tiempo</asp:label></TD>
										<TD width="*" style="width: 391px"><asp:textbox id="tbTiempoSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="200px"></asp:textbox></TD>
									</TR>
								</TABLE>
								<br>
								<TABLE id="TableObserv" style="HEIGHT: 95%" cellSpacing="1" cellPadding="1" width="100%"
									border="0">
									<TR>
										<TD style="WIDTH: 15%"></TD>
										<TD width="*"><asp:label id="Label2" runat="server" CssClass="tdTituloSub">Observaciones del Usuario Autorizador</asp:label></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%; height: 60px;" valign="top">
											<P align="left" style="text-align: center">
												<asp:Image id="Image3" runat="server" ImageUrl="./image/write.gif"></asp:Image></P>
										</TD>
										<TD style="height: 60px" align="left">
										<asp:textbox id="TbObservaciones" runat="server" CssClass="LabelInInfo" Width="98%" Height="50px" MaxLength="500" TextMode="MultiLine" ValidationGroup="ValidaAcept"></asp:textbox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TbObservaciones"
                                                CssClass="TextoErrorValidators" ErrorMessage="Debe Ingresar las Observaciones de la Autorización o Rechazo"
                                                ValidationGroup="ValidaTodo" Width="379px"></asp:RequiredFieldValidator></TD>
									</TR>
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
                    <asp:XmlDataSource ID="xdsUnitRqst" runat="server" DataFile="~/App_Data/UnitRqst.xml">
                    </asp:XmlDataSource>
                </td>
            </tr>
								</TABLE>
							</DIV>
							<DIV align="center"><br/>
								<br/>
								<asp:button id="BAprobar" runat="server" CssClass="boton" Width="75px" Text="Aprobar" OnClick="BAprobar_Click"  UseSubmitBehavior="false" ></asp:button>&nbsp;&nbsp;
								<asp:Button ID="BRechazar" runat="server" CssClass="boton" OnClick="BRechazar_Click"
                                    Text="Rechazar" UseSubmitBehavior="false" Width="75px" /><br/>
							</DIV>
							<div align="center"><br>
								<asp:button id="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click" CausesValidation="False"></asp:button><br>
							</div>
							<div>
								<asp:Literal id="PasswordsRequestsID" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
							</div>
						</td>
					</tr>
				</table>
</asp:Content>

