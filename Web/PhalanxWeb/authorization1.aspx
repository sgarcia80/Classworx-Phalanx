<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="authorization.aspx.cs" Inherits="authorization" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
				<table width="100%" border="0">
					<tr valign="top">
						<td height="*" valign=top>
							<table width="100%" border="0">
								<TR>
									<TD>
										<asp:Image id="Image3" runat="server" ImageUrl=".\image\key16.gif"></asp:Image>&nbsp;<asp:label id="Label3" runat="server" CssClass="LabelNormal">Lista de Contraseñas Solicitadas</asp:label>
									</TD>
								</TR>
								<TR>
									<TD>
                                        <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            DataSourceID="odsReqPwd" EmptyDataText="No tiene Solicitudes de Contraseñas pendientes de Autorizar"
                                            Font-Bold="False" ForeColor="#333333" GridLines="None" OnRowDataBound="gvSolicitudes_RowDataBound" Width="100%" Font-Names="Tahoma" Font-Size="9pt">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                                                <asp:BoundField HeaderText="Nombre" ReadOnly="True" SortExpression="Nombre" />
                                                <asp:BoundField HeaderText="Descripci&#243;n" ReadOnly="True" />
                                                <asp:BoundField HeaderText="Info Adicional" Visible="false"  />
                                                <asp:BoundField HeaderText="Usuario" ReadOnly="True" />
                                                <asp:BoundField HeaderText="Fecha Sol." />
                                                <asp:BoundField HeaderText="Estado" />
                                                <asp:BoundField HeaderText="Solicitante" />
                                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/authwinpassword.aspx?prid={0}"
                                                    Text="Ver" />
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma" Font-Size="9pt" />
                                            <HeaderStyle BackColor="Navy" Font-Bold="False" Font-Names="Tahoma" Font-Size="10pt"
                                                ForeColor="White" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
                                            <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                            <EmptyDataRowStyle CssClass="LabelNormal" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="odsReqPwd" runat="server" SelectMethod="GetRequestsToAuthByAuth"
                                            TypeName="PhalanxBL.PasswordRequestBusiness">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="Auth" SessionField="PhxUser" Type="Object" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
									
									</TD>
								</TR>
								<TR>
									<TD height="18"></TD>
								</TR>
								<TR>
									<TD style="height: 22px">
										<div align="center"><asp:button id="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click"></asp:button></div>
									</TD>
								</TR>
							</table>
						</td>
					</tr>
				</table>
</asp:Content>

