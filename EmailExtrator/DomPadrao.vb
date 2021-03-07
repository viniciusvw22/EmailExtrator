Public Class DomPadrao
    Public Shared ReadOnly Aliases() As String = {}
    Private printblChars As String = "!#$%&'*+-/=?^_`{|}~"
    Public Function extParteLocal(txtCol As String, posI As Integer, posA As Integer) As String
        'If unquoted Then, it may use any Of these ASCII character:
        'uppercase And lowercase Latin letters A to Z And a to z
        'digits 0 to 9
        'printable characters !#$%&'*+-/=?^_`{|}~
        'dot., provided that it Is Not the first Or last character And provided also that it does 
        'Not appear consecutively (e.g., John..Doe@example.com Is Not allowed).
        Dim i As Integer = posA - 1
        Dim ch As Char
        Dim chtras, chfrente As Char
        Dim ptLocal As String = ""
        While i >= 0
            ch = txtCol(i)
            If Char.IsLetterOrDigit(ch) OrElse ch = "." OrElse printblChars.Contains(ch) Then
                chfrente = txtCol(i + 1)
                chtras = txtCol.ElementAtOrDefault(i - 1)
                'Parando quando encontrar pontos duplos, ou pontos no final.
                'exemplo..com..pontosduplos@gmail.com -> pontosduplos@gmail.com
                'exemplo.com.pontos.no.final.@gmail.com -> @gmail.com
                If ch = "." AndAlso (chfrente = "@" OrElse chtras = ".") Then
                    Exit While
                Else
                    i -= 1
                End If
            Else
                Exit While
            End If
        End While
        'Deslocando +1 posição para copiar apenas a parte válida.
        i += 1
        ptLocal = txtCol.Substring(i, posA - i)
        Return ptLocal
    End Function
End Class
