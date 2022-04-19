using System;
using System.Collections.Generic;
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
            string ConnectionString = "SERVER=localhost;DATABASE=lab4wpf;UID=root;PASSWORD=";
            connection = new MySqlConnection(ConnectionString);

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
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
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
                Delete();
            }
        }
    }
}
