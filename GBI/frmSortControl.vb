Imports System.IO

Public Class frmSortControl

    'Instantiate Stored Procedures 
    Private sp As New clsStoredProcedures
    'Instantiate error handler
    Private eh As clsErrorHandler
    'Instantiate Table objects
    Private tblWavelist As DataTable
    Private tblWaveDetail As DataTable
    Private tblLog As DataTable
    Private tblDrops As DataTable
    Private tblCarriers As DataTable
    Private tblShortages As DataTable
    Private tblVerify As DataTable

    'Badge Controls


    Private ConnectionString As String = ""

    Private Sub frmSortControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlBadge.Visible = False
        Try
            ConnectionString = sp.SQLServerConnection_GET("GBI", "PROD").Rows(0).Item("ConnectionString").ToString.Trim

        Catch ex As Exception
            ex.ToString()
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
            ex.ToString()
        End Try

        If TabControl1.SelectedTab.ToString = "TabPage: {Logs}" Then
            Try
                GetMessagesFromGBI()
            Catch ex As Exception
                ex.ToString()
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Carriers}" Then
            Try
                GetCarriers()
            Catch ex As Exception
                ex.ToString()
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Drops}" Then
            Try
                GetDrops()
            Catch ex As Exception
                ex.ToString()
            End Try
        End If

        If TabControl1.SelectedTab.ToString = "TabPage: {Shortages}" Then
            Try
                GetShortages()
            Catch ex As Exception
                ex.ToString()
            End Try
        End If

    End Sub

    Private Sub GetPendingWaves()
        Dim i As Int16 = 0
        Dim rowCount As Int16 = 0
        lstWaves.Items.Clear()
        tblWavelist = sp.PendingWaveLookup(ConnectionString)

        rowCount = tblWavelist.Rows.Count()

        While rowCount > i
            lstWaves.Items.Add(tblWavelist.Rows(i).Item("WaveId").ToString())
            i = i + 1
        End While
    End Sub


    Private Sub GetLoginfo()
        Try

            tblLog = sp.GetLogInfo(ConnectionString)

            dgvLogs.DataSource = tblLog

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetShortages()
        Try

            tblShortages = sp.GetShortages(ConnectionString)

            dgvShortages.DataSource = tblShortages

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub SendRepick()
        Try

            tblShortages = sp.SendRepick(ConnectionString)

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetMessagesFromGBI()
        Try

            tblLog = sp.GetMessagesFromGBI(ConnectionString)

            dgvMessages.DataSource = tblLog

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetDrops()
        Try

            tblDrops = sp.GetDrops(ConnectionString)

            dgvDrops.DataSource = tblDrops

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetCarriers()
        Try

            tblCarriers = sp.GetCarriers(ConnectionString)

            dgvCarriers.DataSource = tblCarriers

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub GetActiveWave()
        Try

            Dim ds As DataSet = sp.GetActiveWave(ConnectionString, "")

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

            sp.ActivateWave(ConnectionString, lstWaves.SelectedItem)

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
        GetLoginfo()
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

            Dim VerifyDs As DataSet = sp.VerifyBadge(ConnectionString, rtbBadge.Text)

            tblVerify = VerifyDs.Tables(0)

            Dim Status As String = tblVerify.Rows(0).Item("Status").ToString

            If Status = "Approved" Then
                sp.AbortWave(ConnectionString, txtWaveNmbr.Text, "Abort", rtbBadge.Text)
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
End Class