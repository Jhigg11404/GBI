Imports System.IO
Imports Common.clsCommon

Public Class frmSortControl

    'Instantiate Stored Procedures 
    Private sp As New DataHandling.clsStoredProcedures

    'Instantiate Profile object
    Dim Profile As Common.objProfile = New Common.objProfile

    'Instantiate error handler
    Dim eh As New ErrorHandling.clsErrorHandler
    Dim ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)

    'Instantiate Table objects
    Private tblWavelist As DataTable
    Private tblWaveDetail As DataTable
    Private tblLog As DataTable
    Private tblDrops As DataTable
    Private tblCarriers As DataTable
    Private tblShortages As DataTable
    Private tblVerify As DataTable
    Private tblManual As DataTable

    'Badge Controls

    Private ConnectionString As String = ""

    Private Sub frmSortControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Profile
            .p_AppMode = "PROD"
            .p_UserName = My.User.Name
            .p_UserProf = My.Computer.Name
            .p_Userlvl = "0"
            .p_Authenticated = "False"
            .p_ComputerName = My.Computer.Name
            .p_AppName = My.Application.Info.AssemblyName
            .p_AppVersion = String.Format("Version {0}", My.Application.Info.Version.ToString)
            If Not Debugger.IsAttached And System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                Dim Deploy As Version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                .p_AppVersion = String.Format("Version {0}.{1}.{2}.{3}", Deploy.Major, Deploy.Minor, Deploy.Build, Deploy.Revision)
            End If
        End With

        pnlBadge.Visible = False


        Try
            Profile.p_ConnectionString = sp.SQLServerConnection_GET("GBI", Profile.p_AppMode).Rows(0).Item("ConnectionString").ToString.Trim

        Catch ex As Exception
            eh._Err(Profile, "Form Sorter Control Load", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

        Try
            GetPendingWaves()

            GetLoginfo()

            GetActiveWave()

            tmrRefresh.Start()

        Catch ex As Exception
            ex.ToString()
        End Try


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Try
            GetLoginfo()

        Catch ex As Exception
            eh._Err(Profile, "GetLogInfo", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

        If TabControl1.SelectedTab.ToString = "TabPage: {Logs}" Then
            Try
                GetMessagesFromGBI()
            Catch ex As Exception
                eh._Err(Profile, "GetMessagesFromGBI", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Carriers}" Then
            Try
                GetCarriers()
            Catch ex As Exception
                eh._Err(Profile, "GetCarriers", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Drops}" Then
            Try
                GetDrops()
            Catch ex As Exception
                eh._Err(Profile, "GetDrops", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Shortages}" Then
            Try
                GetShortages()
            Catch ex As Exception
                eh._Err(Profile, "GetShortages", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Manual Station}" Then
            Try
                txtManWaveNmbr.Enabled = False
                GetManPendingWaves()
            Catch ex As Exception
                eh._Err(Profile, "GetPendingWaves", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            End Try
        End If

    End Sub

    Private Sub GetPendingWaves()
        Dim i As Int16 = 0
        Dim rowCount As Int16 = 0
        lstWaves.Items.Clear()

        tblWavelist = sp.PendingWaveLookup(Profile.p_ConnectionString)

        rowCount = tblWavelist.Rows.Count()

        While rowCount > i
            lstWaves.Items.Add(tblWavelist.Rows(i).Item("WaveId").ToString())
            i = i + 1
        End While
    End Sub

    Private Sub GetManPendingWaves()
        Dim i As Int16 = 0
        Dim rowCount As Int16 = 0
        lstManWaves.Items.Clear()

        tblWavelist = sp.PendingWaveLookup(Profile.p_ConnectionString)

        rowCount = tblWavelist.Rows.Count()

        While rowCount > i
            lstManWaves.Items.Add(tblWavelist.Rows(i).Item("WaveId").ToString())
            i = i + 1
        End While
    End Sub


    Private Sub GetLoginfo()
        Try

            tblLog = sp.GetLogInfo(Profile.p_ConnectionString)

            dgvLogs.DataSource = tblLog

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetShortages()
        Try

            tblShortages = sp.GetShortages(Profile.p_ConnectionString)

            dgvShortages.DataSource = tblShortages

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub SendRepick()
        Try

            tblShortages = sp.SendRepick(Profile.p_ConnectionString)

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetMessagesFromGBI()
        Try

            tblLog = sp.GetMessagesFromGBI(Profile.p_ConnectionString)

            dgvMessages.DataSource = tblLog

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetDrops()
        Try

            tblDrops = sp.GetDrops(Profile.p_ConnectionString)

            dgvDrops.DataSource = tblDrops

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetCarriers()
        Try

            tblCarriers = sp.GetCarriers(Profile.p_ConnectionString)

            dgvCarriers.DataSource = tblCarriers

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetActiveWave()
        Try

            Dim ds As DataSet = sp.GetActiveWave(Profile.p_ConnectionString, "")

            tblWaveDetail = ds.Tables(1)
            tblWavelist = ds.Tables(0)

            dgvWaveDtl.DataSource = tblWaveDetail

            txtWaveNmbr.Text = tblWavelist.Rows(0).Item("Waveid").ToString
            txtOrders.Text = tblWavelist.Rows(0).Item("Orderid").ToString
            txtDestinations.Text = tblWavelist.Rows(0).Item("DropLocation").ToString
            txtUnitsRequired.Text = tblWavelist.Rows(0).Item("QtyRequired").ToString
            txtUnitsFilled.Text = tblWavelist.Rows(0).Item("ConfirmedDrops").ToString

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub BtnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click

        Try

            sp.ActivateWave(Profile.p_ConnectionString, lstWaves.SelectedItem)

            GetActiveWave()

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub TmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        Me.Cursor = Cursors.WaitCursor
        GetPendingWaves()
        GetActiveWave()
        GetCarriers()
        GetDrops()
        GetMessagesFromGBI()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click

        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to abort the wave?", "Alert!", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            'Do nothing
        ElseIf result = DialogResult.Yes Then
            pnlBadge.Visible = True
            rtbBadge.Focus()
        End If

    End Sub

    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs) Handles rtbBadge.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim VerifyDs As DataSet = sp.VerifyBadge(Profile.p_ConnectionString, rtbBadge.Text)

            tblVerify = VerifyDs.Tables(0)

            Dim Status As String = tblVerify.Rows(0).Item("Status").ToString

            If Status = "Approved" Then
                sp.AbortWave(Profile.p_ConnectionString, txtWaveNmbr.Text, "Abort", rtbBadge.Text)
                txtWaveNmbr.Clear()
                txtOrders.Clear()
                txtDestinations.Clear()
                txtUnitsFilled.Clear()
                txtUnitsRequired.Clear()
                dgvWaveDtl.DataSource = Nothing
                pnlBadge.Visible = False
                rtbBadge.Clear()
            Else
                MessageBox.Show("You are not authorized to run this process, please contact your supervisor!", "Alert", MessageBoxButtons.OK)
                rtbBadge.Clear()
            End If
        End If

    End Sub

    Private Sub createRepick()
        Dim dsMiss As DataSet
        Dim strLine As String = String.Empty
        Dim strfilePath As String = "C:\Users\Admin\Documents\Repicks\"
        Dim strfileName As String = String.Empty
        Dim strfilePathName As String = String.Empty
        Dim objFileStream As FileStream = Nothing
        Dim objStreamWriter As StreamWriter = Nothing

        Dim strfileDateTime As String = DateTime.Now.ToString("yyyyMMdd") & DateTime.Now.ToString("HHmmssfff")

        strfileName = "GBI-REPICK" & strfileDateTime
        strfilePathName = strfilePath & strfileName

        Try

            SendRepick()

            ' prep file
            objFileStream = New FileStream(strfilePathName, FileMode.Create, FileAccess.Write)
            objStreamWriter = New StreamWriter(objFileStream)

            ' write to file
            For i = 0 To tblShortages.Rows.Count - 1
                For j = 0 To tblShortages.Columns.Count - 1
                    strLine = strLine & tblShortages.Rows(i).Item(j).ToString & ","
                Next

                ' remove extraneous comma
                strLine = strLine.Substring(0, strLine.Length - 1)

                '
                objStreamWriter.WriteLine(strLine)
                strLine = ""
            Next

            ' cleanup
            objStreamWriter.Close()
            objFileStream.Close()

            ' create empty done file
            strfilePathName += ".done"
            objFileStream = New FileStream(strfilePathName, FileMode.Create, FileAccess.Write)
            objFileStream.Close()

            MsgBox("RePick File has been created.", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub btnRepick_Click(sender As Object, e As EventArgs) Handles btnRepick.Click
        createRepick()
    End Sub

    Private Sub btnManOpenWave_Click(sender As Object, e As EventArgs) Handles btnManOpenWave.Click

        txtManWaveNmbr.Text = lstManWaves.SelectedItem
        lstManWaves.Enabled = False
        rtbBarcode.Focus()
    End Sub

    Private Sub BtnManCloseWave_Click(sender As Object, e As EventArgs) Handles BtnManCloseWave.Click

        lstManWaves.Enabled = True
        txtManWaveNmbr.Clear()

    End Sub

    Private Sub OnKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles rtbBarcode.KeyDown

        If e.KeyCode = Keys.Enter Then

            tblManual = sp.FillManualPart(Profile.p_ConnectionString, rtbBarcode.Text)

            dgvManual.DataSource = tblManual
            PrintManualLabel()
            rtbBarcode.Clear()
        End If

    End Sub


    Private Sub PrintManualLabel()
        Dim IpAddress As String
        Dim port As Integer
        Dim zplstring As String

        Dim WaveNmbr As String
        Dim DropLocation As String
        Dim Barcode As String
        Dim OrdNmbr As String

        IpAddress = "10.10.211.69"
        port = 9100

        WaveNmbr = tblManual.Rows(0).Item("WaveID").ToString()
        DropLocation = tblManual.Rows(0).Item("DropLocation").ToString()
        OrdNmbr = tblManual.Rows(0).Item("OrderID").ToString()
        Barcode = tblManual.Rows(0).Item("UPC").ToString()

        zplstring =
            "^XA" &
            "^FO30,30^ADN,36,10^FDWave# " & WaveNmbr & "^FS" &
            "^FO30,60^ADN,36,10^FDBarcode# " & Barcode & "^FS" &
            "^FO30,90^ADN,36,10^FDOrder# " & OrdNmbr & "^FS" &
            "^FO30,120^ADN,36,10^FDDrop# " & DropLocation & "^FS" &
            "^XZ"
        'Open Connection
        Dim client As New System.Net.Sockets.TcpClient
        client.Connect(IpAddress, port)

        'Write ZPL String to Connection
        Dim writer As New System.IO.StreamWriter(client.GetStream())
            writer.Write(zplstring)
            writer.Flush()

            'Close Connection
            writer.Close()
        client.Close()
    End Sub
End Class