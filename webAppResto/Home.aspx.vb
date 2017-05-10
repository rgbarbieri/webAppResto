Imports webRestoLibrary
Imports System.Threading



Partial Public Class Home
    Inherits System.Web.UI.Page

    Dim row As TableRow
    Dim col As TableCell

    Dim presentacion As New Logica


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim logout As Integer = Nothing
        logout = CInt(Request("logout"))

        If logout = 1 Then
            Master.Session.RemoveAll()
        End If


        If Not Page.IsPostBack Then
            popularGridView.DataSource = presentacion.traerRestoAll()
            popularGridView.DataBind()
        End If


    End Sub

    Protected Sub gdvTable_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles popularGridView.RowCommand
        Dim idResto As Integer = 0

        If e.CommandName = "EditCommunity" Then
            idResto = CInt(e.CommandArgument)
            presentacion.actualiza_o_InsertaVoto(idResto)
            Master.NotificaVotoRealizado()



            'If Master.usuarioLogueado Then
            '    Master.mensajeBienvenida()
            'Else
            '    Master.CrearNotificacion()
            'End If

        End If


    End Sub


End Class