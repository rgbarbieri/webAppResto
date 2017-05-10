Public Class Restaurant
    Private _idResto As Nullable(Of Integer)
    Private _nomResto As String
    Private _direccion As String
    Private _telefono As String
    Private _status As Integer
    Private _valoracion As Integer


    Public Sub New()
        _idResto = Nothing
        _nomResto = String.Empty
        _direccion = String.Empty
        _telefono = String.Empty
        _status = Nothing
        _valoracion = Nothing

    End Sub

    Public Property idResto() As Integer
        Get
            Return _idResto
        End Get
        Set(ByVal value As Integer)
            _idResto = value
        End Set
    End Property

    Public Property nomResto() As String
        Get
            Return _nomResto
        End Get
        Set(ByVal value As String)
            _nomResto = value
        End Set
    End Property

    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Public Property status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Public Property valoracion() As Integer
        Get
            Return _valoracion
        End Get
        Set(ByVal value As Integer)
            _valoracion = value
        End Set
    End Property

End Class

