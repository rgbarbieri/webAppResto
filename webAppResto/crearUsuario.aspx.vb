Imports webRestoLibrary
Public Partial Class crearUsuario
    Inherits System.Web.UI.Page
Dim presentacion As New Logica
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub StepNextButton_Click(ByVal sender As Object, ByVal e As EventArgs)

If presentacion.existeUsuario(crearusuarioWizard.UserName) then
        Master.NotificaUsuarioExistente()
End If
        
If presentacion.crearUsuario(crearUsuarioWizard.UserName,crearUsuarioWizard.Password,crearUsuarioWizard.Email) then
Master.NotificaUsuarioCreado()
End If
        

End Sub

    
End Class