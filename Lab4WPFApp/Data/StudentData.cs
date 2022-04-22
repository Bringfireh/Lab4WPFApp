using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace Lab4WPFApp.Business
{
    class StudentData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        //Queries and ConnectionString (The connection string is got from App.Config file...
        public string selectAllQuery = "SELECT * FROM students";
        public string insertQuery = "INSERT INTO `students` (`ID`, `Name`, `Surname`, `Gender`, `Email`) VALUES (@ID, @Name,@Surname, @Gender, @Email)";
        public string deleteQuery = "DELETE FROM students WHERE ID=@ID";
        public string updateQuery = "UPDATE students SET Name=@Name, Surname=@Surname, Gender=@Gender, Email=@Email WHERE ID=@ID";
        public string ConnectionString = ConfigurationManager.ConnectionStrings["WPFConnection"].ConnectionString;
    }

}

