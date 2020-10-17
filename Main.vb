Imports System.IO
Imports System.Data.OleDb

Public Class Main
    Private Property CurrentFile As String

    Private Sub GetFilingData(ByVal pstrFileName As String)
        'test
        lstExcelTab.SuspendLayout()

        Try
            Using con As New OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pstrFileName}; Extended Properties=""Excel 12.0 Xml;HDR=YES;""")

                con.Open()

                Dim table As DataTable = con.GetSchema("Tables")

                For Each item As DataRow In table.Rows
                    lstExcelTab.Items.Add(item("Table_Name").ToString)
                Next

                con.Close()
            End Using

            lstExcelTab.Visible = True
        Catch ex As Exception
            lstExcelTab.Items.Clear()
            lstExcelTab.Visible = False
            dtDisplay.DataSource = Nothing
        End Try

        lstExcelTab.ResumeLayout()
    End Sub


    Private Sub lstExcelTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstExcelTab.SelectedIndexChanged
        DisplayFilingData(CurrentFile, lstExcelTab.Items(lstExcelTab.SelectedIndex))
    End Sub

    Private Sub DisplayFilingData(ByVal pstrFileName As String, ByVal subfile As String)

        Try
            dtDisplay.SuspendLayout()
            Using con As New OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pstrFileName}; Extended Properties=""Excel 12.0 Xml;HDR=Yes; IMEX=1""")
                con.Open()

                Dim adapter As New OleDbDataAdapter($"SELECT * FROM [{subfile}]", con)
                Dim ds As New DataSet()
                adapter.Fill(ds)

                dtDisplay.DataSource = ds.Tables(0)
                'dtDisplay.DataSource = ds.Tables(1)

                'If subfile.StartsWith("Statement of") Then
                '    Dim f As New Statement_of_Income("APPLE", "10-Q", subfile, Now, "AAPL")
                '    f


                'End If


                con.Close()
            End Using
            dtDisplay.Visible = True
        Catch ex As Exception
            dtDisplay.DataSource = Nothing
            dtDisplay.Visible = False
        End Try

        dtDisplay.ResumeLayout()
    End Sub


    Private Sub tsiFilings_Click(sender As Object, e As EventArgs) Handles tsiFilings.Click
        tmrFileExploreUpdate.Stop()
        Using CIK As New Filing
            CIK.ShowDialog()
            CIK.Dispose()
        End Using
        tmrFileExploreUpdate.Start()
    End Sub

    Private Sub tmrFilerBrowser_Tick(sender As Object, e As EventArgs) Handles tmrFileExploreUpdate.Tick
        Dim astrCompany As String() = Directory.GetDirectories(Filing.EdgarDataDirectory)
        For Each strCompanyDirectory As String In astrCompany
            Dim dirInfo As New DirectoryInfo(strCompanyDirectory)

            If Not treFileExplorer.Nodes.ContainsKey(strCompanyDirectory) Then
                treFileExplorer.Nodes.Add(strCompanyDirectory, dirInfo.Name)
            End If

            For Each files As FileInfo In dirInfo.EnumerateFiles
                Dim tmp As TreeNode = treFileExplorer.Nodes.Item(dirInfo.FullName)
                If (files.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden AndAlso
                    Not tmp.Nodes.ContainsKey(files.FullName) Then
                    tmp.Nodes.Add(files.FullName, files.Name)
                End If
            Next
        Next
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrFileExploreUpdate.Start()
    End Sub

    Private Sub treFileExplorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treFileExplorer.AfterSelect
        Select Case Path.GetExtension(Path.GetFileName(e.Node.Name))
            Case ".xls", ".xlsx"
                lstExcelTab.Items.Clear()
                My.Computer.Clipboard.SetText(e.Node.Name)
                treFileExplorer.Enabled = False
                CurrentFile = e.Node.Name
                GetFilingData(CurrentFile)
                treFileExplorer.Enabled = True
            Case Else
        End Select
    End Sub


End Class

Public Class SECFiling
    Public Property FilingType As String
    Public Property DocumentLink As String
    Public Property InteractiveDataLink As String
    Public Property Description As String
    Public Property FilingDate As Date
    Public Property FileNumber As String

End Class
