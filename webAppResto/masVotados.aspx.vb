Imports webRestoLibrary


Partial Public Class masVotados
    Inherits System.Web.UI.Page

    Dim presentacion As New Logica

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            popularGridView.DataSource = presentacion.traerMejoresResto()
            popularGridView.DataBind()
        End If

    End Sub
    
End Class