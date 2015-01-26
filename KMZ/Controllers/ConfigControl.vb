Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


Public Class ConfigControl

    Dim aConfigForm As ConfigForm
    Dim xmlDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory).ToString()
    Dim configContents As New ConfigObject

    Sub New(ByVal ConfigForm As ConfigForm)
        aConfigForm = ConfigForm
    End Sub

    Public Sub LoadFormValues()
        Try
            Dim serializer As New XmlSerializer(GetType(ConfigObject))
            Dim reader As New StreamReader(xmlDirectory & "\config.xml")
            configContents = serializer.Deserialize(reader)
            reader.Close()
            Me.aConfigForm.ColumnWidthUpDown.Value = configContents.columnWidth
            Me.aConfigForm.HightScaleNumUpDown.Value = configContents.hightscale
        Catch e As Exception
            MessageBox.Show("Could not deserialize config.xml" & vbNewLine & "Message: " & e.Message)
        End Try


    End Sub
    Private Sub GetValues()
        configContents.columnWidth = Me.aConfigForm.ColumnWidthUpDown.Value
        configContents.hightscale = Me.aConfigForm.HightScaleNumUpDown.Value
    End Sub

    Sub SaveConfig()
        Dim serializer As New XmlSerializer(GetType(ConfigObject))
        Dim writer As New StreamWriter(xmlDirectory & "\config.xml", False)
        GetValues()
        serializer.Serialize(writer, configContents)
        writer.Close()
    End Sub
End Class
