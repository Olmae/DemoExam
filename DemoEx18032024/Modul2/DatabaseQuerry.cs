using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DemoEx18032024.Modul2
{
    internal class DatabaseQuerry
    {
        private string _connectionString = "Data Source=\"10.118.95.29, 1433\";Initial Catalog=18032024User12ErenburgDanya;Persist Security Info=True;User ID=User_04_012;Password=t7cjHlsCMm";

        public string AuthenticateUser(string identifier, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT Password FROM [User] WHERE Email = @Identifier OR Login = @Identifier";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Identifier", identifier);
                    var hashedPassword = command.ExecuteScalar() as string;

                    if (hashedPassword != null)
                    {
                        //Проверка совпадения пароля
                        if (VerifyPassword(password, hashedPassword))
                        {
                            return "Success";
                        }
                        else
                        {
                            return "IncorrectPassword";
                        }
                    }
                    else
                    {
                        return "UserNotFound";
                    }
                }
            }
        }

        private bool VerifyPassword(string inputPassword, string DBPass)
        {
            string InputPassword = inputPassword;

            return string.Equals(InputPassword, DBPass);
        }

        public string VerifyRole(string identifier)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT Role FROM [User] WHERE Email = @Identifier OR Login = @Identifier";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@Identifier", SqlDbType.NVarChar).Value = identifier;
                    var role = command.ExecuteScalar();

                    if (role != null && role != DBNull.Value)
                    {
                        return role.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void CreateRequest(string name, string Number, string Email, string Device, string SerialNumber, string Descprition, string Comment, string Status)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Request (Name, Number, Email, Device, SerialNumber, Description, Comment, Status, StartDate) " +
                                  "VALUES (@Name, @Number, @Email, @Device, @SerialNumber, @Description, @Comment, @Status, @Start_Date)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Number", Number);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Device", Device);
                    command.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                    command.Parameters.AddWithValue("@Description", Descprition);
                    command.Parameters.AddWithValue("@Comment", Comment);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Start_Date", DateTime.Now);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public List<string> GetDevice()
        {
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT Name FROM [Device]";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    SqlDataReader DR = command.ExecuteReader();
                    while (DR.Read())
                    {
                        list.Add(DR[0].ToString());
                    }

                    return list;
                }
            }
        }

        public DataTable GetAllRequests()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Request";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public List<string> GetIdRequest()
        {
            List<string> listid = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT id FROM [Request]";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    SqlDataReader DR = command.ExecuteReader();
                    while (DR.Read())
                    {
                        listid.Add(DR[0].ToString());
                    }

                    return listid;
                }
            }
        }

        public string GetDescription(string num)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = $"SELECT Description FROM [Request] where id ={num}";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    var description = command.ExecuteScalar();
                    return description.ToString();
                }
            }
        }
        public List<string> GetIdWorker()
        {
            List<string> listworker = new List<string>();
            string role = "Editor";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = $"SELECT Fio FROM [User] where Role = @role";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@role", role);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    SqlDataReader DR = command.ExecuteReader();
                    while (DR.Read())
                    {
                        listworker.Add(DR[0].ToString());
                    }

                    return listworker;
                }
            }
        }

        public List<string> GetBreakdownsByDeviceId(int deviceId)
        {
            List<string> breakdowns = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT Name FROM [BreakPoint] WHERE idDevice = @deviceId";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@deviceId", deviceId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        breakdowns.Add(reader["Name"].ToString());
                    }
                }
            }

            return breakdowns;
        }

        public int GetDeviceID(string selectedName)
        {
            int deviceID = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT id FROM Device WHERE Name = @SelectedName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedName", selectedName);
                    connection.Open();
                    deviceID = (int)command.ExecuteScalar();
                }
            }

            return deviceID;
        }

        public string GetDeviceName(int id)
        {
            string nameDevice = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Device FROM Request WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    nameDevice = command.ExecuteScalar().ToString();
                }
            }
            return nameDevice;
        }

        public int GetIdWorker(string FIO)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT id FROM [User] WHERE FIO = @SelectedName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedName", FIO);
                    connection.Open();
                    id = (int)command.ExecuteScalar();
                }
            }

            return id;
        }


        public List<string> GetWorker()
        {
            string role = "Worker";
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT FIO FROM [User] where Role = @Worker";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@Worker", SqlDbType.NVarChar).Value = role;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    SqlDataReader DR = command.ExecuteReader();
                    while (DR.Read())
                    {
                        list.Add(DR[0].ToString());
                    }

                    return list;
                }
            }
        }


        public void UpdateWorker(int id, string FIO)
        {
            int IDworker = GetIdWorker(FIO);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "UPDATE IdWorker FROM [User] where Id = @ID";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    IDworker = (int)command.ExecuteScalar();
                }
            }
        }
    }
}

