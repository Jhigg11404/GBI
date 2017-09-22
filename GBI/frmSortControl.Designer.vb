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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbHMI = New System.Windows.Forms.TabPage()
        Me.dgvWaveDtl = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUnitsFilled = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.txtUnitsRequired = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDestinations = New System.Windows.Forms.TextBox()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.txtOrders = New System.Windows.Forms.TextBox()
        Me.lblWaveNbr = New System.Windows.Forms.Label()
        Me.txtWaveNmbr = New System.Windows.Forms.TextBox()
        Me.lblWavelist = New System.Windows.Forms.Label()
        Me.lstWaves = New System.Windows.Forms.ListBox()
        Me.tbCarriers = New System.Windows.Forms.TabPage()
        Me.dgvCarriers = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbDrops = New System.Windows.Forms.TabPage()
        Me.dgvDrops = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbShortages = New System.Windows.Forms.TabPage()
        Me.dgvShortages = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbLogs = New System.Windows.Forms.TabPage()
        Me.dgvMessages = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvLogs = New System.Windows.Forms.DataGridView()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tbHMI.SuspendLayout()
        CType(Me.dgvWaveDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCarriers.SuspendLayout()
        CType(Me.dgvCarriers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDrops.SuspendLayout()
        CType(Me.dgvDrops, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbShortages.SuspendLayout()
        CType(Me.dgvShortages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbLogs.SuspendLayout()
        CType(Me.dgvMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbHMI)
        Me.TabControl1.Controls.Add(Me.tbCarriers)
        Me.TabControl1.Controls.Add(Me.tbDrops)
        Me.TabControl1.Controls.Add(Me.tbShortages)
        Me.TabControl1.Controls.Add(Me.tbLogs)
        Me.TabControl1.Location = New System.Drawing.Point(0, 5)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1806, 698)
        Me.TabControl1.TabIndex = 0
        '
        'tbHMI
        '
        Me.tbHMI.Controls.Add(Me.dgvWaveDtl)
        Me.tbHMI.Controls.Add(Me.Label4)
        Me.tbHMI.Controls.Add(Me.txtUnitsFilled)
        Me.tbHMI.Controls.Add(Me.Label3)
        Me.tbHMI.Controls.Add(Me.Button3)
        Me.tbHMI.Controls.Add(Me.btnActivate)
        Me.tbHMI.Controls.Add(Me.txtUnitsRequired)
        Me.tbHMI.Controls.Add(Me.Button2)
        Me.tbHMI.Controls.Add(Me.Label2)
        Me.tbHMI.Controls.Add(Me.txtDestinations)
        Me.tbHMI.Controls.Add(Me.lblOrders)
        Me.tbHMI.Controls.Add(Me.txtOrders)
        Me.tbHMI.Controls.Add(Me.lblWaveNbr)
        Me.tbHMI.Controls.Add(Me.txtWaveNmbr)
        Me.tbHMI.Controls.Add(Me.lblWavelist)
        Me.tbHMI.Controls.Add(Me.lstWaves)
        Me.tbHMI.Location = New System.Drawing.Point(4, 29)
        Me.tbHMI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbHMI.Name = "tbHMI"
        Me.tbHMI.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbHMI.Size = New System.Drawing.Size(1798, 665)
        Me.tbHMI.TabIndex = 0
        Me.tbHMI.Text = "HMI"
        Me.tbHMI.UseVisualStyleBackColor = True
        '
        'dgvWaveDtl
        '
        Me.dgvWaveDtl.AllowUserToAddRows = False
        Me.dgvWaveDtl.AllowUserToDeleteRows = False
        Me.dgvWaveDtl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvWaveDtl.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWaveDtl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvWaveDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWaveDtl.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvWaveDtl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvWaveDtl.Location = New System.Drawing.Point(272, 142)
        Me.dgvWaveDtl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvWaveDtl.Name = "dgvWaveDtl"
        Me.dgvWaveDtl.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvWaveDtl.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvWaveDtl.RowHeadersVisible = False
        Me.dgvWaveDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWaveDtl.Size = New System.Drawing.Size(1468, 448)
        Me.dgvWaveDtl.TabIndex = 227
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(747, 77)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 226
        Me.Label4.Text = "Units Filled:"
        '
        'txtUnitsFilled
        '
        Me.txtUnitsFilled.Location = New System.Drawing.Point(746, 102)
        Me.txtUnitsFilled.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitsFilled.Name = "txtUnitsFilled"
        Me.txtUnitsFilled.Size = New System.Drawing.Size(148, 26)
        Me.txtUnitsFilled.TabIndex = 225
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(585, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Units Required:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button3.Location = New System.Drawing.Point(14, 471)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(174, 57)
        Me.Button3.TabIndex = 215
        Me.Button3.Text = "Abort Wave"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnActivate
        '
        Me.btnActivate.BackColor = System.Drawing.Color.Green
        Me.btnActivate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivate.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnActivate.Location = New System.Drawing.Point(14, 338)
        Me.btnActivate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(174, 57)
        Me.btnActivate.TabIndex = 213
        Me.btnActivate.Text = "Activate Wave"
        Me.btnActivate.UseVisualStyleBackColor = False
        '
        'txtUnitsRequired
        '
        Me.txtUnitsRequired.Location = New System.Drawing.Point(586, 102)
        Me.txtUnitsRequired.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUnitsRequired.Name = "txtUnitsRequired"
        Me.txtUnitsRequired.Size = New System.Drawing.Size(148, 26)
        Me.txtUnitsRequired.TabIndex = 223
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button2.Location = New System.Drawing.Point(14, 405)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(174, 57)
        Me.Button2.TabIndex = 214
        Me.Button2.Text = "Close Wave"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(426, 77)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "Destinations:"
        '
        'txtDestinations
        '
        Me.txtDestinations.Location = New System.Drawing.Point(428, 102)
        Me.txtDestinations.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDestinations.Name = "txtDestinations"
        Me.txtDestinations.Size = New System.Drawing.Size(148, 26)
        Me.txtDestinations.TabIndex = 221
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Location = New System.Drawing.Point(267, 77)
        Me.lblOrders.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(61, 20)
        Me.lblOrders.TabIndex = 220
        Me.lblOrders.Text = "Orders:"
        '
        'txtOrders
        '
        Me.txtOrders.Location = New System.Drawing.Point(268, 102)
        Me.txtOrders.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOrders.Name = "txtOrders"
        Me.txtOrders.Size = New System.Drawing.Size(148, 26)
        Me.txtOrders.TabIndex = 219
        '
        'lblWaveNbr
        '
        Me.lblWaveNbr.AutoSize = True
        Me.lblWaveNbr.Location = New System.Drawing.Point(264, 15)
        Me.lblWaveNbr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWaveNbr.Name = "lblWaveNbr"
        Me.lblWaveNbr.Size = New System.Drawing.Size(113, 20)
        Me.lblWaveNbr.TabIndex = 218
        Me.lblWaveNbr.Text = "Wave Number:"
        '
        'txtWaveNmbr
        '
        Me.txtWaveNmbr.Location = New System.Drawing.Point(266, 40)
        Me.txtWaveNmbr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtWaveNmbr.Name = "txtWaveNmbr"
        Me.txtWaveNmbr.Size = New System.Drawing.Size(148, 26)
        Me.txtWaveNmbr.TabIndex = 217
        '
        'lblWavelist
        '
        Me.lblWavelist.AutoSize = True
        Me.lblWavelist.Location = New System.Drawing.Point(9, 15)
        Me.lblWavelist.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWavelist.Name = "lblWavelist"
        Me.lblWavelist.Size = New System.Drawing.Size(128, 20)
        Me.lblWavelist.TabIndex = 1
        Me.lblWavelist.Text = "Available Waves:"
        '
        'lstWaves
        '
        Me.lstWaves.FormattingEnabled = True
        Me.lstWaves.ItemHeight = 20
        Me.lstWaves.Location = New System.Drawing.Point(14, 40)
        Me.lstWaves.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstWaves.Name = "lstWaves"
        Me.lstWaves.Size = New System.Drawing.Size(178, 264)
        Me.lstWaves.TabIndex = 0
        '
        'tbCarriers
        '
        Me.tbCarriers.Controls.Add(Me.dgvCarriers)
        Me.tbCarriers.Controls.Add(Me.Label7)
        Me.tbCarriers.Location = New System.Drawing.Point(4, 29)
        Me.tbCarriers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbCarriers.Name = "tbCarriers"
        Me.tbCarriers.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbCarriers.Size = New System.Drawing.Size(1798, 665)
        Me.tbCarriers.TabIndex = 1
        Me.tbCarriers.Text = "Carriers"
        Me.tbCarriers.UseVisualStyleBackColor = True
        '
        'dgvCarriers
        '
        Me.dgvCarriers.AllowUserToAddRows = False
        Me.dgvCarriers.AllowUserToDeleteRows = False
        Me.dgvCarriers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCarriers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCarriers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvCarriers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCarriers.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvCarriers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCarriers.Location = New System.Drawing.Point(54, 69)
        Me.dgvCarriers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvCarriers.Name = "dgvCarriers"
        Me.dgvCarriers.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCarriers.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvCarriers.RowHeadersVisible = False
        Me.dgvCarriers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCarriers.Size = New System.Drawing.Size(1686, 520)
        Me.dgvCarriers.TabIndex = 218
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 26)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 37)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Carriers:"
        '
        'tbDrops
        '
        Me.tbDrops.Controls.Add(Me.dgvDrops)
        Me.tbDrops.Controls.Add(Me.Label6)
        Me.tbDrops.Location = New System.Drawing.Point(4, 29)
        Me.tbDrops.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbDrops.Name = "tbDrops"
        Me.tbDrops.Size = New System.Drawing.Size(1798, 665)
        Me.tbDrops.TabIndex = 2
        Me.tbDrops.Text = "Drops"
        Me.tbDrops.UseVisualStyleBackColor = True
        '
        'dgvDrops
        '
        Me.dgvDrops.AllowUserToAddRows = False
        Me.dgvDrops.AllowUserToDeleteRows = False
        Me.dgvDrops.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDrops.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrops.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvDrops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDrops.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgvDrops.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDrops.Location = New System.Drawing.Point(54, 69)
        Me.dgvDrops.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDrops.Name = "dgvDrops"
        Me.dgvDrops.ReadOnly = True
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrops.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvDrops.RowHeadersVisible = False
        Me.dgvDrops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDrops.Size = New System.Drawing.Size(1686, 520)
        Me.dgvDrops.TabIndex = 218
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 28)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 37)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Drops:"
        '
        'tbShortages
        '
        Me.tbShortages.Controls.Add(Me.dgvShortages)
        Me.tbShortages.Controls.Add(Me.Button4)
        Me.tbShortages.Controls.Add(Me.Label5)
        Me.tbShortages.Location = New System.Drawing.Point(4, 29)
        Me.tbShortages.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbShortages.Name = "tbShortages"
        Me.tbShortages.Size = New System.Drawing.Size(1798, 665)
        Me.tbShortages.TabIndex = 3
        Me.tbShortages.Text = "Shortages"
        Me.tbShortages.UseVisualStyleBackColor = True
        '
        'dgvShortages
        '
        Me.dgvShortages.AllowUserToAddRows = False
        Me.dgvShortages.AllowUserToDeleteRows = False
        Me.dgvShortages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvShortages.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShortages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dgvShortages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShortages.DefaultCellStyle = DataGridViewCellStyle29
        Me.dgvShortages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvShortages.Location = New System.Drawing.Point(54, 69)
        Me.dgvShortages.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvShortages.Name = "dgvShortages"
        Me.dgvShortages.ReadOnly = True
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShortages.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvShortages.RowHeadersVisible = False
        Me.dgvShortages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShortages.Size = New System.Drawing.Size(1686, 520)
        Me.dgvShortages.TabIndex = 218
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Cornsilk
        Me.Button4.Location = New System.Drawing.Point(1568, 9)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(174, 57)
        Me.Button4.TabIndex = 213
        Me.Button4.Text = "Submit Repick"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(182, 37)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Shortages:"
        '
        'tbLogs
        '
        Me.tbLogs.Controls.Add(Me.dgvMessages)
        Me.tbLogs.Controls.Add(Me.Label1)
        Me.tbLogs.Location = New System.Drawing.Point(4, 29)
        Me.tbLogs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbLogs.Name = "tbLogs"
        Me.tbLogs.Size = New System.Drawing.Size(1798, 665)
        Me.tbLogs.TabIndex = 4
        Me.tbLogs.Text = "Logs"
        Me.tbLogs.UseVisualStyleBackColor = True
        '
        'dgvMessages
        '
        Me.dgvMessages.AllowUserToAddRows = False
        Me.dgvMessages.AllowUserToDeleteRows = False
        Me.dgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMessages.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMessages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMessages.DefaultCellStyle = DataGridViewCellStyle32
        Me.dgvMessages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMessages.Location = New System.Drawing.Point(56, 80)
        Me.dgvMessages.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvMessages.Name = "dgvMessages"
        Me.dgvMessages.ReadOnly = True
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMessages.RowHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.dgvMessages.RowHeadersVisible = False
        Me.dgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMessages.Size = New System.Drawing.Size(1686, 520)
        Me.dgvMessages.TabIndex = 217
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 37)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GBI Log:"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Gold
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Maroon
        Me.btnExit.Location = New System.Drawing.Point(1574, 745)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(174, 154)
        Me.btnExit.TabIndex = 213
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Green
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnRefresh.Location = New System.Drawing.Point(1390, 745)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(174, 154)
        Me.btnRefresh.TabIndex = 212
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dgvLogs
        '
        Me.dgvLogs.AllowUserToAddRows = False
        Me.dgvLogs.AllowUserToDeleteRows = False
        Me.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLogs.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLogs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLogs.DefaultCellStyle = DataGridViewCellStyle35
        Me.dgvLogs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLogs.Location = New System.Drawing.Point(33, 712)
        Me.dgvLogs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvLogs.Name = "dgvLogs"
        Me.dgvLogs.ReadOnly = True
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLogs.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.dgvLogs.RowHeadersVisible = False
        Me.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLogs.Size = New System.Drawing.Size(1282, 205)
        Me.dgvLogs.TabIndex = 228
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 10000
        '
        'frmSortControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1804, 935)
        Me.Controls.Add(Me.dgvLogs)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmSortControl"
        Me.Text = "frmSortControl"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.tbHMI.ResumeLayout(False)
        Me.tbHMI.PerformLayout()
        CType(Me.dgvWaveDtl, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.dgvLogs, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtUnitsFilled As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents btnActivate As Button
    Friend WithEvents txtUnitsRequired As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDestinations As TextBox
    Friend WithEvents lblOrders As Label
    Friend WithEvents txtOrders As TextBox
    Friend WithEvents lblWaveNbr As Label
    Friend WithEvents txtWaveNmbr As TextBox
    Friend WithEvents lblWavelist As Label
    Friend WithEvents lstWaves As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvMessages As DataGridView
    Friend WithEvents dgvWaveDtl As DataGridView
    Friend WithEvents dgvCarriers As DataGridView
    Friend WithEvents dgvDrops As DataGridView
    Friend WithEvents dgvShortages As DataGridView
    Friend WithEvents dgvLogs As DataGridView
    Friend WithEvents tmrRefresh As Timer
End Class
