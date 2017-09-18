<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.btnRepack = New System.Windows.Forms.Button()
        Me.btnManual = New System.Windows.Forms.Button()
        Me.gbProfile = New System.Windows.Forms.GroupBox()
        Me.lblUserLvl = New System.Windows.Forms.Label()
        Me.lblComputerType = New System.Windows.Forms.Label()
        Me.lblAppVersion = New System.Windows.Forms.Label()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.lblUserProf = New System.Windows.Forms.Label()
        Me.lblComputerName = New System.Windows.Forms.Label()
        Me.lblAppMode = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.gbDiag = New System.Windows.Forms.GroupBox()
        Me.rbLiveMode = New System.Windows.Forms.RadioButton()
        Me.rbTestMode = New System.Windows.Forms.RadioButton()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPacker = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Menu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_File_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbProfile.SuspendLayout()
        Me.gbDiag.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReprint
        '
        Me.btnReprint.BackColor = System.Drawing.Color.Green
        Me.btnReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnReprint.Location = New System.Drawing.Point(709, 37)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(116, 100)
        Me.btnReprint.TabIndex = 217
        Me.btnReprint.Text = "Logs"
        Me.btnReprint.UseVisualStyleBackColor = False
        '
        'btnRepack
        '
        Me.btnRepack.BackColor = System.Drawing.Color.Green
        Me.btnRepack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepack.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnRepack.Location = New System.Drawing.Point(577, 37)
        Me.btnRepack.Name = "btnRepack"
        Me.btnRepack.Size = New System.Drawing.Size(116, 100)
        Me.btnRepack.TabIndex = 216
        Me.btnRepack.Text = "Reporting"
        Me.btnRepack.UseVisualStyleBackColor = False
        '
        'btnManual
        '
        Me.btnManual.BackColor = System.Drawing.Color.Green
        Me.btnManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManual.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnManual.Location = New System.Drawing.Point(447, 37)
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(116, 100)
        Me.btnManual.TabIndex = 214
        Me.btnManual.Text = "Shortages"
        Me.btnManual.UseVisualStyleBackColor = False
        '
        'gbProfile
        '
        Me.gbProfile.Controls.Add(Me.lblUserLvl)
        Me.gbProfile.Controls.Add(Me.lblComputerType)
        Me.gbProfile.Controls.Add(Me.lblAppVersion)
        Me.gbProfile.Controls.Add(Me.lblAppName)
        Me.gbProfile.Controls.Add(Me.lblUserProf)
        Me.gbProfile.Controls.Add(Me.lblComputerName)
        Me.gbProfile.Controls.Add(Me.lblAppMode)
        Me.gbProfile.Controls.Add(Me.lblUserName)
        Me.gbProfile.Location = New System.Drawing.Point(13, 158)
        Me.gbProfile.Name = "gbProfile"
        Me.gbProfile.Size = New System.Drawing.Size(680, 45)
        Me.gbProfile.TabIndex = 213
        Me.gbProfile.TabStop = False
        '
        'lblUserLvl
        '
        Me.lblUserLvl.AutoSize = True
        Me.lblUserLvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserLvl.Location = New System.Drawing.Point(122, 33)
        Me.lblUserLvl.Name = "lblUserLvl"
        Me.lblUserLvl.Size = New System.Drawing.Size(54, 9)
        Me.lblUserLvl.TabIndex = 203
        Me.lblUserLvl.Text = "USER LEVEL:"
        '
        'lblComputerType
        '
        Me.lblComputerType.AutoSize = True
        Me.lblComputerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputerType.Location = New System.Drawing.Point(239, 33)
        Me.lblComputerType.Name = "lblComputerType"
        Me.lblComputerType.Size = New System.Drawing.Size(73, 9)
        Me.lblComputerType.TabIndex = 202
        Me.lblComputerType.Text = "COMPUTER TYPE"
        '
        'lblAppVersion
        '
        Me.lblAppVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAppVersion.Location = New System.Drawing.Point(475, 16)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(111, 17)
        Me.lblAppVersion.TabIndex = 193
        '
        'lblAppName
        '
        Me.lblAppName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAppName.Location = New System.Drawing.Point(358, 16)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(111, 17)
        Me.lblAppName.TabIndex = 192
        '
        'lblUserProf
        '
        Me.lblUserProf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserProf.Location = New System.Drawing.Point(124, 16)
        Me.lblUserProf.Name = "lblUserProf"
        Me.lblUserProf.Size = New System.Drawing.Size(111, 17)
        Me.lblUserProf.TabIndex = 199
        '
        'lblComputerName
        '
        Me.lblComputerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblComputerName.Location = New System.Drawing.Point(241, 16)
        Me.lblComputerName.Name = "lblComputerName"
        Me.lblComputerName.Size = New System.Drawing.Size(111, 17)
        Me.lblComputerName.TabIndex = 190
        '
        'lblAppMode
        '
        Me.lblAppMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAppMode.Location = New System.Drawing.Point(592, 12)
        Me.lblAppMode.Name = "lblAppMode"
        Me.lblAppMode.Size = New System.Drawing.Size(82, 23)
        Me.lblAppMode.TabIndex = 194
        Me.lblAppMode.Text = "lblAppMode"
        Me.lblAppMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUserName
        '
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserName.Location = New System.Drawing.Point(7, 16)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(111, 17)
        Me.lblUserName.TabIndex = 191
        '
        'gbDiag
        '
        Me.gbDiag.Controls.Add(Me.rbLiveMode)
        Me.gbDiag.Controls.Add(Me.rbTestMode)
        Me.gbDiag.Location = New System.Drawing.Point(709, 158)
        Me.gbDiag.Name = "gbDiag"
        Me.gbDiag.Size = New System.Drawing.Size(169, 45)
        Me.gbDiag.TabIndex = 212
        Me.gbDiag.TabStop = False
        Me.gbDiag.Text = "Diag"
        '
        'rbLiveMode
        '
        Me.rbLiveMode.AutoSize = True
        Me.rbLiveMode.Checked = True
        Me.rbLiveMode.Location = New System.Drawing.Point(7, 20)
        Me.rbLiveMode.Name = "rbLiveMode"
        Me.rbLiveMode.Size = New System.Drawing.Size(75, 17)
        Me.rbLiveMode.TabIndex = 1
        Me.rbLiveMode.TabStop = True
        Me.rbLiveMode.Text = "Live Mode"
        Me.rbLiveMode.UseVisualStyleBackColor = True
        '
        'rbTestMode
        '
        Me.rbTestMode.AutoSize = True
        Me.rbTestMode.Location = New System.Drawing.Point(88, 20)
        Me.rbTestMode.Name = "rbTestMode"
        Me.rbTestMode.Size = New System.Drawing.Size(76, 17)
        Me.rbTestMode.TabIndex = 0
        Me.rbTestMode.Text = "Test Mode"
        Me.rbTestMode.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Gold
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Maroon
        Me.btnExit.Location = New System.Drawing.Point(841, 37)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(116, 100)
        Me.btnExit.TabIndex = 211
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnPacker
        '
        Me.btnPacker.BackColor = System.Drawing.Color.Green
        Me.btnPacker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPacker.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnPacker.Location = New System.Drawing.Point(315, 37)
        Me.btnPacker.Name = "btnPacker"
        Me.btnPacker.Size = New System.Drawing.Size(116, 100)
        Me.btnPacker.TabIndex = 210
        Me.btnPacker.Text = "Sort Control"
        Me.btnPacker.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File, Me.Menu_Tools, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1102, 24)
        Me.MenuStrip1.TabIndex = 209
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Menu_File
        '
        Me.Menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File_Exit})
        Me.Menu_File.Name = "Menu_File"
        Me.Menu_File.Size = New System.Drawing.Size(37, 20)
        Me.Menu_File.Text = "&File"
        '
        'Menu_File_Exit
        '
        Me.Menu_File_Exit.Name = "Menu_File_Exit"
        Me.Menu_File_Exit.Size = New System.Drawing.Size(128, 22)
        Me.Menu_File_Exit.Text = "E&xit"
        '
        'Menu_Tools
        '
        Me.Menu_Tools.Name = "Menu_Tools"
        Me.Menu_Tools.Size = New System.Drawing.Size(47, 20)
        Me.Menu_Tools.Text = "‬&Tools"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(58, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 75)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "GBI"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.ToolStripMenuItem1.Text = "‬&About"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 210)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnReprint)
        Me.Controls.Add(Me.btnRepack)
        Me.Controls.Add(Me.btnManual)
        Me.Controls.Add(Me.gbProfile)
        Me.Controls.Add(Me.gbDiag)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPacker)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMenu"
        Me.Text = "GBI Systems"
        Me.gbProfile.ResumeLayout(False)
        Me.gbProfile.PerformLayout()
        Me.gbDiag.ResumeLayout(False)
        Me.gbDiag.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReprint As Button
    Friend WithEvents btnRepack As Button
    Friend WithEvents btnManual As Button
    Friend WithEvents gbProfile As GroupBox
    Friend WithEvents lblUserLvl As Label
    Friend WithEvents lblComputerType As Label
    Friend WithEvents lblAppVersion As Label
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblUserProf As Label
    Friend WithEvents lblComputerName As Label
    Friend WithEvents lblAppMode As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents gbDiag As GroupBox
    Friend WithEvents rbLiveMode As RadioButton
    Friend WithEvents rbTestMode As RadioButton
    Friend WithEvents btnExit As Button
    Friend WithEvents btnPacker As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Menu_File As ToolStripMenuItem
    Friend WithEvents Menu_File_Exit As ToolStripMenuItem
    Friend WithEvents Menu_Tools As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
