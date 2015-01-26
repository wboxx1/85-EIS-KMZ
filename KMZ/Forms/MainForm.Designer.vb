<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtBxMGPSfile = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.NumUpDwnSensitivityThreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumUpDwnSysLossFactor = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBxOutDir = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBxMLOGfile = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.chkBxMgpsAndCsv = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkBxDecimate = New System.Windows.Forms.CheckBox()
        Me.cmbBxDecimateMeters = New System.Windows.Forms.ComboBox()
        Me.txtBxfilename = New System.Windows.Forms.TextBox()
        Me.chkBxThreshold = New System.Windows.Forms.CheckBox()
        Me.kmzCheckBox = New System.Windows.Forms.CheckBox()
        Me.visualStyleComboBox = New System.Windows.Forms.ComboBox()
        Me.NumericUpDownThreshLineThickness = New System.Windows.Forms.NumericUpDown()
        Me.thresholdOnlyCheckBox = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBxUnits = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.threshLabel = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.failLabel = New System.Windows.Forms.Label()
        Me.btnPassColor = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.passLabel = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.NumUpDwnSensitivityThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUpDwnSysLossFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownThreshLineThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtBxMGPSfile
        '
        Me.txtBxMGPSfile.Location = New System.Drawing.Point(2, 66)
        Me.txtBxMGPSfile.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBxMGPSfile.Name = "txtBxMGPSfile"
        Me.txtBxMGPSfile.Size = New System.Drawing.Size(161, 20)
        Me.txtBxMGPSfile.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtBxMGPSfile, "This is populated afterwards and not directly used as an input." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And only updated" & _
        " if .mgps and csv check box is checked")
        '
        'btnStart
        '
        Me.btnStart.AutoSize = True
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(276, 33)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(257, 84)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start File Import and KML file Creation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.btnStart, resources.GetString("btnStart.ToolTip"))
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'NumUpDwnSensitivityThreshold
        '
        Me.NumUpDwnSensitivityThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumUpDwnSensitivityThreshold.Location = New System.Drawing.Point(9, 47)
        Me.NumUpDwnSensitivityThreshold.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDwnSensitivityThreshold.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumUpDwnSensitivityThreshold.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.NumUpDwnSensitivityThreshold.Name = "NumUpDwnSensitivityThreshold"
        Me.NumUpDwnSensitivityThreshold.Size = New System.Drawing.Size(90, 26)
        Me.NumUpDwnSensitivityThreshold.TabIndex = 5
        Me.NumUpDwnSensitivityThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.NumUpDwnSensitivityThreshold, "This is the threshold that the power levels in the csv are compared to")
        Me.NumUpDwnSensitivityThreshold.Value = New Decimal(New Integer() {102, 0, 0, -2147483648})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Minimum Sensitivty/Threshold"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 111)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "System Loss Factor"
        '
        'NumUpDwnSysLossFactor
        '
        Me.NumUpDwnSysLossFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumUpDwnSysLossFactor.Location = New System.Drawing.Point(14, 132)
        Me.NumUpDwnSysLossFactor.Margin = New System.Windows.Forms.Padding(2)
        Me.NumUpDwnSysLossFactor.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumUpDwnSysLossFactor.Name = "NumUpDwnSysLossFactor"
        Me.NumUpDwnSysLossFactor.Size = New System.Drawing.Size(90, 26)
        Me.NumUpDwnSysLossFactor.TabIndex = 10
        Me.NumUpDwnSysLossFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.NumUpDwnSysLossFactor, "This value is added to the power levels read in from the csv to account for any a" & _
        "dditional system losses that need to be added back in")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(116, 139)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "dB"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = ".mgps File"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 144)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Ouput Directory"
        '
        'txtBxOutDir
        '
        Me.txtBxOutDir.Location = New System.Drawing.Point(2, 169)
        Me.txtBxOutDir.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBxOutDir.Name = "txtBxOutDir"
        Me.txtBxOutDir.Size = New System.Drawing.Size(504, 20)
        Me.txtBxOutDir.TabIndex = 13
        Me.txtBxOutDir.Text = "C:\Desktop\MancatConverter\" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ToolTip1.SetToolTip(Me.txtBxOutDir, "This field is populated afterwards and is not used directly as an input.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 97)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = ".csv File"
        '
        'txtBxMLOGfile
        '
        Me.txtBxMLOGfile.Location = New System.Drawing.Point(4, 125)
        Me.txtBxMLOGfile.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBxMLOGfile.Name = "txtBxMLOGfile"
        Me.txtBxMLOGfile.Size = New System.Drawing.Size(161, 20)
        Me.txtBxMLOGfile.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.txtBxMLOGfile, "This is populated afterwards and not directly used as an input.")
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'chkBxMgpsAndCsv
        '
        Me.chkBxMgpsAndCsv.AutoSize = True
        Me.chkBxMgpsAndCsv.Location = New System.Drawing.Point(176, 98)
        Me.chkBxMgpsAndCsv.Name = "chkBxMgpsAndCsv"
        Me.chkBxMgpsAndCsv.Size = New System.Drawing.Size(95, 17)
        Me.chkBxMgpsAndCsv.TabIndex = 17
        Me.chkBxMgpsAndCsv.Text = ".mgps and csv"
        Me.ToolTip1.SetToolTip(Me.chkBxMgpsAndCsv, resources.GetString("chkBxMgpsAndCsv.ToolTip"))
        Me.chkBxMgpsAndCsv.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'chkBxDecimate
        '
        Me.chkBxDecimate.AutoSize = True
        Me.chkBxDecimate.Checked = True
        Me.chkBxDecimate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBxDecimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBxDecimate.Location = New System.Drawing.Point(474, 24)
        Me.chkBxDecimate.Name = "chkBxDecimate"
        Me.chkBxDecimate.Size = New System.Drawing.Size(153, 24)
        Me.chkBxDecimate.TabIndex = 19
        Me.chkBxDecimate.Text = "spatially decimate"
        Me.ToolTip1.SetToolTip(Me.chkBxDecimate, "When checked, the applcation will decimate the points given in the csv file by th" & _
        "e spatial amount in meters chosen below. ")
        Me.chkBxDecimate.UseVisualStyleBackColor = True
        '
        'cmbBxDecimateMeters
        '
        Me.cmbBxDecimateMeters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBxDecimateMeters.FormattingEnabled = True
        Me.cmbBxDecimateMeters.Items.AddRange(New Object() {"1", "3", "5", "10", "15", "20", "25", "50", "75", "100", "125", "150", "175", "200"})
        Me.cmbBxDecimateMeters.Location = New System.Drawing.Point(474, 80)
        Me.cmbBxDecimateMeters.Name = "cmbBxDecimateMeters"
        Me.cmbBxDecimateMeters.Size = New System.Drawing.Size(109, 28)
        Me.cmbBxDecimateMeters.TabIndex = 20
        Me.cmbBxDecimateMeters.Text = "5"
        Me.ToolTip1.SetToolTip(Me.cmbBxDecimateMeters, "Data points collected that are spaced apart less than this amount are ignored.")
        '
        'txtBxfilename
        '
        Me.txtBxfilename.Location = New System.Drawing.Point(246, 47)
        Me.txtBxfilename.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBxfilename.Name = "txtBxfilename"
        Me.txtBxfilename.Size = New System.Drawing.Size(161, 20)
        Me.txtBxfilename.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.txtBxfilename, "The name here is added to the beginning of all KML files created.  It is optional" & _
        " but helps to track the files later.")
        '
        'chkBxThreshold
        '
        Me.chkBxThreshold.AutoSize = True
        Me.chkBxThreshold.Checked = True
        Me.chkBxThreshold.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBxThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBxThreshold.Location = New System.Drawing.Point(247, 234)
        Me.chkBxThreshold.Name = "chkBxThreshold"
        Me.chkBxThreshold.Size = New System.Drawing.Size(150, 20)
        Me.chkBxThreshold.TabIndex = 31
        Me.chkBxThreshold.Text = "create threshold files"
        Me.ToolTip1.SetToolTip(Me.chkBxThreshold, "When unchecked, corresponding threshold files are not created for each data point" & _
        ".")
        Me.chkBxThreshold.UseVisualStyleBackColor = True
        '
        'kmzCheckBox
        '
        Me.kmzCheckBox.AutoSize = True
        Me.kmzCheckBox.Checked = True
        Me.kmzCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.kmzCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kmzCheckBox.Location = New System.Drawing.Point(474, 123)
        Me.kmzCheckBox.Name = "kmzCheckBox"
        Me.kmzCheckBox.Size = New System.Drawing.Size(113, 24)
        Me.kmzCheckBox.TabIndex = 35
        Me.kmzCheckBox.Text = "Create KMZ"
        Me.ToolTip1.SetToolTip(Me.kmzCheckBox, "When checked will create a zipped version of the KML file.")
        Me.kmzCheckBox.UseVisualStyleBackColor = True
        '
        'visualStyleComboBox
        '
        Me.visualStyleComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.visualStyleComboBox.FormattingEnabled = True
        Me.visualStyleComboBox.Items.AddRange(New Object() {"Line String", "Column", "Point"})
        Me.visualStyleComboBox.Location = New System.Drawing.Point(474, 183)
        Me.visualStyleComboBox.Name = "visualStyleComboBox"
        Me.visualStyleComboBox.Size = New System.Drawing.Size(109, 28)
        Me.visualStyleComboBox.TabIndex = 36
        Me.visualStyleComboBox.Text = "Line String"
        Me.ToolTip1.SetToolTip(Me.visualStyleComboBox, "Line string creates a fence like appearance on google earth.  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Column will show " & _
        "each data point as a seperate column.")
        '
        'NumericUpDownThreshLineThickness
        '
        Me.NumericUpDownThreshLineThickness.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDownThreshLineThickness.Location = New System.Drawing.Point(474, 249)
        Me.NumericUpDownThreshLineThickness.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDownThreshLineThickness.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDownThreshLineThickness.Name = "NumericUpDownThreshLineThickness"
        Me.NumericUpDownThreshLineThickness.Size = New System.Drawing.Size(90, 26)
        Me.NumericUpDownThreshLineThickness.TabIndex = 39
        Me.NumericUpDownThreshLineThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.NumericUpDownThreshLineThickness, "This controls the thickness of the line used to create the threshold ""fence"" in g" & _
        "oogle earth.")
        Me.NumericUpDownThreshLineThickness.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'thresholdOnlyCheckBox
        '
        Me.thresholdOnlyCheckBox.AutoSize = True
        Me.thresholdOnlyCheckBox.Location = New System.Drawing.Point(247, 258)
        Me.thresholdOnlyCheckBox.Name = "thresholdOnlyCheckBox"
        Me.thresholdOnlyCheckBox.Size = New System.Drawing.Size(155, 17)
        Me.thresholdOnlyCheckBox.TabIndex = 38
        Me.thresholdOnlyCheckBox.Text = "Create Only Threshold Files"
        Me.ToolTip1.SetToolTip(Me.thresholdOnlyCheckBox, "When checked, only threshold pionts are added to kml.")
        Me.thresholdOnlyCheckBox.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(558, 33)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 84)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Close" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(474, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(109, 25)
        Me.Panel1.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Distance (m)"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.NumericUpDownThreshLineThickness)
        Me.GroupBox1.Controls.Add(Me.thresholdOnlyCheckBox)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.visualStyleComboBox)
        Me.GroupBox1.Controls.Add(Me.kmzCheckBox)
        Me.GroupBox1.Controls.Add(Me.chkBxThreshold)
        Me.GroupBox1.Controls.Add(Me.txtBxUnits)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.cmbBxDecimateMeters)
        Me.GroupBox1.Controls.Add(Me.threshLabel)
        Me.GroupBox1.Controls.Add(Me.chkBxDecimate)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NumUpDwnSysLossFactor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBxfilename)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.failLabel)
        Me.GroupBox1.Controls.Add(Me.btnPassColor)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.NumUpDwnSensitivityThreshold)
        Me.GroupBox1.Controls.Add(Me.passLabel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(748, 285)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(470, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(188, 20)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Threshold Line Thickness"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(470, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Data Point Visual Style"
        '
        'txtBxUnits
        '
        Me.txtBxUnits.Enabled = False
        Me.txtBxUnits.Location = New System.Drawing.Point(110, 53)
        Me.txtBxUnits.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBxUnits.Name = "txtBxUnits"
        Me.txtBxUnits.Size = New System.Drawing.Size(50, 20)
        Me.txtBxUnits.TabIndex = 32
        Me.txtBxUnits.Text = "dBm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(170, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "units"
        '
        'Button4
        '
        Me.Button4.AutoSize = True
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(11, 250)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(183, 30)
        Me.Button4.TabIndex = 34
        Me.Button4.Text = "Reset form to default values"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'threshLabel
        '
        Me.threshLabel.AutoSize = True
        Me.threshLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.threshLabel.Location = New System.Drawing.Point(358, 196)
        Me.threshLabel.Name = "threshLabel"
        Me.threshLabel.Size = New System.Drawing.Size(55, 20)
        Me.threshLabel.TabIndex = 30
        Me.threshLabel.Text = "Yellow"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(246, 187)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 41)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "Edit Threshold Color"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(248, 25)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Project Name"
        '
        'failLabel
        '
        Me.failLabel.AutoSize = True
        Me.failLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.failLabel.Location = New System.Drawing.Point(358, 141)
        Me.failLabel.Name = "failLabel"
        Me.failLabel.Size = New System.Drawing.Size(39, 20)
        Me.failLabel.TabIndex = 26
        Me.failLabel.Text = "Red"
        '
        'btnPassColor
        '
        Me.btnPassColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPassColor.Location = New System.Drawing.Point(246, 77)
        Me.btnPassColor.Name = "btnPassColor"
        Me.btnPassColor.Size = New System.Drawing.Size(106, 41)
        Me.btnPassColor.TabIndex = 23
        Me.btnPassColor.Text = "Edit Passing Color"
        Me.btnPassColor.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(246, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 41)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Edit Failing Color"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'passLabel
        '
        Me.passLabel.AutoSize = True
        Me.passLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passLabel.Location = New System.Drawing.Point(358, 88)
        Me.passLabel.Name = "passLabel"
        Me.passLabel.Size = New System.Drawing.Size(54, 20)
        Me.passLabel.TabIndex = 24
        Me.passLabel.Text = "Green"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(750, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.OptionsToolStripMenuItem.Text = "CONFIGURATION"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ConfigurationToolStripMenuItem.Text = "Edit Configuration"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(750, 481)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkBxMgpsAndCsv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBxMLOGfile)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBxOutDir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtBxMGPSfile)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.Text = "Main"
        CType(Me.NumUpDwnSensitivityThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUpDwnSysLossFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownThreshLineThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtBxMGPSfile As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents NumUpDwnSensitivityThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumUpDwnSysLossFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBxOutDir As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBxMLOGfile As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkBxMgpsAndCsv As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkBxDecimate As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBxDecimateMeters As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnPassColor As System.Windows.Forms.Button
    Friend WithEvents passLabel As System.Windows.Forms.Label
    Friend WithEvents failLabel As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBxfilename As System.Windows.Forms.TextBox
    Friend WithEvents threshLabel As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chkBxThreshold As System.Windows.Forms.CheckBox
    Friend WithEvents txtBxUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents kmzCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents visualStyleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents thresholdOnlyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDownThreshLineThickness As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
