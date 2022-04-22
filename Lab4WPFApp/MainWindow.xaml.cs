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
using Lab4WPFApp.Business;


namespace Lab4WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentLogic sl= new StudentLogic();


        public MainWindow()
        {
            
            InitializeComponent();
            try
            {
                dgRecord.DataContext = sl.LoadData();
            }
            catch(Exception ex) {
                MessageBox.Show("Connection Error. Contact Admin. Error Details: " + ex.Message, "MySql Error Message!");
            }
            

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
                bool isDeleted=sl.Delete(txtID.Text);
                if (isDeleted == true)
                {
                    MessageBox.Show("Record deleted sucessfully", "Success Message");
                    dgRecord.DataContext=sl.LoadData();
                }
                
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtName.Text == " " || txtSurname.Text == "" || txtSurname.Text == " " || txtGender.Text == "" || txtGender.Text == " " || txtEmail.Text == "" || txtEmail.Text == " " || txtID.Text == "" || txtID.Text == " ")
            {
                MessageBox.Show("Please provide all informations", "Error Message");
            }
            else
            {
                bool istrue = sl.Insert(txtID.Text , txtName.Text ,  txtSurname.Text , txtGender.Text,  txtEmail.Text );
                if (istrue == true)
                {
                    MessageBox.Show("Record Inserted sucessfully", "Success Message");
                    dgRecord.DataContext =sl.LoadData();
                }
                else
                {
                    MessageBox.Show("Could Not Insert Record. Duplicate Entry", "Error Message");
                }
            }
           
            
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtName.Text==" " || txtSurname.Text == "" || txtSurname.Text == " " || txtGender.Text == "" || txtGender.Text == " " || txtEmail.Text == "" || txtEmail.Text == " " || txtID.Text == "" || txtID.Text == " ")
            {
                MessageBox.Show("Please provide all informations", "Error Message");
            }
            else
            {
                
                bool isUpdated = sl.Update(txtName.Text,txtSurname.Text,txtGender.Text,txtEmail.Text,txtID.Text);
                if (isUpdated == true)
                {
                    MessageBox.Show("Record Updated sucessfully", "Success Message");
                    dgRecord.DataContext = sl.LoadData();
                }
            }
            
           
           
        }
    }
}
