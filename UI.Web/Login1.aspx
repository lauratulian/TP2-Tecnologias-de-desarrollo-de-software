<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="UI.Web.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Bienvenido al sistema!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Ingrese el usuario." ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Clave"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClave" ErrorMessage="Ingrese la contraseña." ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
        </div>
    </form>
</body>
</html>
