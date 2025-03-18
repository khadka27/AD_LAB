using Oracle.ManagedDataAccess.Client;

public class DatabaseHandler
{
	public string _connectionString = "User Id=abishek;Password=khadka;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=xe)));";

	public List<Student> Students;

	public async Task<List<Student>> GetStudentDetail()
	{
		using (var connection = new OracleConnection(_connectionString))
		{
			await connection.OpenAsync();

			using (var command = new OracleCommand("SELECT Id, Name, Gender FROM Students", connection))
			{
				using (var reader = await command.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						Students.Add(new Student
						{
							Id = reader.GetInt32(0),
							Name = reader.GetString(1),
							Gender = reader.GetString(2)
						});
					}
				}
			}
		}

		return Students;
	}
}
