<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="agregarResto.aspx.vb" Inherits="webAppResto.agregarResto" %>
<%@ MasterType virtualpath="~/MasterPage.master" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" >


    <table border="0"  style="font-family:Verdana;font-size:100%;">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color:White;background-color:#5D7B9D;font-weight:bold;font-size:small;" >
                                Agregar Restaurant</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="RestoNameLabel" runat="server" AssociatedControlID="RestoName" 
                                    Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Size="Small">Nombre Restaurant :</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RestoName" runat="server" ValidationGroup="agregarResto"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RestoNameRequired" runat="server" 
                                    ControlToValidate="RestoName" ErrorMessage="El nombre de restaurant es requerido." 
                                    ToolTip="Es requerido el nombre de restaurant." 
                                    ValidationGroup="agregarResto" Font-Bold="True" Font-Italic="True" 
                                    Font-Names="Arial">(*) El nombre de restaurant es requerido</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="DireccionLabel" runat="server" AssociatedControlID="Direccion" 
                                    Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Size="Small">Direccion:</asp:Label>
                                </td>
                            <td>
                                <asp:TextBox ID="Direccion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="TelefonoLabel" runat="server" AssociatedControlID="Telefono" 
                                    Font-Bold="True" Font-Italic="True" Font-Names="Arial" Font-Size="Small">Teléfono:</asp:Label>
                                </td>
                            <td>
                                <asp:TextBox ID="Telefono" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                    </table>
                <table border="0" cellspacing="5" style="width:100%;height:100%;">
                        <tr align="right">
                            <td align="center" colspan="0">
                                <asp:Button ID="btnAgregarResto" runat="server" BackColor="#FFFBFF" 
                                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                    CommandName="MoveNext" Font-Names="Verdana" ForeColor="#284775" 
                                    Text="agregar" ValidationGroup="agregarResto" 
                                    onclick="btnAgregarResto_Click" />
                            </td>
                        </tr>
                    </table>
                
          
</asp:Content>

