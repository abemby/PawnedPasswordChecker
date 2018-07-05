<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fPPChecker
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
        Me.clbPasswordsToCheck = New System.Windows.Forms.CheckedListBox()
        Me.bLoad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbWebApi = New System.Windows.Forms.TextBox()
        Me.bVerify = New System.Windows.Forms.Button()
        Me.bClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFile = New System.Windows.Forms.TextBox()
        Me.bSelect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lStatus = New System.Windows.Forms.Label()
        Me.bStop = New System.Windows.Forms.Button()
        Me.bUnload = New System.Windows.Forms.Button()
        Me.bVerify2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'clbPasswordsToCheck
        '
        Me.clbPasswordsToCheck.Enabled = False
        Me.clbPasswordsToCheck.FormattingEnabled = True
        Me.clbPasswordsToCheck.Location = New System.Drawing.Point(12, 94)
        Me.clbPasswordsToCheck.Name = "clbPasswordsToCheck"
        Me.clbPasswordsToCheck.Size = New System.Drawing.Size(445, 424)
        Me.clbPasswordsToCheck.TabIndex = 0
        '
        'bLoad
        '
        Me.bLoad.Location = New System.Drawing.Point(152, 65)
        Me.bLoad.Name = "bLoad"
        Me.bLoad.Size = New System.Drawing.Size(52, 23)
        Me.bLoad.TabIndex = 1
        Me.bLoad.Text = "Load"
        Me.bLoad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Web API"
        '
        'tbWebApi
        '
        Me.tbWebApi.Location = New System.Drawing.Point(62, 39)
        Me.tbWebApi.Name = "tbWebApi"
        Me.tbWebApi.ReadOnly = True
        Me.tbWebApi.Size = New System.Drawing.Size(398, 20)
        Me.tbWebApi.TabIndex = 3
        Me.tbWebApi.Text = "https://api.pwnedpasswords.com/range/{0}"
        '
        'bVerify
        '
        Me.bVerify.Location = New System.Drawing.Point(303, 65)
        Me.bVerify.Name = "bVerify"
        Me.bVerify.Size = New System.Drawing.Size(52, 23)
        Me.bVerify.TabIndex = 4
        Me.bVerify.Text = "Verify"
        Me.bVerify.UseVisualStyleBackColor = True
        '
        'bClear
        '
        Me.bClear.Location = New System.Drawing.Point(256, 65)
        Me.bClear.Name = "bClear"
        Me.bClear.Size = New System.Drawing.Size(47, 23)
        Me.bClear.TabIndex = 5
        Me.bClear.Text = "Clear"
        Me.bClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "File"
        '
        'tbFile
        '
        Me.tbFile.Location = New System.Drawing.Point(62, 12)
        Me.tbFile.Name = "tbFile"
        Me.tbFile.Size = New System.Drawing.Size(366, 20)
        Me.tbFile.TabIndex = 7
        '
        'bSelect
        '
        Me.bSelect.Location = New System.Drawing.Point(436, 10)
        Me.bSelect.Name = "bSelect"
        Me.bSelect.Size = New System.Drawing.Size(24, 23)
        Me.bSelect.TabIndex = 8
        Me.bSelect.Text = "..."
        Me.bSelect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Are Password Pawned ?"
        '
        'lStatus
        '
        Me.lStatus.AutoSize = True
        Me.lStatus.Location = New System.Drawing.Point(12, 521)
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Size = New System.Drawing.Size(16, 13)
        Me.lStatus.TabIndex = 10
        Me.lStatus.Text = "..."
        '
        'bStop
        '
        Me.bStop.Enabled = False
        Me.bStop.Location = New System.Drawing.Point(407, 65)
        Me.bStop.Name = "bStop"
        Me.bStop.Size = New System.Drawing.Size(53, 23)
        Me.bStop.TabIndex = 11
        Me.bStop.Text = "Stop"
        Me.bStop.UseVisualStyleBackColor = True
        '
        'bUnload
        '
        Me.bUnload.Location = New System.Drawing.Point(204, 65)
        Me.bUnload.Name = "bUnload"
        Me.bUnload.Size = New System.Drawing.Size(52, 23)
        Me.bUnload.TabIndex = 2
        Me.bUnload.Text = "Unload"
        Me.bUnload.UseVisualStyleBackColor = True
        '
        'bVerify2
        '
        Me.bVerify2.Location = New System.Drawing.Point(355, 65)
        Me.bVerify2.Name = "bVerify2"
        Me.bVerify2.Size = New System.Drawing.Size(52, 23)
        Me.bVerify2.TabIndex = 12
        Me.bVerify2.Text = "Verify 2"
        Me.bVerify2.UseVisualStyleBackColor = True
        '
        'fPPChecker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(471, 541)
        Me.Controls.Add(Me.bVerify2)
        Me.Controls.Add(Me.bUnload)
        Me.Controls.Add(Me.bStop)
        Me.Controls.Add(Me.lStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bSelect)
        Me.Controls.Add(Me.tbFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bClear)
        Me.Controls.Add(Me.bVerify)
        Me.Controls.Add(Me.tbWebApi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bLoad)
        Me.Controls.Add(Me.clbPasswordsToCheck)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fPPChecker"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pawned Password Checker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents clbPasswordsToCheck As CheckedListBox
    Friend WithEvents bLoad As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tbWebApi As TextBox
    Friend WithEvents bVerify As Button
    Friend WithEvents bClear As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFile As TextBox
    Friend WithEvents bSelect As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lStatus As Label
    Friend WithEvents bStop As Button
    Friend WithEvents bUnload As Button
    Friend WithEvents bVerify2 As Button
End Class
