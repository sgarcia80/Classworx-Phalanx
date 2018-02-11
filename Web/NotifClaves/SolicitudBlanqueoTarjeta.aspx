<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SolicitudBlanqueoTarjeta.aspx.cs" Inherits="SolicitudBlanqueoTarjeta" Title="Macro SA - Notificación de Claves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: left">
        <br />
        <table id="Table3" width="100%" cellspacing="1" cellpadding="1" border="0">
            <tr style="height: 5px">
                <td style="width: 20%; height: auto; background-color: #b0e0e6;">
                </td>
                <td style="background-color: #b0e0e6; height: auto; padding-left: 1">
                </td>
            </tr>
            <tr style="background-color: #f0f8ff">
                <td style="width: 7px; height: 19px;">
                </td>
                <td style="text-align: left; width: auto; height: 19px;">
                    <asp:Label ID="lblPwdType" runat="server" CssClass="tdTituloSub">Solicitud de Blanqueo de Usuario de Tarjetas de Créditos</asp:Label></td>
            </tr>
            <tr style="background-color: White;">
                <td style="width: 7px; height: 19px;">
                </td>
                <td style="width: auto; height: 19px;">
                    <asp:Label ID="LTitulo" runat="server" CssClass="tdTituloSub"></asp:Label></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center left">
        <table border="0" cellspacing="1" cellpadding="1" style="width: 100%; background-color: White">
            <tr id="row_Data_1" runat="server">
                <td id="colImage" align="center" style="width: 20%; vertical-align: top; text-align: center;"
                    valign="top" runat="server">
                    &nbsp;</td>
                <td style="height: 16px; width: 220px; text-align: left; vertical-align: middle">
                    <asp:Label ID="lblField1" runat="server" CssClass="LabelNormal">Fecha</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="tbFecha" runat="server" ReadOnly="True" Width="210px" CssClass="labelCombo"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="vertical-align: top; text-align: center;" valign="top">
                    &nbsp;</td>
                <td style="height: 16px; text-align: left; vertical-align: middle">
                    <asp:Label ID="Label1" runat="server" CssClass="LabelNormal">Usuario Red</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:TextBox ID="tbUsuarioRed" runat="server" ReadOnly="True" Width="210px" CssClass="labelCombo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="vertical-align: top; text-align: center;" valign="top">
                    &nbsp;</td>
                <td style="width: auto; text-align: left; vertical-align: top; padding-top: 8px;">
                </td>
                <td></td>
            </tr>
            <tr>
                <td align="center" style="vertical-align: top; text-align: center;" valign="top">
                    &nbsp;</td>
                <td style="width: auto; text-align: left; vertical-align: top; padding-top: 5px;">
                    <asp:Label ID="Label2" runat="server" CssClass="LabelNormal">Seleccionar los Usuarios a blanquear</asp:Label>
                </td>
                <td style="height: auto; width: auto;">
                    <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" EmptyDataRowStyle-CssClass="labelCombo"
                        CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="[Sin Usuarios de Tarjetas]"
                        Font-Bold="False" DataKeyNames="Id">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSeleccionar" runat="server" ValidationGroup="solicitar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Aplicacion" HeaderText="Aplicación" ItemStyle-Width="180px">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UsuarioTC" HeaderText="Usuario" ItemStyle-Width="120px">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#0190cc" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                            Font-Size="14px" />
                        <AlternatingRowStyle BackColor="White" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsTickets" runat="server" SelectMethod="GetAll"
                        TypeName="NDCBL.MacroUsuarioTarjetaBusiness">
                        <SelectParameters>
                            <asp:SessionParameter Name="usuariored" SessionField="Usuario" Type="String" />
                            <asp:SessionParameter Name="usuariotc" Type="String" />
                            <asp:SessionParameter Name="appcode" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                    <br />
        <div class="mensaje">
            <asp:Label ID="lblInfo" runat="server" style="color: Red" CssClass="LabelNormal"></asp:Label> 
        </div>
        <br />
        <table id="tblSolicPwd" runat="server" cellspacing="1" cellpadding="1" border="0"
            style="width: 100%; height: auto; background-color: #f0f8ff">
            <tr style="background-color: #b0e0e6; height: 5px">
                <td align="center" style="width: 20%" valign="top">
                </td>
            </tr>
        </table>
        <table style="width: 100%; background-color: #f0f8ff;">
            <tr>
                <td align="center" rowspan="1" style="width: 20%" valign="top">
                    </td>
            </tr>
            <tr>
                <td align="center" colspan="1" valign="middle" style="height:30; background-color: #f0f8ff; text-align: center;">
                </td>
                <td style="height: 16px; width: 220px; text-align: left; vertical-align: middle">
                </td>
                <td align="left" valign="middle" style="height:30">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn" Width="75px" Text="Solicitar"
                        ToolTip="Generar Solicitudes" ValidationGroup="solicitar" OnClick="btnAceptar_Click">
                    </asp:Button>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn" Width="75px" Text="Volver"
                        ToolTip="Volver" CausesValidation="False" OnClick="btnVolver_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

