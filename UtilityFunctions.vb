Imports System.Runtime.CompilerServices

Module UtilityFunctions
    <Extension()>
    Public Function [Class](ByVal phte As HtmlElement) As String
        Return phte.GetAttribute("className")
    End Function

    <Extension()>
    Public Function Type(ByVal phte As HtmlElement) As String
        Return phte.GetAttribute("type")
    End Function
    <Extension()>
    Public Function Value(ByVal phte As HtmlElement) As String
        Return phte.GetAttribute("value")
    End Function

    <Extension()>
    Public Function Ref(ByVal phte As HtmlElement) As String
        Return phte.GetAttribute("href")
    End Function


    <Extension()>
    Public Sub NavigateAsync(ByVal pwb As WebBrowser, ByVal pobjUri As Object)
        If pobjUri.GetType Is GetType(Uri) Then
            pwb.Navigate(CType(pobjUri, Uri))
        ElseIf pobjUri.GetType Is GetType(String) Then
            pwb.Navigate(CType(pobjUri, String))
        Else
            Throw New Exception("Invalid uri type")
        End If

        While pwb.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        End While
    End Sub
End Module
