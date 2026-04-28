<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Login" Title="Phalanx Security Manager Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 280px; margin: 0 auto;">
        <table cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <table cellpadding="3">
                        <tr>
                            <td align="center" class="LabelNormal" colspan="2" style="color: White; background-color: #020286;
                                font-size: 12pt; font-weight: bold;">
                                Login
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="LabelNormal" style="font-size: 10pt;">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" CssClass="labelCombo" Font-Size="10pt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="El Usuario es obligatorio" ToolTip="Campo Obligatorio" ValidationGroup="LoginControl">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="LabelNormal" style="font-size: 10pt;">
                                <asp:Label ID="DomainLabel" runat="server" AssociatedControlID="Domain">Dominio</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Domain" runat="server" CssClass="labelCombo" Font-Size="10pt">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="DomainRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="El Dominio es obligatorio" ToolTip="Campo Obligatorio." ValidationGroup="LoginControl">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="LabelNormal" style="font-size: 10pt;">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" CssClass="labelCombo" Font-Size="10pt"
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="La Contrase�a es obligatoria" ToolTip="Campo Obligatorio" ValidationGroup="LoginControl">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1" OnClick="LoginButton_Click"
                                    BorderStyle="Solid" BorderWidth="1px" CommandName="Login" CssClass="boton" Font-Names="Verdana"
                                    Font-Size="10pt" ForeColor="#284E98" Text="Ingresar" ValidationGroup="LoginControl" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;" class="LabelInError">
                                <asp:ValidationSummary ID="FailureText" runat="server" DisplayMode="List" ValidationGroup="LoginControl">
                                </asp:ValidationSummary>
                                 <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
