Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class HomeScreen
    Dim tableName As String
    Dim ipAddress As String
    Dim stopWatch As New Stopwatch
    Dim chosenServer As String
    Dim cryptoServiceObj As New RSACryptoServiceProvider
    Dim utf8Encoder As New UTF8Encoding
    Dim headServer As Integer = 1
    Dim sqlConnection As MySqlConnection
    Dim sqlQuery As String
    Dim sqlCommand As MySqlCommand
    Dim sqlDataReader As MySqlDataReader
    Dim output As String
    Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Dim plotGraph_SS_MC(1000), plotGraph_MS_MC(1000), plotGraph_MS_MC_WC(1000) As Integer


    'Single Server - Multiple Client Scenario - BFT
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        tableName = "ss_mc_table"
        ipAddress = DNS_Replica()
        Dim inputText, encryptedText As Byte()
        For i As Integer = 1 To 1000
            stopWatch.Start()
            encryptedText = CryptoService(i)
            inputText = cryptoServiceObj.Decrypt(encryptedText, True)
            'text2 = encoder.GetString(textbytes)
            stopWatch.Stop()
            SaveElapsedTime(i, tableName)
        Next
        TextBox1.Text = stopWatch.ElapsedMilliseconds.ToString
        stopWatch.Reset()
    End Sub



    'Multiple Server - Multiple Client Scenario - SAREK
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        tableName = "ms_mc_table"
        ipAddress = DNS_Replica()
        For i As Integer = 1 To 1000
            stopWatch.Start()
            chosenServer = ServerResultValidation(i)
            stopWatch.Stop()
            SaveElapsedTime(i, tableName)
        Next
        TextBox2.Text = stopWatch.ElapsedMilliseconds.ToString
        stopWatch.Reset()
    End Sub


    'Multiple Server - Multiple Client Scenario - With CryptoService
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Text = ""
        tableName = "ms_mc_wc_table"
        ipAddress = DNS_Replica()
        Dim inputText, encryptedText As Byte()
        For i As Integer = 1 To 1000
            stopWatch.Start()
            encryptedText = ServerResultValidationWithCrypto(i)
            inputText = cryptoServiceObj.Decrypt(encryptedText, True)
            'text2 = encoder.GetString(textbytes)
            stopWatch.Stop()
            SaveElapsedTime(i, tableName)
        Next
        TextBox3.Text = stopWatch.ElapsedMilliseconds.ToString
        stopWatch.Reset()
    End Sub



    Private Sub SaveElapsedTime(i As Integer, tableName As String)
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;userid=root;password=sarvesh;database=bft_db"
        sqlQuery = "insert into " + tableName + " values('" + i.ToString + "','" + stopWatch.ElapsedMilliseconds.ToString + "');"
        Try
            sqlConnection.Open()
            sqlCommand = New MySqlCommand
            sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
            sqlDataReader = sqlCommand.ExecuteReader
            While sqlDataReader.Read
                output = sqlDataReader(1).ToString
            End While
            sqlConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ServerResultValidation(i As Integer) As String
        Dim a, b, c, d, returnString As String
        a = ServerConfiguration_1(i)
        'b = ServerConfiguration_2(i)
        'c = ServerConfiguration_3(i)
        'd = ServerConfiguration_4(i)

        b = ServerConfiguration_1(i)
        c = ServerConfiguration_1(i)
        d = ServerConfiguration_1(i)
        returnString = ""

        headServer = headServer + 1
        If headServer = 5 Then
            headServer = 1
        End If

        If a = b And b = c And c = d Then
            returnString = a
        ElseIf a = b And b = c And Not c = d Then
            returnString = a
            If headServer = 4 Then
                headServer = 1
            End If
        ElseIf a = b And b = d And Not b = c Then
            returnString = a
            If headServer = 3 Then
                headServer = headServer + 1
            End If
        ElseIf b = c And c = d Then
            If headServer = 1 Then
                headServer = 2
            End If
            returnString = b
        End If

        Return returnString
    End Function

    'Private Function ServerConfiguration_4(i As Integer) As String
    '    Throw New NotImplementedException()
    'End Function

    'Private Function ServerConfiguration_3(i As Integer) As String
    '    Throw New NotImplementedException()
    'End Function

    'Private Function ServerConfiguration_2(i As Integer) As String
    '    Throw New NotImplementedException()
    'End Function

    Private Function ServerConfiguration_1(i As Integer) As String
        Dim returnString As String
        returnString = ReadFromDatabase(i)
        Return returnString
    End Function

    Private Function ServerResultValidationWithCrypto(i As Integer) As Byte()
        Dim a, b, c, d, returnString As String
        a = ServerConfiguration_1(i)
        'b = ServerConfiguration_2(i)
        'c = ServerConfiguration_3(i)
        'd = ServerConfiguration_4(i)

        b = ServerConfiguration_1(i)
        c = ServerConfiguration_1(i)
        d = ServerConfiguration_1(i)
        returnString = ""

        headServer = headServer + 1
        If headServer = 5 Then
            headServer = 1
        End If

        If a = b And b = c And c = d Then
            returnString = a
        ElseIf a = b And b = c And Not c = d Then
            returnString = a
            If headServer = 4 Then
                headServer = 1
            End If
        ElseIf a = b And b = d And Not b = c Then
            returnString = a
            If headServer = 3 Then
                headServer = headServer + 1
            End If
        ElseIf b = c And c = d Then
            If headServer = 1 Then
                headServer = 2
            End If
            returnString = b
        End If

        Dim inputText, encryptedText As Byte()
        inputText = utf8Encoder.GetBytes(returnString)
        encryptedText = cryptoServiceObj.Encrypt(inputText, True)
        Return encryptedText

    End Function

    Private Function DNS_Replica() As String
        Dim returnString As String = ""
        If headServer = 1 Then
            returnString = "190.17.12.1"
        ElseIf headServer = 2 Then
            returnString = "190.17.12.2"
        ElseIf headServer = 3 Then
            returnString = "190.17.12.3"
        ElseIf headServer = 4 Then
            returnString = "190.17.12.4"
        End If
        Return returnString
    End Function

    Private Function CryptoService(i As Integer) As Byte()
        Dim textFromDB As String
        textFromDB = ReadFromDatabase(i)
        Dim inputText, encryptedText As Byte()
        inputText = utf8Encoder.GetBytes(textFromDB)
        encryptedText = cryptoServiceObj.Encrypt(inputText, True)
        Return encryptedText
    End Function

    Private Function ReadFromDatabase(i As Integer) As String
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;uid=root;password=sarvesh;database=bft_db"
        sqlQuery = "select * from text_table where entry_count='" + i.ToString + "'"
        Try
            sqlConnection.Open()
            sqlCommand = New MySqlCommand
            sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
            sqlDataReader = sqlCommand.ExecuteReader
            While sqlDataReader.Read
                output = sqlDataReader(1).ToString
            End While
            sqlConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
        Return output
    End Function

    'Generate data for the text table
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;userid=root;password=sarvesh;database=bft_db"
        Dim textFlag As Boolean = False
        sqlQuery = "insert into text_table values "
        For i As Integer = 1 To 1000
            If (Not textFlag And Not i = 1000) Then
                sqlQuery += "('" + i.ToString() + "','A'),"
                textFlag = True
            ElseIf (textFlag And Not i = 1000) Then
                sqlQuery += "('" + i.ToString() + "','B'),"
                textFlag = False
            ElseIf (Not textFlag And i = 1000) Then
                sqlQuery += "('" + i.ToString() + "','A');"
            ElseIf (textFlag And i = 1000) Then
                sqlQuery += "('" + i.ToString() + "','B');"
            End If
        Next
        Try
            sqlConnection.Open()
            sqlCommand = New MySqlCommand
            sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
            sqlDataReader = sqlCommand.ExecuteReader
            sqlConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Flush all the tables
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;userid=root;password=sarvesh;database=bft_db"
        sqlQuery = "truncate text_table; truncate ms_mc_table; truncate ss_mc_table; truncate ms_mc_wc_table;"
        Try
            sqlConnection.Open()
            sqlCommand = New MySqlCommand
            sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
            sqlDataReader = sqlCommand.ExecuteReader
            sqlConnection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Display SS_MC Scenario Table
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim outputString As String = ""
        outputString += "SS_MC_Table" + Environment.NewLine
        'outputString += "client_request_count" + ControlChars.Tab + "elapsed_time" + Environment.NewLine
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;uid=root;password=sarvesh;database=bft_db"
        For i As Integer = 1 To 1000
            sqlQuery = "select * from ss_mc_table where client_request_count='" + i.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    output = sqlDataReader(1).ToString
                    outputString += i.ToString + ControlChars.Tab + output + Environment.NewLine
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        My.Computer.FileSystem.WriteAllText(Path.Combine(mydocpath, "SS_MC_Table.txt"), outputString, True)
        Dim content As String = ""
        Using textReader As New System.IO.StreamReader(Path.Combine(mydocpath, "SS_MC_Table.txt"))
            content = textReader.ReadToEnd
        End Using
        ShowTable.RichTextBox1.Text = content
        ShowTable.Show()
    End Sub

    'Display MS_MC Scenario Table
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim outputString As String = ""
        outputString += "MS_MC_Table" + Environment.NewLine
        'outputString += "client_request_count" + ControlChars.Tab + "elapsed_time" + Environment.NewLine
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;uid=root;password=sarvesh;database=bft_db"
        For i As Integer = 1 To 1000
            sqlQuery = "select * from ms_mc_table where client_request_count='" + i.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    output = sqlDataReader(1).ToString
                    outputString += i.ToString + ControlChars.Tab + output + Environment.NewLine
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        My.Computer.FileSystem.WriteAllText(Path.Combine(mydocpath, "MS_MC_Table.txt"), outputString, True)
        Dim content As String = ""
        Using textReader As New System.IO.StreamReader(Path.Combine(mydocpath, "MS_MC_Table.txt"))
            content = textReader.ReadToEnd
        End Using
        ShowTable.RichTextBox1.Text = content
        ShowTable.Show()
    End Sub

    'Display MS_MC_WC Scenario Table
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim outputString As String = ""
        outputString += "MS_MC_WC_Table" + Environment.NewLine
        'outputString += "client_request_count" + ControlChars.Tab + "elapsed_time" + Environment.NewLine
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;uid=root;password=sarvesh;database=bft_db"
        For i As Integer = 1 To 1000
            sqlQuery = "select * from ms_mc_wc_table where client_request_count='" + i.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    output = sqlDataReader(1).ToString
                    outputString += i.ToString + ControlChars.Tab + output + Environment.NewLine
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        My.Computer.FileSystem.WriteAllText(Path.Combine(mydocpath, "MS_MC_WC_Table.txt"), outputString, True)
        Dim content As String = ""
        Using textReader As New System.IO.StreamReader(Path.Combine(mydocpath, "MS_MC_WC_Table.txt"))
            content = textReader.ReadToEnd
        End Using
        ShowTable.RichTextBox1.Text = content
        ShowTable.Show()
    End Sub

    'Load SS_MC Scenario - Graph Generation
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim intValue As Integer = getDataToBuildGraph()

        For x As Integer = 0 To 999
            OutputGraph.FinalChart.Series("Single Server - Multiple Clients").Points.AddXY(x, plotGraph_SS_MC(x))
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisX.Title = "Number Of Request From Clients"
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisY.Title = "Time Taken To Process The Requests In Milli Seconds"
        Next
        OutputGraph.Show()
    End Sub

    'Load MS_MC Scenario - Graph Generation
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim intValue As Integer = getDataToBuildGraph()

        For x As Integer = 0 To 999
            OutputGraph.FinalChart.Series("Multiple Server - Multiple Clients").Points.AddXY(x, plotGraph_MS_MC(x))
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisX.Title = "Number Of Request From Clients"
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisY.Title = "Time Taken To Process The Requests In Milli Seconds"
        Next
        OutputGraph.Show()
    End Sub

    'Load MS_MC_WC Scenario - Graph Generation
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim intValue As Integer = getDataToBuildGraph()

        For x As Integer = 0 To 999
            OutputGraph.FinalChart.Series("Multiple Server - Multiple Clients - With CryptoService").Points.AddXY(x, plotGraph_MS_MC_WC(x))
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisX.Title = "Number Of Request From Clients"
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisY.Title = "Time Taken To Process The Requests In Milli Seconds"
        Next
        OutputGraph.Show()
    End Sub

    'Load All Scenarios - Graph Generation
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim intValue As Integer = getDataToBuildGraph()

        For x As Integer = 0 To 999
            OutputGraph.FinalChart.Series("Single Server - Multiple Clients").Points.AddXY(x, plotGraph_SS_MC(x))
            OutputGraph.FinalChart.Series("Multiple Server - Multiple Clients").Points.AddXY(x, plotGraph_MS_MC(x))
            OutputGraph.FinalChart.Series("Multiple Server - Multiple Clients - With CryptoService").Points.AddXY(x, plotGraph_MS_MC_WC(x))
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisX.Title = "Number Of Request From Clients"
            OutputGraph.FinalChart.ChartAreas("ChartArea1").AxisY.Title = "Time Taken To Process The Requests In Milli Seconds"
        Next
        OutputGraph.Show()
    End Sub

    Private Function getDataToBuildGraph() As Integer
        sqlConnection = New MySqlConnection
        sqlConnection.ConnectionString = "server=localhost;uid=root;password=sarvesh;database=bft_db"
        For x As Integer = 1 To 1000
            sqlQuery = "select * from ss_mc_table where client_request_count='" + x.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    x = x - 1
                    plotGraph_SS_MC(x) = sqlDataReader(1).ToString
                    x = x + 1
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        For x As Integer = 1 To 1000
            sqlQuery = "select * from ms_mc_table where client_request_count='" + x.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    x = x - 1
                    plotGraph_MS_MC(x) = sqlDataReader(1).ToString
                    x = x + 1
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        For x As Integer = 1 To 1000
            sqlQuery = "select * from ms_mc_wc_table where client_request_count='" + x.ToString + "'"
            Try
                sqlConnection.Open()
                sqlCommand = New MySqlCommand
                sqlCommand = New MySqlCommand(sqlQuery, sqlConnection)
                sqlDataReader = sqlCommand.ExecuteReader
                While sqlDataReader.Read
                    X = X - 1
                    plotGraph_MS_MC_WC(x) = sqlDataReader(1).ToString
                    x = X + 1
                End While
                sqlConnection.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        Next
        Dim i As Integer = 1
        Return i
    End Function
End Class
