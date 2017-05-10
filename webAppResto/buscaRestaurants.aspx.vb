Imports webRestoLibrary

Partial Public Class buscaRestaurants
    Inherits System.Web.UI.Page

    Dim presentacion As New Logica


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        If txtnomResto.Text <> String.Empty Then
            popularGridView.DataSource = presentacion.buscaResto(, txtnomResto.Text.Trim())
            popularGridView.DataBind()
        End If

    End Sub
End Class