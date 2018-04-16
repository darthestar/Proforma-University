using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class ElectedCourse
    {
        public int Id { get; set; }
        public int CoursesId { get; set; }
        public int StudentsId { get; set; }

        public ElectedCourse()
        {

        }

        public ElectedCourse(SqlDataReader reader)
        {
            Id = (int)reader["ID"];
            CoursesId = (int)reader["CoursesID"];
            StudentsId = (int)reader["StudentsID"];

        }
    }
}
