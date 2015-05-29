<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="DesbloqueoUsuarioCOBIS.aspx.cs" Inherits="DesbloqueoUsuarioCOBIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="tituloSeccion">
        Desbloqueo de Usuario COBIS</div>
    <br />
    <table class="login">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label">Se solicitará desbloqueo de su usuario de COBIS </asp:Label>
            </td>            
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <asp:Button ID="btnDesbloquear" Text="Desbloquear" CssClass="btn" 
                    runat="server" onclick="btnDesbloquear_Click"  />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn" runat="server" 
                    onclick="btnVolver_Click"  />
            </td>            
        </tr>
        <tr runat="server" id="trTitRespuesta">
            <td>
                <br />
            Respuesta
            </td>
        </tr>
        <tr id="trRespuesta" runat="server">
            <td><asp:TextBox ID="txtRespuesta" runat="server" Height="107px" TextMode="MultiLine" 
        Width="345px"></asp:TextBox>
            </td>
        </tr>
    </table>

</asp:Content>
