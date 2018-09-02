<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="Tickets.aspx.cs" Inherits="Tickets" Title="Macro SA - Notificación de Claves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div style="width: 100%;" align="center">
        <table class="login" style="width: 70%;">
            <tr>
                <td style="width:160px;">
                    <asp:Label ID="lblTitulo" runat="server" Text="Tipo de Notificaciones:"></asp:Label>
                </td>
                <td>
                <asp:RadioButtonList ID="chkNotifAlta" runat="server"  AutoPostBack="true"
                        onselectedindexchanged="chkNotifAlta_SelectedIndexChanged" >
                   <asp:ListItem Selected="True" Value="A" Text="Claves de Alta de Usuario de Aplicación" />
                   <asp:ListItem Value="B" Text="Blanqueo de Claves solicitadas" />
                </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Consultar los últimos:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlVigencia" runat="server"  AutoPostBack="true"
                        onselectedindexchanged="ddlVigencia_SelectedIndexChanged">
                        <asp:ListItem Value="30" Text="30 dias" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="60" Text="60 dias"></asp:ListItem>
                        <asp:ListItem Value="90" Text="90 dias"></asp:ListItem>
                        <asp:ListItem Value="120" Text="120 dias"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Refrescar" />
                </td>
            </tr>
        </table>
    <br />
        <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" Width="50%"
            CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No tiene tickets disponibles para Visualizar"
            Font-Bold="False" DataSourceID="odsTickets" 
            AllowSorting="True" onsorting="gvTickets_Sorting">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="22%" />
                </asp:BoundField>
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="15%"/>
                </asp:BoundField>
                <asp:BoundField DataField="UsuarioAplicacion" HeaderText="Usuario" SortExpression="UsuarioAplicacion">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="25%" />
                </asp:BoundField>
                <asp:BoundField DataField="Aplicacion" HeaderText="Aplicaci&#243;n" SortExpression="Aplicacion">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="28%" />
                </asp:BoundField>
                <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id,Tipo" DataNavigateUrlFormatString="~/DetalleTicket.aspx?id={0}&tipo={1}">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                </asp:HyperLinkField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#0190cc" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                Font-Size="14px" />
            <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsTickets" runat="server" SelectMethod="GetAllActiveByUser"
            TypeName="NDCBL.TicketNotificacionBusiness" SortParameterName="sortcolumn">
            <SelectParameters>
                <asp:SessionParameter Name="dominio" SessionField="Dominio" Type="String" />
                <asp:SessionParameter Name="usuario" SessionField="Usuario" Type="String" />
                <asp:SessionParameter Name="tipo" SessionField="TipoNotif" Type="String" />
                <asp:SessionParameter Name="fechadesde" SessionField="FechaDesde" Type="DateTime" />
                <asp:SessionParameter Name="fechahasta" SessionField="FechaHasta" Type="DateTime" />
                <asp:SessionParameter Name="sortcolumn" SessionField="sortcolumn" Type="String" />
                <asp:SessionParameter Name="sortdirection" SessionField="sortdirection" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <br />
    <div class="division">
    </div>
    <br />
    <table class="login" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" OnClick="btnVolver_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
