Public Class DataPoint

    Private _latitude As Double
    Private _longitude As Double
    Private _power As Double
    Private _dateAndTime As DateTime
    Private _frequency As Double
    Private _elevation As Double
    Private _arrayIndex As Integer

    Property Latitude() As Double
        Get
            Return _latitude
        End Get
        Set(value As Double)
            _latitude = value
        End Set
    End Property

    Property Longitude() As Double
        Get
            Return _longitude
        End Get
        Set(value As Double)
            _longitude = value
        End Set
    End Property

    Property Power() As Double
        Get
            Return _power
        End Get
        Set(value As Double)
            _power = value
        End Set
    End Property

    Property DateandTime() As DateTime
        Get
            Return _dateAndTime
        End Get
        Set(value As DateTime)
            _dateAndTime = value
        End Set
    End Property

    Property Frequency() As Double
        Get
            Return _frequency
        End Get
        Set(value As Double)
            _frequency = value
        End Set
    End Property

    Property Elevation() As Double
        Get
            Return _elevation
        End Get
        Set(value As Double)
            _elevation = value
        End Set
    End Property

    Property ArrayIndex() As Double
        Get
            Return _arrayIndex
        End Get
        Set(value As Double)
            _arrayIndex = value
        End Set
    End Property
End Class
