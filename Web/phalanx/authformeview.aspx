<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="authformeview.aspx.cs" Inherits="authformwinview" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
				<table width="100%" border="0">
					<tr>
						<td align="left" height="*">
							<DIV align="left">
								<TABLE id="Table1" style="HEIGHT: 95%" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="WIDTH: 15%" rowSpan="3" valign="top">
											<P align="center">
												<asp:Image id="Image1" runat="server" ImageUrl="./image/req.gif"></asp:Image></P>
										</TD>
										<TD width="*"><asp:label id="LFechaSol" runat="server" CssClass="LabelNormal">Fecha de Solicitud:</asp:label>&nbsp;
											<asp:label id="LInFechaSol" runat="server" CssClass="LabelInInfo"></asp:label></TD>
									</TR>
									<TR>
										<TD width="*">
											<asp:label id="LEstado" runat="server" CssClass="LabelNormal">Estado:</asp:label>&nbsp;&nbsp;
											<asp:label id="LInEstado" runat="server" CssClass="LabelInInfo"></asp:label></TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="left"><br>
								<TABLE id="Table1SolTit" style="HEIGHT: 95%" cellSpacing="0" cellPadding="0" width="100%"
									border="0">
									<TR>
										<TD style="WIDTH: 15%" bgColor="#b0e0e6" height="5"></TD>
										<TD bgColor="#b0e0e6" height="5"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%" bgColor="#f0f8ff"></TD>
										<TD width="*" bgColor="#f0f8ff"><asp:label id="LTitulo" runat="server" CssClass="tdTituloSub">Información Solicitada</asp:label>
										</TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="left">
								<TABLE id="TableSol" style="HEIGHT: 95%" cellSpacing="1" cellPadding="1" width="100%" border="0"
									bgColor="#f0f8ff">
									<TR>
										<TD width="15%" rowSpan="7" valign="top">
											<P align="center">
												<asp:Image id="Image2" runat="server" ImageUrl="./image/usrreq.gif"></asp:Image></P>
										</TD>
										<TD width="140px"><asp:label id="LContrasenia" runat="server" CssClass="LabelNormal"> Usuario</asp:label></TD>
										<TD width="*" style="HEIGHT: 16px" align="left">
                                            <asp:textbox id="TbUsuarioSolicitado" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
												Width="266px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="*">
											<asp:label id="Label1" runat="server" CssClass="LabelNormal">Contraseña</asp:label></TD>
										<TD width="*" align="left">
											<asp:textbox id="TbContrasenia" runat="server" CssClass="LabelReadOnly" Width="266px" ReadOnly="True"
												BackColor="AntiqueWhite"></asp:textbox>
                                            <asp:Button ID="btnViewPwd" runat="server" Text="Ver" OnClick="btnViewPwd_Click" Width="48px" /></TD>
									</TR>
									<TR>
										<TD width="140px"><asp:label id="LServidor" runat="server" CssClass="LabelNormal"> Servidor</asp:label></TD>
										<TD width="*" align="left">
                                            <asp:textbox id="TbServerSolic" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="266px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%">
                                            <asp:Label ID="LAux1" runat="server" CssClass="LabelNormal">LAux1</asp:Label></TD>
										<TD width="*" align="left">
                                            <asp:TextBox ID="TbAux1" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                                Width="266px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%">
                                            <asp:Label ID="LAux2" runat="server" CssClass="LabelNormal">LAux2</asp:Label></TD>
										<TD width="*" align="left">
                                            <asp:TextBox ID="TbAux2" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                                Width="266px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%">
                                            <asp:Label ID="LAux3" runat="server" CssClass="LabelNormal">LAux3</asp:Label></TD>
										<TD width="*" align="left">
                                            <asp:TextBox ID="TbAux3" runat="server" CssClass="LabelReadOnly" ReadOnly="True"
                                                Width="266px"></asp:TextBox></TD>
									</TR>

									<TR>
										<TD style="WIDTH: 15%" vAlign="top" height="53"><asp:label id="LDescripcion" runat="server" CssClass="LabelNormal">Descripción</asp:label></TD>
										<TD width="*" height="53" align="left"><asp:textbox id="TbDesc" runat="server" CssClass="LabelReadOnly" ReadOnly="True" Width="98%"
												Height="50px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="left">&nbsp;</DIV>
							<DIV align="left">
								<TABLE id="TableAutTit" style="HEIGHT: 95%" cellSpacing="0" cellPadding="0" width="100%"
									border="0">
									<TR>
										<TD style="WIDTH: 15%"></TD>
										<TD width="*">
											<asp:label id="Label3" runat="server" CssClass="tdTituloSub">Datos sobre Usuario Autorizador</asp:label>
										</TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="left">
								<TABLE id="TableAut" style="HEIGHT: 95%" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD width="15%" rowspan="3" valign="top">
											<P align="center">
												<asp:Image id="Image3" runat="server" ImageUrl="./image/check.gif"></asp:Image></P>
										</TD>
										<TD style="WIDTH: 15%">
											<asp:label id="Label2" runat="server" CssClass="LabelNormal">Usuario</asp:label></TD>
										<TD width="*">
											<asp:textbox id="TbUsuarioAut" runat="server" CssClass="LabelReadOnly" Width="200px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%">
											<asp:label id="Label5" runat="server" CssClass="LabelNormal">Fecha</asp:label></TD>
										<TD width="*">
											<asp:textbox id="TbFechaAut" runat="server" CssClass="LabelReadOnly" Width="200px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 15%" vAlign="top" height="53">
											<asp:label id="Label6" runat="server" CssClass="LabelNormal">Observaciones</asp:label></TD>
										<TD width="*" height="53" ><asp:textbox id="TbObservacionesAut" runat="server" CssClass="LabelInInfo" Width="98%" Height="50px"
												ReadOnly="True"></asp:textbox></TD>
									</TR>
								</TABLE>
							</DIV>
							<DIV align="center"><br>
								<asp:button id="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click"></asp:button><br>
							</DIV>
							<div>
								<asp:Literal id="PasswordsRequestsID" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
							</div>
						</td>
					</tr>
				</table>
</asp:Content>

