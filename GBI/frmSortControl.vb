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

    Private ConnectionString As String = ""

    Private Sub frmSortControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Int16 = 0
        Dim rowCount As Int16 = 0
        Try
            ConnectionString = sp.SQLServerConnection_GET("GBI", "PROD").Rows(0).Item("ConnectionString").ToString.Trim

        Catch ex As Exception
            ex.ToString()
        End Try

        Try

            tblWavelist = sp.PendingWaveLookup(ConnectionString)

            rowCount = tblWavelist.Rows.Count()

            While rowCount > i
                lstWaves.Items.Add(tblWavelist.Rows(i).Item("WaveId").ToString())
                i = i + 1
            End While

            GetLoginfo()

            GetActiveWave()

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
End Class