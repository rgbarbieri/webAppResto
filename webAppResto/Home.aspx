<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="webAppResto.Home" MasterPageFile="~/MasterPage.Master" %>
<%@ MasterType virtualpath="~/MasterPage.Master" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" >
   
     
   
    <asp:Table ID="tbl" runat="server"> 
        
   </asp:Table>
  
    <div align="center"><asp:GridView ID="popularGridView"  runat="server" AutoGenerateColumns="False" OnRowCommand="gdvTable_RowCommand" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField />
            <asp:BoundField DataField="idResto" HeaderText="idResto" 
                SortExpression="idResto" Visible="False"  />
            <asp:BoundField DataField="nomResto" HeaderText="Restaurant" 
                SortExpression="nomResto" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" 
                SortExpression="Direccion" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" 
                SortExpression="Telefono" />
            
            <asp:TemplateField >
                <ItemTemplate>
                <asp:ImageButton runat="server" ID="imgVotar" ImageUrl="~/imagenes/icono-votar.png"
Width="26px" Height="26px" CommandName="EditCommunity" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idResto").ToString() %>' ToolTip="Votar" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView></div>

    
   </asp:Content>


