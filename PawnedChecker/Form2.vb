Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Net.Http

Public Class fPPChecker

    Enum MethodToUse
        WebClient = 0
        HttpClient = 1
    End Enum



#Region "Events"
    Private Sub fPPChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lStatus.Text = "fPPChecker_Load"
        Try

            ReadConfig()
            Initialise()

        Catch ex As Exception
            lStatus.Text = String.Format("fPPChecker_Load Error: {0}", ex.Message)
        End Try

    End Sub

    Private Sub bSelect_Click(sender As Object, e As EventArgs) Handles bSelect.Click
        lStatus.Text = "bSelect_Click"
        Try
            SelectFile()
        Catch ex As Exception
            lStatus.Text = String.Format("bSelect_Click Error: {0}", ex.Message)
        End Try

    End Sub


    Private Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click
        lStatus.Text = "bLoad_Click"
        Try
            If Not String.IsNullOrEmpty(tbFile.Text) Then

                If clbPasswordsToCheck.DataSource IsNot Nothing Then
                    clbPasswordsToCheck.DataSource = Nothing
                End If

                Dim dataSource = File.ReadAllLines(tbFile.Text).Distinct().ToList()

                clbPasswordsToCheck.DataSource = dataSource
                bVerify.Enabled = (clbPasswordsToCheck.Items.Count > 0)
                bVerify2.Enabled = bVerify.Enabled
            End If

        Catch ex As Exception
            lStatus.Text = String.Format("bLoad_Click Error: {0}", ex.Message)
        End Try

    End Sub


    Private Sub bUnload_Click(sender As Object, e As EventArgs) Handles bUnload.Click
        lStatus.Text = "bUnload_Click"
        Try
            Initialise()
        Catch ex As Exception
            lStatus.Text = String.Format("bUnload_Click Error: {0}", ex.Message)
        End Try
    End Sub


    Private Sub bClear_Click(sender As Object, e As EventArgs) Handles bClear.Click
        lStatus.Text = "bClear_Click"
        Try
            UnCheckAll(clbPasswordsToCheck)
        Catch ex As Exception
            lStatus.Text = String.Format("bClear_Click Error: {0}", ex.Message)
        End Try
    End Sub

    Private Sub bVerify_Click(sender As Object, e As EventArgs) Handles bVerify.Click
        lStatus.Text = "bVerify_Click"
        Try
            If clbPasswordsToCheck.Items.Count > 0 Then
                bStop.Enabled = True

                For counter As Integer = 0 To clbPasswordsToCheck.Items.Count - 1
                    If Not clbPasswordsToCheck.GetItemChecked(counter) Then

                        clbPasswordsToCheck.SetSelected(counter, True)

                        Dim passwordToCheck = clbPasswordsToCheck.Items(counter).ToString()

                        'check if password is pawned
                        If Not String.IsNullOrEmpty(passwordToCheck) Then
                            If IsPasswordPawned(passwordToCheck, MethodToUse.WebClient) Then
                                clbPasswordsToCheck.SetItemCheckState(counter, CheckState.Checked)
                            End If
                        End If

                    End If

                    If Not bStop.Enabled Then
                        Exit For
                    End If

                Next

                bStop.Enabled = False
            End If

            lStatus.Text = "Done"
        Catch ex As Exception
            lStatus.Text = String.Format("bVerify_Click Error: {0}", ex.Message)
        End Try

    End Sub

    Private Sub bVerify2_Click(sender As Object, e As EventArgs) Handles bVerify2.Click
        lStatus.Text = "bVerify2_Click"
        Try
            If clbPasswordsToCheck.Items.Count > 0 Then
                bStop.Enabled = True

                For counter As Integer = 0 To clbPasswordsToCheck.Items.Count - 1

                    If Not clbPasswordsToCheck.GetItemChecked(counter) Then

                        clbPasswordsToCheck.SetSelected(counter, True)

                        Dim passwordToCheck = clbPasswordsToCheck.Items(counter).ToString()

                        'check if password is pawned
                        If Not String.IsNullOrEmpty(passwordToCheck) Then
                            If IsPasswordPawned(passwordToCheck, MethodToUse.HttpClient) Then
                                clbPasswordsToCheck.SetItemCheckState(counter, CheckState.Checked)
                            End If
                        End If

                    End If

                    If Not bStop.Enabled Then
                        Exit For
                    End If

                Next

                bStop.Enabled = False
            End If

            lStatus.Text = "Done"
        Catch ex As Exception
            lStatus.Text = String.Format("bVerify2_Click Error: {0}", ex.Message)
        End Try
    End Sub

    Private Sub bStop_Click(sender As Object, e As EventArgs) Handles bStop.Click
        lStatus.Text = "SelectFile"
        bStop.Enabled = False
    End Sub


#End Region

