<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Personas" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="formPanel" runat="server">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo nombre requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="Campo apellido requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo email requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" Width="200px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Campo legajo requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Campo direccion requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
        <asp:TextBox ID="txtTelefono"  runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Campo telefono requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento: "></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento"  runat="server" TextMode="Date" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Campo fecha nacimiento requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
         <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server" Width="200px">
         <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlPlan" ErrorMessage="Campo id plan requerido." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
        <br />
          <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo de persona:"></asp:Label>
        <asp:TextBox ID="txtTipoPersona"  runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTipoPersona" ErrorMessage="Campo tipo persona requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CausesValidation="False" >Cancelar</asp:LinkButton>
    </asp:Panel>
   </asp:Panel>

</asp:Content>