using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class Program
    {
        //get courses
        //add to DB

        static void Main(string[] args)
        {
            Console.WriteLine("Enter (course) or (professor)");
            var reply = Console.ReadLine();
            const string CONNECTION_STRING =
               @"Server=localhost\SQLEXPRESS;Database=Universities;Trusted_Connection=True;";

            if (reply == "professor")
            {
                Console.WriteLine("Enter professor name");
                var pname = Console.ReadLine();
                Console.WriteLine("Enter professor title: Mr., Mrs., Dr., etc");
                var tname = Console.ReadLine();
                var newProfessor = new Professor
                {
                    Name = pname,
                    Title = tname,
                };

                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    //var newProfessor = new Professor
                    //{
                    //    Name = "Bueller",
                    //   Title = "Mr.",
                    //};

                    conn.Open();
                    ProfessorService.InsertProfessor(conn, newProfessor);
                    ProfessorService.GetAllProfessors(conn);
                }
            }
            else
            {
                Console.WriteLine("Enter course number:");
                var cnumber = Console.ReadLine();
                Console.WriteLine("Enter course level:");
                var clevel = Console.ReadLine();
                Console.WriteLine("Enter course name:");
                var cname = Console.ReadLine();
                Console.WriteLine("Enter room number:");
                var roomnumber = Console.ReadLine();
                Console.WriteLine("Enter start time in :");
                var starttime = Console.ReadLine();
                Console.WriteLine("Enter professor ID");
                var pid = Console.ReadLine();
                var convertedpid = Convert.ToInt32(pid);

                var newcourse = new Course
                {
                    CourseNumber = cnumber,
                    CourseLevel = clevel,
                    CourseName = cname,
                    RoomNumber = roomnumber,
                    StartTime = starttime,
                    ProfessorID = convertedpid
                };

                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    //var newCourse = new Course
                    //{
                    //    CourseNumber = "100",
                    //    CourseLevel = "1",
                    //    CourseName = "Math Level 1",
                    //    RoomNumber = "10",
                    //    StartTime = "8AM",
                    //    ProfessorID = 1
                    //};

                    conn.Open();
                    CourseService.InsertCourse(conn, newcourse);
                    CourseService.GetAllCourses(conn);
                }
            }
        }
    }
}
