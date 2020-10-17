<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtDisplay = New System.Windows.Forms.DataGridView()
        Me.tbMain = New System.Windows.Forms.TableLayoutPanel()
        Me.treFileExplorer = New System.Windows.Forms.TreeView()
        Me.lstExcelTab = New System.Windows.Forms.ListBox()
        Me.tsMenu = New System.Windows.Forms.MenuStrip()
        Me.tsiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiFilings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrFileExploreUpdate = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dtDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtDisplay
        '
        Me.dtDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtDisplay.Location = New System.Drawing.Point(428, 3)
        Me.dtDisplay.Name = "dtDisplay"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtDisplay.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtDisplay.Size = New System.Drawing.Size(655, 740)
        Me.dtDisplay.TabIndex = 3
        Me.dtDisplay.Visible = False
        '
        'tbMain
        '
        Me.tbMain.ColumnCount = 3
        Me.tbMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.29834!))
        Me.tbMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.02026!))
        Me.tbMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.77348!))
        Me.tbMain.Controls.Add(Me.treFileExplorer, 0, 0)
        Me.tbMain.Controls.Add(Me.dtDisplay, 2, 0)
        Me.tbMain.Controls.Add(Me.lstExcelTab, 1, 0)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 24)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.RowCount = 1
        Me.tbMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tbMain.Size = New System.Drawing.Size(1086, 746)
        Me.tbMain.TabIndex = 4
        '
        'treFileExplorer
        '
        Me.treFileExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treFileExplorer.Location = New System.Drawing.Point(3, 3)
        Me.treFileExplorer.Name = "treFileExplorer"
        Me.treFileExplorer.Size = New System.Drawing.Size(170, 740)
        Me.treFileExplorer.TabIndex = 4
        '
        'lstExcelTab
        '
        Me.lstExcelTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstExcelTab.FormattingEnabled = True
        Me.lstExcelTab.Location = New System.Drawing.Point(179, 3)
        Me.lstExcelTab.Name = "lstExcelTab"
        Me.lstExcelTab.Size = New System.Drawing.Size(243, 740)
        Me.lstExcelTab.TabIndex = 5
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiNew})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1086, 24)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.Text = "MenuStrip1"
        '
        'tsiNew
        '
        Me.tsiNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiFilings})
        Me.tsiNew.Name = "tsiNew"
        Me.tsiNew.Size = New System.Drawing.Size(37, 20)
        Me.tsiNew.Text = "&File"
        '
        'tsiFilings
        '
        Me.tsiFilings.Name = "tsiFilings"
        Me.tsiFilings.Size = New System.Drawing.Size(199, 22)
        Me.tsiFilings.Text = "&New Company Monitor"
        '
        'tmrFileExploreUpdate
        '
        Me.tmrFileExploreUpdate.Interval = 1000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 770)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.tsMenu)
        Me.MainMenuStrip = Me.tsMenu
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.Text = "Market Watch"
        CType(Me.dtDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtDisplay As DataGridView
    Friend WithEvents tbMain As TableLayoutPanel
    Friend WithEvents treFileExplorer As TreeView
    Friend WithEvents tsMenu As MenuStrip
    Friend WithEvents tsiNew As ToolStripMenuItem
    Friend WithEvents tsiFilings As ToolStripMenuItem
    Friend WithEvents tmrFileExploreUpdate As Timer
    Friend WithEvents lstExcelTab As ListBox
End Class
