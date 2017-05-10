Imports System.Data.SQLite
Imports System.Text

Public Class Mapper

    Dim conn As New SQLite.SQLiteConnection
    Dim cmd As New SQLite.SQLiteCommand
    Dim sql As String
    Dim strSQL As String
    Dim dss As New DataSet
    Dim drTabla As SQLite.SQLiteDataReader
    Dim das As New SQLite.SQLiteDataAdapter
    Dim mensaje As String = ""
    Dim path As String = ""

#Region "Conexion / Desconexion BD"


    Public Sub conectarBD()
        Try

            conn.ConnectionString = "Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory() & "bd\restaurant.sqlite; Version=3"
            conn.Open()
            cmd = conn.CreateCommand()
        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> conectarBD() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        End Try

    End Sub

    Public Sub desconectarBD()
        Try
            If conn.State = Data.ConnectionState.Open Then
                cmd.Dispose()
                conn.Close()
            End If
        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd>No se pudo desconectarBD. Ver Clase MapperConexiones --> desconectarBD() <br>Mensaje:<br><dd><dd>" + ex.Message + "<br><br>SQLite Exception Error:<br><dd><dd>" + ex.StackTrace + "</b>")
        Finally
            cmd.Dispose()
            conn.Close()

        End Try

    End Sub

#End Region

