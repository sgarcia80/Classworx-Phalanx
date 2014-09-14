<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="noAutho.aspx.cs" Inherits="noAutho" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
				<table width="100%" border="0">
					<tr>
						<td align="center" height="*">
							<DIV align="center"><br>
								<table style="HEIGHT: 94px" width="50%" border="0">
									<tr>
										<td width="*" align="center" colspan="2">
											<asp:label id="Label2" runat="server" CssClass="LabelNormal">Usuario no Identificado</asp:label></td>
									</tr>
									<tr>
										<td width="19" style="WIDTH: 19px">
											<asp:image id="Information" runat="server" ImageUrl=".\image\noAuth.gif"></asp:image>
										</td>
										<td width="*" align="center">
											<asp:label id="Label1" runat="server" CssClass="LabelInInfo"> Usuario No Autorizado en Phalanx Security Manager</asp:label></td>
									</tr>
									<tr>
										<td width="*" colspan="2"></td>
									</tr>
								</table>
								<br>
							</DIV>
							<div align="center"><br>
								<asp:button id="Bcancel" runat="server" Text="Salir" Width="89px" CssClass="boton" OnClick="Bcancel_Click"></asp:button><br>
							</div>
							<div>&nbsp;&nbsp;
							</div>
						</td>
					</tr>
				</table>
</asp:Content>

