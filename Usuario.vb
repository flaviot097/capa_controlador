Public Class Usuario
    Private id As Integer
    Private nombreUsuario As String
    Private contrasena As String

    'Propiedad para obtener y establecer todos los datos de la clase
    Public Property Datos As Usuario
        Get
            Return Me
        End Get
        Set(value As Usuario)
            Me.id = value.id
            Me.nombreUsuario = value.nombreUsuario
            Me.contrasena = value.contrasena
        End Set
    End Property

    ' propiedad id
    Public Property IdUsuario As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    ' Propiedad para el campo nombreUsuario
    Public Property Nombre As String
        Get
            Return nombreUsuario
        End Get
        Set(value As String)
            nombreUsuario = value
        End Set
    End Property

    ' Propiedad para el campo contrasena
    Public Property ContrasenaUsuario As String
        Get
            Return contrasena
        End Get
        Set(value As String)
            contrasena = value
        End Set
    End Property

    'Public Overrides Function Equals(obj As Object) As Boolean
    'Dim usuario = TryCast(obj, Usuario)
    'Return usuario IsNot Nothing AndAlso
    'id = usuario.id AndAlso
    'nombreUsuario = usuario.nombreUsuario AndAlso
    'contrasena = usuario.contrasena
    'End Function

    'Public Overrides Function GetHashCode() As Integer
    'Return (id, nombreUsuario, contrasena).GetHashCode()
    'End Function




End Class