#Region "Functions/Methods"
    Private Sub ReadConfig()
        Dim toolTip As New ToolTip()
        toolTip.ShowAlways = True

        tbWebApi.Text = ConfigurationSettings.AppSettings("webapi").ToString()
        tbWebApi.Tag = ConfigurationSettings.AppSettings("firstn").ToString()

        clbPasswordsToCheck.Tag = ConfigurationSettings.AppSettings("timeout").ToString()
        If Not IsNumeric(clbPasswordsToCheck.Tag) Then
            clbPasswordsToCheck.Tag = "5000000"
        End If

        toolTip.SetToolTip(tbWebApi, tbWebApi.Tag)
    End Sub

    Private Sub Initialise()

        Dim pwdFileName = ConfigurationSettings.AppSettings("PwdFileName").ToString()
        Dim rootPath As String = Application.StartupPath.ToLower.Replace("\bin\debug", "").Replace("\bin\release", "")
        tbFile.Text = String.Format("{0}\{1}", rootPath, pwdFileName)

        clbPasswordsToCheck.DataSource = Nothing
        clbPasswordsToCheck.Items.Clear()

        bVerify.Enabled = False
        bVerify2.Enabled = False
        bStop.Enabled = False
    End Sub

    Private Sub SelectFile()
        lStatus.Text = "SelectFile"

        Dim rootPath As String = Application.StartupPath.ToLower.Replace("\bin\debug", "").Replace("\bin\release", "")
        'rootPath = String.Format("{0}\TextFile1.txt", rootPath)


        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = rootPath
        'fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.Filter = "Text file|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            tbFile.Text = fd.FileName
        End If
    End Sub

    Private Sub UnCheckAll(clbPasswordsToCheck As CheckedListBox)
        For counter As Integer = 0 To clbPasswordsToCheck.Items.Count - 1
            clbPasswordsToCheck.SetItemChecked(counter, False)
        Next
    End Sub

    Private Function IsPasswordPawned(passwordToCheck As String, methodToUse As MethodToUse) As Boolean
        lStatus.Text = "IsPasswordPawned"

        Dim bPawned As Boolean = False

        Try

            lPassword.Text = passwordToCheck

            'sha hash
            Dim sha1 = getSHA1Hash(passwordToCheck)

            lPasswordHash.Text = sha1

            'get first 5
            Dim hash5 = Mid(sha1, 1, 5)

            'form webapi
            tbURI.Text = tbWebApi.Text.Replace("{0}", hash5)

            'response data
            Dim apiResponseData As String = String.Empty

            'timespan
            Dim timeSpan = New TimeSpan(Integer.Parse(clbPasswordsToCheck.Tag.ToString()))

            If methodToUse = MethodToUse.WebClient Then

                'webclient with timeout....
                Using client As New WebClientWithTimeout(timeSpan)
                    apiResponseData = client.DownloadString(tbURI.Text)
                End Using

            End If

            If methodToUse = MethodToUse.HttpClient Then

                'httpclient
                Using httpClient = New HttpClient()
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36")
                    httpClient.Timeout = timeSpan
                    apiResponseData = httpClient.GetStringAsync(New Uri(tbURI.Text)).Result
                End Using

            End If

            If Not String.IsNullOrEmpty(apiResponseData) Then
                bPawned = LoopAndCheckIsPasswordPawned(apiResponseData, sha1, hash5)
            End If

        Catch ex As Exception
            lStatus.Text = String.Format("IsPasswordPawnedV2 Error: {0}", ex.Message)
        End Try

        Return bPawned
    End Function

    Private Function LoopAndCheckIsPasswordPawned(apiResponseData As String, sha1 As String, hash5 As String) As Boolean

        Dim bPawned = False

        Dim data As List(Of String) = apiResponseData.Split(New String() {Environment.NewLine}, StringSplitOptions.None).ToList()

        lDataCount.Text = data.Count.ToString()

        lbResponse.DataSource = data


        For counter As Integer = 0 To lbResponse.Items.Count - 1
            Application.DoEvents()

            lbResponse.SetSelected(counter, True)
            'clbResponse.TopIndex = counter

            Dim partSplit = lbResponse.Items(counter).ToString.Split(New Char() {":"c})

            Dim partSplitHash5 = String.Format("{0}{1}", hash5, partSplit(0))
            Dim partSplitHash5Count = partSplit(1)

            If partSplitHash5.ToLower() = sha1.ToLower() Then
                bPawned = True
                Exit For
            End If

            If Not bStop.Enabled Then
                Exit For
            End If

        Next

        lbResponse.DataSource = Nothing
        lDataCount.Text = "0"

        Return bPawned

    End Function

    Function getSHA1Hash(ByVal strToHash As String) As String
        lStatus.Text = "getSHA1Hash"

        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function

#End Region


End Class


Public Class WebClientWithTimeout
    Inherits WebClient

    Private ReadOnly _timeSpan As TimeSpan

    Public Sub New()
        _timeSpan = New TimeSpan(5000000)
    End Sub

    Public Sub New(timeSpan As TimeSpan)
        _timeSpan = timeSpan
    End Sub

    Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
        Dim wr As WebRequest = MyBase.GetWebRequest(address)
        wr.Timeout = _timeSpan.Milliseconds ' // timeout in milliseconds (ms)
        Return wr
    End Function
End Class
