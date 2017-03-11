<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NoPermitido.aspx.cs" Inherits="NotifClavesWeb.NoPermitido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mensaje noPermitido">
        Acceso no permitido
    </div>
    <div>
        <asp:Button ID="btnVolver" CssClass="btn botonVolver" Text="Volver" runat="server" OnClick="btnVolver_Click" />
    </div>
</asp:Content>
