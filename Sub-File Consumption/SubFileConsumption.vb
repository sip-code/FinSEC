Public MustInherit Class SubFileConsumption
    Public ReadOnly Property Company As String
    Public ReadOnly Property Filing As String
    Public ReadOnly Property SubFile As String
    Public ReadOnly Property CIK As String
    Public ReadOnly Property FilingPeriod As Date
    Public MustOverride Sub DataProcessing()

    Protected Sub New(ByVal pstrCompany As String,
                      ByVal pstrFiling As String,
                      ByVal pstrSubFile As String,
                      ByVal pdtmFilingPeriod As Date,
                      ByVal pstrCIK As String)
        Company = pstrCompany
        Filing = pstrFiling
        SubFile = pstrSubFile
        FilingPeriod = pdtmFilingPeriod
        CIK = pstrCIK
    End Sub
End Class
