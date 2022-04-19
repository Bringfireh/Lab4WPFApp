using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Lab4WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MySqlConnection connection;


        public MainWindow()
        {
            
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            string ConnectionString = "SERVER=localhost;DATABASE=studentdata;UID=root;PASSWORD=";
            connection = new MySqlConnection(ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM students", connection);
            this.OpenConnection();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            this.CloseConnection();

            dgRecord.DataContext = dt;
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
                //Handled Errors.
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
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
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool Insert()
        {
            string query = "INSERT INTO `students` (`ID`, `Name`, `Surname`, `Gender`, `Email`) VALUES ('" + txtID.Text +"', '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtGender.Text + "', '" + txtEmail.Text + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                try
                {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
                    return true;
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }
            return false;
        }

        //Update statement
        public bool Update()
        {
            string query = "UPDATE students SET Name='" + txtName.Text+ "', Surname='" +txtSurname.Text + "', Gender='"+txtGender.Text +"', Email='" +txtEmail.Text+"' WHERE ID='" +txtID.Text +"'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            return false;
        }

        //Delete statement
        public bool Delete()
        {
            string query = "DELETE FROM students WHERE ID='" + txtID.Text +"'";

            if (this.OpenConnection() == true)
            {
                try {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                } catch (MySqlException ex) { MessageBox.Show(ex.Message); }
                
            }
            return false;
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //Control ctrl = new Control();

            txtName.Text = "";
            txtSurname.Text = "";
            txtGender.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(txtID.Text=="" || txtID.Text==" ")
            {
                MessageBox.Show( "You must provide ID for the record to be deleted", "Error Message");
            }
            else
            {
                bool isDeleted=Delete();
                if (isDeleted == true)
                {
                    MessageBox.Show("Record deleted sucessfully", "Success Message");
                    LoadData();
                }
                
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtName.Text == " " || txtSurname.Text == "" || txtSurname.Text == " " || txtGender.Text == "" || txtGender.Text == " " || txtEmail.Text == "" || txtEmail.Text == " " || txtID.Text == "" || txtID.Text == " ")
            {
                MessageBox.Show("Please provide all informations", "Error Message");
            }
            bool istrue=Insert();
            if (istrue == true)
            {
                MessageBox.Show("Record Inserted sucessfully", "Success Message");
                LoadData();
            }
            
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtName.Text==" " || txtSurname.Text == "" || txtSurname.Text == " " || txtGender.Text == "" || txtGender.Text == " " || txtEmail.Text == "" || txtEmail.Text == " " || txtID.Text == "" || txtID.Text == " ")
            {
                MessageBox.Show("Please provide all informations", "Error Message");
            }
            
           
            bool isUpdated = Update();
            if (isUpdated == true)
            {
                MessageBox.Show("Record Updated sucessfully", "Success Message");
                LoadData();
            }
        }
    }
}
