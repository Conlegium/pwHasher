Imports System.Security.Cryptography
Imports System.Text

Public Class Form1

    Public Function MD5StringHash(ByVal strString As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Data As Byte()
        Dim Result As Byte()
        Dim Res As String = ""
        Dim Tmp As String = ""

        Data = Encoding.ASCII.GetBytes(strString)
        Result = MD5.ComputeHash(Data)
        For i As Integer = 0 To Result.Length - 1
            Tmp = Hex(Result(i))
            If Len(Tmp) = 1 Then Tmp = "0" & Tmp
            Res += Tmp
        Next
        Return Res
    End Function

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox2.Text = "Du musst erst Verschlüsseln"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.PasswordChar = "*"c
        Else
            TextBox1.PasswordChar = ControlChars.NullChar
        End If
    End Sub

    Private Sub TextBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        If CheckBox2.Checked Then
            TextBox2.SelectAll()
            Clipboard.SetText(TextBox2.Text)
        Else
            TextBox2.SelectAll()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            TextBox2.Text = "Du hast KEIN Passwort eingegeben"
        ElseIf CheckBox2.Checked Then
            TextBox2.Text = MD5StringHash(TextBox1.Text)
            Clipboard.SetText(TextBox2.Text)
            TextBox2.SelectAll()
        Else
            TextBox2.Text = MD5StringHash(TextBox1.Text)
        End If
    End Sub

End Class

