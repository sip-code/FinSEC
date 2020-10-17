<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filing
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
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.txtCompanyTicket = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.pnlIcon = New System.Windows.Forms.Panel()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMenu.SuspendLayout()
        Me.pnlIcon.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(3, 12)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(71, 13)
        Me.lblCompany.TabIndex = 3
        Me.lblCompany.Text = "Company TIC"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCompanyTicket
        '
        Me.txtCompanyTicket.Location = New System.Drawing.Point(80, 9)
        Me.txtCompanyTicket.Name = "txtCompanyTicket"
        Me.txtCompanyTicket.Size = New System.Drawing.Size(179, 20)
        Me.txtCompanyTicket.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(16, 35)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 22)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(138, 35)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(116, 22)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Company_Watch.My.Resources.Resources.Info
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProgress.Location = New System.Drawing.Point(0, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblProgress.TabIndex = 6
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.btnOk)
        Me.pnlMenu.Controls.Add(Me.btnCancel)
        Me.pnlMenu.Controls.Add(Me.lblCompany)
        Me.pnlMenu.Controls.Add(Me.txtCompanyTicket)
        Me.pnlMenu.Location = New System.Drawing.Point(66, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(265, 60)
        Me.pnlMenu.TabIndex = 0
        '
        'pnlIcon
        '
        Me.pnlIcon.Controls.Add(Me.PictureBox1)
        Me.pnlIcon.Location = New System.Drawing.Point(0, 0)
        Me.pnlIcon.Name = "pnlIcon"
        Me.pnlIcon.Size = New System.Drawing.Size(60, 60)
        Me.pnlIcon.TabIndex = 1
        '
        'pnlStatus
        '
        Me.pnlStatus.Controls.Add(Me.lblProgress)
        Me.pnlStatus.Location = New System.Drawing.Point(0, 66)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(331, 20)
        Me.pnlStatus.TabIndex = 2
        '
        'Filing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 61)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlIcon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "Filing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Retrieve New Filings"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.pnlIcon.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCompany As Label
    Friend WithEvents txtCompanyTicket As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblProgress As Label
    Friend WithEvents pnlIcon As Panel
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents pnlStatus As Panel
End Class
