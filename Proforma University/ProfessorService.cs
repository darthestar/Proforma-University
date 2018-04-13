using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Proforma_University
{
    class ProfessorService
    {

        public static void InsertProfessor(SqlConnection conn, Professor newProfessor)
        {
            const string V = "           VALUES (@Name, @Title)";
            var _insert = "INSERT INTO Professors (Name, Title)" +
                V;
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", newProfessor.Name);
            cmd.Parameters.AddWithValue("Title", newProfessor.Title);

            cmd.ExecuteScalar();
        }

        public static List<Professor> GetAllProfessors(SqlConnection conn)
        {

            // Query the database
            var _select = "SELECT ID, Name, Title" +
                " FROM Professors";

            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Professor>();

            // parse the results
            while (reader.Read())
            {
                var _professor = new Professor(reader);
                Console.WriteLine(_professor.Name + "was added");
            }
            ///Console.ReadLine();
            return _rv;
        }
    }
}
