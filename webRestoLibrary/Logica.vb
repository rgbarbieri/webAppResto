
Public Class Logica
    Dim AccesoDatos As New Mapper


    Public Sub actualiza_o_InsertaVoto(ByVal idresto As Integer)
        If AccesoDatos.existeVotoParaResto(idresto) Then
            AccesoDatos.actualizaCantidadVoto(idresto)
        Else
            AccesoDatos.InsertarVoto(idresto)
        End If

    End Sub

    Public Function esUsuarioValido(ByVal usuario As String, ByVal password As String) As Boolean
        Return AccesoDatos.validaUsuarioPassword(usuario, password)
    End Function

    Public Function crearUsuario(ByVal nomUsu As String, ByVal password As String, Optional ByVal mail As String = "") As Boolean
        Dim crearUsu As Boolean = False

        If Not AccesoDatos.existeUsuario(nomUsu) Then
            AccesoDatos.crearUsuario(nomUsu, password, mail)
            crearUsu = True
        End If
        Return crearUsu
    End Function

    Public Function existeUsuario(ByVal nomUsu As String) As Boolean
        Dim existeUsu As Boolean = False

        If AccesoDatos.existeUsuario(nomUsu) Then
            existeUsu = True
        End If
        Return existeUsu
    End Function

    Public Function altaResto(ByVal nomResto As String, Optional ByVal direccion As String = "", Optional ByVal telefono As String = "") As Boolean
        Dim altaRestoOk As Boolean = False
        If AccesoDatos.altaResto(nomResto, direccion, telefono) Then
            altaRestoOk = True
        End If
        Return altaRestoOk
    End Function

    Public Function buscaResto(Optional ByVal idResto As Integer = 0, Optional ByVal nomResto As String = "") As List(Of Restaurant)
        Return AccesoDatos.buscaResto(idResto, nomResto)
    End Function

    Public Function traerMejoresResto() As List(Of Restaurant)
        Return AccesoDatos.traerMejoresResto()
    End Function

    Public Function traerRestoAll() As List(Of Restaurant)
        Return AccesoDatos.traerRestoAll()
    End Function

End Class
