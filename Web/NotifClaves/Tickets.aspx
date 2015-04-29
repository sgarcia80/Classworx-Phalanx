<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Tickets.aspx.cs" Inherits="Tickets" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"
        ForeColor="#333333" GridLines="None" EmptyDataText="No tiene tickets disponibles para Visualizar" Font-Bold="False" DataSourceID="odsTickets">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NumeroSolicitud" HeaderText="Nro Solicitud" SortExpression="NumeroSolicitud" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Aplicacion" HeaderText="Aplicaci&#243;n" SortExpression="Aplicacion" >
                <ItemStyle Width="150px" />
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/DetalleTicket.aspx?id={0}" >
                <ItemStyle HorizontalAlign="Right" />
                <HeaderStyle HorizontalAlign="Right" />
            </asp:HyperLinkField>
        </Columns>
        <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#0190cc" Font-Bold="True" ForeColor="White" Font-Names="Tahoma" Font-Size="14px" />
        <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsTickets" runat="server" SelectMethod="GetAllActiveByUser" TypeName="NDCBL.TicketNotificacionClaveBusiness">
        <SelectParameters>
            <asp:SessionParameter Name="dominio" SessionField="Dominio" Type="String" />
            <asp:SessionParameter Name="usuario" SessionField="Usuario" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <br />
    <div class="division">
    </div>
    <br />

    <table class="login" style="width:100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

