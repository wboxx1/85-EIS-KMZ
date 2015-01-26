Public Class MainForm
    Private aMainController As MainController
    Private aConfigForm As ConfigForm
    Private isInitialized As Boolean = False
    Public colorPass As String
    Public colorFail As String
    Public colorThresh As String
    Public Abyte As Byte
    Public Bbyte As Byte
    Public Gbyte As Byte
    Public Rbyte As Byte
    Public colorHex As String
    Public customColorsPass(16) As Integer
    Public customColorsFail(16) As Integer
    Public customColorsThresh(16) As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.aMainController = New MainController(Me)
        Me.isInitialized = True
        Me.aMainController.xmlFileReader()
        Me.aMainController.ConfigLoad()


    End Sub

    Private Sub btnOpenCSVfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If Me.chkBxMgpsAndCsv.Checked = True Then
            Me.aMainController.convertCsvToKml()
        Else
            'Me.aMainController.ConfigLoad()
            Me.aMainController.createArraysFrom6columnCsv()
        End If

    End Sub

    Private Sub NumericUpDownSensitivityThreshold_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDwnSensitivityThreshold.ValueChanged
        If Me.isInitialized <> False Then
            Me.aMainController.threshold = CDbl(NumUpDwnSensitivityThreshold.Value)
        End If
    
    End Sub

    Private Sub NumUpDwnSysLossFactor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUpDwnSysLossFactor.ValueChanged
        If Me.isInitialized <> False Then
            Me.aMainController.sysLossFactor = CDbl(NumUpDwnSysLossFactor.Value)
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.aMainController.xmlFileWriter()
        End
    End Sub

    Private Sub btnPassColor_Click(sender As System.Object, e As System.EventArgs) Handles btnPassColor.Click
        Try
            ' display the open file message box
            ColorDialog1.CustomColors = customColorsPass                'Added 2/12/2014 by Will Boxx
            If Me.ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Dim color As System.Drawing.Color = Me.ColorDialog1.Color
                Me.colorPass = color.Name
                Me.Abyte = color.A
                Me.Bbyte = color.B
                Me.Gbyte = color.G
                Me.Rbyte = color.R

                Me.colorHex = Me.Abyte.ToString("X2") & Me.Bbyte.ToString("X2") & Me.Gbyte.ToString("X2") & Me.Rbyte.ToString("X2")
                Me.aMainController.kmlColorGreen = Me.colorHex
                Me.passLabel.Text = Me.colorPass

                customColorsPass = Me.ColorDialog1.CustomColors        'Added 2/12/2014 by Will Boxx

            ElseIf Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        Catch ex As Exception
            MsgBox("Unable to choose color: " & ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            ' display the open file message box
            ColorDialog1.CustomColors = customColorsFail                'Added 2/12/2014 by Will Boxx
            If Me.ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Dim color As System.Drawing.Color = Me.ColorDialog1.Color
                Me.colorFail = color.Name
                Me.Abyte = color.A
                Me.Bbyte = color.B
                Me.Gbyte = color.G
                Me.Rbyte = color.R

                Me.colorHex = Me.Abyte.ToString("X2") & Me.Bbyte.ToString("X2") & Me.Gbyte.ToString("X2") & Me.Rbyte.ToString("X2")
                Me.aMainController.kmlColorRed = Me.colorHex
                Me.failLabel.Text = Me.colorFail

                customColorsFail = Me.ColorDialog1.CustomColors        'Added 2/12/2014 by Will Boxx

            ElseIf Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        Catch ex As Exception
            MsgBox("Unable to choose color: " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            ' display the open file message box
            ColorDialog1.CustomColors = customColorsThresh               'Added 2/12/2014 by Will Boxx
            If Me.ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                Dim color As System.Drawing.Color = Me.ColorDialog1.Color
                Me.colorThresh = color.Name
                Me.Abyte = color.A
                Me.Bbyte = color.B
                Me.Gbyte = color.G
                Me.Rbyte = color.R

                Me.colorHex = Me.Abyte.ToString("X2") & Me.Bbyte.ToString("X2") & Me.Gbyte.ToString("X2") & Me.Rbyte.ToString("X2")
                Me.aMainController.kmlColorYellow = Me.colorHex
                Me.threshLabel.Text = Me.colorThresh

                customColorsThresh = Me.ColorDialog1.CustomColors        'Added 2/12/2014 by Will Boxx

            ElseIf Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        Catch ex As Exception
            MsgBox("Unable to choose color: " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            Me.failLabel.Text = "Red"
            Me.aMainController.kmlColorRed = "ff0000ff"
            Me.passLabel.Text = "Green"
            Me.aMainController.kmlColorGreen = "ff00ff00"
            Me.threshLabel.Text = "Yellow"
            Me.aMainController.kmlColorYellow = "ff00ffff"
            Me.txtBxUnits.Text = "dBm"
            Me.NumUpDwnSensitivityThreshold.Value = -102
            Me.NumUpDwnSysLossFactor.Value = 0
            Me.txtBxfilename.Text = ""
            Me.chkBxThreshold.Checked = True
            Me.chkBxDecimate.Checked = True
            Me.chkBxMgpsAndCsv.Checked = False
            Me.cmbBxDecimateMeters.Text = "5"
            Me.kmzCheckBox.Checked = True       'Added 2/12/14 by Will Boxx
            Me.Update()

        Catch ex As Exception
            MsgBox("Unable to set form values to default values: " & ex.Message)

        End Try
    End Sub
    
    Private Sub thresholdOnlyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles thresholdOnlyCheckBox.CheckedChanged
        If (Me.thresholdOnlyCheckBox.Checked) Then
            Me.NumUpDwnSysLossFactor.Enabled = False
            Me.btnPassColor.Enabled = False
            Me.Button2.Enabled = False
            Me.visualStyleComboBox.Enabled = False
            Me.chkBxThreshold.Enabled = False
            Me.Button4.Enabled = False
            Me.visualStyleComboBox.Text = "Column"
            Me.chkBxThreshold.Checked = True
        Else
            Me.NumUpDwnSysLossFactor.Enabled = True
            Me.btnPassColor.Enabled = True
            Me.Button2.Enabled = True
            Me.visualStyleComboBox.Enabled = True
            Me.chkBxThreshold.Enabled = True
            Me.Button4.Enabled = True
        End If
    End Sub

 

    Private Sub chkBxMgpsAndCsv_CheckedChanged(sender As Object, e As EventArgs) Handles chkBxMgpsAndCsv.CheckedChanged
        If (Me.chkBxMgpsAndCsv.Checked = True) Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)   'Added 2/12/14 by Will Boxx
            MessageBox.Show("This feature is currently not available in this version." & vbNewLine & "To access this feature, please use an older version (2013 or earlier)")
            Me.chkBxMgpsAndCsv.Checked = False
        End If
    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Me.aConfigForm = New ConfigForm(aMainController)
        Me.aConfigForm.Show()
    End Sub

End Class
