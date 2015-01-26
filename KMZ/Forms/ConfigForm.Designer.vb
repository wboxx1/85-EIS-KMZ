<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnWidthUpDown = New System.Windows.Forms.NumericUpDown()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.HightScaleNumUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ColumnWidthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HightScaleNumUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Column Width"
        '
        'ColumnWidthUpDown
        '
        Me.ColumnWidthUpDown.Location = New System.Drawing.Point(12, 12)
        Me.ColumnWidthUpDown.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.ColumnWidthUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ColumnWidthUpDown.Name = "ColumnWidthUpDown"
        Me.ColumnWidthUpDown.Size = New System.Drawing.Size(120, 20)
        Me.ColumnWidthUpDown.TabIndex = 1
        Me.ColumnWidthUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(321, 227)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 2
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(240, 227)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'HightScaleNumUpDown
        '
        Me.HightScaleNumUpDown.DecimalPlaces = 1
        Me.HightScaleNumUpDown.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.HightScaleNumUpDown.Location = New System.Drawing.Point(12, 38)
        Me.HightScaleNumUpDown.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.HightScaleNumUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.HightScaleNumUpDown.Name = "HightScaleNumUpDown"
        Me.HightScaleNumUpDown.Size = New System.Drawing.Size(120, 20)
        Me.HightScaleNumUpDown.TabIndex = 4
        Me.HightScaleNumUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hight Scale Number"
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 262)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.HightScaleNumUpDown)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.ColumnWidthUpDown)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ConfigForm"
        Me.Text = "Configuration"
        CType(Me.ColumnWidthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HightScaleNumUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnWidthUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents HightScaleNumUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
