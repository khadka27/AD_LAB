using Oracle.ManagedDataAccess.Client;
using WeekTwo.Model;

namespace StudentDatabaseAPI.Services
{
    public class DatabaseHandler
    {
        public string _connectionString = "User Id=abishek;Password=khadka;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=xe)));";

        public async Task<List<Appointment>> GetAppointment()
        {
            var appointments = new List<Appointment>();

            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new OracleCommand("SELECT Id, Title, Description, APPOINTMENTDATE FROM appointment", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                appointments.Add(new Appointment
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    AppointmentDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }

            return appointments;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new OracleCommand("SELECT Id, Title, Description, APPOINTMENTDATE FROM Appointment WHERE Id = :id", connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", id));

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Appointment
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    AppointmentDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> AddAppointment(Appointment appointment)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "INSERT INTO Appointment (Title, Description, APPOINTMENTDATE) VALUES (:title, :description, :date)";

                    using (var command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add(new OracleParameter("title", appointment.Title));
                        command.Parameters.Add(new OracleParameter("description", appointment.Description ?? (object)DBNull.Value));
                        command.Parameters.Add(new OracleParameter("date", appointment.AppointmentDate));

                        int result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding appointment: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAppointment(Appointment appointment)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "UPDATE Appointment SET Title = :title, Description = :description, APPOINTMENTDATE = :date WHERE Id = :id";

                    using (var command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add(new OracleParameter("title", appointment.Title));
                        command.Parameters.Add(new OracleParameter("description", appointment.Description ?? (object)DBNull.Value));
                        command.Parameters.Add(new OracleParameter("date", appointment.AppointmentDate));
                        command.Parameters.Add(new OracleParameter("id", appointment.Id));

                        int result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sql = "DELETE FROM Appointment WHERE Id = :id";

                    using (var command = new OracleCommand(sql, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", id));

                        int result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting appointment: {ex.Message}");
                return false;
            }
        }
    }
}
