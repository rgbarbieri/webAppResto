<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="crearUsuario.aspx.vb" Inherits="webAppResto.crearUsuario" %>
<%@ MasterType virtualpath="~/MasterPage.master" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" >
    <asp:CreateUserWizard ID="crearUsuarioWizard" runat="server" 
        BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="0.8em" RequireEmail="False">
        <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" 
            VerticalAlign="Top" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284775" />
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284775" />
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <StepStyle BorderWidth="0px" />
        
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" 
                Title="crear cuenta de usuario">
                <ContentTemplate>
                    <table border="0" style="font-family:Verdana;font-size:100%;">
                        <tr>
                            <td align="center" colspan="2" 
                                style="color:White;background-color:#5D7B9D;font-weight:bold;">
                                Crear cuenta de usuario</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario :</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" ValidationGroup="crearUsuarioWizard"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="es requerido el usuario." 
                                    ToolTip="es requerido el usuario." ValidationGroup="crearUsuarioWizard">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" 
                                    ValidationGroup="crearUsuarioWizard"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="debe ingresar una contraseña." 
                                    ToolTip="ingresar contraseña." ValidationGroup="crearUsuarioWizard">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirmar Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" 
                                    ValidationGroup="crearUsuarioWizard"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Debe re-ingresar la contraseña ingresada." 
                                    ToolTip="Debe re-ingresar la contraseña ingresada." ValidationGroup="crearUsuarioWizard">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="El Password y la confirmacion de password son Distintos!" 
                                    ValidationGroup="crearUsuarioWizard" Visible="False"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr visible="false">
                            <td visible="false" align="center" colspan="2" style="color:Red;">
                                <%--<asp:Literal Visible="False" ID="ErrorMessage" runat="server" EnableViewState="False" 
                                    ></asp:Literal>--%>
                            </td>
                        </tr>
                        <tr visible="false">
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" 
                                    Visible="False">Security Question:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr visible="false">
                            <td align="right" visible="false">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" 
                                    Visible="False">Security Answer:</asp:Label>
                            </td>
                            <td visible="false">
                                <asp:TextBox ID="Answer" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <CustomNavigationTemplate>
                    <table border="0" cellspacing="5" style="width:100%;height:100%;">
                        <tr align="right">
                            <td align="center" colspan="0">
                                <asp:Button ID="StepNextButton" runat="server" BackColor="#FFFBFF" 
                                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                    CommandName="MoveNext" Font-Names="Verdana" ForeColor="#284775" 
                                    Text="Crear" ValidationGroup="crearUsuarioWizard" 
                                    onclick="StepNextButton_Click" />
                            </td>
                        </tr>
                    </table>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>
          </WizardSteps>
    </asp:CreateUserWizard>
    
    <br />
    <br />
    <br />
    
        
</asp:Content>