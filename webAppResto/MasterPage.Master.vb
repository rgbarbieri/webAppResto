Imports webRestoLibrary

Partial Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Include As New HtmlGenericControl("script")
        Include.Attributes.Add("type", "text/javascript")
        Include.Attributes.Add("src", "~/scripts/jquery-1.7.1.min.js")
        Page.Header.Controls.Add(Include)


        Dim Csslink As New HtmlLink
        Csslink.Href = "App_themes/restoStyles.css"
        Csslink.Attributes.Add("rel", "stylesheet")
        Csslink.Attributes.Add("type", "text/css")
        Page.Header.Controls.Add(Csslink)



        If Not usuarioLogueado() Then
            CrearNotificacion()
        Else
            mensajeBienvenida()
        End If

    End Sub

    Public Function usuarioLogueado() As Boolean
        Dim logueado As Boolean = False

        If Session("sUsuario") <> String.Empty Then
            logueado = True
        End If
        Return logueado
    End Function



    Public Function CrearNotificacion() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image
        tblTop.Rows.Clear()

        notificacion.ImageUrl = "~/imagenes/notif.gif"

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Center
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblTop.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<font color=""red""><b>Recuerde:</b></font><br>" & _
                        "<dd><dd><dd><dd><dd><strong><i>Para agregar un restaurant, debe loguearse en el sistema <a href=""Login.aspx"">Ingresar</a><br> " & _
                        " en caso de no contar con una cuenta de usuario, deberá proceder a crearla</i> <a href=""crearUsuario.aspx"">Crear Usuario</a></strong></br>"

        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)
        tblTop.Rows.Add(fila)

        Return tblTop
    End Function


    Public Function mensajeBienvenida() As Table

        Dim fila As TableRow
        Dim columna As TableCell

        tblTop.Rows.Clear()

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#B40404")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<strong><i>Bienvenido " & Session("sUsuario") & "!!</i></strong><div align=""right""><a href=""home.aspx?logout=1""> cerrar sesion</a></div> <br>" & _
                       " <div align=""center"">Para agregar un restaurant ingrese aquí <a href=""agregarResto.aspx""> Agregar Restaurant </a>  </div>"

        columna.Height = "19"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)
        tblTop.Rows.Add(fila)

        Return tblTop
    End Function



    Public Function NotificacionLoginIncorrecto() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image
        notificacion.ImageUrl = "~/imagenes/alert.jpg"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>Usuario o contraseña incorrecto, intente loguearse nuevamente</b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        Return tblMensaje
    End Function

    Public Function NotificaUsuarioCreado() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image

        notificacion.ImageUrl = "~/imagenes/clave.png"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>Su cuenta de usuario ha sido creada, puede loguearse al sistema <a href=""Login.aspx"">Ingresar</a></b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)

        tblMensaje.Rows.Add(fila)

        Return tblMensaje
    End Function


    Public Function NotificaUsuarioExistente() As Table
        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image

        notificacion.ImageUrl = "~/imagenes/alert.jpg"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>El usuario que está intentando registrar ya existe en nuestra base de datos, registrese con otro nombre de usuario </b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)
        tblMensaje.Rows.Clear()
        tblMensaje.Rows.Add(fila)

        Return tblMensaje
    End Function


    Public Function NotificaVotoRealizado() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image

        tblTop.Rows.Clear()

        notificacion.ImageUrl = "~/imagenes/resto.jpg"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblTop.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>Su voto ha sido realizado! </b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)

        tblTop.Rows.Add(fila)

        Return tblMensaje
    End Function


    Public Function NotificaRestoCreado() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image

        notificacion.ImageUrl = "~/imagenes/resto.jpg"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>Se agregó el restaurant exitosamente! </b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)

        tblMensaje.Rows.Add(fila)

        Return tblMensaje
    End Function


    Public Function NotificacionRestoNoCreado() As Table

        Dim fila As TableRow
        Dim columna As TableCell
        Dim notificacion As New Image
        notificacion.ImageUrl = "~/imagenes/alert.jpg"
        notificacion.Height = Unit.Pixel(24)
        notificacion.Width = Unit.Pixel(24)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#002852")
        columna.Style.Add("bordercolor", "#002852")
        columna.HorizontalAlign = HorizontalAlign.Left
        columna.Controls.Add(notificacion)
        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        fila = New TableRow
        columna = New TableCell
        columna.VerticalAlign = VerticalAlign.Middle
        columna.Style.Add("background-color", "#EFEFDE")
        columna.Style.Add("border-color", "EFEFDE")
        columna.Style.Add("font-family", "Verdana, Arial, Helvetica, sans-serif")
        columna.Style.Add("color", "#002852")
        columna.Style.Add("font-size", "12px")
        columna.Text = "<div align=""center""><font color=""red""><b>El restaurant no pudo ser creado</b></font></div><br>"
        columna.HorizontalAlign = HorizontalAlign.Left

        fila.Cells.Add(columna)
        tblMensaje.Rows.Add(fila)

        Return tblMensaje
    End Function


End Class