Imports System.Data.SqlClient
Public Class mainForm
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\OneDrive\Documents\RoomDb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim adp As SqlDataAdapter

    Public Sub populate()
        Con.Open()
        Dim sql As String = "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, CheckOut, NumberOfGuess,isOccupied FROM roomInfo"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        DGVshuttle.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Public Sub populateHistory()
        Con.Open()
        Dim sql As String = "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, CheckOut, NumberOfGuess FROM historyInfo"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Public Sub populateMaintenance()
        Con.Open()
        Dim sql As String = "SELECT Id,RoomNo FROM mainteInfo"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        Con.Close()
    End Sub


    Public Sub RoomAvailability()
        Con.Open()

        Dim query As String = "INSERT INTO RoomAvailability (Room101, Room102, Room103, Room104, Room105, Room106, Room201, Room202, Room203, Room204, Room205, Room206, Room301, Room302, Room303, Room304, Room305, Room306, RoomNumber) " &
                         "VALUES (@Room101, @Room102, @Room103, @Room104, @Room105, @Room106, @Room201, @Room202, @Room203, @Room204, @Room205, @Room206, @Room301, @Room302, @Room303, @Room304, @Room305, @Room306, @RoomNumber)"

        Using cmd As New SqlCommand(query, Con)
            ' Replace the following isOccupied.Text with the actual values you want to insert for each room
            cmd.Parameters.AddWithValue("@Room101", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room102", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room103", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room104", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room105", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room106", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room201", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room202", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room203", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room204", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room205", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room206", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room301", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room302", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room303", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room304", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room305", isOccupied.Text)
            cmd.Parameters.AddWithValue("@Room306", isOccupied.Text)
            cmd.Parameters.AddWithValue("@RoomNumber", roomNumber2.Text)
            cmd.ExecuteNonQuery()
        End Using

        Con.Close()
    End Sub


    Private Sub fetchIfOccupied()
        Con.Open()
        Dim query = "SELECT * FROM roomInfo"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Dim status = reader(8).ToString()
            Dim roomNumber = reader(4).ToString()
            Select Case roomNumber
                Case 101
                    tbStatus1.Text = "Status: " + status
                    Panel2.BackColor = Color.Orange
                    PictureBox1.Image = My.Resources.booked
                Case 102
                    tbStatu2.Text = "Status: " + status
                    Panel3.BackColor = Color.Orange
                    PictureBox2.Image = My.Resources.booked
                Case 103
                    tbStatus3.Text = "Status: " + status
                    Panel4.BackColor = Color.Orange
                    PictureBox3.Image = My.Resources.booked
                Case 104
                    tbStatus4.Text = "Status: " + status
                    Panel5.BackColor = Color.Orange
                    PictureBox4.Image = My.Resources.booked
                Case 105
                    tbStatus5.Text = "Status: " + status
                    Panel6.BackColor = Color.Orange
                    PictureBox5.Image = My.Resources.booked
                Case 106
                    tbStatus6.Text = "Status: " + status
                    Panel7.BackColor = Color.Orange
                    PictureBox6.Image = My.Resources.booked
                Case 201
                    tbStatus7.Text = "Status: " + status
                    Panel13.BackColor = Color.Orange
                    PictureBox12.Image = My.Resources.booked
                Case 202
                    tbStatus8.Text = "Status: " + status
                    Panel12.BackColor = Color.Orange
                    PictureBox11.Image = My.Resources.booked
                Case 203
                    tbStatus9.Text = "Status: " + status
                    Panel11.BackColor = Color.Orange
                    PictureBox10.Image = My.Resources.booked
                Case 204
                    tbStatus10.Text = "Status: " + status
                    Panel10.BackColor = Color.Orange
                    PictureBox9.Image = My.Resources.booked
                Case 205
                    tbStatus11.Text = "Status: " + status
                    Panel9.BackColor = Color.Orange
                    PictureBox8.Image = My.Resources.booked
                Case 206
                    tbStatus12.Text = "Status: " + status
                    Panel8.BackColor = Color.Orange
                    PictureBox7.Image = My.Resources.booked
                Case 301
                    tbStatus13.Text = "Status: " + status
                    Panel19.BackColor = Color.Orange
                    PictureBox18.Image = My.Resources.booked
                Case 302
                    tbStatus14.Text = "Status: " + status
                    Panel18.BackColor = Color.Orange
                    PictureBox17.Image = My.Resources.booked
                Case 303
                    tbStatus15.Text = "Status: " + status
                    Panel17.BackColor = Color.Orange
                    PictureBox16.Image = My.Resources.booked
                Case 304
                    tbStatus16.Text = "Status: " + status
                    Panel16.BackColor = Color.Orange
                    PictureBox15.Image = My.Resources.booked
                Case 305
                    tbStatus17.Text = "Status: " + status
                    Panel15.BackColor = Color.Orange
                    PictureBox14.Image = My.Resources.booked
                Case 306
                    tbStatus18.Text = "Status: " + status
                    Panel14.BackColor = Color.Orange
                    PictureBox13.Image = My.Resources.booked
                Case Else
                    MessageBox.Show("Room " & roomNumber.ToString() & " Not found")
            End Select
        End While
        Con.Close()

    End Sub

    Private Sub fetchStatus()
        Con.Open()
        Dim query = "SELECT * FROM RoomAvailability"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Dim status1 = reader(1).ToString()
            Dim status2 = reader(2).ToString()
            Dim status3 = reader(3).ToString()
            Dim status4 = reader(4).ToString()
            Dim status5 = reader(5).ToString()
            Dim status6 = reader(6).ToString()
            Dim status7 = reader(7).ToString()
            Dim status8 = reader(8).ToString()
            Dim status9 = reader(9).ToString()
            Dim status10 = reader(10).ToString()
            Dim status11 = reader(11).ToString()
            Dim status12 = reader(12).ToString()
            Dim status13 = reader(13).ToString()
            Dim status14 = reader(14).ToString()
            Dim status15 = reader(15).ToString()
            Dim status16 = reader(16).ToString()
            Dim status17 = reader(17).ToString()
            Dim status18 = reader(18).ToString()
            Dim roomNumber = reader(19).ToString()

            Select Case roomNumber
                Case 101
                    tbStatus1.Text = "Status: " + status1
                    Panel2.BackColor = Color.Red
                    PictureBox1.Image = My.Resources.maintenance
                Case 102
                    tbStatu2.Text = "Status: " + status2
                    Panel3.BackColor = Color.Red
                    PictureBox2.Image = My.Resources.maintenance
                Case 103
                    tbStatus3.Text = "Status: " + status3
                    Panel4.BackColor = Color.Red
                    PictureBox3.Image = My.Resources.maintenance
                Case 104
                    tbStatus4.Text = "Status: " + status4
                    Panel5.BackColor = Color.Red
                    PictureBox4.Image = My.Resources.maintenance
                Case 105
                    tbStatus5.Text = "Status: " + status5
                    Panel6.BackColor = Color.Red
                    PictureBox5.Image = My.Resources.maintenance
                Case 106
                    tbStatus6.Text = "Status: " + status6
                    Panel7.BackColor = Color.Red
                    PictureBox6.Image = My.Resources.maintenance
                Case 201
                    tbStatus7.Text = "Status: " + status7
                    Panel13.BackColor = Color.Red
                    PictureBox12.Image = My.Resources.maintenance
                Case 202
                    tbStatus8.Text = "Status: " + status8
                    Panel12.BackColor = Color.Red
                    PictureBox11.Image = My.Resources.maintenance
                Case 203
                    tbStatus9.Text = "Status: " + status9
                    Panel11.BackColor = Color.Red
                    PictureBox10.Image = My.Resources.maintenance
                Case 204
                    tbStatus10.Text = "Status: " + status10
                    Panel10.BackColor = Color.Red
                    PictureBox9.Image = My.Resources.maintenance
                Case 205
                    tbStatus11.Text = "Status: " + status11
                    Panel9.BackColor = Color.Red
                    PictureBox8.Image = My.Resources.maintenance
                Case 206
                    tbStatus12.Text = "Status: " + status12
                    Panel8.BackColor = Color.Red
                    PictureBox7.Image = My.Resources.maintenance
                Case 301
                    tbStatus13.Text = "Status: " + status13
                    Panel19.BackColor = Color.Red
                    PictureBox18.Image = My.Resources.maintenance
                Case 302
                    tbStatus14.Text = "Status: " + status14
                    Panel18.BackColor = Color.Red
                    PictureBox17.Image = My.Resources.maintenance
                Case 303
                    tbStatus15.Text = "Status: " + status15
                    Panel17.BackColor = Color.Red
                    PictureBox16.Image = My.Resources.maintenance
                Case 304
                    tbStatus16.Text = "Status: " + status16
                    Panel16.BackColor = Color.Red
                    PictureBox15.Image = My.Resources.maintenance
                Case 305
                    tbStatus17.Text = "Status: " + status17
                    Panel15.BackColor = Color.Red
                    PictureBox14.Image = My.Resources.maintenance
                Case 306
                    tbStatus18.Text = "Status: " + status18
                    Panel14.BackColor = Color.Red
                    PictureBox13.Image = My.Resources.maintenance
                Case Else
                    MessageBox.Show("Room " & roomNumber.ToString() & " Not found")
            End Select
        End While
        Con.Close()

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

    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RoomDbDataSet.historyInfo' table. You can move, or remove it, as needed.
        'Me.HistoryInfoTableAdapter.Fill(Me.RoomDbDataSet.historyInfo)
        'TODO: This line of code loads data into the 'InformationDBDataSet.shuttleInfo' table. You can move, or remove it, as needed.

        TabPage1.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage2.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage3.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage4.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        populate()
        fetchIfOccupied()
        populateHistory()
        populateMaintenance()
        fetchStatus()


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
                        Dim query As String = "INSERT INTO roomInfo (Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, isOccupied) VALUES (@Id, @LastName, @FirstName, @ContactNo, @RoomNo, GETDATE(), @NumberOfGuess, @Checkout, @isOccupied)"
                        Dim checkOutDate As DateTime = CheckOut.Value
                        isOccupied.Text = "Occupied"
                    Using cmd As New SqlCommand(query, Con)
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text)
                        cmd.Parameters.AddWithValue("@LastName", Lname.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@FirstName", Fname.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@RoomNo", roomNumber) ' Assuming you have a plateNo field
                        cmd.Parameters.AddWithValue("@TimeIn", timeIn.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@CheckOut", checkOutDate)
                        cmd.Parameters.AddWithValue("@NumberOfGuess", noOfGuess.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@ContactNo", Cnumber.Text.ToUpper()) ' Corrected variable name
                        cmd.Parameters.AddWithValue("@isOccupied", isOccupied.Text.ToUpper())
                        cmd.ExecuteNonQuery()
                    End Using
                    MsgBox("Added successfully!")
                    Con.Close()
                        populate()
                    fetchIfOccupied()
                    ClearBtn()
                    End If
                End If


        Catch ex As Exception
            Con.Close()
            MsgBox("This Guess is already Check in")
        End Try

    End Sub

    Private Sub remove_Click(sender As Object, e As EventArgs) Handles Remove.Click
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\OneDrive\Documents\RoomDb.mdf;Integrated Security=True;Connect Timeout=30" ' Replace with your connection string
        Try
            If ShuttleId.Text = "" Then
                MessageBox.Show("Select a customer before checking out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Using Con As New SqlConnection(connectionString)
                    Con.Open()
                    ' First, transfer the selected record to the destination table
                    Dim transferQuery As String = "INSERT INTO historyInfo (Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, isOccupied) " &
        "SELECT Id, LastName, FirstName, ContactNo, RoomNo, CheckIn, NumberOfGuess, CheckOut, isOccupied " &
        "FROM roomInfo " &
        "WHERE Id = @Id"

                    Using cmd As New SqlCommand(transferQuery, Con)
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text)
                        MsgBox("Checking out successfully")
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Next, delete the transferred record from the source table
                    Dim deleteQuery As String = "DELETE FROM roomInfo WHERE Id = @Id"

                    Using cmd As New SqlCommand(deleteQuery, Con)
                        cmd.Parameters.AddWithValue("@Id", ShuttleId.Text)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' Now, populate the history or refresh your view
                ClearBtn()
                populate()
                populateHistory()
            End If
        Catch ex As Exception
            ' Handle exceptions, such as displaying an error message
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
            isOccupied.Text = row.Cells("isOccupied").Value.ToString()
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
        'Dim query As String = "SELECT * FROM historyInfo WHERE RoomNo LIKE @searchPattern"
        'Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\OneDrive\Documents\RoomDb.mdf;Integrated Security=True;Connect Timeout=30")
        '    Using cmd As New SqlCommand(query, Con)
        '        cmd.Parameters.AddWithValue("@searchPattern", "%" & search.Text & "%")

        '        Using da As New SqlDataAdapter()
        '            da.SelectCommand = cmd
        '            Using dt As New DataTable()
        '                da.Fill(dt)
        '                If dt.Rows.Count > 0 Then
        '                    DataGridView1.DataSource = dt
        '                Else
        '                    MsgBox("Record not found!")
        '                    search.Text = ""
        '                End If
        '            End Using
        '        End Using
        '    End Using
        'End Using
        Dim query As String = "SELECT * FROM historyInfo WHERE RoomNo LIKE @searchPattern OR LastName LIKE @searchPattern OR FirstName LIKE @searchPattern"
        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\OneDrive\Documents\RoomDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@searchPattern", "%" & search.Text & "%")
                Using da As New SqlDataAdapter()
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
            Dim query As String = "INSERT INTO mainteInfo (Id, RoomNo) VALUES (@Id, @RoomNo)"
            Using cmd1 As New SqlCommand(query, Con)
                cmd1.Parameters.AddWithValue("@Id", roomId.Text)
                cmd1.Parameters.AddWithValue("@RoomNo", roomNumber2.Text.ToUpper())
                cmd1.ExecuteNonQuery()
            End Using
            Dim sql = "UPDATE roomInfo SET isOccupied=@isOccupied WHERE RoomNo=@RoomNo"
            Dim cmd As New SqlCommand(sql, Con)
            cmd.Parameters.AddWithValue("@isOccupied", isOccupied.Text)
            cmd.Parameters.AddWithValue("@RoomNo", roomNumber2.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Added Successfully!")
            Con.Close()

            isOccupied.Text = "Under Maintenance"
            RoomAvailability()
            fetchStatus()
            populateMaintenance()
            ClearBtn()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


        Try
            If roomId.Text = "" Then
                MsgBox("Enter room ID to be deleted!")
            Else
                Con.Open()
                Dim deleteQuery As String = "DELETE FROM mainteInfo WHERE Id = @Id"
                Using cmd1 As New SqlCommand(deleteQuery, Con)
                    cmd1.Parameters.AddWithValue("@Id", roomId.Text)
                    cmd1.ExecuteNonQuery()
                End Using

                ' Delete from RoomAvailability
                Dim deleteQuery2 As String = "DELETE FROM RoomAvailability WHERE RoomNumber = @RoomNo"
                Using cmd2 As New SqlCommand(deleteQuery2, Con)
                    cmd2.Parameters.AddWithValue("@RoomNo", roomNumber2.Text)
                    cmd2.ExecuteNonQuery()
                End Using
                MsgBox("Removing Room for maintenance!")
                Con.Close()

                Con.Open()
                isOccupied.Text = "OCCUPIED"
                Dim sql = "UPDATE roomInfo SET isOccupied=@isOccupied WHERE RoomNo=@RoomNo"
                Dim cmd As New SqlCommand(sql, Con)
                cmd.Parameters.AddWithValue("@isOccupied", isOccupied.Text)
                cmd.Parameters.AddWithValue("@RoomNo", roomNumber2.Text)
                cmd.ExecuteNonQuery()
                Con.Close()
                populateMaintenance()

                ClearBtn()
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
        Dim query As String = "SELECT * FROM roomInfo WHERE RoomNo LIKE @searchPattern OR LastName LIKE @searchPattern OR FirstName LIKE @searchPattern"
        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\OneDrive\Documents\RoomDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@searchPattern", "%" & searchRoom.Text & "%")
                Using da As New SqlDataAdapter()
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