#Region "Gestion Restaurant"

    Public Function altaResto(ByVal nomResto As String, Optional ByVal direccion As String = "", Optional ByVal telefono As String = "") As Boolean
        Dim altaOk As Boolean = False
        Try

        
            conectarBD()

            Dim transaction = conn.BeginTransaction()

            cmd.CommandText = "INSERT INTO RESTO (NOMBRE,DIRECCION,TELEFONO,STATUS) VALUES(@nomResto,@direccion,@telefono,1)"
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@nomResto", nomResto)
            cmd.Parameters.AddWithValue("@direccion", direccion)
            cmd.Parameters.AddWithValue("@telefono", telefono)
            cmd.ExecuteNonQuery()
            transaction.Commit()

            altaOk = True

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> altaResto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")
        Finally
            desconectarBD()

        End Try

        Return altaOk
    End Function

    Public Function buscaResto(Optional ByVal idResto As Integer = 0, Optional ByVal nomResto As String = "") As List(Of Restaurant)
        Dim Resto As Restaurant = Nothing
        Dim restoDatos As New List(Of Restaurant)
        Dim strSQL As String = ""
        Dim condicion As String = ""

        Try

        
            conectarBD()

            If idResto <> 0 Then
                ' buscar restaurant por IdResto 
                condicion = " WHERE RESTO.IDRESTO=" & idResto & ""
            End If

            If nomResto <> String.Empty Then
                'buscar por nombre de restaurant
                condicion = " WHERE RESTO.NOMBRE LIKE'%" & nomResto & "%'"
            End If

            strSQL = "SELECT RESTO.IDRESTO, " & _
                     "       RESTO.NOMBRE," & _
                     "       RESTO.DIRECCION," & _
                     "       RESTO.TELEFONO," & _
                     "       RESTO.STATUS," & _
                     "       VOTOS_RESTO.VALORACION " & _
                     "       FROM RESTO " & _
                     "              LEFT JOIN VOTOS_RESTO " & _
                     "                ON RESTO.IDRESTO=VOTOS_RESTO.IDRESTO " & _
                      condicion & _
                     " AND RESTO.STATUS=1 " & _
                     " ORDER BY RESTO.NOMBRE ASC"



            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text

            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                While drTabla.Read
                    Resto = New Restaurant

                    If IsDBNull(drTabla("idResto")) Then
                        Resto.idResto = Nothing
                    Else
                        Resto.idResto = drTabla("idResto")
                    End If

                    If IsDBNull(drTabla("NOMBRE")) Then
                        Resto.nomResto = Nothing
                    Else
                        Resto.nomResto = drTabla("NOMBRE")
                    End If

                    If IsDBNull(drTabla("DIRECCION")) Then
                        Resto.direccion = Nothing
                    Else
                        Resto.direccion = drTabla("DIRECCION")
                    End If

                    If IsDBNull(drTabla("TELEFONO")) Then
                        Resto.telefono = Nothing
                    Else
                        Resto.telefono = drTabla("TELEFONO")
                    End If

                    If IsDBNull(drTabla("STATUS")) Then
                        Resto.status = Nothing
                    Else
                        Resto.status = drTabla("STATUS")
                    End If

                    If IsDBNull(drTabla("VALORACION")) Then
                        Resto.valoracion = Nothing
                    Else
                        Resto.valoracion = drTabla("VALORACION")
                    End If

                    restoDatos.Add(Resto)

                End While
            End If

            desconectarBD()

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> buscaResto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

        Return restoDatos
    End Function

    Public Function traerRestoAll() As List(Of Restaurant)
        Dim Resto As Restaurant = Nothing
        Dim restoDatos As New List(Of Restaurant)
        Dim strSQL As String = ""

        Try


            conectarBD()

            strSQL = "SELECT RESTO.IDRESTO, " & _
                     "       RESTO.NOMBRE," & _
                     "       RESTO.DIRECCION," & _
                     "       RESTO.TELEFONO," & _
                     "       RESTO.STATUS" & _
                     " FROM RESTO " & _
                     " WHERE RESTO.STATUS=1 " & _
                     " ORDER BY RESTO.NOMBRE ASC"


            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text

            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                While drTabla.Read
                    Resto = New Restaurant

                    If IsDBNull(drTabla("idResto")) Then
                        Resto.idResto = Nothing
                    Else
                        Resto.idResto = drTabla("idResto")
                    End If

                    If IsDBNull(drTabla("NOMBRE")) Then
                        Resto.nomResto = Nothing
                    Else
                        Resto.nomResto = drTabla("NOMBRE")
                    End If

                    If IsDBNull(drTabla("DIRECCION")) Then
                        Resto.direccion = Nothing
                    Else
                        Resto.direccion = drTabla("DIRECCION")
                    End If

                    If IsDBNull(drTabla("TELEFONO")) Then
                        Resto.telefono = Nothing
                    Else
                        Resto.telefono = drTabla("TELEFONO")
                    End If

                    If IsDBNull(drTabla("STATUS")) Then
                        Resto.status = Nothing
                    Else
                        Resto.status = drTabla("STATUS")
                    End If


                    restoDatos.Add(Resto)

                End While
            End If

            desconectarBD()

            Return restoDatos

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> traerRestoAll() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()

        End Try

    End Function


    Public Function traerMejoresResto() As List(Of Restaurant)
        Dim Resto As Restaurant = Nothing
        Dim restoDatos As New List(Of Restaurant)
        Dim strSQL As String = ""

        Try

            conectarBD()

            strSQL = "SELECT RESTO.IDRESTO, " & _
                     "       RESTO.NOMBRE," & _
                     "       RESTO.DIRECCION," & _
                     "       RESTO.TELEFONO," & _
                     "       RESTO.STATUS," & _
                     "       VOTOS_RESTO.VALORACION " & _
                     "       FROM RESTO " & _
                     "              JOIN VOTOS_RESTO " & _
                     "                ON RESTO.IDRESTO=VOTOS_RESTO.IDRESTO " & _
                     " ORDER BY VOTOS_RESTO.VALORACION DESC " & _
                     " LIMIT 10 "

            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text

            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                While drTabla.Read
                    Resto = New Restaurant

                    If IsDBNull(drTabla("idResto")) Then
                        Resto.idResto = Nothing
                    Else
                        Resto.idResto = drTabla("idResto")
                    End If

                    If IsDBNull(drTabla("NOMBRE")) Then
                        Resto.nomResto = Nothing
                    Else
                        Resto.nomResto = drTabla("NOMBRE")
                    End If

                    If IsDBNull(drTabla("DIRECCION")) Then
                        Resto.direccion = Nothing
                    Else
                        Resto.direccion = drTabla("DIRECCION")
                    End If

                    If IsDBNull(drTabla("TELEFONO")) Then
                        Resto.telefono = Nothing
                    Else
                        Resto.telefono = drTabla("TELEFONO")
                    End If

                    If IsDBNull(drTabla("STATUS")) Then
                        Resto.status = Nothing
                    Else
                        Resto.status = drTabla("STATUS")
                    End If

                    If IsDBNull(drTabla("VALORACION")) Then
                        Resto.valoracion = Nothing
                    Else
                        Resto.valoracion = drTabla("VALORACION")
                    End If

                    restoDatos.Add(Resto)

                End While
            End If

            desconectarBD()

            Return restoDatos

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> traerMejoresResto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Function

#End Region


