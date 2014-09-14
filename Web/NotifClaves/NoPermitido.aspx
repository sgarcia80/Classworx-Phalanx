<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="NoPermitido.aspx.cs" Inherits="NoPermitido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="mensaje noPermitido">
        Acceso no permitido
    </div>
    <div>
        <asp:Button ID="btnVolver" CssClass="btn botonVolver" Text="Volver" runat="server" OnClick="btnVolver_Click" />
    </div>
</asp:Content>

