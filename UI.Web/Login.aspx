<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="55px" Width="780px">
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Bienvenido al sistema!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Ingrese el usuario." ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="Ingrese la contraseña." ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            <br />
        </asp:Panel>
    </asp:Panel>
        </asp:Content>
