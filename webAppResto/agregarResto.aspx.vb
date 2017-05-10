Imports webRestoLibrary
Partial Public Class agregarResto
    Inherits System.Web.UI.Page
    Dim presentacion As New Logica

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Master.usuarioLogueado Then
            Response.Redirect("Home.aspx")
        End If


    End Sub

    Protected Sub btnAgregarResto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarResto.Click

        If RestoName.Text <> String.Empty Or Direccion.Text <> String.Empty Or Telefono.Text <> String.Empty Then
            If presentacion.altaResto(RestoName.Text, Direccion.Text, Telefono.Text) Then
                Master.NotificaRestoCreado()
            Else
                Master.NotificacionRestoNoCreado()
            End If
        End If
    End Sub
End Class