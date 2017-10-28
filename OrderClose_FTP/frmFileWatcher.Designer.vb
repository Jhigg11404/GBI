<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileWatcher
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
        Me.btnSend = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.lstAlarm = New System.Windows.Forms.ListBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.Green
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnSend.Location = New System.Drawing.Point(12, 500)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(116, 100)
        Me.btnSend.TabIndex = 213
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = false
        Me.btnSend.Visible = false
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 10000
        '
        'lstAlarm
        '
        Me.lstAlarm.Location = New System.Drawing.Point(12, 12)
        Me.lstAlarm.Name = "lstAlarm"
        Me.lstAlarm.Size = New System.Drawing.Size(776, 485)
        Me.lstAlarm.TabIndex = 214
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(317, 503)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(104, 97)
        Me.cmdClear.TabIndex = 215
        Me.cmdClear.Text = "Clear Messages"
        '
        'frmFileWatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 612)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.lstAlarm)
        Me.Controls.Add(Me.btnSend)
        Me.Name = "frmFileWatcher"
        Me.Text = "GBI - File Processor"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btnSend As Button
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents lstAlarm As ListBox
    Friend WithEvents cmdClear As Button
End Class