#Region "Gestion Votos"


    Public Function existeVotoParaResto(ByVal idresto As Integer) As Boolean

        Dim hayVotos As Boolean = False

        Try
            conectarBD()

            cmd.CommandText = " SELECT VOTOS_RESTO.IDRESTO, " & _
                              " VOTOS_RESTO.VALORACION " & _
                              " FROM VOTOS_RESTO " & _
                              "     WHERE IDRESTO=" & idresto & ""

            cmd.CommandType = CommandType.Text
            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                hayVotos = True
            End If
            desconectarBD()

            Return hayVotos

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> existeVotoParaResto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try


    End Function

    Public Sub actualizaCantidadVoto(ByVal idresto As Integer)

        Try
            conectarBD()

            Dim transaction = conn.BeginTransaction()

            cmd.CommandText = " UPDATE VOTOS_RESTO SET VALORACION = " & _
                              " (SELECT VALORACION FROM VOTOS_RESTO WHERE IDRESTO=@idresto)+1 " & _
                              " WHERE IDRESTO=@idresto "
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@idresto", idresto)
            cmd.ExecuteNonQuery()
            transaction.Commit()

            desconectarBD()

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> actualizaCantidadVoto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Sub

    Public Sub InsertarVoto(ByVal idresto As Integer)

        Try
            conectarBD()

            Dim transaction = conn.BeginTransaction()

            cmd.CommandText = "INSERT INTO VOTOS_RESTO (IDRESTO,VALORACION) VALUES(@idresto,1)"
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@idresto", idresto)
            cmd.ExecuteNonQuery()
            transaction.Commit()
            desconectarBD()

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> InsertarVoto() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Sub

#End Region

#Region "Gestion de Usuarios"
    Public Function existeUsuario(ByVal usuario As String) As Boolean

        Dim hayUsuario As Boolean = False

        Try
            conectarBD()

            cmd.CommandText = " SELECT NOMBRE " & _
                              " FROM USUARIOS " & _
                              "     WHERE NOMBRE='" & usuario & "'" & _
                              "      AND STATUS=1 "


            cmd.CommandType = CommandType.Text
            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                hayUsuario = True
            End If
            desconectarBD()

            Return hayUsuario

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> existeUsuario() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Function

    Public Sub crearUsuario(ByVal nomUsu As String, ByVal password As String, Optional ByVal mail As String = "")

        Try
            conectarBD()

            Dim transaction = conn.BeginTransaction()

            cmd.CommandText = "INSERT INTO USUARIOS (NOMBRE,MAIL,STATUS) VALUES(@nomUsu,@mail,1)"
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@nomUsu", nomUsu)
            cmd.Parameters.AddWithValue("@mail", mail)
            cmd.ExecuteNonQuery()
            transaction.Commit()

            desconectarBD()

            altaPassword(password)

        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> crearUsuario() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Sub

    Private Sub altaPassword(ByVal password As String)
        Try
            conectarBD()

            Dim transaction = conn.BeginTransaction()

            cmd.CommandText = "INSERT INTO USUARIOS_PASSWORD (PASSWORD) VALUES(@password)"
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@password", password)
            cmd.ExecuteNonQuery()
            transaction.Commit()
            desconectarBD()
        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> altaPassword() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try
    End Sub

#End Region

#Region "Validacion Usuario"


    Public Function validaUsuarioPassword(ByVal nomUsu As String, ByVal password As String) As Boolean

        Dim usuarioValido As Boolean = False

        Try

            conectarBD()

            cmd.CommandText = " SELECT USUARIOS.NOMBRE, " & _
                              " USUARIOS.MAIL," & _
                              " USUARIOS_PASSWORD.PASSWORD " & _
                              " FROM USUARIOS_PASSWORD " & _
                              "        JOIN USUARIOS " & _
                              "          ON USUARIOS.IDUSUARIO=USUARIOS_PASSWORD.IDUSUARIO " & _
                              " WHERE USUARIOS.NOMBRE LIKE'%" & nomUsu & "%' " & _
                              " AND USUARIOS_PASSWORD.PASSWORD ='" & password & "'" & _
                              " AND USUARIOS.STATUS=1 "

            cmd.CommandType = CommandType.Text
            drTabla = cmd.ExecuteReader()

            If drTabla.HasRows Then
                usuarioValido = True
            End If

            desconectarBD()

            Return usuarioValido
        Catch ex As Exception
            Throw New Exception("<b>Inconveniente:<br><dd><dd> Ver Clase Mapper -> validaUsuarioPassword() <br><dd><dd>" + ex.Message + "<br><br>Error:<br><dd><dd>" + ex.StackTrace + "</b>")

        Finally
            desconectarBD()
        End Try

    End Function

#End Region

End Class

