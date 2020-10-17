Public Class Statement_of_Income
    Inherits SubFileConsumption
    Public Sub New(ByVal pstrCompany As String,
               ByVal pstrFiling As String,
               ByVal pstrSubFile As String,
               ByVal pdtmFilingPeriod As Date,
               ByVal pstrCIK As String)
        MyBase.New(pstrCompany,
                   pstrFiling,
                   pstrSubFile,
                   pdtmFilingPeriod,
                   pstrCIK)
    End Sub


    Public Property MonetaryScale

    Public Overrides Sub DataProcessing()
        Throw New NotImplementedException()
    End Sub



End Class
