﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="masVotados.aspx.vb" Inherits="webAppResto.masVotados" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" >
   
  
    <div align="center"> <asp:GridView ID="popularGridView"   runat="server" AutoGenerateColumns="False" 
        CellPadding="4" GridLines="None" ForeColor="#333333">
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
            <asp:BoundField DataField="Valoracion" HeaderText="Valoracion" 
                SortExpression="Telefono" />
            
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView></div>
   
    
   </asp:Content>
