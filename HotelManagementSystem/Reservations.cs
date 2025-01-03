using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Reservations : Form
    {

            
        private string currentUserRole;

        public Reservations(string role)
        {
            InitializeComponent();
            currentUserRole = role;

        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            CheckPermissions();

            LoadReservations();
            LoadClients();
            LoadRooms();
            guna2DataGridView1.ClearSelection();
            numGuestsTextBox.Text = "1";

        }


        private void CheckPermissions()
        {
            if (currentUserRole.Equals("Receptionist", StringComparison.OrdinalIgnoreCase))
            {
                deleteBtn.Enabled = false;
            }
            else
            {
                deleteBtn.Enabled = true;
            }
        }

        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            guna2DataGridView1.ClearSelection();
        }

        private void LoadReservations()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT r.ReservationID, rm.RoomNumber,r.RoomID, c.Name AS ClientName,
                                    r.CheckInDate, r.CheckOutDate, r.NumberOfGuests, r.TotalPrice, r.Status
                             FROM Reservations r
                             JOIN Clients c ON r.ClientID = c.ClientID
                             JOIN Rooms rm ON r.RoomID = rm.RoomID
                             ORDER BY r.ReservationID DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            guna2DataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadClients()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ClientID, Name FROM Clients";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            clientComboBox.DataSource = dataTable;
                            clientComboBox.DisplayMember = "Name";
                            clientComboBox.ValueMember = "ClientID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT RoomID, RoomNumber FROM Rooms";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            roomComboBox.DataSource = dataTable;
                            roomComboBox.DisplayMember = "RoomNumber";
                            roomComboBox.ValueMember = "RoomID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            roomComboBox.SelectedIndex = -1;
            clientComboBox.SelectedIndex = -1;
            checkInDatePicker.Value = DateTime.Today;
            checkOutDatePicker.Value = DateTime.Today;
            totalPriceTextBox.Clear();
            statusComboBox.SelectedIndex = 0;
            numGuestsTextBox.Text = "1";

        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (roomComboBox.SelectedIndex == -1 || clientComboBox.SelectedIndex == -1 || string.IsNullOrWhiteSpace(numGuestsTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkInDatePicker.Value.Date >= checkOutDatePicker.Value.Date)
            {
                MessageBox.Show("Check-out date must be after the check-in date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    //retrive email client
                    string clientEmailQuery = @"SELECT Email FROM Clients WHERE ClientID = @ClientID";
                    string clientEmail = string.Empty;

                    using (var emailCmd = new MySqlCommand(clientEmailQuery, conn))
                    {
                        emailCmd.Parameters.AddWithValue("@ClientID", clientComboBox.SelectedValue);
                        clientEmail = emailCmd.ExecuteScalar()?.ToString();

                    }

                    // Check overlapping reservations
                    string overlapQuery = @"SELECT COUNT(*) 
                                    FROM Reservations 
                                    WHERE RoomID = @RoomID 
                                    AND (CheckInDate < @CheckOutDate AND CheckOutDate > @CheckInDate)";

                    using (var overlapCmd = new MySqlCommand(overlapQuery, conn))
                    {
                        overlapCmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        overlapCmd.Parameters.AddWithValue("@CheckInDate", checkInDatePicker.Value.Date);
                        overlapCmd.Parameters.AddWithValue("@CheckOutDate", checkOutDatePicker.Value.Date);

                        int overlapCount = Convert.ToInt32(overlapCmd.ExecuteScalar());

                        if (overlapCount > 0)
                        {
                            MessageBox.Show("The selected room is already booked for the chosen dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Calculate total price dynamically
                    int numberOfNights = (int)(checkOutDatePicker.Value.Date - checkInDatePicker.Value.Date).TotalDays;
                    decimal roomPricePerNight = GetRoomPricePerNight((int)roomComboBox.SelectedValue, conn);
                    decimal totalPrice = numberOfNights * roomPricePerNight;

                    // Insert reservation
                    string query = @"INSERT INTO Reservations (RoomID, ClientID, CheckInDate, CheckOutDate, 
                             NumberOfGuests, TotalPrice, Status)
                             VALUES (@RoomID, @ClientID, @CheckInDate, @CheckOutDate, @NumberOfGuests, 
                             @TotalPrice, @Status)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@ClientID", clientComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CheckInDate", checkInDatePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDatePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@NumberOfGuests", numGuestsTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    // If the reservation is Confirmed, change room to Occupied
                    if (statusComboBox.SelectedItem.ToString().Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        string updateRoomQuery = @"UPDATE Rooms SET Status = 'Occupied' WHERE RoomID = @RoomID";

                        using (var updateCmd = new MySqlCommand(updateRoomQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                            updateCmd.ExecuteNonQuery();

                            //send email
                            SendReservationEmail(clientComboBox.Text, clientEmail, roomComboBox.Text, checkInDatePicker.Value, checkOutDatePicker.Value, totalPrice);

                        }
                    }

                   
                    MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearFields();
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendReservationEmail(string clientName, string clientEmail, string roomNumber, DateTime checkInDate, DateTime checkOutDate, decimal totalPrice)
        {
            try
            {
                string emailBody = $@"
        <html>
        <body>
            <h2>Reservation Confirmation</h2>
            <p>Dear {clientName},</p>
            <p>Thank you for choosing our hotel. Your reservation details are as follows:</p>
            <table style='width:100%; border:1px solid #ddd; border-collapse: collapse;'>
                <tr style='background-color: #f2f2f2;'>
                    <th style='border: 1px solid #ddd; padding: 8px;'>Room Number</th>
                    <th style='border: 1px solid #ddd; padding: 8px;'>Check-In Date</th>
                    <th style='border: 1px solid #ddd; padding: 8px;'>Check-Out Date</th>
                    <th style='border: 1px solid #ddd; padding: 8px;'>Total Price</th>
                </tr>
                <tr>
                    <td style='border: 1px solid #ddd; padding: 8px;'>{roomNumber}</td>
                    <td style='border: 1px solid #ddd; padding: 8px;'>{checkInDate.ToShortDateString()}</td>
                    <td style='border: 1px solid #ddd; padding: 8px;'>{checkOutDate.ToShortDateString()}</td>
                    <td style='border: 1px solid #ddd; padding: 8px;'>${totalPrice:F2}</td>
                </tr>
            </table>
            <p>We look forward to hosting you!</p>
        </body>
        </html>";

                using (var smtpClient = new System.Net.Mail.SmtpClient("sandbox.smtp.mailtrap.io", 2525))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("7c3c4df3537622", "6e811454b719f0");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress("contact@hotelme.com", "Hotelme"),
                        Subject = "Reservation Confirmation",
                        Body = emailBody,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(clientEmail);
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private decimal GetRoomPricePerNight(int roomId, MySqlConnection conn)
        {
            try
            {
                string query = @"SELECT PricePerNight FROM Rooms WHERE RoomID = @RoomID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", roomId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                    {
                        return price;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching room price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0.00m; 
        }




        private void UpdateTotalPrice()
        {
            if (roomComboBox.SelectedIndex == -1 || roomComboBox.SelectedValue == null)
            {
                totalPriceTextBox.Text = "0.00";
                return;
            }

            if (checkInDatePicker.Value.Date >= checkOutDatePicker.Value.Date)
            {
                totalPriceTextBox.Text = "0.00";
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    int roomId = Convert.ToInt32(roomComboBox.SelectedValue);

                    if (!int.TryParse(numGuestsTextBox.Text.Trim(), out int nbfGuests) || nbfGuests <= 0)
                    {
                        totalPriceTextBox.Text = "0.00";
                        return;
                    }

                    decimal roomPricePerNight = GetRoomPricePerNight(roomId, conn);
                    if (roomPricePerNight <= 0)
                    {
                        totalPriceTextBox.Text = "0.00";
                        return;
                    }

                    int numberOfNights = (int)(checkOutDatePicker.Value.Date - checkInDatePicker.Value.Date).TotalDays;
                    decimal totalPrice = numberOfNights * roomPricePerNight * nbfGuests;

                    totalPriceTextBox.Text = totalPrice.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int reservationId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ReservationID"].Value);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    //retrive email client
                    string clientEmailQuery = @"SELECT Email FROM Clients WHERE ClientID = @ClientID";
                    string clientEmail = string.Empty;

                    using (var emailCmd = new MySqlCommand(clientEmailQuery, conn))
                    {
                        emailCmd.Parameters.AddWithValue("@ClientID", clientComboBox.SelectedValue);
                        clientEmail = emailCmd.ExecuteScalar()?.ToString();


                    }


                    // Update the reservation
                    string query = @"UPDATE Reservations 
                             SET RoomID = @RoomID, ClientID = @ClientID, 
                             CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, 
                             NumberOfGuests = @NumberOfGuests, TotalPrice = @TotalPrice, 
                             Status = @Status 
                             WHERE ReservationID = @ReservationID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@ClientID", clientComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@CheckInDate", checkInDatePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDatePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@NumberOfGuests", numGuestsTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@TotalPrice", totalPriceTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                        cmd.ExecuteNonQuery();
                    }

                    // If reservation is Confirmed, update room to Occupied
                    if (statusComboBox.SelectedItem.ToString().Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        string updateRoomQuery = @"UPDATE Rooms SET Status = 'Occupied' WHERE RoomID = @RoomID";

                        using (var updateRoomCmd = new MySqlCommand(updateRoomQuery, conn))
                        {
                            updateRoomCmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                            updateRoomCmd.ExecuteNonQuery();

                            //send email
                            SendReservationEmail(clientComboBox.Text, clientEmail, roomComboBox.Text, checkInDatePicker.Value, checkOutDatePicker.Value, decimal.Parse(totalPriceTextBox.Text) );

                        }
                    }


                    // If reservation is Cancelled, change room to Occupied
                    if (statusComboBox.SelectedItem.ToString().Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        string updateRoomQuery = @"UPDATE Rooms SET Status = 'Available' WHERE RoomID = @RoomID";

                        using (var updateCmd = new MySqlCommand(updateRoomQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@RoomID", roomComboBox.SelectedValue);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearFields();
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int reservationId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                string reservationStatus = guna2DataGridView1.SelectedRows[0].Cells["Status"].Value?.ToString();
                int roomId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["RoomID"].Value);

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // If the reservation Confirmed ,change room to Available
                    if (!string.IsNullOrEmpty(reservationStatus) && reservationStatus.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                    {
                        string updateRoomQuery = @"UPDATE Rooms SET Status = 'Available' WHERE RoomID = @RoomID";

                        using (var updateCmd = new MySqlCommand(updateRoomQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@RoomID", roomId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    // Delete reservation
                    string deleteReservationQuery = @"DELETE FROM Reservations WHERE ReservationID = @ReservationID";

                    using (var deleteCmd = new MySqlCommand(deleteReservationQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@ReservationID", reservationId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Reservation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearFields();
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            bool hasSelection = guna2DataGridView1.SelectedRows.Count > 0;

            updateBtn.Enabled = hasSelection;

            if (hasSelection)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];

                if (selectedRow.Cells["CheckInDate"].Value != DBNull.Value && selectedRow.Cells["CheckInDate"].Value is DateTime)
                {
                    checkInDatePicker.Value = Convert.ToDateTime(selectedRow.Cells["CheckInDate"].Value);
                }
                else
                {
                    checkInDatePicker.Value = DateTime.Today;
                }

                if (selectedRow.Cells["CheckOutDate"].Value != DBNull.Value && selectedRow.Cells["CheckOutDate"].Value is DateTime)
                {
                    checkOutDatePicker.Value = Convert.ToDateTime(selectedRow.Cells["CheckOutDate"].Value);
                }
                else
                {
                    checkOutDatePicker.Value = DateTime.Today;
                }

                roomComboBox.SelectedIndex = roomComboBox.FindString(selectedRow.Cells["RoomNumber"].Value?.ToString() ?? "");
                clientComboBox.SelectedIndex = clientComboBox.FindString(selectedRow.Cells["ClientName"].Value?.ToString() ?? "");
                numGuestsTextBox.Text = selectedRow.Cells["NumberOfGuests"].Value?.ToString() ?? "";
                totalPriceTextBox.Text = selectedRow.Cells["TotalPrice"].Value?.ToString() ?? "";
                statusComboBox.SelectedItem = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            }
            else
            {
                ClearFields();
            }
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();

        }

        private void filterBtnRoom_Click(object sender, EventArgs e)
        {
            roomComboBox.BorderColor = Color.LightBlue;

            if (roomComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room to filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT r.ReservationID, rm.RoomNumber, c.Name AS ClientName, 
                         r.CheckInDate, r.CheckOutDate, r.NumberOfGuests, 
                         r.TotalPrice, r.Status
                         FROM Reservations r
                         JOIN Rooms rm ON r.RoomID = rm.RoomID
                         JOIN Clients c ON r.ClientID = c.ClientID
                         WHERE rm.RoomNumber = @RoomNumber";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNumber", roomComboBox.Text);
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fildterBtnClient_Click(object sender, EventArgs e)
        {

            clientComboBox.BorderColor = Color.LightBlue;

            if (clientComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a client to filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT r.ReservationID, rm.RoomNumber, c.Name AS ClientName, 
                         r.CheckInDate, r.CheckOutDate, r.NumberOfGuests, 
                         r.TotalPrice, r.Status
                         FROM Reservations r
                         JOIN Rooms rm ON r.RoomID = rm.RoomID
                         JOIN Clients c ON r.ClientID = c.ClientID
                         WHERE c.Name = @ClientName";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientName", clientComboBox.Text);
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void filterBtnStatus_Click(object sender, EventArgs e)
        {
            statusComboBox.BorderColor = Color.LightBlue;

            if (statusComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status to filter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT r.ReservationID, rm.RoomNumber, c.Name AS ClientName, 
                         r.CheckInDate, r.CheckOutDate, r.NumberOfGuests, 
                         r.TotalPrice, r.Status
                         FROM Reservations r
                         JOIN Rooms rm ON r.RoomID = rm.RoomID
                         JOIN Clients c ON r.ClientID = c.ClientID
                         WHERE r.Status = @Status";

                DataTable dataTable = new DataTable();

                using (var conn = Database.GetConnection())
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", statusComboBox.Text);
                        conn.Open();
                        dataTable.Load(cmd.ExecuteReader());
                    }
                }

                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering by status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();


        }

        private void clientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkInDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();


        }

        private void checkOutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();


        }

        private void totalPriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numGuestsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(numGuestsTextBox.Text.Trim(), out int nbfGuests) || nbfGuests <= 0)
            {
                numGuestsTextBox.Text = "1";
            }
            UpdateTotalPrice();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refrechBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Fetch all reservations with checkout dates before today and status not Ended
                    string fetchQuery = @"SELECT ReservationID, RoomID 
                                  FROM Reservations 
                                  WHERE CheckOutDate < @Today AND Status != 'Ended'";

                    using (var fetchCmd = new MySqlCommand(fetchQuery, conn))
                    {
                        fetchCmd.Parameters.AddWithValue("@Today", DateTime.Today);

                        using (var reader = fetchCmd.ExecuteReader())
                        {
                            DataTable expiredReservations = new DataTable();
                            expiredReservations.Load(reader);

                            foreach (DataRow row in expiredReservations.Rows)
                            {
                                int reservationId = Convert.ToInt32(row["ReservationID"]);
                                int roomId = Convert.ToInt32(row["RoomID"]);

                                // Update reservation to Ended
                                string updateReservationQuery = @"UPDATE Reservations 
                                                          SET Status = 'Ended' 
                                                          WHERE ReservationID = @ReservationID";

                                using (var updateReservationCmd = new MySqlCommand(updateReservationQuery, conn))
                                {
                                    updateReservationCmd.Parameters.AddWithValue("@ReservationID", reservationId);
                                    updateReservationCmd.ExecuteNonQuery();
                                }

                                // Update room to Available
                                string updateRoomQuery = @"UPDATE Rooms 
                                                   SET Status = 'Available' 
                                                   WHERE RoomID = @RoomID";

                                using (var updateRoomCmd = new MySqlCommand(updateRoomQuery, conn))
                                {
                                    updateRoomCmd.Parameters.AddWithValue("@RoomID", roomId);
                                    updateRoomCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    MessageBox.Show("Reservation statuses and room availabilities have been refreshed.",
                                    "Refresh Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reload reservations
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while refreshing reservations: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void client_Click(object sender, EventArgs e)
        {

        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
