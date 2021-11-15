<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docentes.aspx.cs" Inherits="UI.Web.Docentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="322px" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                <asp:BoundField DataField="IDDocente" HeaderText="Id Docente" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="Silver" BorderColor="#0033CC" Font-Bold="True" ForeColor="#333333" />
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
<asp:Panel ID="formPanel" runat="server" Height="233px" Visible="False" style="margin-top: 7px">
    &nbsp;<asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label>
    &nbsp;&nbsp; <asp:TextBox ID="txtCargo" runat="server"  Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCargo" ErrorMessage="Campo cargo requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label>
&nbsp; <asp:DropDownList ID="ddlCurso" runat="server"  Width="200px">
     <asp:ListItem Text="---Seleccione una opcion ---" Value="0"></asp:ListItem>    
</asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCurso" ErrorMessage="Campo curso requerido." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblDocente" runat="server" Text="ID Docente"></asp:Label>
    &nbsp;&nbsp; <asp:TextBox ID="txtIDDocente" runat="server"  Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIDDocente" ErrorMessage="Campo id docente requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">
         <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CausesValidation="False">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Panel>

</asp:Content>
