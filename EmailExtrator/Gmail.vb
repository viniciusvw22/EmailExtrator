Public Class Gmail
    Public Shared ReadOnly Aliases() As String = {"gmail"}
    Public Function extParteLocal(txtCol As String, posI As Integer, posA As Integer) As String
        'Regras: Somente letras, números e pontos são permitidos.
        'O primeiro caractere deve ser uma letra do tipo ascii (a-z) ou um número (0-9).
        'O último caractere deve ser uma letra do tipo ascii (a-z) ou um número (0-9).
        Dim i As Integer = posA - 1
        Dim ch As Char
        Dim chtras, chfrente As Char
        Dim ptLocal As String = ""
        While i >= 0
            ch = txtCol(i)
            If Char.IsLetterOrDigit(ch) OrElse ch = "." Then
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
