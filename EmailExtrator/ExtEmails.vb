Public Class ExtEmails
    Public Shared ReadOnly tldGen() As String = {".com", ".org", ".gouv"}
    Public Shared ReadOnly tldPais() As String = {".br", ".fr"}

    Private lstDom() As String = {"google", "hotmail", "yahoo"}
    Private txtCol As String
    Private emails As String

    Sub New(txtCol As String)
        Me.txtCol = txtCol
        Dim nomeDom As String
        Dim pDom As Integer = 1
        Dim posTldg, posTldp As Integer
        Dim tldg, tldp, ptLocal As String
        Dim posBusca As Integer = 0
        Dim posA As Integer = 0
        Dim gmailObj As New Gmail()
        Dim domPadrao As New DomPadrao()

        While True
            'Encontrando o @ do email.
            posA = txtCol.IndexOf("@", posA)
            If posA = -1 Then
                Exit While
            End If
            nomeDom = extDom(posA)
            'Extraindo Top Level Domain Genérico, como ".com/.org/etc"
            posTldg = (posA + 1) + nomeDom.Length
            tldg = extrairTld(posTldg, tldGen)

            'Extraindo Top Level Domain de País, como ".br/.us/.sp/etc"
            posTldp = posTldg + tldg.Length
            tldp = extrairTld(posTldp, tldPais)

            'Extraindo parte local (cada servidor de domínio tem uma regra de extração).
            Dim nomeDomMin As String = nomeDom.ToLower()
            If nomeDomMin = "gmail" Then
                ptLocal = gmailObj.extParteLocal(txtCol, posBusca, posA)
            Else
                ptLocal = domPadrao.extParteLocal(txtCol, posBusca, posA)
            End If

            emails += ptLocal + "@" + nomeDom + tldg + tldp + vbCrLf
            posA += 1
        End While
    End Sub

    Public Function getEmails() As String
        Return emails
    End Function

    'Extraindo o domínio a partir da posição de @.
    Private Function extDom(posA As Integer) As String
        'Regras (wikipedia):
        '1) uppercase and lowercase Latin letters A to
        '  Z And a to z;
        '2) digits 0 to 9, provided that top-level domain 
        '  names are Not all - numeric;
        '3) hyphen -, provided that it is not the first 
        '  Or last character.
        Dim nomeDom As String = ""
        Dim ch As Char
        Dim cntDg As Integer
        'Extraindo nome do Dómínio.
        For i As Integer = posA + 1 To txtCol.Length - 1
            ch = txtCol(i)
            If Char.IsLetterOrDigit(ch) Or ch = "-"c Then
                nomeDom += ch
            Else
                Exit For
            End If
        Next
        'Validando.
        cntDg = nomeDom.Count(Function(x) Char.IsDigit(x))
        If (nomeDom.StartsWith("-") Or nomeDom.EndsWith("-")) Then
            nomeDom = ""
        ElseIf cntDg = nomeDom.Length Then
            nomeDom = ""
        End If
        Return nomeDom
    End Function
    Private Function extrairTld(pTld As Integer, lstTld() As String) As String
        Dim tldExt As String = ""
        Dim corteTxtCol As String = txtCol.Substring(pTld)

        'Validando.
        For Each tld As String In lstTld
            'Verificando se o tld (top level domain) em texto colado existe. Se existir, ..
            '.. irá extraí - lo.
            If corteTxtCol.StartsWith(tld) Then
                tldExt = tld
            End If
        Next
        Return tldExt
    End Function

End Class
