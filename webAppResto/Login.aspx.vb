Imports webRestoLibrary
Partial Public Class Login
    Inherits System.Web.UI.Page
    Dim presentacion As New Logica
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, LoginResto.DataBinding

    End Sub


    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        If presentacion.esUsuarioValido(LoginResto.UserName, LoginResto.Password) Then
            Master.Session.Add("sUsuario", LoginResto.UserName)
            Response.Redirect("Home.aspx")
        Else
            Master.NotificacionLoginIncorrecto()
        End If
    End Sub

    
    
End Class