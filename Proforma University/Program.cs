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
                    conn.Open();
                    CourseService.InsertCourse(conn, newcourse);
                    CourseService.GetAllCourses(conn);
                }
            }
            Console.WriteLine("Enter Student Name");
            var sname = Console.ReadLine();
            Console.WriteLine("Enter Student Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Student Phone");
            var phone = Console.ReadLine();
            Console.WriteLine("Enter Student Major");
            var major = Console.ReadLine();

            var newStudent = new Student
            {
                StudentName = sname,
                Email = email,
                Phone = phone,
                Major = major,
            };

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                StudentService.InsertStudent(conn, newStudent);
            }

            Console.WriteLine("Enroll or View My Enrolled Class List? Type (enroll) or (view)");
            reply = Console.ReadLine();
            if (reply == "enroll")
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    CourseService.GetAllCourses(conn);
                    Console.WriteLine("Enter course ID to enroll");
                    var answer = Console.ReadLine();
                    var courseid = Convert.ToInt32(answer);
                    Console.WriteLine("Enter name");
                    var enrolleeName = Console.ReadLine();

                    var _select = "SELECT ID, StudentName, Email, Phone, Major" +
                " FROM Students" +
                " WHERE Students.StudentName = " + enrolleeName;

                    var query = new SqlCommand(_select, conn);
                    var reader = query.ExecuteReader();
                    var _rv = new List<Student>();
                    var studentid = 0;
                    // parse the results
                    
                    while (reader.Read())
                    {
                        var _student = new Student(reader);
                        studentid = _student.Id;
                    }

                    reader.Close();

                    var electedCourse = new ElectedCourse
                    {
                        CoursesId = courseid,
                        StudentsId = studentid,
                    };
                    Console.WriteLine(electedCourse.StudentsId);
                    CourseService.GetSelectedCourse(conn, courseid);
                    CourseService.InsertElectedCourse(conn, electedCourse);
                }
            }
        }
    }
}
