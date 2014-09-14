<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="reqpwd.aspx.cs" Inherits="reqpwd" Title="Phalanx Security Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0">
        <tr>
            <td style="height: 16px; width: 100%">
                &nbsp;<asp:Label
                    ID="Label1" runat="server" CssClass="LabelNormal">Tipo de Contraseñas</asp:Label>&nbsp;&nbsp;
                <asp:DropDownList ID="cbPwdTypes" runat="server" CssClass="labelCombo" AutoPostBack="True"
                    Width="180px" DataSourceID="odsUserTypes" DataTextField="Desc" DataValueField="Id" OnSelectedIndexChanged="cbPwdTypes_SelectedIndexChanged" >
                </asp:DropDownList><asp:ObjectDataSource ID="odsUserTypes" runat="server" SelectMethod="FillSelect"
                    TypeName="PhalanxBL.UserTypeBusiness"></asp:ObjectDataSource>
            </td>
            <td style="height: 16px; width: 470px;">
            </td>
        </tr>
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="Label7" runat="server" CssClass="LabelNormal">Búsqueda</asp:Label>
                    <asp:TextBox ID="txtFiltro" runat="server" CssClass="labelCombo" Width="196px"></asp:TextBox>&nbsp;<asp:Button
                        ID="btnSearch" runat="server" CssClass="boton" Text="Buscar" OnClick="btnSearch_Click" /></td>
            </tr>
        <tr>
            <td valign="bottom" width="50%" bgcolor="powderblue" height="5">
            </td>
            <td valign="bottom" bgcolor="powderblue" height="5" style="width: 470px">
            </td>
        </tr>
        <tr id="trPWDs" runat="server">
        <td colspan="2">
            <asp:Panel id="pnlWinPwd" Width="100%" runat="server">
            <table width="100%">
            <tr>
                <td style="width: 100%">
                    <asp:GridView ID="gvWinPwd" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                        DataSourceID="odsWinPWD" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                            <asp:BoundField DataField="Domain" HeaderText="Dominio" SortExpression="Dominio" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PCName" HeaderText="Servidor" SortExpression="PCName" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Username" HeaderText="Usuario" SortExpression="Username" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" SortExpression="Desc" >
                                <ItemStyle Width="150px" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}" >
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:HyperLinkField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                        <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsWinPWD" runat="server" SelectMethod="GetAllForRqst"
                        TypeName="PhalanxBL.WinLocalUserBusiness">
                        <SelectParameters>
                            <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td></tr></table>
        </asp:Panel>
        
            <asp:Panel id="pnlDBPwd" Visible="false" runat="server" Width="100%" >
            <table width="100%">
            <tr>
                <td>
                    <asp:GridView ID="gvDBPwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                        DataSourceID="odsDBPwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                            <asp:BoundField DataField="Db" HeaderText="Base de Datos">
                                <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Tipo" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Servidor" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UserName" HeaderText="Usuario" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}" >
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:HyperLinkField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                        <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsDBPwd" runat="server" SelectMethod="GetAllForRqst"
                        TypeName="PhalanxBL.DatabaseUserBusiness">
                        <SelectParameters>
                            <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        </asp:Panel>
        
            <asp:Panel id="pnlAppPwd" Visible="false" runat="server" Width="100%" >
            <table width="100%">
            <tr>
                <td>
                    <asp:GridView ID="gvAppPwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                        DataSourceID="odsAppPwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                            <asp:BoundField DataField="Application" HeaderText="Aplicaci&#243;n" SortExpression="Application" >
                                <ItemStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Username" HeaderText="Usuario" SortExpression="Username" >
                                <ItemStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" SortExpression="Desc" >
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Informaci&#243;n Adicional" Visible="false">
                                <HeaderStyle Wrap="True" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}" >
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:HyperLinkField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                        <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsAppPwd" runat="server" SelectMethod="GetAllForRqst"
                        TypeName="PhalanxBL.ApplicationUserBusiness">
                        <SelectParameters>
                            <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        </asp:Panel>
        
            <asp:Panel ID="pnlUnixPwd" runat="server" Visible="False" Width="100%" >
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvUnixPwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                        DataSourceID="odsUnixPwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField DataField="Unix" HeaderText="Servidor" SortExpression="Unix" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Direcci&#243;n IP">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Username" HeaderText="Usuario" SortExpression="Username" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" SortExpression="Desc" >
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}"
                                        Text="Ver" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:HyperLinkField>
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                                <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsUnixPwd" runat="server" SelectMethod="GetAllForRqst"
                        TypeName="PhalanxBL.UnixUserBusiness">
                                <SelectParameters>
                                    <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlAS400Pwd" runat="server" Visible="False" Width="100%" >
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvAS400Pwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                        DataSourceID="odsAS400Pwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField DataField="AS400" HeaderText="Servidor" SortExpression="AS400" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Direcci&#243;n IP">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Username" HeaderText="Usuario" SortExpression="Username" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" SortExpression="Desc" >
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}"
                                        Text="Ver" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:HyperLinkField>
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                                <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsAS400Pwd" runat="server" SelectMethod="GetAllForRqst"
                        TypeName="PhalanxBL.AS400UserBusiness">
                                <SelectParameters>
                                    <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel id="pnlCDPwd" Visible="false" runat="server" Width="100%" >
			    <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvCDPwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                                DataSourceID="odsCDPwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField DataField="CommunicationDeviceName" HeaderText="Nombre equipo">
                                        <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CommunicationDeviceType" HeaderText="Tipo">
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Direcci&#243;n IP" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserName" HeaderText="Usuario" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:HyperLinkField>
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                                <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsCDPwd" runat="server" SelectMethod="GetAllForRqst"
                                TypeName="PhalanxBL.CommunicationDeviceUserBusiness">
                                <SelectParameters>
                                    <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel id="pnlATMPwd" Visible="false" runat="server" Width="100%" >
			    <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvATMPwd" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" 
                                DataSourceID="odsATMPwd" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene contraseñas disponibles para Visualizar" Font-Bold="False" OnRowDataBound="gvPassword_RowDataBound">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField DataField="ATMName" HeaderText="Nombre ATM">
                                        <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UserName" HeaderText="Usuario" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Desc" HeaderText="Descripci&#243;n" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reqpwddetail.aspx?wpid={0}" >
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:HyperLinkField>
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
                                <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsATMPwd" runat="server" SelectMethod="GetAllForRqst"
                                TypeName="PhalanxBL.ATMUserBusiness">
                                <SelectParameters>
                                    <asp:SessionParameter Name="PhxUserRqst" SessionField="PhxUser" Type="Object" />
                            <asp:ControlParameter ControlID="txtFiltro" Name="Filtro" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        </tr>
        <tr id="Tr1" runat="server" style="text-align: center">
            <td style="width: 100%">
                <asp:Button ID="btnBack" runat="server" Text="Volver" PostBackUrl="~/Default.aspx" /></td>
        </tr>
    </table>
</asp:Content>

