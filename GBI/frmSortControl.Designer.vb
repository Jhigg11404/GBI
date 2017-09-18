<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSortControl
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbHMI = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblWaveNbr = New System.Windows.Forms.Label()
        Me.txtWaveNmbr = New System.Windows.Forms.TextBox()
        Me.dgvHMI = New System.Windows.Forms.DataGridView()
        Me.lblWavelist = New System.Windows.Forms.Label()
        Me.lstWaves = New System.Windows.Forms.ListBox()
        Me.tbCarriers = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvCarriers = New System.Windows.Forms.DataGridView()
        Me.tbDrops = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDrops = New System.Windows.Forms.DataGridView()
        Me.tbShortages = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvShortages = New System.Windows.Forms.DataGridView()
        Me.tbLogs = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMessages = New System.Windows.Forms.DataGridView()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.tbHMI.SuspendLayout()
        CType(Me.dgvHMI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCarriers.SuspendLayout()
        CType(Me.dgvCarriers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDrops.SuspendLayout()
        CType(Me.dgvDrops, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbShortages.SuspendLayout()
        CType(Me.dgvShortages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbLogs.SuspendLayout()
        CType(Me.dgvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbHMI)
        Me.TabControl1.Controls.Add(Me.tbCarriers)
        Me.TabControl1.Controls.Add(Me.tbDrops)
        Me.TabControl1.Controls.Add(Me.tbShortages)
        Me.TabControl1.Controls.Add(Me.tbLogs)
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1204, 454)
        Me.TabControl1.TabIndex = 0
        '
        'tbHMI
        '
        Me.tbHMI.Controls.Add(Me.Label4)
        Me.tbHMI.Controls.Add(Me.TextBox4)
        Me.tbHMI.Controls.Add(Me.Label3)
        Me.tbHMI.Controls.Add(Me.Button3)
        Me.tbHMI.Controls.Add(Me.Button1)
        Me.tbHMI.Controls.Add(Me.TextBox3)
        Me.tbHMI.Controls.Add(Me.Button2)
        Me.tbHMI.Controls.Add(Me.Label2)
        Me.tbHMI.Controls.Add(Me.TextBox2)
        Me.tbHMI.Controls.Add(Me.lblOrders)
        Me.tbHMI.Controls.Add(Me.TextBox1)
        Me.tbHMI.Controls.Add(Me.lblWaveNbr)
        Me.tbHMI.Controls.Add(Me.txtWaveNmbr)
        Me.tbHMI.Controls.Add(Me.dgvHMI)
        Me.tbHMI.Controls.Add(Me.lblWavelist)
        Me.tbHMI.Controls.Add(Me.lstWaves)
        Me.tbHMI.Location = New System.Drawing.Point(4, 22)
        Me.tbHMI.Name = "tbHMI"
        Me.tbHMI.Padding = New System.Windows.Forms.Padding(3)
        Me.tbHMI.Size = New System.Drawing.Size(1196, 428)
        Me.tbHMI.TabIndex = 0
        Me.tbHMI.Text = "HMI"
        Me.tbHMI.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(498, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 226
        Me.Label4.Text = "Units Filled:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(497, 66)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 225
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(390, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Units Required:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button3.Location = New System.Drawing.Point(9, 306)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 37)
        Me.Button3.TabIndex = 215
        Me.Button3.Text = "Abort Wave"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button1.Location = New System.Drawing.Point(9, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 37)
        Me.Button1.TabIndex = 213
        Me.Button1.Text = "Activate Wave"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(391, 66)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 223
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button2.Location = New System.Drawing.Point(9, 263)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 37)
        Me.Button2.TabIndex = 214
        Me.Button2.Text = "Close Wave"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(284, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "Destinations:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(285, 66)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 221
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Location = New System.Drawing.Point(178, 50)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(41, 13)
        Me.lblOrders.TabIndex = 220
        Me.lblOrders.Text = "Orders:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(179, 66)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 219
        '
        'lblWaveNbr
        '
        Me.lblWaveNbr.AutoSize = True
        Me.lblWaveNbr.Location = New System.Drawing.Point(176, 10)
        Me.lblWaveNbr.Name = "lblWaveNbr"
        Me.lblWaveNbr.Size = New System.Drawing.Size(79, 13)
        Me.lblWaveNbr.TabIndex = 218
        Me.lblWaveNbr.Text = "Wave Number:"
        '
        'txtWaveNmbr
        '
        Me.txtWaveNmbr.Location = New System.Drawing.Point(177, 26)
        Me.txtWaveNmbr.Name = "txtWaveNmbr"
        Me.txtWaveNmbr.Size = New System.Drawing.Size(100, 20)
        Me.txtWaveNmbr.TabIndex = 217
        '
        'dgvHMI
        '
        Me.dgvHMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHMI.Location = New System.Drawing.Point(179, 92)
        Me.dgvHMI.Name = "dgvHMI"
        Me.dgvHMI.Size = New System.Drawing.Size(982, 296)
        Me.dgvHMI.TabIndex = 216
        '
        'lblWavelist
        '
        Me.lblWavelist.AutoSize = True
        Me.lblWavelist.Location = New System.Drawing.Point(6, 10)
        Me.lblWavelist.Name = "lblWavelist"
        Me.lblWavelist.Size = New System.Drawing.Size(90, 13)
        Me.lblWavelist.TabIndex = 1
        Me.lblWavelist.Text = "Available Waves:"
        '
        'lstWaves
        '
        Me.lstWaves.FormattingEnabled = True
        Me.lstWaves.Location = New System.Drawing.Point(9, 26)
        Me.lstWaves.Name = "lstWaves"
        Me.lstWaves.Size = New System.Drawing.Size(120, 173)
        Me.lstWaves.TabIndex = 0
        '
        'tbCarriers
        '
        Me.tbCarriers.Controls.Add(Me.Label7)
        Me.tbCarriers.Controls.Add(Me.dgvCarriers)
        Me.tbCarriers.Location = New System.Drawing.Point(4, 22)
        Me.tbCarriers.Name = "tbCarriers"
        Me.tbCarriers.Padding = New System.Windows.Forms.Padding(3)
        Me.tbCarriers.Size = New System.Drawing.Size(1196, 428)
        Me.tbCarriers.TabIndex = 1
        Me.tbCarriers.Text = "Carriers"
        Me.tbCarriers.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 25)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Carriers:"
        '
        'dgvCarriers
        '
        Me.dgvCarriers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCarriers.Location = New System.Drawing.Point(39, 45)
        Me.dgvCarriers.Name = "dgvCarriers"
        Me.dgvCarriers.Size = New System.Drawing.Size(1122, 340)
        Me.dgvCarriers.TabIndex = 2
        '
        'tbDrops
        '
        Me.tbDrops.Controls.Add(Me.Label6)
        Me.tbDrops.Controls.Add(Me.dgvDrops)
        Me.tbDrops.Location = New System.Drawing.Point(4, 22)
        Me.tbDrops.Name = "tbDrops"
        Me.tbDrops.Size = New System.Drawing.Size(1196, 428)
        Me.tbDrops.TabIndex = 2
        Me.tbDrops.Text = "Drops"
        Me.tbDrops.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 25)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Drops:"
        '
        'dgvDrops
        '
        Me.dgvDrops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDrops.Location = New System.Drawing.Point(39, 46)
        Me.dgvDrops.Name = "dgvDrops"
        Me.dgvDrops.Size = New System.Drawing.Size(1122, 340)
        Me.dgvDrops.TabIndex = 2
        '
        'tbShortages
        '
        Me.tbShortages.Controls.Add(Me.Button4)
        Me.tbShortages.Controls.Add(Me.Label5)
        Me.tbShortages.Controls.Add(Me.dgvShortages)
        Me.tbShortages.Location = New System.Drawing.Point(4, 22)
        Me.tbShortages.Name = "tbShortages"
        Me.tbShortages.Size = New System.Drawing.Size(1196, 428)
        Me.tbShortages.TabIndex = 3
        Me.tbShortages.Text = "Shortages"
        Me.tbShortages.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button4.Location = New System.Drawing.Point(1045, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(116, 37)
        Me.Button4.TabIndex = 213
        Me.Button4.Text = "Submit Repick"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Shortages:"
        '
        'dgvShortages
        '
        Me.dgvShortages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShortages.Location = New System.Drawing.Point(39, 46)
        Me.dgvShortages.Name = "dgvShortages"
        Me.dgvShortages.Size = New System.Drawing.Size(1122, 340)
        Me.dgvShortages.TabIndex = 0
        '
        'tbLogs
        '
        Me.tbLogs.Controls.Add(Me.Label1)
        Me.tbLogs.Controls.Add(Me.dgvMessages)
        Me.tbLogs.Location = New System.Drawing.Point(4, 22)
        Me.tbLogs.Name = "tbLogs"
        Me.tbLogs.Size = New System.Drawing.Size(1196, 428)
        Me.tbLogs.TabIndex = 4
        Me.tbLogs.Text = "Logs"
        Me.tbLogs.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GBI Log:"
        '
        'dgvMessages
        '
        Me.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMessages.Location = New System.Drawing.Point(37, 39)
        Me.dgvMessages.Name = "dgvMessages"
        Me.dgvMessages.Size = New System.Drawing.Size(1109, 371)
        Me.dgvMessages.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Gold
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Maroon
        Me.btnExit.Location = New System.Drawing.Point(1049, 484)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(116, 100)
        Me.btnExit.TabIndex = 213
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Green
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnRefresh.Location = New System.Drawing.Point(927, 484)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(116, 100)
        Me.btnRefresh.TabIndex = 212
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dgvLog
        '
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Location = New System.Drawing.Point(60, 476)
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.Size = New System.Drawing.Size(761, 112)
        Me.dgvLog.TabIndex = 217
        '
        'frmSortControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 608)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmSortControl"
        Me.Text = "frmSortControl"
        Me.TabControl1.ResumeLayout(False)
        Me.tbHMI.ResumeLayout(False)
        Me.tbHMI.PerformLayout()
        CType(Me.dgvHMI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCarriers.ResumeLayout(False)
        Me.tbCarriers.PerformLayout()
        CType(Me.dgvCarriers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDrops.ResumeLayout(False)
        Me.tbDrops.PerformLayout()
        CType(Me.dgvDrops, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbShortages.ResumeLayout(False)
        Me.tbShortages.PerformLayout()
        CType(Me.dgvShortages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbLogs.ResumeLayout(False)
        Me.tbLogs.PerformLayout()
        CType(Me.dgvMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbHMI As TabPage
    Friend WithEvents tbCarriers As TabPage
    Friend WithEvents tbDrops As TabPage
    Friend WithEvents tbShortages As TabPage
    Friend WithEvents tbLogs As TabPage
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents lblOrders As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblWaveNbr As Label
    Friend WithEvents txtWaveNmbr As TextBox
    Friend WithEvents dgvHMI As DataGridView
    Friend WithEvents lblWavelist As Label
    Friend WithEvents lstWaves As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dgvCarriers As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvDrops As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvShortages As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvMessages As DataGridView
    Friend WithEvents dgvLog As DataGridView
End Class
