using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Proforma_University
{
    class Course 
    {
        public int Id { get; set; }
        public string CourseNumber { get; set; }
        public string CourseLevel { get; set; }
        public string CourseName { get; set; }
        public string RoomNumber { get; set; }
        public string StartTime { get; set; }
        public int ProfessorID { get; set; }


        public Course()
        {

        }

        public Course(string CourseNumber, string CourseLevel, string CourseName, string RoomNumber, string StartTime, int ProfessorID)
        {

        }

        public Course(SqlDataReader reader)
        {
            Id = (int)reader["ID"];
            CourseNumber = reader["CourseNumber"].ToString();
            CourseLevel = reader["CourseLevel"].ToString();
            CourseName = reader["CourseName"].ToString();
            RoomNumber = reader["RoomNumber"].ToString();
            StartTime = reader["StartTime"].ToString();
            ProfessorID = (int)reader["ProfessorID"];

        }
    }
}
