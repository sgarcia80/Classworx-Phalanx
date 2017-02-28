<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="PhalanxWeb.Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0">
        <tr>
            <td align="center" height="*">
                <div align="center">
                    <br>
                    <table style="height: 94px" width="50%" border="0">
                        <tr>
                            <td width="*" align="center" colspan="2">
                                <asp:Label ID="Label2" runat="server" CssClass="LabelNormal"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 20px">
                                <asp:Image ID="Information" runat="server" ImageUrl=".\image\info.gif"></asp:Image></td>
                            <td width="*" align="center">
                                <asp:Label ID="LabelMsg" runat="server" CssClass="LabelInInfo">Se Produjo un error interno en la aplicación, comuniquese con el administrador</asp:Label></td>
                        </tr>
                        <tr>
                            <td width="*" colspan="2">&nbsp;</td>
                        </tr>
                    </table>
                    <br>
                </div>
                <div align="center">
                    <br>
                    <asp:Button ID="Bcancel" runat="server" Text="Volver" Width="94px" CssClass="boton" OnClick="Bcancel_Click"></asp:Button><br>
                </div>
                <div>
                    <asp:Literal ID="GoPage" runat="server" Visible="False"></asp:Literal>&nbsp;&nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
