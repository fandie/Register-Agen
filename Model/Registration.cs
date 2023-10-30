using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Data;

namespace Register_Agen.Model
{

    public class IndexModel : PageModel
    {
        public List<Registration>listregister = new List<Registration>();

        public void OnGet()
        {
            try 
            {
                String connectionString = "Data Source=FANDI\\SQLEXPRESS;Initial Catalog=db_agen;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Registration";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Registration registration = new Registration();
                                registration.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                registration.RegDate = reader.GetDateTime(reader.GetOrdinal("RegDate"));
                                registration.RegStatus = reader.GetString(reader.GetOrdinal("RegStatus"));
                                registration.Name = reader.GetString(reader.GetOrdinal("Name"));
                                registration.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                                registration.BirthPlace = reader.GetString(reader.GetOrdinal("BirthPlace"));
                                registration.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("BirthDate")));
                                registration.Address = reader.GetString(reader.GetOrdinal("Address"));
                                registration.Username = reader.GetString(reader.GetOrdinal("Username"));
                                registration.Password = reader.GetString(reader.GetOrdinal("Password"));
                                registration.Email = reader.GetString(reader.GetOrdinal("Email"));
                                registration.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                                registration.IdCard = reader.GetString(reader.GetOrdinal("IdCard"));
                                registration.Strata = reader.GetString(reader.GetOrdinal("Strata"));
                                registration.Institution = reader.GetString(reader.GetOrdinal("Institution"));
                                registration.Major = reader.GetString(reader.GetOrdinal("Major"));
                                registration.GPA = reader.GetDecimal(reader.GetOrdinal("GPA"));
                                registration.StartDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("StartDate")));
                                registration.EndDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("EndDate")));
                                registration.Company = reader.GetString(reader.GetOrdinal("Company"));
                                registration.Field = reader.GetString(reader.GetOrdinal("Field"));
                                registration.Position = reader.GetString(reader.GetOrdinal("Position"));
                                registration.WorkStartDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("WorkStartDate")));
                                registration.WorkEndDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("WorkEndDate")));
                                registration.JobDesc = reader.GetString(reader.GetOrdinal("JobDesk"));
                                registration.AttachmentType = reader.GetString(reader.GetOrdinal("AttachmentType"));
                                registration.FileType = reader.GetString(reader.GetOrdinal("FileType"));
                                registration.FileName = reader.GetString(reader.GetOrdinal("FileName"));
                                registration.FilePath = reader.GetString(reader.GetOrdinal("FilePath"));

                                listregister.Add(registration);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class Registration
    {
        public int ID;
        public DateTime RegDate;
        public string? RegStatus;
        public string? Name;
        public string? Gender;
        public string? BirthPlace;
        public DateOnly BirthDate;
        public string? Address;
        public string? Username;
        public string? Password;
        public string? Email;
        public string? Phone;
        public string? IdCard;
        public string? Strata;
        public string? Institution;
        public string? Major;
        public decimal GPA;
        public DateOnly StartDate;
        public DateOnly EndDate;
        public string? Company;
        public string? Field;
        public string? Position;
        public DateOnly WorkStartDate;
        public DateOnly WorkEndDate;
        public string? JobDesc;
        public string? AttachmentType;
        public string? FileType;
        public string? FileName;
        public string? FilePath;


    }
}