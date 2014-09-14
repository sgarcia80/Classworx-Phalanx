<%@ Page Title="Autogestión de Usuario COBIS" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0">
    <tr><td style="height:80px;">&nbsp;</td></tr>
        <tr>
            <td valign="top" style="text-align:center; height:inherit">
                <div style="text-align:center">
                    <table style="width:330px">
                        <tr style="width:100%" >
                            <td style="width:100%">
                                <asp:LinkButton runat="server" ID="LBConsContras" OnClick="LBConsContras_Click" CssClass="LabelOption">Desbloqueo de Usuario</asp:LinkButton>
                            </td>
                        </tr>
    <tr><td style="height:30px;">&nbsp;</td></tr>
                        <tr style="width:100%" >
                            <td style="width:100%">
                                <asp:LinkButton ID="LBAutPedidos" runat="server" CssClass="LabelOption" OnClick="LBAutPedidos_Click">Cambio de Clave</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

