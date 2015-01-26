Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic

Public Class MainController


    ''' <summary>
    ''' Needed for mgps
    ''' </summary>
    ''' <remarks></remarks>
    Private aMgpsFile As String
    Private aMlogFile As String
    Private aLineCount As Integer = 0
    Private aLineArray() As String
    Private bLineCount As Integer = 0
    Private bLineArray() As String
    Private lastIndex As Integer = 0
    Private aKmlArray() As String
    Private aKmlThresholdArray() As String
    Private aKmlBackPathArray() As String
    Private aPowerArray() As String
    Private aLatLongArray() As String
    Private templateDir As String = Directory.GetCurrentDirectory ' "C:\MancatConverter\"   'Added on 2/12/14 by Will Boxx
    Private rootDir As DirectoryInfo = Directory.GetParent(templateDir)         'Aadded on 2/12/14 by Will Boxx

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
  
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Needed
    Private aMainForm As MainForm
    Private aCsvFile As String
    Public aDistanceCalculatorController As DistanceCalculatorController
    Private formValues As String = rootDir.ToString & "\formValues.xml"     'Added on 2/12/14 by Will Boxx
    Private newDir As String = rootDir.ToString & "\KML_Files\"         'Added on 2/12/14 by Will Boxx
    Private xmlDocument As New System.Xml.XmlDocument
    Private xmlNodeList As System.Xml.XmlNodeList
    Private xmlNode As System.Xml.XmlNode
    Private inputDirectory As String = templateDir
    Private outputDirectory As String = newDir
    Public pointList As New List(Of DataPoint)
    Dim theKML As New kml
    Public CSVLineList As New List(Of String)
    Dim reader As StreamReader
    Dim KMLOutputFile As String
    Dim aMainFormValuesObject As MainFormValuesObject
    Dim configContents As New ConfigObject


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Constants
    'kml color pattern is: 0 - 255 hex values for 4 fields: opacity, blue, green, red
    Public kmlColorRed As String = "ff0000ff"
    Public kmlColorGreen As String = "ff00ff00"
    Public kmlColorYellow As String = "ff00ffff"
    Private kmlColorBlue As String = "ffff0000"

    Private kmlColorPolyRed As String = "7f0000ff"
    Private kmlColorPolyGreen As String = "7f00ff00"
    Private kmlColorPolyYellow As String = "7f00ffff"

    Private yellowPushPinHREF As String = "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png"
    Private redPushPinHREF As String = "http://maps.google.com/mapfiles/kml/pushpin/red-pushpin.png"

    Private ZuluOffset As Integer = 5
    Public threshold As Double = 102 * -1
    Private powerIndex1 As Integer = 7
    Private powerIndex2 As Integer = 8
    Private powerIndex3 As Integer = 9
    Private powerIndex4 As Integer = 10
    Private centerColPowVal1 As Integer = 11
    Private centerColPowVal2 As Integer = 12
    Private powerIndex7 As Integer = 13
    Private powerIndex8 As Integer = 14
    Private powerIndex9 As Integer = 15
    Private powerIndex10 As Integer = 16
    Private scaleFactor As Integer = 180
    Public sysLossFactor As Integer = 0
    Public index As Integer = 0

    Public visualStyle As String


    Public Sub New(ByVal mainForm As MainForm)
        Me.aMainForm = mainForm
        Me.aDistanceCalculatorController = New DistanceCalculatorController(Me)

        visualStyle = Me.aMainForm.visualStyleComboBox.SelectedText

    End Sub
    ''' <summary>
    ''' this function is used when the '.mgps and csv file' check box is checked
    ''' this output is from RFCAT program
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub convertCsvToKml()

        ' set up the open file dialog properties for .mgps file
        Me.aMainForm.OpenFileDialog1.InitialDirectory = Me.templateDir
        Me.aMainForm.OpenFileDialog1.Multiselect = True
        Me.aMainForm.OpenFileDialog1.Title = "Select .mgps file, Please"
        Me.aMainForm.OpenFileDialog1.FileName = ""
        Me.aMainForm.OpenFileDialog1.Filter = "Trace Files (*.mgps)|*.mgps*| All files (*.*)|*.*"
        Me.aMainForm.OpenFileDialog1.FilterIndex = 1
        Me.aMainForm.txtBxMGPSfile.Text = Me.aMainForm.OpenFileDialog1.FileName
        ' display the open file message box
        If Me.aMainForm.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.aMainForm.txtBxMGPSfile.Text = Me.aMainForm.OpenFileDialog1.FileName
            Me.aMgpsFile = Me.aMainForm.txtBxMGPSfile.Text
        ElseIf Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Me.aLineCount = 0
        Me.lastIndex = 0

        ' check that file is not empty -- if so, then skip it
        If FileLen(Me.aMgpsFile) = 0 Then
            MessageBox.Show("Skipping: " & Me.aMgpsFile & vbCrLf & "File is empty", "Returning to main...")
            Return
        End If

        ' open the file as a stream
        Dim traceA As String = ""
        Try
            FileOpen(1, Me.aMgpsFile, OpenMode.Input)
        Catch ex As Exception
            MsgBox("Unable to open " & Me.aMgpsFile)
            Return
        End Try
        Do Until EOF(1)
            traceA = traceA & "=" & LineInput(1)
            Me.aLineCount = Me.aLineCount + 1
        Loop
        FileClose(1)

        ' set up the open file dialog properties for .mlog file
        Me.aMainForm.OpenFileDialog2.InitialDirectory = Me.templateDir
        Me.aMainForm.OpenFileDialog2.Multiselect = True
        Me.aMainForm.OpenFileDialog2.Title = "Select .csv file, Please"
        Me.aMainForm.OpenFileDialog2.FileName = ""
        Me.aMainForm.OpenFileDialog2.Filter = "Trace Files (*.csv)|*.csv*| All files (*.*)|*.*"
        Me.aMainForm.OpenFileDialog2.FilterIndex = 1
        Me.aMainForm.txtBxMLOGfile.Text = Me.aMainForm.OpenFileDialog2.FileName
        ' display the open file message box
        If Me.aMainForm.OpenFileDialog2.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.aMainForm.txtBxMLOGfile.Text = Me.aMainForm.OpenFileDialog2.FileName
            Me.aMlogFile = Me.aMainForm.txtBxMLOGfile.Text
        ElseIf Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Me.bLineCount = 0

        ' check that file is not empty -- if so, then skip it
        If FileLen(Me.aMlogFile) = 0 Then
            MessageBox.Show("Skipping: " & Me.aMlogFile & vbCrLf & "File is empty", "Returning to main...")
            Return
        End If

        ' open the file as a stream
        Dim traceB As String = ""
        Try
            FileOpen(1, Me.aMlogFile, OpenMode.Input)
        Catch ex As Exception
            MsgBox("Unable to open " & Me.aMlogFile)
            Return
        End Try
        Do Until EOF(1)
            traceB = traceB & "=" & LineInput(1)
            Me.bLineCount = Me.bLineCount + 1
        Loop
        FileClose(1)

        ReDim Me.aLineArray(Me.aLineCount - 1)
        ReDim Me.bLineArray(Me.bLineCount - 1)
        ReDim Me.aKmlArray(Me.bLineCount - 1)
        ReDim Me.aKmlThresholdArray(Me.bLineCount - 1)
        ReDim Me.aKmlBackPathArray(Me.bLineCount - 1)
        ReDim Me.aPowerArray(Me.bLineCount - 1)
        ReDim Me.aLatLongArray(Me.bLineCount - 1)


        'get the lines of the .mgps file 
        Me.aLineArray = Split(traceA, ">")
        Me.bLineArray = Split(traceB, "=")


        Dim longitude As String
        Dim latitude As String
        Dim previousLongitude As String
        Dim previousLatitude As String
        Dim index As Integer = 0
        Dim elevation As Double = 0
        Dim thresholdElevation As Integer = 0


        'go through each time stamp in the bLineArray and find the match in the aLineArry
        'when a match is found, get the long, lat and power value

        For ii As Integer = 0 To Me.bLineArray.Length - 1
            'skip the first 2 lines
            If ii > 1 Then
                '2011-06-08T10:02:42.4530000,-94.9
                Dim tmpArr() As String = Split(Me.bLineArray(ii), "T")
                Dim dateStr As String = tmpArr(0)
                Dim dateArr() As String = Split(dateStr, "-")
                Dim year As String = dateArr(0)
                Dim month As String = dateArr(1)
                Dim day As String = dateArr(2)
                Dim timeAndPower As String = tmpArr(1)
                Dim tmpArr1() As String = Split(timeAndPower, ",")
                Dim timeLong As String = tmpArr1(0)
                Dim power As String = tmpArr1(1)
                Dim tmpArr2() As String = Split(timeLong, ".")
                Dim time As String = tmpArr2(0)
                Dim tmpArr3() As String = Split(time, ":")
                Dim hour As String = (CDbl(tmpArr3(0)) + Me.ZuluOffset).ToString
                Dim minute As String = tmpArr3(1)
                Dim second As String = tmpArr3(2)
                Dim timeStamp As String = year & month & day & hour & minute & second & ".0000"

                'now parse through the .mgps file
                For jj = 0 To Me.aLineArray.Length - 1
                    'Location Alt="-1.29999995231628" Lon="-88.9414937085858" Az="182.28" Lat="30.411424847908" Time="20110608150343.0000"
                    Dim tmpArr4() As String = Split(Me.aLineArray(jj), "=")
                    If tmpArr4.Length > 1 Then

                        Dim timeWithCommas As String = tmpArr4(tmpArr4.Length - 1)
                        Dim tmpArr5() As String = Split(timeWithCommas, Chr(34))
                        Dim gpsTimeStamp As String = tmpArr5(1)

                        If timeStamp = gpsTimeStamp Then
                            'Me.lastIndex = jj
                            'Me.lastIndex = 0

                            ' get long and lat
                            Dim longitudeArr() As String = Split(tmpArr4(3), Chr(34))
                            longitude = longitudeArr(1)
                            Dim latitudeArr() As String = Split(tmpArr4(5), Chr(34))
                            latitude = latitudeArr(1)
                            If index > 0 Then

                                If CDbl(latitude) > CDbl(previousLatitude) Then
                                    previousLatitude = CDbl(previousLatitude + 0.00001).ToString
                                ElseIf CDbl(latitude) > CDbl(previousLatitude) Then
                                    previousLatitude = CDbl(previousLatitude - 0.00001).ToString
                                End If
                                If CDbl(longitude) > CDbl(previousLongitude) Then
                                    previousLongitude = CDbl(previousLongitude + 0.000001).ToString
                                ElseIf CDbl(longitude) > CDbl(previousLongitude) Then
                                    previousLongitude = CDbl(previousLongitude - 0.000001).ToString
                                End If

                                elevation = (Me.scaleFactor - Math.Abs(CDbl(power)))
                                thresholdElevation = (Me.scaleFactor - Math.Abs(Me.threshold))

                                Dim tmpString As String = longitude & "," & latitude & "," & elevation.ToString & " " & previousLongitude & "," & previousLatitude & "," & elevation.ToString
                                Dim tmpThreshString As String = longitude & "," & latitude & "," & thresholdElevation.ToString & " " & previousLongitude & "," & previousLatitude & "," & thresholdElevation.ToString
                                Dim tmpBackPathString As String = previousLongitude & "," & previousLatitude & "," & elevation.ToString & " " & longitude & "," & latitude & "," & elevation.ToString

                                Me.aKmlArray(index - 1) = tmpString
                                Me.aKmlThresholdArray(index - 1) = tmpThreshString
                                Me.aKmlBackPathArray(index - 1) = tmpBackPathString
                                Me.aPowerArray(index - 1) = power
                                Me.aLatLongArray(index - 1) = longitude & ", " & latitude

                            End If

                            previousLongitude = longitude
                            previousLatitude = latitude
                            index = index + 1
                            Exit For
                        End If
                    End If


                Next


            End If
        Next

        ' Me.createKMLfromArrays()

    End Sub


    ''' <summary>
    ''' this function is used if just a csv is being used and not a .mgps and a .csv from mancat
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub createArraysFrom6columnCsv()

        Dim isCancelled As Boolean = False

        Me.aMainForm.Cursor = Cursors.WaitCursor
        'Prompt user for .CSV file
        isCancelled = getCSV()

        'Check if file Dialogue was cancelled
        If (isCancelled) Then
            Me.aMainForm.Cursor = Cursors.Default
            Return
        End If

        'Parse .CSV for dataPoint information
        Me.aMainForm.Cursor = Cursors.WaitCursor
        If (ParseCSV()) Then
            Me.aMainForm.Cursor = Cursors.Default
            Return
        End If

        'Parse Point List and create KML
        Me.aMainForm.Cursor = Cursors.WaitCursor
        ParsePointList()

        'Prompt user for kml target directory
        isCancelled = GetTargetDirectory()

        'Check if file Dialogue was cancelled
        If (isCancelled) Then
            Me.aMainForm.Cursor = Cursors.Default
            Return
        End If

        'Serialize kml object to .kml file
        Me.aMainForm.Cursor = Cursors.WaitCursor
        SerializeKML()

        'zip KML to a KMZ
        If Me.aMainForm.kmzCheckBox.Checked = True Then
            ZipKMZ()
        End If

        'Anounce Completion
        AnounceCompletion()

        Me.aMainForm.Cursor = Cursors.Default

    End Sub
  
    ''' <summary>
    ''' Gets CSV file from user
    ''' </summary>
    ''' <remarks></remarks>
    Function getCSV() As Boolean
        Try
            ' set up the open file dialog properties
            Me.aMainForm.OpenFileDialog1.InitialDirectory = Me.inputDirectory
            Me.aMainForm.OpenFileDialog1.Multiselect = True
            Me.aMainForm.OpenFileDialog1.Title = "Select a CSV File, Please"
            Me.aMainForm.OpenFileDialog1.FileName = ""
            Me.aMainForm.OpenFileDialog1.Filter = "Trace Files (*.csv)|*.csv*| All files (*.*)|*.*"
            Me.aMainForm.OpenFileDialog1.FilterIndex = 1
            Me.aMainForm.txtBxMLOGfile.Text = Me.aMainForm.OpenFileDialog1.FileName

            ' display the open file message box
            If Me.aMainForm.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Me.aMainForm.txtBxMLOGfile.Text = Me.aMainForm.OpenFileDialog1.FileName
                Me.aCsvFile = Me.aMainForm.txtBxMLOGfile.Text
                Dim tempArr() As String = Me.aMainForm.OpenFileDialog1.FileName.Split("\") 'split(Me.aMainForm.OpenFileDialog1.FileName, "\")
                Dim temp As String = ""
                For aa As Integer = 0 To tempArr.Length - 2
                    temp = temp & tempArr(aa) & "\"
                Next
                Me.inputDirectory = temp

            ElseIf Windows.Forms.DialogResult.Cancel Then
                Return True
            End If


            ' check that file is not empty -- if so, then skip it
            If FileLen(Me.aCsvFile) = 0 Then
                MessageBox.Show("Skipping: " & Me.aCsvFile & vbCrLf & "File is empty", "Returning to main...")
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Read through CSV and add data for each line to a point object then add all point objects to point list
    ''' </summary>
    ''' <remarks></remarks>
    Function ParseCSV() As Boolean
        Dim buffer As String
        Dim split() As String
        Dim arrayIndex As Integer = 0
        Dim aPoint As DataPoint
        pointList = New List(Of DataPoint)
        Try
            reader = New StreamReader(Me.aCsvFile)
            'FileOpen(1, Me.aCsvFile, OpenMode.Input)
        Catch ex As Exception
            MsgBox("Unable to open " & Me.aCsvFile & vbCrLf & ex.Message)
            Return True
        End Try

        While Not (reader.EndOfStream)
            buffer = reader.ReadLine
            If Not (buffer = "") Then
                split = buffer.Split(",")
                Try
                    If (split(1) = "freq" Or split(1) = "") Then
                        'skip
                    Else

                        aPoint = New DataPoint
                        aPoint.DateandTime = Convert.ToDateTime(split(0))
                        aPoint.Frequency = Convert.ToDouble(split(1))
                        aPoint.Power = Convert.ToDouble(split(2))
                        aPoint.Latitude = Convert.ToDouble(split(3))
                        aPoint.Longitude = If(split(4) = "", 0, Convert.ToDouble(split(4)))
                        aPoint.Elevation = If(split(5) = "", 0, Convert.ToDouble(split(5)))
                        aPoint.ArrayIndex = arrayIndex
                        pointList.Add(aPoint)
                        arrayIndex = arrayIndex + 1
                    End If
                Catch e As Exception
                    Dim result As System.Windows.Forms.DialogResult
                    result = MessageBox.Show("Error in information of line " & arrayIndex & " in CSV." & vbNewLine _
                                             & "Select OK to skip Data Point and continue." & vbNewLine _
                                             & "Select Cancel to return to Main Form." & vbNewLine _
                                             & vbNewLine & "Error Information: " & e.ToString(), "Error Message", MessageBoxButtons.OKCancel)
                    Select Case result
                        Case DialogResult.OK
                            arrayIndex = arrayIndex + 1
                            Continue While
                        Case DialogResult.Cancel
                            Return True
                    End Select

                End Try
            End If
        End While

        reader.Close()
        Return False
    End Function
    Sub Decimate()

        Dim sortedList As New List(Of DataPoint)
        Dim tempList As New List(Of DataPoint)
        Dim distance As New Double()
        Dim previousPoint As New DataPoint()

        'Sort by Latitude
        sortedList = Me.pointList.OrderBy(Function(x) x.Latitude).ToList()

        'Decimate using distance calculator
        For Each point In sortedList
            If Not (DataPoint.Equals(point, sortedList(0))) Then
                distance = Me.aDistanceCalculatorController.run(point.Latitude.ToString(), point.Longitude.ToString(), previousPoint.Latitude.ToString(), previousPoint.Longitude.ToString())

                If (distance < CDbl(Me.aMainForm.cmbBxDecimateMeters.Text)) Then
                    'skip
                    Continue For
                Else
                    tempList.Add(point)
                    previousPoint = point
                End If
            Else
                previousPoint = point
            End If

        Next

        'Sort by Longitude
        sortedList = New List(Of DataPoint)
        sortedList = tempList.OrderBy(Function(x) x.Longitude).ToList()
        tempList = New List(Of DataPoint)

        'Decimate using distance calculator
        For Each point In sortedList
            If Not (DataPoint.Equals(point, sortedList(0))) Then
                distance = Me.aDistanceCalculatorController.run(point.Latitude.ToString(), point.Longitude.ToString(), previousPoint.Latitude.ToString(), previousPoint.Longitude.ToString())

                If (distance < CDbl(Me.aMainForm.cmbBxDecimateMeters.Text)) Then
                    'skip
                    Continue For
                Else
                    tempList.Add(point)
                    previousPoint = point
                End If
            Else
                previousPoint = point
            End If

        Next

        'Sort by original index
        sortedList = New List(Of DataPoint)
        sortedList = tempList.OrderBy(Function(x) x.ArrayIndex).ToList()
        tempList = New List(Of DataPoint)

        'Decimate using distance calculator
        For Each point In sortedList
            If Not (DataPoint.Equals(point, sortedList(0))) Then
                distance = Me.aDistanceCalculatorController.run(point.Latitude.ToString(), point.Longitude.ToString(), previousPoint.Latitude.ToString(), previousPoint.Longitude.ToString())

                If (distance < CDbl(Me.aMainForm.cmbBxDecimateMeters.Text)) Then
                    'skip
                    Continue For
                Else
                    tempList.Add(point)
                    previousPoint = point
                End If
            Else
                previousPoint = point
            End If
        Next

        Me.pointList = New List(Of DataPoint)
        Me.pointList = tempList

    End Sub
    ''' <summary>
    ''' Parse Point List and create KML object
    ''' </summary>
    ''' <remarks></remarks>
    Sub ParsePointList()
        Dim longitude As String
        Dim latitude As String
        Dim previousLongitude As String
        Dim previousLatitude As String
        Dim powerValue As Double
        Dim avgPower As String
        Dim elevation As Double = 0
        Dim thresholdElevation As Double = 0
        theKML = New kml

        previousLongitude = System.Math.Round(pointList(0).Longitude, 5)
        previousLatitude = System.Math.Round(pointList(0).Latitude, 5)

        If Me.aMainForm.chkBxDecimate.Checked = True Then
            Me.Decimate()
        End If

        Try
            For Each point In Me.pointList

                longitude = System.Math.Round(point.Longitude, 5)
                latitude = System.Math.Round(point.Latitude, 5)

                

                powerValue = System.Math.Round(point.Power, 2)
                avgPower = (powerValue + Me.sysLossFactor).ToString

                'elevation used here is to artiificially raise the lines off the ground to provide ease of viewing the lines
                If (CDbl(avgPower) < 0) Then
                    elevation = (Me.scaleFactor - Math.Abs(CDbl(avgPower))) * Me.configContents.hightscale '/ 5            'Adjusted 2/18/14
                Else
                    elevation = (Me.scaleFactor + CDbl(avgPower)) * Me.configContents.hightscale
                End If

                thresholdElevation = (Me.scaleFactor - Math.Abs(Me.threshold)) '/ 5     'Adjusted 2/18/14
                Dim square = {longitude - Me.configContents.columnWidth / 100000 & "," & latitude + Me.configContents.columnWidth / 100000 & "," & elevation.ToString,
                              longitude + Me.configContents.columnWidth / 100000 & "," & latitude + Me.configContents.columnWidth / 100000 & "," & elevation.ToString,
                              longitude + Me.configContents.columnWidth / 100000 & "," & latitude - Me.configContents.columnWidth / 100000 & "," & elevation.ToString,
                              longitude - Me.configContents.columnWidth / 100000 & "," & latitude - Me.configContents.columnWidth / 100000 & "," & elevation.ToString} 'added 2/18/14

                Dim threshSquare = {longitude - 0.00002 & "," & latitude + 0.00002 & "," & thresholdElevation.ToString,
                                    longitude + 0.00002 & "," & latitude + 0.00002 & "," & thresholdElevation.ToString,
                                    longitude + 0.00002 & "," & latitude - 0.00002 & "," & thresholdElevation.ToString,
                                    longitude - 0.00002 & "," & latitude - 0.00002 & "," & thresholdElevation.ToString} 'added 2/18/14

                Dim coordinates As String = Nothing
                Dim threshCoordinates As String = Nothing


                'Select case added 2/18/14 by Will Boxx for use with visual style choices: column or line
                Select Case Me.aMainForm.visualStyleComboBox.Text
                    Case "Line String"
                        coordinates = longitude & "," & latitude & "," & elevation.ToString & " " & previousLongitude & "," & previousLatitude & "," & elevation.ToString
                        'tmpThreshString = longitude & "," & latitude & "," & thresholdElevation.ToString & " " & previousLongitude & "," & previousLatitude & "," & thresholdElevation.ToString
                    Case "Column"
                        coordinates = square(0) & " " & square(1) & " " & square(2) & " " & square(3) & " " & square(0)     'added 2/18/14
                        'tmpThreshString = threshSquare(0) & " " & threshSquare(1) & " " & threshSquare(2) & " " & threshSquare(3) & " " & threshSquare(0)
                    Case "Point"
                        coordinates = longitude & "," & latitude & "," & "0" '& elevation.ToString
                End Select
                threshCoordinates = longitude & "," & latitude & "," & thresholdElevation.ToString & " " & previousLongitude & "," & previousLatitude & "," & thresholdElevation.ToString



                previousLatitude = latitude
                previousLongitude = longitude

                'If threshold only is unchecked then create kml file for all datapoints
                If (Me.aMainForm.thresholdOnlyCheckBox.Checked = False) Then
                    Dim DataPointDocument As New Document
                    Dim DataPointPlacemark As New Placemark

                    'If a filename was not given then use "DataPoint" for document name
                    If (Me.aMainForm.txtBxfilename.Text = Nothing) Then
                        DataPointDocument.name = "DataPoint" & point.ArrayIndex
                        DataPointPlacemark.name = "DataPoint" & point.ArrayIndex
                    Else
                        DataPointDocument.name = Me.aMainForm.txtBxfilename.Text & point.ArrayIndex
                        DataPointPlacemark.name = Me.aMainForm.txtBxfilename.Text & point.ArrayIndex
                    End If



                    If (Me.aMainForm.visualStyleComboBox.Text = "Point") Then

                        DataPointPlacemark.Point = New Point
                        DataPointPlacemark.Point.coordinates = coordinates
                        DataPointPlacemark.description = point.Frequency & " MHz" & vbNewLine & "Output Power " & point.Power & vbNewLine & point.Longitude & "," & point.Latitude
                        If (point.Power >= CDbl(Me.aMainForm.NumUpDwnSensitivityThreshold.Value)) Then
                            DataPointDocument.Style.id = "red-pushpin"
                            DataPointPlacemark.styleUrl = "#red-pushpin"
                            DataPointDocument.Style.IconStyle.Icon.href = redPushPinHREF
                        Else
                            DataPointDocument.Style.id = "ylw-pushpin"
                            DataPointPlacemark.styleUrl = "#ylw-pushpin"
                            DataPointDocument.Style.IconStyle.Icon.href = yellowPushPinHREF
                        End If
                    Else
                        DataPointDocument.Style.id = "sn_ylw-pushpin"
                        DataPointPlacemark.styleUrl = "#sn_ylw-pushpin"
                        'If power of point is greater than threshold then use colorPass else use colorFail
                        If (point.Power >= CDbl(Me.aMainForm.NumUpDwnSensitivityThreshold.Value)) Then
                            DataPointDocument.Style.LineStyle.color = Me.kmlColorGreen
                            DataPointDocument.Style.PolyStyle.color = Me.kmlColorGreen
                        Else
                            DataPointDocument.Style.LineStyle.color = Me.kmlColorRed
                            DataPointDocument.Style.PolyStyle.color = Me.kmlColorRed
                        End If

                        DataPointDocument.Style.LineStyle.width = 10
                        DataPointDocument.Style.PolyStyle.colorMode = "normal"
                        DataPointDocument.Style.PolyStyle.fill = 1
                        DataPointDocument.Style.PolyStyle.outline = 1

                        DataPointPlacemark.description = point.Longitude & ", " & point.Latitude & vbNewLine & point.Power
                        Select Case Me.aMainForm.visualStyleComboBox.Text
                            Case "Line String"
                                DataPointPlacemark.LineString = New LineString
                                DataPointPlacemark.LineString.extrude = 1
                                DataPointPlacemark.LineString.tesselate = 0
                                DataPointPlacemark.LineString.altitudeMode = "relativeToGround"
                                DataPointPlacemark.LineString.coordinates = coordinates
                            Case "Column"
                                DataPointPlacemark.Polygon = New Polygon
                                DataPointPlacemark.Polygon.extrude = 1
                                DataPointPlacemark.Polygon.tesselate = 1
                                DataPointPlacemark.Polygon.altitudeMode = "relativeToGround"
                                DataPointPlacemark.Polygon.outerBoundaryIs.LinearRing.coordinates = coordinates
                        End Select
                    End If
                    DataPointDocument.Placemark = DataPointPlacemark
                    theKML.Folder.Add(DataPointDocument)

                End If

                'If create threshold checkbox is checked then create threshold points
                If (Me.aMainForm.chkBxThreshold.Checked = True) Then
                    Dim ThresholdDocument As New Document
                    Dim ThresholdPlacemark As New Placemark

                    'If a filename was not given then use "Threshold" for document name
                    If (Me.aMainForm.txtBxfilename.Text = Nothing) Then
                        ThresholdDocument.name = "Threshold" & point.ArrayIndex
                        ThresholdPlacemark.name = "Threshold" & point.ArrayIndex
                    Else
                        ThresholdDocument.name = Me.aMainForm.txtBxfilename.Text & "Threshold" & point.ArrayIndex
                        ThresholdPlacemark.name = Me.aMainForm.txtBxfilename.Text & "Threshold" & point.ArrayIndex
                    End If

                    ThresholdDocument.Style.id = "sn_ylw-pushpin"
                    ThresholdPlacemark.styleUrl = "#sn_ylw-pushpin"

                    ThresholdDocument.Style.LineStyle.color = Me.kmlColorYellow
                    ThresholdDocument.Style.PolyStyle.color = Me.kmlColorYellow

                    ThresholdDocument.Style.LineStyle.width = Me.aMainForm.NumericUpDownThreshLineThickness.Value
                    ThresholdDocument.Style.PolyStyle.colorMode = "normal"
                    ThresholdDocument.Style.PolyStyle.fill = 1
                    ThresholdDocument.Style.PolyStyle.outline = 1

                    ThresholdPlacemark.description = point.Longitude & ", " & point.Latitude & ", " & Me.aMainForm.NumUpDwnSensitivityThreshold.Value
                    ThresholdPlacemark.LineString = New LineString
                    ThresholdPlacemark.LineString.extrude = 1
                    ThresholdPlacemark.LineString.tesselate = 0
                    ThresholdPlacemark.LineString.altitudeMode = "relativeToGround"
                    ThresholdPlacemark.LineString.coordinates = threshCoordinates

                    ThresholdDocument.Placemark = ThresholdPlacemark
                    theKML.Folder.Add(ThresholdDocument)
                End If
            Next

        Catch ex As Exception
            MsgBox("Error!  " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Prompt user for target directory to save kml file
    ''' </summary>
    ''' <remarks></remarks>
    Function GetTargetDirectory() As Boolean

        'MessageBox.Show("Enter a path and file to store current trace data", "File")
        Me.aMainForm.SaveFileDialog1.Title = "Specify Destination Directory and Filename"
        Me.aMainForm.SaveFileDialog1.FileName = Me.aMainForm.txtBxfilename.Text
        Me.aMainForm.SaveFileDialog1.InitialDirectory = Me.outputDirectory
        Me.aMainForm.SaveFileDialog1.Filter = "All files (*.*)|*.*"
        Me.aMainForm.SaveFileDialog1.FilterIndex = 1
        Me.aMainForm.SaveFileDialog1.OverwritePrompt = True
        If Me.aMainForm.SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Dim tempArr() As String = Split(Me.aMainForm.SaveFileDialog1.FileName, "\")
            Dim temp As String = ""
            For aa As Integer = 0 To tempArr.Length - 2
                temp = temp & tempArr(aa) & "\"
            Next
            Me.aMainForm.txtBxOutDir.Text = temp
            Me.newDir = temp
            Me.outputDirectory = temp
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)   'Added 2/12/14 by Will Boxx
            MsgBox("created: " & Me.newDir)
        Else
            Return True
        End If

        Me.KMLOutputFile = Me.aMainForm.SaveFileDialog1.FileName

        Return False
    End Function

    ''' <summary>
    ''' Serializes data in kml object to a .kml file
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SerializeKML()

        Dim serializer As New XmlSerializer(GetType(kml))
        Dim writer As New StreamWriter(Me.KMLOutputFile & ".kml", False)

        
        serializer.Serialize(writer, theKML)
        writer.Close()


        

    End Sub


    ''' <summary>
    ''' Displys pop up anouncing completion.  Plays sound 
    ''' </summary>
    ''' <remarks></remarks>
    Sub AnounceCompletion()
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)   'Added 2/12/14 by Will Boxx
        MsgBox("Successfully created KML") ': " & index & " files to: " & Me.newDir)
    End Sub


    Public Sub ZipKMZ()             'Added 2/12/14 by Will Boxx
        Dim filename As String = Me.KMLOutputFile & ".kml"
        Dim zipPath As String = Me.KMLOutputFile & ".kmz"

        If IO.File.Exists(zipPath) Then IO.File.Delete(zipPath)

        If IO.File.Exists(filename) Then
            Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create)
                archive.CreateEntryFromFile(filename, Path.GetFileName(filename), CompressionLevel.Fastest)
            End Using

        End If

    End Sub
   

    Public Sub xmlFileReader()

        Dim serializer As New XmlSerializer(GetType(MainFormValuesObject))
        aMainFormValuesObject = New MainFormValuesObject()
        Dim reader As StreamReader

        Try
            reader = New StreamReader(Me.formValues)
        Catch ex As Exception
            MsgBox("Unable to load History file: " & Me.formValues)
            Return
        End Try

        Try
            aMainFormValuesObject = serializer.Deserialize(reader)

            Me.aMainForm.passLabel.Text = aMainFormValuesObject.passColor
            Me.aMainForm.failLabel.Text = aMainFormValuesObject.failColor
            Me.aMainForm.threshLabel.Text = aMainFormValuesObject.threshColor
            Me.kmlColorGreen = aMainFormValuesObject.passColorHex
            Me.kmlColorRed = aMainFormValuesObject.failColorHex
            Me.kmlColorYellow = aMainFormValuesObject.threshColorHex
            Me.aMainForm.customColorsPass(0) = aMainFormValuesObject.passCustomColors.color0
            Me.aMainForm.customColorsPass(1) = aMainFormValuesObject.passCustomColors.color1
            Me.aMainForm.customColorsPass(2) = aMainFormValuesObject.passCustomColors.color2
            Me.aMainForm.customColorsPass(3) = aMainFormValuesObject.passCustomColors.color3
            Me.aMainForm.customColorsPass(4) = aMainFormValuesObject.passCustomColors.color4
            Me.aMainForm.customColorsPass(5) = aMainFormValuesObject.passCustomColors.color5
            Me.aMainForm.customColorsPass(6) = aMainFormValuesObject.passCustomColors.color6
            Me.aMainForm.customColorsPass(7) = aMainFormValuesObject.passCustomColors.color7
            Me.aMainForm.customColorsPass(8) = aMainFormValuesObject.passCustomColors.color8
            Me.aMainForm.customColorsPass(9) = aMainFormValuesObject.passCustomColors.color9
            Me.aMainForm.customColorsPass(10) = aMainFormValuesObject.passCustomColors.color10
            Me.aMainForm.customColorsPass(11) = aMainFormValuesObject.passCustomColors.color11
            Me.aMainForm.customColorsPass(12) = aMainFormValuesObject.passCustomColors.color12
            Me.aMainForm.customColorsPass(13) = aMainFormValuesObject.passCustomColors.color13
            Me.aMainForm.customColorsPass(14) = aMainFormValuesObject.passCustomColors.color14
            Me.aMainForm.customColorsPass(15) = aMainFormValuesObject.passCustomColors.color15
            Me.aMainForm.customColorsFail(0) = aMainFormValuesObject.failCustomColors.color0
            Me.aMainForm.customColorsFail(1) = aMainFormValuesObject.failCustomColors.color1
            Me.aMainForm.customColorsFail(2) = aMainFormValuesObject.failCustomColors.color2
            Me.aMainForm.customColorsFail(3) = aMainFormValuesObject.failCustomColors.color3
            Me.aMainForm.customColorsFail(4) = aMainFormValuesObject.failCustomColors.color4
            Me.aMainForm.customColorsFail(5) = aMainFormValuesObject.failCustomColors.color5
            Me.aMainForm.customColorsFail(6) = aMainFormValuesObject.failCustomColors.color6
            Me.aMainForm.customColorsFail(7) = aMainFormValuesObject.failCustomColors.color7
            Me.aMainForm.customColorsFail(8) = aMainFormValuesObject.failCustomColors.color8
            Me.aMainForm.customColorsFail(9) = aMainFormValuesObject.failCustomColors.color9
            Me.aMainForm.customColorsFail(10) = aMainFormValuesObject.failCustomColors.color10
            Me.aMainForm.customColorsFail(11) = aMainFormValuesObject.failCustomColors.color11
            Me.aMainForm.customColorsFail(12) = aMainFormValuesObject.failCustomColors.color12
            Me.aMainForm.customColorsFail(13) = aMainFormValuesObject.failCustomColors.color13
            Me.aMainForm.customColorsFail(14) = aMainFormValuesObject.failCustomColors.color14
            Me.aMainForm.customColorsFail(15) = aMainFormValuesObject.failCustomColors.color15
            Me.aMainForm.customColorsThresh(0) = aMainFormValuesObject.threshholdCustomColors.color0
            Me.aMainForm.customColorsThresh(1) = aMainFormValuesObject.threshholdCustomColors.color1
            Me.aMainForm.customColorsThresh(2) = aMainFormValuesObject.threshholdCustomColors.color2
            Me.aMainForm.customColorsThresh(3) = aMainFormValuesObject.threshholdCustomColors.color3
            Me.aMainForm.customColorsThresh(4) = aMainFormValuesObject.threshholdCustomColors.color4
            Me.aMainForm.customColorsThresh(5) = aMainFormValuesObject.threshholdCustomColors.color5
            Me.aMainForm.customColorsThresh(6) = aMainFormValuesObject.threshholdCustomColors.color6
            Me.aMainForm.customColorsThresh(7) = aMainFormValuesObject.threshholdCustomColors.color7
            Me.aMainForm.customColorsThresh(8) = aMainFormValuesObject.threshholdCustomColors.color8
            Me.aMainForm.customColorsThresh(9) = aMainFormValuesObject.threshholdCustomColors.color9
            Me.aMainForm.customColorsThresh(10) = aMainFormValuesObject.threshholdCustomColors.color10
            Me.aMainForm.customColorsThresh(11) = aMainFormValuesObject.threshholdCustomColors.color11
            Me.aMainForm.customColorsThresh(12) = aMainFormValuesObject.threshholdCustomColors.color12
            Me.aMainForm.customColorsThresh(13) = aMainFormValuesObject.threshholdCustomColors.color13
            Me.aMainForm.customColorsThresh(14) = aMainFormValuesObject.threshholdCustomColors.color14
            Me.aMainForm.customColorsThresh(15) = aMainFormValuesObject.threshholdCustomColors.color15
            Me.aMainForm.visualStyleComboBox.Text = aMainFormValuesObject.visualStyle
            Me.aMainForm.NumericUpDownThreshLineThickness.Value = aMainFormValuesObject.thresholdLineThickness
            Me.aMainForm.chkBxMgpsAndCsv.Checked = aMainFormValuesObject.mgps
            Me.aMainForm.chkBxDecimate.Checked = aMainFormValuesObject.spatialDecimate
            Me.aMainForm.chkBxThreshold.Checked = aMainFormValuesObject.useThreshold
            Me.aMainForm.NumUpDwnSensitivityThreshold.Value = aMainFormValuesObject.threshold
            Me.aMainForm.NumUpDwnSysLossFactor.Value = aMainFormValuesObject.systemLoss
            Me.aMainForm.txtBxUnits.Text = aMainFormValuesObject.units
            Me.aMainForm.cmbBxDecimateMeters.Text = aMainFormValuesObject.spatialDistance
            Me.inputDirectory = aMainFormValuesObject.inputDirectory
            Me.outputDirectory = aMainFormValuesObject.outputDirectory
            Me.aMainForm.txtBxfilename.Text = aMainFormValuesObject.projectName

            reader.Close()


        Catch ex As Exception
            MsgBox("Unable to write out form history values: " & ex.Message)
        End Try
    End Sub

    Public Sub xmlFileWriter()
        Dim serializer As New XmlSerializer(GetType(MainFormValuesObject))
        aMainFormValuesObject = New MainFormValuesObject()
        Dim writer As StreamWriter

        Try
            writer = New StreamWriter(Me.formValues)
        Catch ex As Exception
            MsgBox("Unable to load History file: " & Me.formValues)
            Return
        End Try

        Try

            aMainFormValuesObject.passColor = Me.aMainForm.passLabel.Text
            aMainFormValuesObject.failColor = Me.aMainForm.failLabel.Text
            aMainFormValuesObject.threshColor = Me.aMainForm.threshLabel.Text
            aMainFormValuesObject.passColorHex = Me.kmlColorGreen
            aMainFormValuesObject.failColorHex = Me.kmlColorRed
            aMainFormValuesObject.threshColorHex = Me.kmlColorYellow
            aMainFormValuesObject.passCustomColors.color0 = Me.aMainForm.customColorsPass(0)
            aMainFormValuesObject.passCustomColors.color1 = Me.aMainForm.customColorsPass(1)
            aMainFormValuesObject.passCustomColors.color2 = Me.aMainForm.customColorsPass(2)
            aMainFormValuesObject.passCustomColors.color3 = Me.aMainForm.customColorsPass(3)
            aMainFormValuesObject.passCustomColors.color4 = Me.aMainForm.customColorsPass(4)
            aMainFormValuesObject.passCustomColors.color5 = Me.aMainForm.customColorsPass(5)
            aMainFormValuesObject.passCustomColors.color6 = Me.aMainForm.customColorsPass(6)
            aMainFormValuesObject.passCustomColors.color7 = Me.aMainForm.customColorsPass(7)
            aMainFormValuesObject.passCustomColors.color8 = Me.aMainForm.customColorsPass(8)
            aMainFormValuesObject.passCustomColors.color9 = Me.aMainForm.customColorsPass(9)
            aMainFormValuesObject.passCustomColors.color10 = Me.aMainForm.customColorsPass(10)
            aMainFormValuesObject.passCustomColors.color11 = Me.aMainForm.customColorsPass(11)
            aMainFormValuesObject.passCustomColors.color12 = Me.aMainForm.customColorsPass(12)
            aMainFormValuesObject.passCustomColors.color13 = Me.aMainForm.customColorsPass(13)
            aMainFormValuesObject.passCustomColors.color14 = Me.aMainForm.customColorsPass(14)
            aMainFormValuesObject.passCustomColors.color15 = Me.aMainForm.customColorsPass(15)
            aMainFormValuesObject.failCustomColors.color0 = Me.aMainForm.customColorsFail(0)
            aMainFormValuesObject.failCustomColors.color1 = Me.aMainForm.customColorsFail(1)
            aMainFormValuesObject.failCustomColors.color2 = Me.aMainForm.customColorsFail(2)
            aMainFormValuesObject.failCustomColors.color3 = Me.aMainForm.customColorsFail(3)
            aMainFormValuesObject.failCustomColors.color4 = Me.aMainForm.customColorsFail(4)
            aMainFormValuesObject.failCustomColors.color5 = Me.aMainForm.customColorsFail(5)
            aMainFormValuesObject.failCustomColors.color6 = Me.aMainForm.customColorsFail(6)
            aMainFormValuesObject.failCustomColors.color7 = Me.aMainForm.customColorsFail(7)
            aMainFormValuesObject.failCustomColors.color8 = Me.aMainForm.customColorsFail(8)
            aMainFormValuesObject.failCustomColors.color9 = Me.aMainForm.customColorsFail(9)
            aMainFormValuesObject.failCustomColors.color10 = Me.aMainForm.customColorsFail(10)
            aMainFormValuesObject.failCustomColors.color11 = Me.aMainForm.customColorsFail(11)
            aMainFormValuesObject.failCustomColors.color12 = Me.aMainForm.customColorsFail(12)
            aMainFormValuesObject.failCustomColors.color13 = Me.aMainForm.customColorsFail(13)
            aMainFormValuesObject.failCustomColors.color14 = Me.aMainForm.customColorsFail(14)
            aMainFormValuesObject.failCustomColors.color15 = Me.aMainForm.customColorsFail(15)
            aMainFormValuesObject.threshholdCustomColors.color0 = Me.aMainForm.customColorsThresh(0)
            aMainFormValuesObject.threshholdCustomColors.color1 = Me.aMainForm.customColorsThresh(1)
            aMainFormValuesObject.threshholdCustomColors.color2 = Me.aMainForm.customColorsThresh(2)
            aMainFormValuesObject.threshholdCustomColors.color3 = Me.aMainForm.customColorsThresh(3)
            aMainFormValuesObject.threshholdCustomColors.color4 = Me.aMainForm.customColorsThresh(4)
            aMainFormValuesObject.threshholdCustomColors.color5 = Me.aMainForm.customColorsThresh(5)
            aMainFormValuesObject.threshholdCustomColors.color6 = Me.aMainForm.customColorsThresh(6)
            aMainFormValuesObject.threshholdCustomColors.color7 = Me.aMainForm.customColorsThresh(7)
            aMainFormValuesObject.threshholdCustomColors.color8 = Me.aMainForm.customColorsThresh(8)
            aMainFormValuesObject.threshholdCustomColors.color9 = Me.aMainForm.customColorsThresh(9)
            aMainFormValuesObject.threshholdCustomColors.color10 = Me.aMainForm.customColorsThresh(10)
            aMainFormValuesObject.threshholdCustomColors.color11 = Me.aMainForm.customColorsThresh(11)
            aMainFormValuesObject.threshholdCustomColors.color12 = Me.aMainForm.customColorsThresh(12)
            aMainFormValuesObject.threshholdCustomColors.color13 = Me.aMainForm.customColorsThresh(13)
            aMainFormValuesObject.threshholdCustomColors.color14 = Me.aMainForm.customColorsThresh(14)
            aMainFormValuesObject.threshholdCustomColors.color15 = Me.aMainForm.customColorsThresh(15)
            aMainFormValuesObject.visualStyle = Me.aMainForm.visualStyleComboBox.Text
            aMainFormValuesObject.thresholdLineThickness = Me.aMainForm.NumericUpDownThreshLineThickness.Value
            aMainFormValuesObject.mgps = Me.aMainForm.chkBxMgpsAndCsv.Checked
            aMainFormValuesObject.spatialDecimate = Me.aMainForm.chkBxDecimate.Checked
            aMainFormValuesObject.useThreshold = Me.aMainForm.chkBxThreshold.Checked
            aMainFormValuesObject.threshold = Me.aMainForm.NumUpDwnSensitivityThreshold.Value
            aMainFormValuesObject.systemLoss = Me.aMainForm.NumUpDwnSysLossFactor.Value
            aMainFormValuesObject.units = Me.aMainForm.txtBxUnits.Text
            aMainFormValuesObject.spatialDistance = Me.aMainForm.cmbBxDecimateMeters.Text
            aMainFormValuesObject.inputDirectory = Me.inputDirectory
            aMainFormValuesObject.outputDirectory = Me.outputDirectory
            aMainFormValuesObject.projectName = Me.aMainForm.txtBxfilename.Text


            serializer.Serialize(writer, aMainFormValuesObject)
            writer.Close()
        Catch ex As Exception
            MsgBox("Unable to write out form history values: " & ex.Message)
        End Try
    End Sub

    Public Sub ConfigLoad()
        Try
            Dim serializer As New XmlSerializer(GetType(ConfigObject))
            Dim reader As New StreamReader(rootDir.ToString() & "\config.xml")

            configContents = serializer.Deserialize(reader)
            reader.Close()
        Catch e As Exception
            MessageBox.Show("Could not deserialize config.xml in Main Controller" & vbNewLine & "Message: " & e.Message)
        End Try
    End Sub
End Class
