
Imports MySql.Data.MySqlClient


Public Class mainForm

    Dim connection As String = "server=127.0.0.1; user=root; database=roomdb; password="
    Dim Con As New MySqlConnection(connection)


    Public Sub Populate()
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim sql As String = "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, CheckOut, NumberOfGuess, Status FROM Booking"
        Dim cmd As New MySqlCommand(sql, Con)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds, "Booking")
        DGVshuttle.DataSource = ds.Tables("Booking")

        Con.Close()
    End Sub

    Public Sub PopulateHistory()
        Try
            Con.Open()

            Dim sql As String = "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, CheckOut, NumberOfGuess FROM BookingHistory"
            Dim cmd As New MySqlCommand(sql, Con)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet()

            adapter.Fill(ds, "BookingHistory")

            DataGridView1.DataSource = ds.Tables("BookingHistory")

        Catch ex As Exception
            ' Handle exceptions (e.g., display an error message)
            MessageBox.Show("An error occurred: " & ex.Message)

        Finally
            ' Close the connection in the finally block to ensure it gets closed
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try

    End Sub
    Public Sub PopulateMaintenance()
        Con.Open()
        Dim sql As String = "SELECT Id, RoomNo FROM RoomMaintenance"
        Dim cmd As New MySqlCommand(sql, Con)
        Dim adapter As New MySqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds, "RoomMaintenance")
        DataGridView2.DataSource = ds.Tables("RoomMaintenance")
        Con.Close()
    End Sub


    Private Sub status()


        Dim query As String = "SELECT Status FROM RoomAvailability"

        Using connection As New MySqlConnection(Con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Counter to keep track of TextBox index
                    Dim index As Integer = 1

                    ' Loop through all the rows returned by the query
                    While reader.Read()
                        ' Assuming "Status" is a string column
                        Dim status As String = reader("Status").ToString()

                        ' Set the text of the TextBoxes based on the retrieved status
                        Select Case index
                            Case 1
                                tbStatus1.Text = "Status: " + status.ToUpper()
                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel2.BackColor = Color.Orange
                                    PictureBox1.Image = My.Resources.booked
                                Else
                                    Panel2.BackColor = Color.Red
                                    PictureBox1.Image = My.Resources.maintenance
                                End If

                            Case 2
                                tbStatu2.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel3.BackColor = Color.Orange
                                    PictureBox2.Image = My.Resources.booked
                                Else
                                    Panel3.BackColor = Color.Red
                                    PictureBox2.Image = My.Resources.maintenance
                                End If
                            Case 3
                                tbStatus3.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel4.BackColor = Color.Orange
                                    PictureBox3.Image = My.Resources.booked
                                Else
                                    Panel4.BackColor = Color.Red
                                    PictureBox3.Image = My.Resources.maintenance
                                End If
                            Case 4
                                tbStatus4.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel5.BackColor = Color.Orange
                                    PictureBox4.Image = My.Resources.booked
                                Else
                                    Panel5.BackColor = Color.Red
                                    PictureBox4.Image = My.Resources.maintenance
                                End If

                            Case 5
                                tbStatus5.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel6.BackColor = Color.Orange
                                    PictureBox5.Image = My.Resources.booked
                                Else
                                    Panel6.BackColor = Color.Red
                                    PictureBox5.Image = My.Resources.maintenance
                                End If
                            Case 6
                                tbStatus6.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel7.BackColor = Color.Orange
                                    PictureBox6.Image = My.Resources.booked
                                Else
                                    Panel7.BackColor = Color.Red
                                    PictureBox6.Image = My.Resources.maintenance
                                End If
                            Case 7
                                tbStatus7.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel13.BackColor = Color.Orange
                                    PictureBox12.Image = My.Resources.booked
                                Else
                                    Panel13.BackColor = Color.Red
                                    PictureBox12.Image = My.Resources.maintenance
                                End If

                            Case 8
                                tbStatus8.Text = "Status: " + status

                                If (status = "AVAILABLE") Then
                                ElseIf (status = "OCCUPIED") Then
                                    Panel12.BackColor = Color.Orange
                                    PictureBox11.Image = My.Resources.booked
                                Else
                                    Panel12.BackColor = Color.Red
                                    PictureBox11.Image = My.Resources.maintenance
                                End If
                            Case 9
                                tbStatus9.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel11.BackColor = Color.Orange
                                    PictureBox10.Image = My.Resources.booked
                                Else
                                    Panel11.BackColor = Color.Red
                                    PictureBox10.Image = My.Resources.maintenance
                                End If
                            Case 10
                                tbStatus10.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel10.BackColor = Color.Orange
                                    PictureBox9.Image = My.Resources.booked
                                Else
                                    Panel10.BackColor = Color.Red
                                    PictureBox9.Image = My.Resources.maintenance
                                End If
                            Case 11
                                tbStatus11.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel9.BackColor = Color.Orange
                                    PictureBox8.Image = My.Resources.booked
                                Else
                                    Panel9.BackColor = Color.Red
                                    PictureBox8.Image = My.Resources.maintenance
                                End If
                            Case 12
                                tbStatus12.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel8.BackColor = Color.Orange
                                    PictureBox7.Image = My.Resources.booked
                                Else
                                    Panel8.BackColor = Color.Red
                                    PictureBox7.Image = My.Resources.maintenance

                                End If
                            Case 13
                                tbStatus13.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel19.BackColor = Color.Orange
                                    PictureBox18.Image = My.Resources.booked
                                Else
                                    Panel19.BackColor = Color.Red
                                    PictureBox18.Image = My.Resources.maintenance
                                End If
                            Case 14
                                tbStatus14.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel18.BackColor = Color.Orange
                                    PictureBox17.Image = My.Resources.booked
                                Else
                                    Panel18.BackColor = Color.Red
                                    PictureBox17.Image = My.Resources.maintenance
                                End If
                            Case 15
                                tbStatus15.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel17.BackColor = Color.Orange
                                    PictureBox16.Image = My.Resources.booked
                                Else
                                    Panel17.BackColor = Color.Red
                                    PictureBox16.Image = My.Resources.maintenance
                                End If
                            Case 16
                                tbStatus16.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel16.BackColor = Color.Orange
                                    PictureBox15.Image = My.Resources.booked
                                Else
                                    Panel16.BackColor = Color.Red
                                    PictureBox15.Image = My.Resources.maintenance
                                End If
                            Case 17
                                tbStatus17.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel15.BackColor = Color.Orange
                                    PictureBox14.Image = My.Resources.booked
                                Else
                                    Panel15.BackColor = Color.Red
                                    PictureBox14.Image = My.Resources.maintenance
                                End If
                            Case 18
                                tbStatus18.Text = "Status: " + status

                                If (status = "AVAILABLE") Then

                                ElseIf (status = "OCCUPIED") Then
                                    Panel14.BackColor = Color.Orange
                                    PictureBox13.Image = My.Resources.booked
                                Else
                                    Panel14.BackColor = Color.Red
                                    PictureBox13.Image = My.Resources.maintenance
                                End If

                        End Select

                        ' Increment the index for the next TextBox
                        index += 1
                    End While
                End Using
            End Using
        End Using

    End Sub



    Public Sub ClearBtn()
        Fname.Text = ""
        Lname.Text = ""
        Cnumber.Text = ""
        timeIn.Text = ""
        roomNo.Text = ""
        noOfGuess.Text = ""
        ShuttleId.Text = ""
        roomNumber2.Text = ""
        roomId.Text = ""
        isOccupied.Text = ""

    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RoomDbDataSet.historyInfo' table. You can move, or remove it, as needed.
        'Me.HistoryInfoTableAdapter.Fill(Me.RoomDbDataSet.historyInfo)
        'TODO: This line of code loads data into the 'InformationDBDataSet.shuttleInfo' table. You can move, or remove it, as needed.

        TabPage1.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage2.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage3.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage4.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        'StatusIsAvailable()
        Populate()
        PopulateHistory()
        PopulateMaintenance()
        status()

    End Sub





    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles MaintenanceBtn.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles ShuttleBtn.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles ParkingBtn.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Lname.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub booking_Click(sender As Object, e As EventArgs) Handles booking.Click
        If ShuttleId.Text = "" Then
            Dim myId As Guid = Guid.NewGuid()
            Dim myIdString = myId.ToString().Substring(0, 6)
            ShuttleId.Text = myIdString

        End If
        Try
            If String.IsNullOrWhiteSpace(Lname.Text) OrElse
       String.IsNullOrWhiteSpace(Fname.Text) OrElse
       String.IsNullOrWhiteSpace(Lname.Text) OrElse
       String.IsNullOrWhiteSpace(Cnumber.Text) OrElse
       String.IsNullOrWhiteSpace(CheckOut.Text) OrElse
       String.IsNullOrWhiteSpace(roomNo.Text) OrElse
       String.IsNullOrWhiteSpace(noOfGuess.Text) OrElse
       String.IsNullOrWhiteSpace(timeIn.Text) Then
                MsgBox("Insert complete details.")
            Else
                Dim roomNumber As String = roomNo.Text.ToUpper()
                Dim validRoomNumbers() As String = {"101", "102", "103", "104", "105", "106", "201", "202", "203", "204", "205", "206", "301", "302", "303", "304", "305", "306"}
                If Not validRoomNumbers.Contains(roomNumber) Then
                    MessageBox.Show("Room " & roomNumber & " Not found")
                Else
                    Con.Open()
                    Dim query As String = "INSERT INTO Booking (Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, Status) VALUES (@Id, @LastName, @FirstName, @ContactNo, @RoomNo, NOW(), @NumberOfGuess, @CheckOut, @isOccupied)"

                    Dim checkOutDate As DateTime = CheckOut.Value
                    isOccupied.Text = "Check_In"

                    Using cmd As New MySqlCommand(query, Con)
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text)
                        cmd.Parameters.AddWithValue("@LastName", Lname.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@FirstName", Fname.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@RoomNo", roomNumber)
                        cmd.Parameters.AddWithValue("@NumberOfGuess", noOfGuess.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@ContactNo", Cnumber.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@isOccupied", isOccupied.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@CheckOut", checkOutDate)
                        cmd.ExecuteNonQuery()
                    End Using
                    'KELANGAN KO IUPDATE YUNG ROOM AVAILABILITY 


                    'Dim addRooms As String = "INSERT INTO RoomAvailabilityy (RoomNo, Status) VALUES (@roomNo, @status );"
                    'Using cmds As New MySqlCommand(addRooms, Con)
                    '    cmds.Parameters.AddWithValue("@roomNo", roomNo.Text)
                    '    cmds.Parameters.AddWithValue("@status", "AVAILABLE")
                    '    cmds.ExecuteNonQuery()
                    'End Using



                    Dim sql = "UPDATE RoomAvailability SET Status=@status WHERE RoomNo=@roomNo"
                    Dim cmds As New MySqlCommand(sql, Con)
                    cmds.Parameters.AddWithValue("@Status", "OCCUPIED")
                    cmds.Parameters.AddWithValue("@roomNo", roomNo.Text)
                    cmds.ExecuteNonQuery()


                    Con.Close()
                    MsgBox("Added successfully!")
                    Populate()
                    status()
                    'fetchIfOccupied()
                    'RoomAvailability()
                    ClearBtn()
                End If
            End If
        Catch ex As Exception
            Con.Close()
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub remove_Click(sender As Object, e As EventArgs) Handles Remove.Click
        Dim connectionString As String = "server=127.0.0.1; user=root; database=roomdb; password="
        Try
            If ShuttleId.Text = "" Then
                MessageBox.Show("Select a customer before checking out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Using Con As New MySqlConnection(connectionString)
                    Con.Open()

                    Dim transferQuery As String = "INSERT INTO BookingHistory (Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, Status) " &
        "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, Status " &
        "FROM Booking " &
        "WHERE Id = @Id"

                    Using cmd As New MySqlCommand(transferQuery, Con)
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text)
                        MsgBox("Checking out successfully")
                        cmd.ExecuteNonQuery()
                    End Using



                    'Dim sqls = "UPDATE Booking SET Status=@status"
                    'Dim cmdss As New MySqlCommand(sqls, Con)
                    'cmdss.Parameters.AddWithValue("@Status", "Check_In")

                    'cmdss.ExecuteNonQuery()





                    Dim sql = "UPDATE RoomAvailability SET Status=@status WHERE RoomNo=@roomNo"
                    Dim cmds As New MySqlCommand(sql, Con)
                    cmds.Parameters.AddWithValue("@Status", "AVAILABLE")
                    cmds.Parameters.AddWithValue("@roomNo", roomNo.Text)
                    cmds.ExecuteNonQuery()

                    isOccupied.Text = "Check_Out"
                    Dim updateQuery As String = "UPDATE Booking SET Status = @Value1 WHERE Id = @Id"

                    Using cmd As New MySqlCommand(updateQuery, Con)
                        ' Assuming ShuttleId.Text contains the value for the Id parameter
                        cmd.Parameters.AddWithValue("@Value1", isOccupied.Text.ToUpper()) ' Replace "NewStatusValue" with the actual value
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text) ' Assuming ShuttleId.Text contains the value for the Id parameter

                        ' Execute the query
                        cmd.ExecuteNonQuery()


                    End Using



                End Using
                ClearBtn()
                Populate()
                PopulateHistory()
                status()
            End If
        Catch ex As Exception

            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub DGVshuttle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVshuttle.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.DGVshuttle.Rows(e.RowIndex)
            Lname.Text = row.Cells("LastName").Value.ToString()
            Fname.Text = row.Cells("FirstName").Value.ToString()
            Cnumber.Text = row.Cells("ContactNo").Value.ToString()
            timeIn.Text = row.Cells("CheckIn").Value.ToString()
            roomNo.Text = row.Cells("RoomNo").Value.ToString()
            noOfGuess.Text = row.Cells("NumberOfGuess").Value.ToString()
            CheckOut.Text = row.Cells("CheckOut").Value.ToString()
            ShuttleId.Text = row.Cells("Id").Value.ToString()
            isOccupied.Text = row.Cells("Status").Value.ToString()

        End If
    End Sub

    Private Sub driverIdNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fname.KeyPress

    End Sub

    Private Sub clientRoomNo_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub clientRoomNo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub noOfPassenger_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub clientRoomNoPark_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub parkingSpaceNo_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub pickUpLoc_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        ClearBtn()
    End Sub

    Private Sub Cnumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cnumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Restart()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles search.TextChanged

        Dim query As String = "SELECT * FROM BookingHistory WHERE RoomNo LIKE @searchPattern OR LastName LIKE @searchPattern OR FirstName LIKE @searchPattern"
        Using Con As New MySqlConnection("server=127.0.0.1; user=root; database=roomdb; password=")
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@searchPattern", "%" & search.Text & "%")
                Using da As New MySqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            DataGridView1.DataSource = dt
                        Else
                            MsgBox("Record not found!")
                            search.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub





    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim validRoomNumbers() As String = {"101", "102", "103", "104", "105", "106", "201", "202", "203", "204", "205", "206", "301", "302", "303", "304", "305", "306"}
        If Not validRoomNumbers.Contains(roomNumber2.Text) Then
            MessageBox.Show("Room " & roomNumber2.Text & " Not found")
        Else
            Con.Open()
            If roomId.Text = "" Then
                Dim myId As Guid = Guid.NewGuid()
                Dim myIdString = myId.ToString().Substring(0, 6)
                roomId.Text = myIdString
            End If
            isOccupied.Text = "UNDER_MAINTENANCE"
            Dim query As String = "INSERT INTO RoomMaintenance (Id, RoomNo, Status) VALUES (@Id, @RoomNo, @status)"
            Using cmd1 As New MySqlCommand(query, Con)
                cmd1.Parameters.AddWithValue("@Id", roomId.Text)
                cmd1.Parameters.AddWithValue("@RoomNo", roomNumber2.Text)
                cmd1.Parameters.AddWithValue("@status", isOccupied.Text)
                cmd1.ExecuteNonQuery()
            End Using


            Dim sql = "UPDATE RoomAvailability SET Status=@status WHERE RoomNo=@roomNo"
            Dim cmds As New MySqlCommand(sql, Con)
            cmds.Parameters.AddWithValue("@status", "UNDER_MAINTENANCE") ' Corrected parameter name
            cmds.Parameters.AddWithValue("@roomNo", roomNumber2.Text)
            cmds.ExecuteNonQuery()

            MsgBox("Room Under Maintenance")


            Con.Close()
            status()
            'RoomAvailability()
            PopulateMaintenance()
            ClearBtn()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Try
            If roomId.Text = "" Then
                MsgBox("Enter room ID to be deleted!")
            Else
                Con.Open()
                Dim deleteQuery As String = "DELETE FROM RoomMaintenance WHERE Id = @Id"
                Using cmd1 As New MySqlCommand(deleteQuery, Con)
                    cmd1.Parameters.AddWithValue("@Id", roomId.Text)
                    cmd1.ExecuteNonQuery()
                End Using

                ' Delete from RoomAvailability
                Dim deleteQuery2 As String = "DELETE FROM RoomAvailability WHERE RoomNo = @RoomNo"
                Using cmd2 As New MySqlCommand(deleteQuery2, Con)
                    cmd2.Parameters.AddWithValue("@RoomNo", roomNumber2.Text)
                    cmd2.ExecuteNonQuery()
                End Using
                MsgBox("Removing Room for maintenance!")

                Dim sql = "UPDATE RoomAvailability SET Status=@status WHERE RoomNo=@roomNo"
                Dim cmds As New MySqlCommand(sql, Con)
                cmds.Parameters.AddWithValue("@status", "AVAILABLE") ' Corrected parameter name
                cmds.Parameters.AddWithValue("@roomNo", roomNumber2.Text)
                cmds.ExecuteNonQuery()



                Con.Close()
                ClearBtn()
                status()
                PopulateMaintenance()
            End If
        Catch ex As Exception
            MsgBox("Error Removing: " & ex.Message)
        End Try
    End Sub

    Private Sub tbStatu2_Click(sender As Object, e As EventArgs) Handles tbStatu2.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
            roomId.Text = row.Cells("Id").Value.ToString()
            roomNumber2.Text = row.Cells("RoomNo").Value.ToString()



        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ClearBtn()
    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs) Handles searchRoom.TextChanged
        Dim query As String = "SELECT * FROM Booking WHERE RoomNo LIKE @searchPattern OR LastName LIKE @searchPattern OR FirstName LIKE @searchPattern"
        Using Con As New MySqlConnection("server=127.0.0.1; user=root; database=roomdb; password=")
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@searchPattern", "%" & searchRoom.Text & "%")
                Using da As New MySqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            DGVshuttle.DataSource = dt
                        Else
                            MsgBox("Record not found!")
                            searchRoom.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Class
