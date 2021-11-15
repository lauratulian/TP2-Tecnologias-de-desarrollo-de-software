<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" >
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged"
            DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionPanel" runat="server" >
        <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
<asp:Panel ID="formPanel" runat="server" Height="233px" Visible="False" style="margin-top: 1px">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo nombre requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="Campo apellido requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo email requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="El formato del mail es incorrecto." ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
    <br />
    <asp:CheckBox ID="cbHabilitado" runat="server" Text="Habilitado" />
    <br />
    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre Usuario"></asp:Label>
    <asp:TextBox ID="txtNombreUsuario" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo nombre usuario requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo clave requerido." ForeColor="Red" ControlToValidate="txtClave">*</asp:RequiredFieldValidator>
    &nbsp;
    <br />
    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave"></asp:Label>
    <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo repetir clave requerido." ForeColor="Red" ControlToValidate="txtRepetirClave">*</asp:RequiredFieldValidator>
    &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtRepetirClave" ControlToValidate="txtClave" CultureInvariantValues="True" ErrorMessage="Las claves no coinciden." ForeColor="Red">*</asp:CompareValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <br />
    
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click"  CausesValidation="False">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Panel>
</asp:Content>
