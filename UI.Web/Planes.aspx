<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridViewPlan" runat="server" AutoGenerateColumns="False"
            SelectedRowsStyle-BackColor="Black"
            SelectedRowsStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="IDEspecialidad" DataField="IDEspecialidad" />
        
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="Silver" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
         </asp:GridView>
    </asp:Panel>
     <asp:Panel ID="gridActionsPanel" runat="server">
         <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
         &nbsp;&nbsp;
         <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
         &nbsp;&nbsp;
         <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo descripcion requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="16px" Width="200px">
            <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="Campo especialidad requerido." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
            &nbsp;&nbsp;&nbsp; 
        <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click1" CausesValidation="False">Cancelar</asp:LinkButton>
    </asp:Panel>
   </asp:Panel>
</asp:Content>
