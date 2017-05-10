<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="menuNavegacion.ascx.vb" Inherits="webAppResto.menuNavegacion"%>

<%--<asp:Table ID="tblMenuDer" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0">--%>
   
   <table id="tblMenuDer"  width="100%" border="0" cellpadding="0" cellspacing="0" >
        <tr>
            <td>
                <a href="Home.aspx">HOME</a>
            </td>
     </tr>
     <tr>
            <td>
                <a href="login.aspx">INGRESO AL SISTEMA</a>
            </td>
        </tr>
     <tr>
            <td>
                <a href="crearUsuario.aspx">CREAR USUARIO</a>
            </td>
        </tr>   
     <tr>
            <td>
                <a href="masVotados.aspx">MAS VOTADOS</a>
            </td>
        </tr>
      <tr>
            <td>
                <a href="agregarResto.aspx">AGREGAR RESTAURANT</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="../buscaRestaurants.aspx">BUSCA RESTAURANTS</a>
            </td>
        </tr>
        </table>
      
<%--</asp:Table>--%>