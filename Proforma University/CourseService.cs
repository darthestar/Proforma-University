using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class CourseService
    {
       public CourseService()
        {

        }

        public static List<Course> GetAllCourses(SqlConnection conn)
        {
            // Query the database
            var _select = "SELECT Courses.ID, Courses.CourseNumber, Courses.CourseLevel, Courses.CourseName, Courses.RoomNumber, Courses.StartTime, Courses.ProfessorID" +
                " FROM Courses";

            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Course>();
            // parse the results
            while (reader.Read())
            {
                var _course = new Course(reader);
                Console.WriteLine(_course.CourseName + "was added");
            }
            return _rv;
        }



        public static void InsertCourse(SqlConnection conn, Course newCourse)
        {
            const string V = "           VALUES (@CourseNumber, @CourseLevel, @CourseName, @RoomNumber, @StartTime, @ProfessorID)";
            var _insert = "INSERT INTO Courses (CourseNumber, CourseLevel, CourseName, RoomNumber, StartTime, ProfessorID)" +
                V;
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("CourseNumber", newCourse.CourseNumber);
            cmd.Parameters.AddWithValue("CourseLevel", newCourse.CourseLevel);
            cmd.Parameters.AddWithValue("CourseName", newCourse.CourseName);
            cmd.Parameters.AddWithValue("RoomNumber", newCourse.RoomNumber);
            cmd.Parameters.AddWithValue("StartTime", newCourse.StartTime);
            cmd.Parameters.AddWithValue("ProfessorID", newCourse.ProfessorID);
            cmd.ExecuteScalar();
        }
    }
}
