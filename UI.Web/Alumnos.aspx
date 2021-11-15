<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.Alumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <asp:Panel ID="GridPanel" runat="server" >
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="421px"
            DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:BoundField DataField="IDCurso" HeaderText="ID Curso" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" BorderColor="#0033CC" Font-Bold="True" ForeColor="#333333" />
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
        <asp:LinkButton ID="lbtnEditarNota" runat="server" OnClick="lbtnEditarNota_Click" CausesValidation="false">Editar Nota</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
<asp:Panel ID="formPanel" runat="server" Height="158px" Visible="False" style="margin-top: 0px">
    <asp:Label ID="Instructivo" runat="server" Text="Modifique la nota del alumno seleccionado" Visible="false"></asp:Label>
    <asp:Label ID="lblCondicion" runat="server" Text="Condicion"></asp:Label>
    &nbsp;&nbsp;<asp:TextBox ID="txtCondicion" runat="server" style="width: 200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCondicion" ErrorMessage="Campo condicion requerido." ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label>
&nbsp;&nbsp;<asp:DropDownList ID="ddlCurso" runat="server" style="width: 200px">
    <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo curso requerido." ForeColor="Red" ControlToValidate="ddlCurso" InitialValue="0">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblNota" runat="server" Text="Nota"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtNota" runat="server" style="width: 200px"></asp:TextBox>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CausesValidation="False">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Panel>
</asp:Content>
