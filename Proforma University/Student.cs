using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class Student
    {
        public int Id { get; set;}
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Major { get; set; }

        public Student()
        {

        }

        public Student(string StudentName, string Email, string Phone, string Major)
        {

        }

        public Student(SqlDataReader reader)
        {
            Id = (int)reader["ID"];
            StudentName = reader["StudentName"].ToString();
            Email = reader["Email"].ToString();
            Phone = reader["Phone"].ToString();
            Major = reader["Major"].ToString();
        }
    }
}
