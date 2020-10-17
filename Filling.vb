Imports System.IO
Imports System.Web
Imports System.Text.RegularExpressions
Imports System.Net.Http

Public Class Filing
    Private cbgData As New Concurrent.ConcurrentBag(Of SECFiling)
    Friend Shared ReadOnly Property EdgarDataDirectory As String
        Get
            Dim strTempDirectory As String = Path.Combine(FileIO.SpecialDirectories.Desktop, "SEC Data")
            If Not Directory.Exists(strTempDirectory) Then Directory.CreateDirectory(strTempDirectory)
            Return strTempDirectory
        End Get
    End Property

    Private ReadOnly Property CompanyDataDirectory As String
        Get
            Dim strCompanyTicket As String = txtCompanyTicket.Text
            If String.IsNullOrEmpty(strCompanyTicket) Then Return ""
            Return Path.Combine(EdgarDataDirectory, strCompanyTicket)
        End Get
    End Property
    Private mrgxFileTable As New Regex("<table class=""tableFile2""(?:[\s|\S](?!table))*\/table>", RegexOptions.Compiled)
    Private mrgxFileRow As New Regex("(?<!""Results"">\s*)(?<!<tbody>\s*)<tr([\s|\S](?!tr>))*\/tr>", RegexOptions.Compiled)
    Private mrgxTableRow As New Regex("<tr>", RegexOptions.Compiled)
    Private mrgxFileCell As New Regex("<td(?:[\s|\S](?!<\/td>))*.<\/td>", RegexOptions.Compiled)
    Private mrgxValueType As New Regex("(?<=>)[^<]*(?=<)", RegexOptions.Compiled)
    Private mrgxInteractiveLinks As New Regex("(?<=<a href="")[^""]*(?=""\s*id=""interactiveDataBtn"">(?:&nbsp;)?Interactive Data<\/a>)", RegexOptions.Compiled)
    Private mrgxFinData As New Regex("(?<=<a class=""xbrlviewer"" href="")[^""]*(?="">View Excel Document<\/a>)", RegexOptions.Compiled)
    Private mrgxCentralIndexKey As New Regex("(?<=CIK=)\d*", RegexOptions.Compiled)

    Private Async Sub txtCompanyTicket_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCompanyTicket.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim strTicket As String = txtCompanyTicket.Text
            If String.IsNullOrEmpty(strTicket) Then
                MsgBox("You must provide a valid CIK")
            Else
                If Not Directory.Exists(CompanyDataDirectory) Then Directory.CreateDirectory(CompanyDataDirectory)
                Debug.Print(Threading.Thread.CurrentThread.ManagedThreadId)
                DialogResult = DialogResult.OK
                Close()

                Await GetFilingAsync(CompanyDataDirectory).ConfigureAwait(False)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            DialogResult = DialogResult.Cancel
            Close()
        End If
    End Sub

    Private Async Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If String.IsNullOrEmpty(CompanyDataDirectory) Then
            MsgBox("You must provide a valid CIK")
        Else
            If Not Directory.Exists(CompanyDataDirectory) Then Directory.CreateDirectory(CompanyDataDirectory)
            Await GetFilingAsync(CompanyDataDirectory)
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Async Function GetFilingAsync(ByVal pstrCompanyDataDirectory As String) As Task

        Dim strCIK As String = Path.GetFileName(pstrCompanyDataDirectory) 'Get Central Index Key

        Dim qi As Specialized.NameValueCollection = HttpUtility.ParseQueryString(String.Empty)
        qi.Add("CIK", strCIK)

        Dim hcInitialSearch As New HttpClient()

        Dim hcrIntialSearchResponse As HttpResponseMessage = Await hcInitialSearch.GetAsync("https://www.sec.gov/cgi-bin/browse-edgar?" & qi.ToString)
        If Not hcrIntialSearchResponse.IsSuccessStatusCode Then Exit Function
        Dim hcrInitialSearchResponseHTML As String = Await hcrIntialSearchResponse.Content.ReadAsStringAsync
        Dim rgmCIK As Match = mrgxCentralIndexKey.Match(hcrInitialSearchResponseHTML)
        If Not rgmCIK.Success Then Exit Function


        Dim strArchiveFiles As String = "https://www.sec.gov/Archives/edgar/data/" & rgmCIK.Value
        hcrIntialSearchResponse = Await hcInitialSearch.GetAsync(strArchiveFiles)
        If Not hcrIntialSearchResponse.IsSuccessStatusCode Then Exit Function
        hcrInitialSearchResponseHTML = Await hcrIntialSearchResponse.Content.ReadAsStringAsync

        Dim lngFiles As Int64 = Math.Ceiling(mrgxTableRow.Matches(hcrInitialSearchResponseHTML).Count / 100)

        Dim lstTask As New List(Of Task)

        For i As Int32 = 0 To lngFiles + 1
            Dim q As Specialized.NameValueCollection = HttpUtility.ParseQueryString(String.Empty)
            q.Add("action", "getcompany")
            q.Add("CIK", strCIK)
            q.Add("start", i * 100)
            q.Add("count", 100)

            lstTask.Add(Task.Run(Function() GetInteractiveLinks(q.ToString)))
        Next

        Await Task.WhenAll(lstTask).ConfigureAwait(False)
        lstTask.Clear()
        Dim SECFiling As IEnumerable(Of SECFiling) = From tmp In cbgData
                                                     Where tmp.InteractiveDataLink <> "" 'AndAlso {"10-Q", "10-K"}.Contains(tmp.FilingType)

        For Each item As SECFiling In SECFiling
            Dim strDownload As String = Path.Combine(pstrCompanyDataDirectory,
                                         String.Format("{0}_{1}",
                                                       item.FilingDate.ToString("yyMMdd"),
                                                       item.FilingType.Replace("-", "")))

            lstTask.Add(Task.Run(Function() DownloadFinancialReportAsync(item.InteractiveDataLink, strDownload)))
        Next

        Await Task.WhenAll(lstTask).ConfigureAwait(False)



    End Function

    Private Async Function GetInteractiveLinks(ByVal pstrQueryString As String) As Task

        Dim hClient As New HttpClient()
        Dim hcResponse As HttpResponseMessage = Await hClient.GetAsync("https://www.sec.gov/cgi-bin/browse-edgar?" & pstrQueryString).ConfigureAwait(False)

        If Not hcResponse.IsSuccessStatusCode Then Exit Function

        Dim htmlBody As String = Await hcResponse.Content.ReadAsStringAsync.ConfigureAwait(False)

        Dim rgmFileTable As Match = mrgxFileTable.Match(htmlBody)
        If Not rgmFileTable.Success Then Exit Function

        Dim argmFileRow As MatchCollection = mrgxFileRow.Matches(rgmFileTable.Value)

        For Each rowFile As Match In argmFileRow
            Dim argmCell As MatchCollection = mrgxFileCell.Matches(rowFile.Value)


            Dim strFilingType As String = mrgxValueType.Match(argmCell(0).Value).Value
            Dim strInteractiveLink As String = mrgxInteractiveLinks.Match(argmCell(1).Value).Value
            Dim strDescription As String = mrgxValueType.Match(argmCell(2).Value).Value
            Dim strFilingDate As Date = CType(mrgxValueType.Match(argmCell(3).Value).Value, Date)
            Dim strFileNumber As String = mrgxValueType.Match(argmCell(4).Value).Value


            cbgData.Add(New SECFiling() With {.FilingType = strFilingType,
                                              .DocumentLink = "",'hteDataUrl(0).GetAttribute("href"),
                                              .InteractiveDataLink = strInteractiveLink, 'If(hteDataUrl.Count > 1,                '   hteDataUrl(1).GetAttribute("href"),                '   ""),
                                              .Description = strDescription,'hteTableRowData(2).InnerText,
                                              .FilingDate = strFilingDate,'CType(hteTableRowData(3).InnerText, Date),
                                              .FileNumber = strFileNumber}) 'hteTableRowData(4).InnerText})
        Next
    End Function

    Private Async Function DownloadFinancialReportAsync(ByVal pstrUrl As String, ByVal pstrSave As String) As Task

        Dim hClient As New HttpClient()

        Dim hcResponse As HttpResponseMessage = Await hClient.GetAsync("https://www.sec.gov/" & pstrUrl).ConfigureAwait(False)
        If hcResponse.IsSuccessStatusCode Then
            Dim htmlBody As String = Await hcResponse.Content.ReadAsStringAsync.ConfigureAwait(False)
            Dim rgmFinFile As Match = mrgxFinData.Match(htmlBody)
            If Not rgmFinFile.Success Then Exit Function

            Dim sr As Stream = Await hClient.GetStreamAsync("https://www.sec.gov/" & rgmFinFile.Value).ConfigureAwait(False)
            Using f As FileStream = New FileStream(pstrSave & Path.GetExtension(rgmFinFile.Value), FileMode.Create, FileAccess.Write)
                Await sr.CopyToAsync(f).ConfigureAwait(False)
            End Using
        End If

    End Function

End Class