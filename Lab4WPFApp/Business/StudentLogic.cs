using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Lab4WPFApp.Business
{
    class StudentLogic
    {
        private StudentData sd = new StudentData();

        private static MySqlConnection connection;


        public DataTable LoadData()
        {

            var ConnectionString = sd.ConnectionString;


            connection = new MySqlConnection(ConnectionString);
            string q = sd.selectAllQuery;
            MySqlCommand cmd = new MySqlCommand(q, connection);
            this.OpenConnection();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            this.CloseConnection();

            //dgRecord.DataContext = dt;
            return dt;
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool Insert(string ID, string Name, string Surname, string Gender, string Email)
        {
            
            string query = sd.insertQuery;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Surname", Surname);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //return false;
                    //MessageBox.Show(ex.Message);

                }
            }
            return false;
        }

        //Update statement
        public bool Update(string Name, string Surname, string Gender, string Email, string ID)
        {
            
            string query = sd.updateQuery;
            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Surname", Surname);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                }

            }
            return false;
        }

        //Delete statement
        public bool Delete(string ID)
        {
           
            string query = sd.deleteQuery;
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.Message); 
                }

            }
            return false;
        }

    }
}
