<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView_SelectedIndexChanged" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" ReadOnly="True" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" ReadOnly="True" />
                <asp:BoundField DataField="IDComision" HeaderText="ID de Comision" />
                <asp:BoundField DataField="IDMateria" HeaderText="ID de Materia" />
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
        <asp:Panel ID="gridActionPanel" runat="server" Height="38px">
        <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Visible="False" style="margin-top: 0px">
            <asp:Label ID="lblAñoCalendario" runat="server" Text="Año Calendario"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtAnioCalendario" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo año calendario requerido. " ControlToValidate="txtAnioCalendario" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="El año ingresado no es correcto." ControlToValidate="txtAnioCalendario" ForeColor="Red" MaximumValue="2021" MinimumValue="2020">*</asp:RangeValidator>
            <br />
            <asp:Label ID="lblCurso" runat="server" Text="Cupo"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtCupo" runat="server" Width="200px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo cupo requerido." ControlToValidate="txtCupo" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblComision" runat="server" Text="Comision"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlComision" runat="server" Width="200px">
            <asp:ListItem Value="0" Text="---Seleccione una opcion ---"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlComision" ErrorMessage="Campo comision requerido." ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblMateria" runat="server" Text="Materia"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlMateria" runat="server" Width="200px">
                <asp:ListItem Text="---Seleccione una opcion ---" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo materia requerido." ControlToValidate="ddlMateria" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click" >Aceptar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CausesValidation="False">Cancelar</asp:LinkButton>
            </asp:Panel>
            <br />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
