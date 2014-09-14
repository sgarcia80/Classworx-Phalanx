<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
				<table width="100%" border="0">
					<tr>
						<td align="center" height="*">
							<DIV align="center"><br>
								<table style="HEIGHT: 94px" width="50%" border="0">
									<tr>
										<td width="*" align="center" colspan="2">
											<asp:label id="Label2" runat="server" CssClass="LabelNormal"></asp:label></td>
									</tr>
									<tr>
										<td style="WIDTH: 20px">
											<asp:image id="Information" runat="server" ImageUrl=".\image\info.gif"></asp:image></td>
										<td width="*" align="center">
											<asp:label id="LabelMsg" runat="server" CssClass="LabelInInfo">Se Produjo un error interno en la aplicación, comuniquese con el administrador</asp:label></td>
									</tr>
									<tr>
										<td width="*" colspan="2">&nbsp;</td>
									</tr>
								</table>
								<br>
							</DIV>
							<div align="center"><br>
								<asp:button id="Bcancel" runat="server" Text="Volver" Width="94px" CssClass="boton" OnClick="Bcancel_Click"></asp:button><br>
							</div>
							<div>
								<asp:Literal id="GoPage" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
							</div>
						</td>
					</tr>
				</table>
</asp:Content>

