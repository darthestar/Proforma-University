using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class StudentService
    {
        public StudentService()
        {

        }

        public static void InsertStudent(SqlConnection conn, Student student)
        {
            const string V = "           VALUES (@StudentName, @Email, @Phone, @Major)";
            var _insert = "INSERT INTO Students (StudentName, Email, Phone, Major)" +
                V;
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("Email", student.Email);
            cmd.Parameters.AddWithValue("Phone", student.Phone);
            cmd.Parameters.AddWithValue("Major", student.Major);
            cmd.ExecuteScalar();
        }
    }
}
