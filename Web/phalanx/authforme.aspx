<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="authforme.aspx.cs" Inherits="authforme" Title="Phalanx Security Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0">
        <tr>
            <td height="*" style="width: 944px">
                <asp:Image ID="Image3" runat="server" ImageUrl=".\image\key16.gif"></asp:Image>&nbsp;<asp:Label
                    ID="Label3" runat="server" CssClass="LabelNormal">Contraseñas Solicitadas por mi</asp:Label>
            </td>
        </tr>
                <tr>
            <td height="*" style="width: 100%">
                <asp:GridView ID="GridViewSolicitadas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="odsWinPWD" EmptyDataText="No tiene contraseñas disponibles para Visualizar"
                    Font-Bold="False" ForeColor="#333333" GridLines="None" Height="100%" Width="100%" Font-Names="Tahoma" Font-Size="9pt" OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField><ItemTemplate><asp:Image runat="server" ID="imgTemp" /></ItemTemplate></asp:TemplateField>
                        <asp:BoundField HeaderText="Usuario" ReadOnly="True" SortExpression="UserName" />
                        <asp:BoundField HeaderText="Descripci&#243;n" ReadOnly="True" />
                        <asp:BoundField HeaderText="Info Adicional" Visible="True" />
                        <asp:BoundField HeaderText="Fecha Sol." SortExpression="RqstDateddmmyyyy" />
                        <asp:BoundField HeaderText="Estado" SortExpression="State" />
                        <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/authformwinview.aspx?prid={0}" />
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Navy" Font-Bold="False" Font-Names="Tahoma" Font-Size="10pt"
                        ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsWinPWD" runat="server" SelectMethod="GetPassRqstByPhxUsr"
                    TypeName="PhalanxBL.PasswordRequestBusiness" OnSelecting="odsWinPWD_Selecting">
                    <SelectParameters>
                        <asp:SessionParameter Name="PhxUser" SessionField="PhxUser" Type="Object" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <div align="center">
                    <br />
                    <asp:Button ID="Bcancel" runat="server" CssClass="boton" Width="75px" Text="Volver" OnClick="Bcancel_Click">
                    </asp:Button>&nbsp;</div>
            </td>
        </tr>
    </table>
</asp:Content>
