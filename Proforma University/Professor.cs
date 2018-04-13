using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proforma_University
{
    class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public Professor(SqlDataReader reader)
        {
            Id = (int) reader["ID"];
            Name = reader["Name"].ToString();
            Title = reader["Title"].ToString();
        }

        public Professor()
        {

        }
    }
}
