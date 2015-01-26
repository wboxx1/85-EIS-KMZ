Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualBasic

<Serializable> Public Class MainFormValuesObject
    Public passColor As String
    Public failColor As String
    Public threshColor As String
    Public passColorHex As String
    Public failColorHex As String
    Public threshColorHex As String
    Public passCustomColors As New PassCustomColors
    Public failCustomColors As New FailCustomColors
    Public threshholdCustomColors As New ThresholdCustomColors
    Public mgps As Boolean
    Public spatialDecimate As Boolean
    Public useThreshold As Boolean
    Public threshold As Integer
    Public systemLoss As Integer
    Public units As String
    Public spatialDistance As Integer
    Public inputDirectory As String
    Public outputDirectory As String
    Public projectName As String
    Public visualStyle As String
    Public thresholdLineThickness As Integer
End Class

Public Class PassCustomColors
    Public color0 As String
    Public color1 As String
    Public color2 As String
    Public color3 As String
    Public color4 As String
    Public color5 As String
    Public color6 As String
    Public color7 As String
    Public color8 As String
    Public color9 As String
    Public color10 As String
    Public color11 As String
    Public color12 As String
    Public color13 As String
    Public color14 As String
    Public color15 As String
End Class
Public Class FailCustomColors
    Public color0 As String
    Public color1 As String
    Public color2 As String
    Public color3 As String
    Public color4 As String
    Public color5 As String
    Public color6 As String
    Public color7 As String
    Public color8 As String
    Public color9 As String
    Public color10 As String
    Public color11 As String
    Public color12 As String
    Public color13 As String
    Public color14 As String
    Public color15 As String
End Class
Public Class ThresholdCustomColors
    Public color0 As String
    Public color1 As String
    Public color2 As String
    Public color3 As String
    Public color4 As String
    Public color5 As String
    Public color6 As String
    Public color7 As String
    Public color8 As String
    Public color9 As String
    Public color10 As String
    Public color11 As String
    Public color12 As String
    Public color13 As String
    Public color14 As String
    Public color15 As String
End Class

'  <threshColor>Yellow</threshColor>
'  <threshColorHex>ff00ffff</threshColorHex>
'  <thresholdCustomColors>
'    <color0>16777215</color0>
'    <color1>16777215</color1>
'    <color2>16777215</color2>
'    <color3>16777215</color3>
'    <color4>16777215</color4>
'    <color5>16777215</color5>
'    <color6>16777215</color6>
'    <color7>16777215</color7>
'    <color8>16777215</color8>
'    <color9>16777215</color9>
'    <color10>16777215</color10>
'    <color11>16777215</color11>
'    <color12>16777215</color12>
'    <color13>16777215</color13>
'    <color14>16777215</color14>
'    <color15>16777215</color15>
'  </thresholdCustomColors>
'  

