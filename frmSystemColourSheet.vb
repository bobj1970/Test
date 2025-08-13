Public Class frmSystemColourSheet

    Private Sub frmSystemColourSheet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetSystemColours()

        ugSystemColour.DataSource = ds

        ugSystemColour.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        ugSystemColour.DisplayLayout.Bands(0).Columns("ColorName").Width = 200
        ugSystemColour.DisplayLayout.Bands(0).Columns("Color").Width = 200

        Dim x As Integer
        For x = 0 To ugSystemColour.Rows.Count - 1
            ugSystemColour.Rows(x).Cells("Color").Appearance.BackColor = System.Drawing.Color.FromName(ugSystemColour.Rows(x).Cells("Color").Text)
            ugSystemColour.Rows(x).Cells("Color").Appearance.ForeColor = System.Drawing.Color.FromName(ugSystemColour.Rows(x).Cells("Color").Text)
        Next

        KPGeneral.SetDefaultGridSettings(ugSystemColour)

        ugSystemColour.ActiveRow = Nothing
        ugSystemColour.Selected.Rows.Clear()
    End Sub
End Class