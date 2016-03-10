<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="CambioContrasenia.aspx.cs" Inherits="CambioContrasenia" Title="Macro SA - Cambio de Contraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="tituloSeccion">
        Cambio de Contraseña</div>
    <br />
     <table class="login">
        <tr>
            <td align="center">
                 <span class="leyenda">Introduce una nueva contraseña</span>
            </td>
        </tr>
    </table>
    <div class="mensaje">
        <br />
        <asp:Label ID="lbMensaje" Visible="false" runat="server" />
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAceptar">
    <table class="login">
         <tr>
            <td>
                Contraseña
            </td>
            <td>
                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" Width="160px" MaxLength="8" />
            </td>
            <td rowspan="4" style="vertical-align:top;">
                <ul style="font-weight: normal; margin:0;">
                    <li><asp:Label ID="lblregla_largo" runat="server">8 dígitos alfanuméricos</asp:Label></li>
                    <li><asp:Label ID="lblregla_min_letras" runat="server">Mínimo 4 letras</asp:Label></li>
                    <li><asp:Label ID="lblregla_min_nro" runat="server">Mínimo 2 números</asp:Label></li>
                    <li><asp:Label ID="lblregla_let_rep" runat="server">No puede haber 2 letras iguales seguidas</asp:Label></li>
                    <li><asp:Label ID="lblregla_nro_rep" runat="server">No puede haber 3 números iguales seguidos</asp:Label></li>
                </ul>
            </td>
        </tr>
         <tr>
            <td>
                Confirmar Contraseña
            </td>
            <td>
                <asp:TextBox ID="tbPasswordConfirm" TextMode="Password" runat="server" Width="160px" MaxLength="8" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn" runat="server" ValidationGroup="Aceptar" 
                    OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn" runat="server" CausesValidation="false"
                    PostBackUrl="~/AutogestionCOBIS.aspx" />
            </td>
        </tr>
        <tr runat="server" id="trTitRespuesta">
            <td colspan="2">
                <br />
            Respuesta
            </td>
        </tr>
        <tr id="trRespuesta" runat="server" class="tdTituloSub">
            <td colspan="3" align="left"><br /><br />
                <asp:Label ID="lblResp2" runat="server" Text="no se ha podido cambiar la contraseña. Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!"></asp:Label><br /><br /><br /><br /><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Equipo de Seguridad Informatica
                </td>
        </tr>

    </table>
    </asp:Panel>
</asp:Content>
