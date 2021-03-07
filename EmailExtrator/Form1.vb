Public Class Form1
    Private Sub btnExt_Click(sender As Object, e As EventArgs) Handles btnExt.Click
        Dim extMail As New ExtEmails(txtCol.Text)
        txtExt.Text = extMail.getEmails()
    End Sub
End Class
