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
        Me.pnlIcon = New System.Windows.Forms.Panel()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIcon.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(59, 22)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(88, 13)
        Me.lblCompany.TabIndex = 2
        Me.lblCompany.Text = "Company Symbol"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCompanyTicket
        '
        Me.txtCompanyTicket.Location = New System.Drawing.Point(153, 19)
        Me.txtCompanyTicket.Name = "txtCompanyTicket"
        Me.txtCompanyTicket.Size = New System.Drawing.Size(162, 20)
        Me.txtCompanyTicket.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(21, 61)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 22)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(192, 61)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(116, 22)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Company_Watch.My.Resources.Resources.Info
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'pnlIcon
        '
        Me.pnlIcon.Controls.Add(Me.PictureBox1)
        Me.pnlIcon.Location = New System.Drawing.Point(12, 7)
        Me.pnlIcon.Name = "pnlIcon"
        Me.pnlIcon.Size = New System.Drawing.Size(41, 40)
        Me.pnlIcon.TabIndex = 1
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlOptions.Controls.Add(Me.lblCompany)
        Me.pnlOptions.Controls.Add(Me.txtCompanyTicket)
        Me.pnlOptions.Controls.Add(Me.pnlIcon)
        Me.pnlOptions.Location = New System.Drawing.Point(0, 0)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(353, 55)
        Me.pnlOptions.TabIndex = 0
        '
        'Filing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 89)
        Me.Controls.Add(Me.pnlOptions)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.Name = "Filing"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Retrieve New Filings"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIcon.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCompany As Label
    Friend WithEvents txtCompanyTicket As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlIcon As Panel
    Friend WithEvents pnlOptions As Panel
End Class
