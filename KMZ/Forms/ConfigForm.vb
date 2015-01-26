Public Class ConfigForm
    Dim aControler As ConfigControl
    Dim aMainController As MainController

    Sub New(ByRef MainController As MainController)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        aControler = New ConfigControl(Me)
        aControler.LoadFormValues()
        aMainController = MainController
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Me.aControler.SaveConfig()
        Me.Close()
        aMainController.ConfigLoad()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
        aMainController.ConfigLoad()
    End Sub

End Class