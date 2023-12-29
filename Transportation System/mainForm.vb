Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Runtime.Serialization
Imports System.Windows.Forms.VisualStyles
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.AspNetCore.JsonPatch


Public Class mainForm
    Dim apiUrlBooking As String = "https://8d6c-136-158-17-210.ngrok-free.app/api/booking.php"
    Dim apiUrlBookingHistory As String = "https://8d6c-136-158-17-210.ngrok-free.app/api/bookinghistory%20.php"
    Dim apiUrlMaintenance As String = "https://8d6c-136-158-17-210.ngrok-free.app/api/roommaintenance.php"
    Dim apiUrlRoomAvailability As String = "https://8d6c-136-158-17-210.ngrok-free.app/api/roomavailability.php"
    Dim apiUrlReservation As String = ""

    Private Function FetchDataFromApi(apiUrl As String) As String
        Using httpClient As New HttpClient()
            Return httpClient.GetStringAsync(apiUrl).Result
        End Using
    End Function

    Private Sub FetchBooking()


        Dim jsonData As String = FetchDataFromApi(apiUrlBooking)
        Dim newDataList As List(Of BookingData) = JsonConvert.DeserializeObject(Of List(Of BookingData))(jsonData)


        listOfData.Clear()
        listOfData.AddRange(newDataList)

        UpdateDataGridView()
        DGVshuttle.DataSource = listOfData

    End Sub


    Private Sub FetchBookingHistory()


        Dim jsonData As String = FetchDataFromApi(apiUrlBookingHistory)

        Dim newDataList As List(Of BookingData2) = JsonConvert.DeserializeObject(Of List(Of BookingData2))(jsonData)

        listOfData2.Clear()
        listOfData2.AddRange(newDataList)

        UpdateDataGridViewBookingHistory()
        DataGridView1.DataSource = listOfData2

    End Sub


    'Private Sub FetchRoomMaintenance()


    '    Dim jsonData As String = FetchDataFromApi(apiUrlMaintenance)

    '    ' Deserialize the JSON data to a list of BookingData
    '    Dim newDataList As List(Of maintenanceData) = JsonConvert.DeserializeObject(Of List(Of maintenanceData))(jsonData)

    '    ' Update the listOfData with the new data
    '    listOfMaintenaceData.Clear()
    '    listOfMaintenaceData.AddRange(newDataList)

    '    ' Update the DataGridView
    '    FetchRoomMaintenance()
    '    DataGridView2.DataSource = listOfMaintenaceData

    'End Sub


    Private Sub UpdateDataGridView()
        DGVshuttle.DataSource = Nothing
        DGVshuttle.DataSource = listOfData.Select(Function(data) New With {
        data.id,
        data.LastName,
        data.FirstName,
        data.ContactNo,
        data.RoomNo,
        data.Status
    }).ToList()
    End Sub


    'Private Sub UpdateDataGridViewRoomMainte()
    '    DGVshuttle.DataSource = Nothing
    '    DGVshuttle.DataSource = listOfMaintenaceData.Select(Function(data) New With {
    '    data.roomId,
    '    data.roomNo,
    '    data.status
    '}).ToList()
    'End Sub

    Private Sub UpdateDataGridViewBookingHistory()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = listOfData2.Select(Function(data) New With {
        data.id,
        data.LastName,
        data.FirstName,
        data.ContactNo
    }).ToList()
    End Sub

    Dim listOfData As List(Of BookingData) = New List(Of BookingData)
    Dim json As String


    'Dim listOfMaintenaceData As List(Of maintenanceData) = New List(Of maintenanceData)
    'Dim jsonMaintenance As String

    Public Class BookingData
        Public Property id As String
        Public Property LastName As String
        Public Property FirstName As String
        Public Property ContactNo As String
        Public Property RoomNo As String
        Public Property CheckIn As String
        Public Property CheckOut As String
        Public Property NumberOfGuests As String
        Public Property Status As String
    End Class

    Private Async Sub SendJsonToApi(apiUrl As String, jsonData As String)
        Using httpClient As New HttpClient()
            Dim content As New StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")

            Try
                Dim response = Await httpClient.PostAsync(apiUrl, content)

                If response.IsSuccessStatusCode Then
                    MessageBox.Show("added successfully.")
                    isOccupied.Text = "OCCUPIED"
                    Await PatchRequestAsync()
                    UpdateUI(stat, roomN)
                    ClearBtn()

                Else
                    MessageBox.Show($"Error sending JSON data to API: {response.StatusCode}")
                End If
            Catch ex As Exception
                MessageBox.Show($"Error sending JSON data to API: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Async Sub checkIn()
        Try
            Dim newData As New BookingData With {
            .id = ShuttleId.Text,
            .LastName = Lname.Text,
            .FirstName = Fname.Text,
            .ContactNo = Cnumber.Text,
            .RoomNo = roomNo.Text,
            .CheckIn = timeIn.Text,
            .CheckOut = CheckOut.Text,
            .NumberOfGuests = noOfGuess.Text,
            .Status = "CHECK_IN"
        }

            listOfData.Add(newData)

            Dim json = JsonConvert.SerializeObject(newData)

            SendJsonToApi(apiUrlBooking, json)
            status()
            UpdateDataGridView()
        Catch ex As Exception
            MessageBox.Show($"Error in checkIn: {ex.Message}")
        End Try
    End Sub

    Public Class RoomAvailabilityData
        Public Property RoomNo As String
        Public Property Status As String
    End Class

    Async Function PatchRequestAsync() As Task

        Using httpClient As New HttpClient()

            Dim updatedRoomData As New RoomAvailabilityData() With {
            .RoomNo = roomNo.Text,
            .Status = isOccupied.Text
        }

            Dim requestData As String = JsonConvert.SerializeObject(updatedRoomData)


            Dim content As New StringContent(requestData, System.Text.Encoding.UTF8, "application/json")
            Dim patchMethod As New HttpMethod("PATCH")


            Dim apiUrlWithRoomNo As String = $"{apiUrlRoomAvailability}/{roomNo.Text}"


            Dim request As New HttpRequestMessage(patchMethod, apiUrlWithRoomNo) With {
            .Content = content
        }

            Try

                Dim response = Await httpClient.SendAsync(request)

                ' Check if the request was successful
                If response.IsSuccessStatusCode Then


                    UpdateUI(stat, roomN)
                Else
                    MsgBox($"Error: {response.StatusCode} - {response.ReasonPhrase}")
                End If
            Catch ex As HttpRequestException

                MsgBox($"HTTP Request Exception: {ex.Message}")
            Catch ex As Exception

                MsgBox($"Exception: {ex.Message}")
            End Try
        End Using
    End Function



    Public Class maintenanceData
        Public Property roomIdd As String
        Public Property roomNum As String
        Public Property status As String
    End Class




    Async Function PatchRequestAsyncRoomMaintenance() As Task
        Using httpClient As New HttpClient()

            Dim updatedRoomData As New RoomAvailabilityData() With {
            .RoomNo = roomNumber2.Text,
            .Status = isOccupied.Text
        }

            Dim requestData As String = JsonConvert.SerializeObject(updatedRoomData)

            Dim content As New StringContent(requestData, System.Text.Encoding.UTF8, "application/json")
            Dim patchMethod As New HttpMethod("PATCH")

            Dim apiUrlWithRoomNo As String = $"{apiUrlRoomAvailability}/{roomNumber2.Text}"

            Dim request As New HttpRequestMessage(patchMethod, apiUrlWithRoomNo) With {
            .Content = content
        }

            Try

                Dim response = Await httpClient.SendAsync(request)
                MessageBox.Show("Room " & roomNumber2.Text & " is  under maintenance.")

                If response.IsSuccessStatusCode Then


                    UpdateUI(stat, roomN)
                Else
                    MsgBox($"Error: {response.StatusCode} - {response.ReasonPhrase}")
                End If
            Catch ex As HttpRequestException
                MsgBox($"HTTP Request Exception: {ex.Message}")
            Catch ex As Exception
                MsgBox($"Exception: {ex.Message}")
            End Try
        End Using
    End Function

    Dim index As Integer = 1
    Dim stat = ""
    Dim roomN = ""


    Private Sub status()

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = client.GetAsync(apiUrlRoomAvailability).Result

                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = response.Content.ReadAsStringAsync().Result

                    Dim data As List(Of RoomAvailabilityData) = JsonConvert.DeserializeObject(Of List(Of RoomAvailabilityData))(responseContent)

                    For Each item As RoomAvailabilityData In data
                        stat = item.Status
                        roomN = item.RoomNo

                        UpdateUI(stat, roomN)
                    Next
                Else

                    MsgBox($"Error: {response.StatusCode}")
                End If
            Catch ex As Exception

                MsgBox($"Exception: {ex.Message}")
            End Try
        End Using
    End Sub


    Private Sub UpdateUI(status As String, roomNumber As String)



        Select Case roomNumber.ToUpper()
            Case "101"
                tbStatus1.Text = "Status: " + status.ToUpper()
                If (status = "AVAILABLE") Then
                    Panel2.BackColor = Color.Lime
                    PictureBox1.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel2.BackColor = Color.Orange
                    PictureBox1.Image = My.Resources.booked

                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel2.BackColor = Color.Red
                    PictureBox1.Image = My.Resources.maintenance

                End If

            Case "102"
                tbStatu2.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel3.BackColor = Color.Lime
                    PictureBox2.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel3.BackColor = Color.Orange
                    PictureBox2.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel3.BackColor = Color.Red
                    PictureBox2.Image = My.Resources.maintenance
                End If
            Case "103"
                tbStatus3.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel4.BackColor = Color.Lime
                    PictureBox3.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel4.BackColor = Color.Orange
                    PictureBox3.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel4.BackColor = Color.Red
                    PictureBox3.Image = My.Resources.maintenance
                End If
            Case "104"
                tbStatus4.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel5.BackColor = Color.Lime
                    PictureBox4.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel5.BackColor = Color.Orange
                    PictureBox4.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel5.BackColor = Color.Red
                    PictureBox4.Image = My.Resources.maintenance
                End If

            Case "105"
                tbStatus5.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel6.BackColor = Color.Lime
                    PictureBox5.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel6.BackColor = Color.Orange
                    PictureBox5.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel6.BackColor = Color.Red
                    PictureBox5.Image = My.Resources.maintenance
                End If
            Case "106"
                tbStatus6.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel7.BackColor = Color.Lime
                    PictureBox6.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel7.BackColor = Color.Orange
                    PictureBox6.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel7.BackColor = Color.Red
                    PictureBox6.Image = My.Resources.maintenance
                End If
            Case "201"
                tbStatus7.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel13.BackColor = Color.Lime
                    PictureBox12.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel13.BackColor = Color.Orange
                    PictureBox12.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel13.BackColor = Color.Red
                    PictureBox12.Image = My.Resources.maintenance
                End If

            Case "202"
                tbStatus8.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel12.BackColor = Color.Lime
                    PictureBox11.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel12.BackColor = Color.Orange
                    PictureBox11.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel12.BackColor = Color.Red
                    PictureBox11.Image = My.Resources.maintenance
                End If
            Case "203"
                tbStatus9.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel11.BackColor = Color.Lime
                    PictureBox10.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel11.BackColor = Color.Orange
                    PictureBox10.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel11.BackColor = Color.Red
                    PictureBox10.Image = My.Resources.maintenance
                End If
            Case "204"
                tbStatus10.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel10.BackColor = Color.Lime
                    PictureBox9.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel10.BackColor = Color.Orange
                    PictureBox9.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel10.BackColor = Color.Red
                    PictureBox9.Image = My.Resources.maintenance
                End If
            Case "205"
                tbStatus11.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel9.BackColor = Color.Lime
                    PictureBox8.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel9.BackColor = Color.Orange
                    PictureBox8.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel9.BackColor = Color.Red
                    PictureBox8.Image = My.Resources.maintenance
                End If
            Case "206"
                tbStatus12.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel8.BackColor = Color.Lime
                    PictureBox7.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel8.BackColor = Color.Orange
                    PictureBox7.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel8.BackColor = Color.Red
                    PictureBox7.Image = My.Resources.maintenance

                End If
            Case "301"
                tbStatus13.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel19.BackColor = Color.Lime
                    PictureBox18.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel19.BackColor = Color.Orange
                    PictureBox18.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel19.BackColor = Color.Red
                    PictureBox18.Image = My.Resources.maintenance
                End If
            Case "302"
                tbStatus14.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel18.BackColor = Color.Lime
                    PictureBox17.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel18.BackColor = Color.Orange
                    PictureBox17.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel18.BackColor = Color.Red
                    PictureBox17.Image = My.Resources.maintenance
                End If
            Case "303"
                tbStatus15.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel17.BackColor = Color.Lime
                    PictureBox16.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel17.BackColor = Color.Orange
                    PictureBox16.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel17.BackColor = Color.Red
                    PictureBox16.Image = My.Resources.maintenance
                End If
            Case "304"
                tbStatus16.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel16.BackColor = Color.Lime
                    PictureBox15.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel16.BackColor = Color.Orange
                    PictureBox15.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel16.BackColor = Color.Red
                    PictureBox15.Image = My.Resources.maintenance
                End If
            Case "305"
                tbStatus17.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel15.BackColor = Color.Lime
                    PictureBox14.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel15.BackColor = Color.Orange
                    PictureBox14.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel15.BackColor = Color.Red
                    PictureBox14.Image = My.Resources.maintenance
                End If
            Case "306"
                tbStatus18.Text = "Status: " + status

                If (status = "AVAILABLE") Then
                    Panel14.BackColor = Color.Lime
                    PictureBox13.Image = My.Resources.bed
                ElseIf (status = "OCCUPIED") Then
                    Panel14.BackColor = Color.Orange
                    PictureBox13.Image = My.Resources.booked
                ElseIf (status = "UNDER_MAINTENANCE") Then
                    Panel14.BackColor = Color.Red
                    PictureBox13.Image = My.Resources.maintenance
                End If

        End Select
        index += 1

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
        FetchBooking()
        FetchBookingHistory()
        TabPage1.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage2.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage3.BackColor = ColorTranslator.FromHtml("#FFCDA3")
        TabPage4.BackColor = ColorTranslator.FromHtml("#FFCDA3")
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
            checkStatus(roomNo.Text)
        End If


    End Sub


    Private Async Sub checkStatus(userInputRoomNumber As String)
        Dim validRoomNumbers() As String = {"101", "102", "103", "104", "105", "106", "201", "202", "203", "204", "205", "206", "301", "302", "303", "304", "305", "306"}
        If Not validRoomNumbers.Contains(roomNo.Text) Then
            MessageBox.Show("Room " & roomNo.Text & " Not found")
        Else

            checkIn()
        End If
    End Sub


    Dim listOfData2 As List(Of BookingData2) = New List(Of BookingData2)
    Dim json2 As String
    Private _context As Object

    Public Class BookingData2
        Public Property id As String
        Public Property LastName As String
        Public Property FirstName As String
        Public Property ContactNo As String
        Public Property NumberOfGuests As String

    End Class

    Private Async Sub SendJsonToApiBookingHistory(apiUrl As String, jsonData As String)
        Using httpClient As New HttpClient()
            Dim content As New StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")

            Try
                Dim response = Await httpClient.PostAsync(apiUrl, content)

                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Checking out successfuly")
                    ClearBtn()

                Else
                    MessageBox.Show($"Error sending JSON data to API: {response.StatusCode}")
                End If
            Catch ex As Exception
                MessageBox.Show($"Error sending JSON data to API: {ex.Message}")
            End Try
        End Using
    End Sub


    Private Async Sub UpdateStatusAsync()


        Using httpClient As New HttpClient()

            Dim updatedBookingData As New RoomAvailabilityData() With {
        .RoomNo = roomNo.Text,
        .Status = isOccupied.Text
    }

            Dim requestData As String = JsonConvert.SerializeObject(updatedBookingData)


            Dim content As New StringContent(requestData, System.Text.Encoding.UTF8, "application/json")
            Dim patchMethod As New HttpMethod("PATCH")

            Dim apiUrlWithRoomNo As String = $"{apiUrlRoomAvailability}/{roomNo}"


            Dim request As New HttpRequestMessage(patchMethod, apiUrlWithRoomNo) With {
        .Content = content
    }

            Try

                Dim response = Await httpClient.SendAsync(request)


                If response.IsSuccessStatusCode Then


                Else
                    MsgBox($"Error: {response.StatusCode} - {response.ReasonPhrase}")
                End If
            Catch ex As HttpRequestException

                MsgBox($"HTTP Request Exception: {ex.Message}")
            Catch ex As Exception

                MsgBox($"Exception: {ex.Message}")
            End Try
        End Using


    End Sub





    Private Async Sub DeleteData()
        Using httpClient As New HttpClient()
            Dim updatedBookingData As New RoomAvailabilityData() With {
            .RoomNo = roomNo.Text,
            .Status = isOccupied.Text
        }

            Dim requestData As String = JsonConvert.SerializeObject(updatedBookingData)
            Dim content As New StringContent(requestData, System.Text.Encoding.UTF8, "application/json")
            Dim patchMethod As New HttpMethod("DELETE")

            ' Use roomNo.Text to get the value
            Dim apiUrlWithRoomNo As String = $"{apiUrlRoomAvailability}/{roomNo.Text}"

            Dim request As New HttpRequestMessage(patchMethod, apiUrlWithRoomNo) With {
            .Content = content
        }

            Try
                Dim response = Await httpClient.SendAsync(request)

                If response.IsSuccessStatusCode Then
                    ' Handle success if needed

                Else
                    MsgBox($"Error: {response.StatusCode} - {response.ReasonPhrase}")
                End If
            Catch ex As HttpRequestException
                MsgBox($"HTTP Request Exception: {ex.Message}")
            Catch ex As Exception
                MsgBox($"Exception: {ex.Message}")
            End Try
        End Using
    End Sub




    Private Async Sub remove_Click(sender As Object, e As EventArgs) Handles Remove.Click

        isOccupied.Text = "AVAILABLE"
        UpdateStatusAsync()

        Try

            Dim newData As New BookingData2 With {
            .id = ShuttleId.Text,
            .LastName = Lname.Text,
            .FirstName = Fname.Text,
            .ContactNo = Cnumber.Text,
            .NumberOfGuests = noOfGuess.Text
        }

            listOfData2.Add(newData)

            Dim json = JsonConvert.SerializeObject(newData)

            SendJsonToApiBookingHistory(apiUrlBookingHistory, json)

            UpdateDataGridViewBookingHistory()
            FetchBookingHistory()

            DeleteData()


        Catch ex As Exception
            MessageBox.Show($"Error in checkIn: {ex.Message}")
        End Try


        ClearBtn()
        status()

    End Sub

    Private Sub DGVshuttle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVshuttle.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DGVshuttle.Rows(e.RowIndex)


            Dim id As String = selectedRow.Cells("id").Value.ToString()
            Dim lastName As String = selectedRow.Cells("LastName").Value.ToString()
            Dim firstName As String = selectedRow.Cells("FirstName").Value.ToString()
            Dim contactNo As String = selectedRow.Cells("ContactNo").Value.ToString()
            'Dim checkin As String = selectedRow.Cells("CheckIn").Value.ToString()
            'Dim checkoutT As String = selectedRow.Cells("CheckOut").Value.ToString()
            Dim roomNumber As String = selectedRow.Cells("RoomNo").Value.ToString()
            'Dim noGuest As String = selectedRow.Cells("NumberOfGuests").Value.ToString()
            Dim status As String = selectedRow.Cells("Status").Value.ToString()


            ShuttleId.Text = id
            Lname.Text = lastName
            Fname.Text = firstName
            Cnumber.Text = contactNo
            'timeIn.Text = checkin
            'CheckOut.Text = checkoutT
            roomNo.Text = roomNumber
            isOccupied.Text = status
            'noOfGuess.Text = noGuest
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

    Private Async Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        'ClearBtn()
        'isOccupied.Text = "OCCUPIED"
        'Await PatchRequestAsync()

        isOccupied.Text = "UNDER_MAINTENANCE"
        'maintenanceStatus(roomNumber2.Text)
        Await PatchRequestAsyncRoomMaintenance()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles search.TextChanged


    End Sub





    Private Async Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim validRoomNumbers() As String = {"101", "102", "103", "104", "105", "106", "201", "202", "203", "204", "205", "206", "301", "302", "303", "304", "305", "306"}
        If Not validRoomNumbers.Contains(roomNumber2.Text) Then
            MessageBox.Show("Room " & roomNumber2.Text & " Not found")
        Else
            isOccupied.Text = "UNDER_MAINTENANCE"
            'maintenanceStatus(roomNumber2.Text)
            Await PatchRequestAsyncRoomMaintenance()


        End If



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


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

        ClearBtn()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Restart()
    End Sub
End Class
