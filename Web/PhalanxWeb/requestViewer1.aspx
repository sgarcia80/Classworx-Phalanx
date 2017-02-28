<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="requestViewer.aspx.cs" Inherits="tempRequestViewer" Title="Phalanx Security Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="tpWinPwd" runat="server" Visible="false" Width="100%" Height="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td colspan="4">
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="76px" ImageUrl="~/IMAGE/SelectedTab.gif" />
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/IMAGE/unselectedTab.gif"
                                    Width="170px" />
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/IMAGE/UnselectedTab.gif"
                                    Width="54px">Texto</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(IMAGE/SelectedTab.gif); width: 25%; background-repeat: no-repeat">
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton3" runat="server" /></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:CheckBox ID="chkVisualizadas" runat="server" CssClass="boton" Text="Visualizadas" />
                                <asp:CheckBox ID="chkAceptadas" runat="server" CssClass="boton" Text="Aceptadas" />
                                <asp:CheckBox ID="chkRechazadas" runat="server" CssClass="boton" Text="Rechazadas" />
                                <asp:CheckBox ID="chkPendientes" runat="server" CssClass="boton" Text="Pendientes" />
                                <asp:CheckBox ID="chkTodas" runat="server" CssClass="boton" Text="Todas" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                                <asp:GridView ID="gvRequestedWinPwd" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataSourceID="odsWinPWD" EmptyDataText="No tiene contraseñas disponibles para Visualizar"
                                    Font-Bold="False" ForeColor="#333333" GridLines="None" Height="100%" Width="100%">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Dominio" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Server" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Usuario" ReadOnly="True" />
                                        <asp:BoundField HeaderText="Fecha Sol." />
                                        <asp:BoundField HeaderText="Estado" />
                                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwdviewdetail.aspx?prid={0}"
                                            Text="Ver" />
                                    </Columns>
                                    <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="Navy" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
                                        ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsWinPWD" runat="server" SelectMethod="GetPassRqstByPhxUsr"
                                    TypeName="PhalanxBL.PasswordRequestBusiness">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="PhxUser" SessionField="PhxUser" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Panel ID="tpAppPwd" runat="server" Width="100%" Height="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="odsAppPwd" EmptyDataText="No tiene Solicitudes de Contraseñas"
                                    Font-Bold="False" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None"
                                    OnRowDataBound="gvSolicitudes_RowDataBound" Width="100%">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle CssClass="LabelNormal" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="imgTemp" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Nombre" ReadOnly="True" SortExpression="Domain" >
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Descripci&#243;n" ReadOnly="True" >
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Info Adicional" >
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Usuario" ReadOnly="True" >
                                            <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                            <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Solicitada" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Expira">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Estado" >
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwdviewdetail.aspx?prid={0}"
                                            Text="Ver" >
                                            <ItemStyle HorizontalAlign="Right" />
                                            <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                    <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="9pt" ForeColor="White"
                                        HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="Navy" Font-Bold="False" Font-Names="Tahoma" Font-Size="10pt"
                                        Font-Strikeout="False" Font-Underline="False" ForeColor="White" Wrap="True" />
                                    <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsAppPwd" runat="server" SelectMethod="GetPassRqstToGetBackByPhxUsr"
                                    TypeName="PhalanxBL.PasswordRequestBusiness">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="PhxUser" SessionField="PhxUser" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Volver" CssClass="boton" PostBackUrl="~/Default.aspx" /></td>
        </tr>
    </table>
</asp:Content>
