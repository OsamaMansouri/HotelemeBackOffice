using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    public partial class Exports : Form
    {
        public Exports()
        {
            InitializeComponent();
        }

        private void ExportToExcel(DataTable dataTable, string fileName)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(dataTable, "ExportedData");
                    workbook.SaveAs(fileName);
                }

                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetData(string query)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void exportclientsBtn_Click(object sender, EventArgs e)
        {
            var query = "SELECT ClientID, Name, Email, Phone, Address FROM Clients";
            var dataTable = GetData(query);

            if (dataTable != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Clients Data"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }

        private void exportroomsBtn_Click(object sender, EventArgs e)
        {
            var query = "SELECT RoomID, RoomNumber, RoomTypeID, Status, PricePerNight, Description FROM Rooms";
            var dataTable = GetData(query);

            if (dataTable != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Rooms Data"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }

        private void exportreservationsBtn_Click(object sender, EventArgs e)
        {
            var query = @"SELECT r.ReservationID, ro.RoomNumber, c.Name AS ClientName, r.CheckInDate, r.CheckOutDate, 
                          r.NumberOfGuests, r.TotalPrice, r.Status 
                          FROM Reservations r
                          JOIN Rooms ro ON r.RoomID = ro.RoomID
                          JOIN Clients c ON r.ClientID = c.ClientID";
            var dataTable = GetData(query);

            if (dataTable != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Reservations Data"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }

        private void exporttasksBtn_Click(object sender, EventArgs e)
        {
            var query = @"SELECT t.TaskID, r.RoomNumber, t.Description, u.Name AS AssignedTo, t.Status, 
                          t.CreatedAt, t.CompletedAt
                          FROM Tasks t
                          JOIN Rooms r ON t.RoomID = r.RoomID
                          LEFT JOIN Users u ON t.AssignedTo = u.UserID";
            var dataTable = GetData(query);

            if (dataTable != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Tasks Data"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }

        private void exportrequestsBtn_Click(object sender, EventArgs e)
        {
            var query = @"SELECT rq.RequestID, ro.RoomNumber, c.Name AS ClientName, rq.Description, u.Name AS AssignedTo, 
                          rq.Status, rq.CreatedAt, rq.CompletedAt
                          FROM Requests rq
                          JOIN Rooms ro ON rq.RoomID = ro.RoomID
                          JOIN Clients c ON rq.ClientID = c.ClientID
                          LEFT JOIN Users u ON rq.AssignedTo = u.UserID";
            var dataTable = GetData(query);

            if (dataTable != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Requests Data"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(dataTable, saveFileDialog.FileName);
                }
            }
        }

        private void exportcroomsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
