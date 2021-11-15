<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                <asp:BoundField DataField="IDPlan" HeaderText="ID de Plan" />
                <asp:CommandField ShowSelectButton="True" />
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
    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Height="24px" Visible="False">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtDescripcion" runat="server"  Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo descripcion requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblHSSemanales" runat="server" Text="Horas Semanales"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtHSSemanales" runat="server"  Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHSSemanales" ErrorMessage="Campo horas semanales requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtHSSemanales" ErrorMessage="El numero ingresado es incorrecto." ForeColor="Red" MaximumValue="16" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
        <br />
        <asp:Label ID="lblHSTotales" runat="server" Text="Horas Totales"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtHSTotales" runat="server"  Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHSTotales" ErrorMessage="Campo horas totales requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
        &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHSTotales" ErrorMessage="El numero ingresado es incorrecto." ForeColor="Red" MaximumValue="300" MinimumValue="20" Type="Integer">*</asp:RangeValidator>
        <br />  
        <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="ddlPlan" runat="server" Width="200px">
        <asp:ListItem Text="---Seleccione una opcion ---" Value="0"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPlan" ErrorMessage="Campo plan requerido." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
