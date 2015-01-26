Imports System.Math

Public Class DistanceCalculatorController
    Private mainController As MainController
    Private latitude1 As Double = 0
    Private latitude2 As Double = 0
    Private longitude1 As Double = 0
    Private longitude2 As Double = 0
    Private earthRadius As Double = 6371000 'meters

    Public Sub New(ByRef aMainController As MainController)
        Me.mainController = aMainController

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aLatitude1"></param>
    ''' <param name="aLongitude1"></param>
    ''' <param name="aLatitude2"></param>
    ''' <param name="aLongitude2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function run(ByVal aLatitude1 As String, ByVal aLongitude1 As String, ByVal aLatitude2 As String, ByVal aLongitude2 As String) As Double
        'check what format each coordinate is: Degrees Minutes Seconds (DMS) or Decimal Degrees
        If aLatitude1 Like "*'*" Then
            Me.latitude1 = convertDMStoRadians(aLatitude1)
        Else
            Me.latitude1 = convertDegreesToRadians(CDbl(aLatitude1))
        End If

        If aLongitude1 Like "*'*" Then
            Me.longitude1 = convertDMStoRadians(aLongitude1)
        Else
            Me.longitude1 = convertDegreesToRadians(CDbl(aLongitude1))
        End If

        If aLatitude2 Like "*'*" Then
            Me.latitude2 = convertDMStoRadians(aLatitude2)
        Else
            Me.latitude2 = convertDegreesToRadians(CDbl(aLatitude2))
        End If

        If aLongitude2 Like "*'*" Then
            Me.longitude2 = convertDMStoRadians(aLongitude2)
        Else
            Me.longitude2 = convertDegreesToRadians(CDbl(aLongitude2))
        End If


        Dim latDelta As Double = Me.latitude2 - Me.latitude1
        Dim longDelta As Double = Me.longitude2 - Me.longitude1

        'Using the Haversine formula
        'a = sin^2(delLat/2) + cos(lat1)*cos(lat2)*sin^2(delLong/2)
        'c = 2*arctan(sqrt(a)/ sqrt(1-a))
        'd = R*c

        Dim A As Double = Sin(latDelta / 2) * Sin(latDelta / 2) + Cos(Me.latitude1) * Cos(Me.latitude2) * Sin(longDelta / 2) * Sin(longDelta / 2)
        Dim C As Double = 2 * Atan2(Sqrt(A), Sqrt(1 - A))
        Dim D As Double = Me.earthRadius * C
        Return D

    End Function

    Public Function convertDMStoRadians(ByVal aCoordinate As String) As Double
        Dim tempStr() As String = aCoordinate.Split(" ")
        Dim wholeDegrees As Double = CDbl(tempStr(0))
        Dim minSec() As String = tempStr(1).Split("'")
        Dim minutes As Double = CDbl(minSec(0))
        Dim seconds As Double = 0
        If tempStr.Length <= 2 Then
            'skip
        ElseIf tempStr(2) = "" Then
            'skip
        Else
            Dim remainingStr() As String = tempStr(2).Split(Chr(34))
            seconds = CDbl(remainingStr(0))
        End If

        'convert DMS to decimal degrees
        Dim temp As Double = (wholeDegrees + (minutes * 60 + seconds) / 3600)
        temp = convertDegreesToRadians(temp)
        Return temp

    End Function

    Public Function convertDegreesToRadians(ByVal aValue As Double)
        Return aValue * Math.PI / 180
    End Function

End Class

