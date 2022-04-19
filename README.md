# Lab4WPFApp
A Simple WPF Application that connects to MySQL Database and performs CRUD Operations on the database
# Database Setup
1. Create the MySql Database named <b>studentdata </b>
2. Create a table <b>students</b> with fields(ID varchar(10), Name varchar(50), Surname varchar(250), Gender varchar(10), Email varchar(50)).
3. Set ID to be primary key.
4. Make sure you have the connectionstring = "SERVER=localhost;DATABASE=studentdata;UID=root;PASSWORD=";
# Running the Application
1. Install the mysql-connector-net-8.0.28.msi setup.
2. Run the application (By selecting Debug Start without debuging).

# Replicating the Application
1. Make sure the mysql-connector-net-8.0.28.msi installer is runned on your Machine.
2. Create a WPF Application
3. Add Reference - MySql.Data
4. Fix the Import - using MySql.Data.MySqlClient;
5. Design the Application and Write the connection String
6. Run the Application.
# *******************************************************
Thank you.
