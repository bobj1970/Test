
Public Class frmPantryDelayPopup
    Public Shared CSID As Integer

    Private Sub btnCustom_Click(sender As Object, e As EventArgs) Handles btnCustom.Click
        SetDelay(1)
    End Sub
    Private Sub btnFinishing_Click(sender As Object, e As EventArgs) Handles btnFinishing.Click
        SetDelay(2)
    End Sub
    Private Sub btnHardware_Click(sender As Object, e As EventArgs) Handles btnHardware.Click
        SetDelay(3)
    End Sub
    Private Sub btnPanelProcessing_Click(sender As Object, e As EventArgs) Handles btnPanelProcessing.Click
        SetDelay(4)
    End Sub
    Private Sub SetDelay(ByVal DelayID As Integer)
        KPGeneral.WebRef_Local.usp_SetPantryDelayDueToParts(CSID, DelayID)
        Me.Close()
    End Sub
End Class