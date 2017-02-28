<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="noAutho.aspx.cs" Inherits="PhalanxWeb.noAutho" %>

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
                                <asp:Label ID="Label2" runat="server" CssClass="LabelNormal">Usuario no Identificado</asp:Label></td>
                        </tr>
                        <tr>
                            <td width="19" style="width: 19px">
                                <asp:Image ID="Information" runat="server" ImageUrl=".\image\noAuth.gif"></asp:Image>
                            </td>
                            <td width="*" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="LabelInInfo"> Usuario No Autorizado en Phalanx Security Manager</asp:Label></td>
                        </tr>
                        <tr>
                            <td width="*" colspan="2"></td>
                        </tr>
                    </table>
                    <br>
                </div>
                <div align="center">
                    <br>
                    <asp:Button ID="Bcancel" runat="server" Text="Salir" Width="89px" CssClass="boton" OnClick="Bcancel_Click"></asp:Button><br>
                </div>
                <div>
                    &nbsp;&nbsp;
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
