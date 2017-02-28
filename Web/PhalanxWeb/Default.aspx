<%@ Page Title="Phalanx Security Manager" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhalanxWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0">
        <tr>
            <td valign="top" style="text-align:center; height:inherit">
                <div style="text-align:left;">
                    <asp:Table ID="tbMenu" runat="server" Width="330px">
                        <asp:TableRow Width="100%" runat="server">
                            <asp:TableCell runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\solcont.gif" CssClass="LabelOption"
                                    ID="ImageButton2"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:LinkButton runat="server" ID="LBConsContras" OnClick="LBConsContras_Click" CssClass="LabelOption">Consulta de Contraseñas</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Width="100%" runat="server">
                            <asp:TableCell runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\autorizar.gif" CssClass="LabelOption"
                                    ID="ImageButton4"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:LinkButton ID="LBAutPedidos" runat="server" CssClass="LabelOption" OnClick="LBAutPedidos_Click">Autorizar Pedidos</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Width="100%" runat="server">
                            <asp:TableCell runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\viewpwd.gif" CssClass="LabelOption"
                                    ID="ImageButton3"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:LinkButton ID="LBAutforme" runat="server" CssClass="LabelOption" OnClick="LBAutforme_Click">Visualizar Autorizaciones sobre mi usuario</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Width="100%" runat="server">
                            <asp:TableCell runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\forme.gif" CssClass="LabelOption"
                                    ID="ImageButton1"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:LinkButton ID="lblGetPwdBack" runat="server" CssClass="LabelOption" OnClick="lblGetPwdBack_Click">Devolución de contraseñas</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow2" Width="100%" runat="server">
                            <asp:TableCell ID="TableCell3" runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\SolicVenc.gif" CssClass="LabelOption"
                                    ID="ImageButton6"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell4" runat="server">
                                <asp:LinkButton ID="lnkSolicExp" runat="server" CssClass="LabelOption" OnClick="lnkSolicExp_Click">Solicitudes Expiradas</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow1" Width="100%" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">
                                <asp:ImageButton runat="server" ImageUrl=".\image\getpwdback.gif" CssClass="LabelOption"
                                    ID="ImageButton5"></asp:ImageButton>
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell2" runat="server">
                                <asp:LinkButton ID="lblClosePwd" runat="server" CssClass="LabelOption" OnClick="lblClosePwd_Click">Cierre de contraseñas</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
