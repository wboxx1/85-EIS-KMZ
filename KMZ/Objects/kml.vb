Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualBasic

<Serializable()> Public Class kml
    Public Folder As New List(Of Document)
End Class

'Public Class Folder
'    Public Document As New Document
'End Class

Public Class Document
    Public name As String
    Public Style As New Style
    Public Placemark As New Placemark
End Class

Public Class Style
    ' The XmlAttribute instructs the XmlSerializer to serialize the Name
    ' field as an XML attribute instead of an XML element (the default
    ' behavior). 
    <XmlAttribute()> Public id As String
    Public LineStyle As New LineStyle
    Public PolyStyle As New PolyStyle
    Public IconStyle As New IconStyle
End Class

Public Class IconStyle
    Public Icon As New aIcon
End Class

Public Class aIcon
    Public href As String
End Class

Public Class LineStyle
    Public color As String
    Public width As Integer
End Class

Public Class PolyStyle
    Public color As String
    Public colorMode As String
    Public fill As Integer
    Public outline As Integer
End Class

Public Class Placemark
    Public name As String
    Public description As String
    Public styleUrl As String
    Public LineString As LineString
    Public Polygon As Polygon

    Public Point As Point
End Class

Public Class Point
    Public coordinates As String
End Class

Public Class Polygon
    Public extrude As Integer
    Public tesselate As Integer
    Public altitudeMode As String
    Public outerBoundaryIs As New outerBoundaryIs
End Class

Public Class outerBoundaryIs
    Public LinearRing As New LinearRing
End Class

Public Class LinearRing
    Public coordinates As String
End Class

Public Class LineString
    Public extrude As Integer
    Public altitudeMode As String
    Public coordinates As String
    Public tesselate As Integer
End Class
'<Folder>
'	<Document>
'		<name></name>
'		<Style id="sn_ylw-pushpin">
'			<LineStyle>
'				<color></color>
'				<width></width>
'			</LineStyle>
'			<PolyStyle>
'				<color></color>
'				<colorMode></colorMode>
'				<fill></fill>
'				<outline></outline>
'			</PolyStyle>
'		</Style>
'		<Placemark>
'			<name></name>
'			<description></description>
'			<styleUrl></styleUrl>
'			<LineString>
'				<extrude></extrude>
'				<altitudeMode></altitudeMode>
'				<coordinates></coordinates>
'				<tesselate></tesselate>
'			</LineString>
'		</Placemark>
'		<Placemark>
'			<name></name>
'			<description></description>
'			<styleUrl></styleUrl>
'			<LineString>
'				<extrude></extrude>
'				<altitudeMode></altitudeMode>
'				<coordinates></coordinates>
'				<tesselate></tesselate>
'			</LineString>
'		</Placemark>
'	</Document>