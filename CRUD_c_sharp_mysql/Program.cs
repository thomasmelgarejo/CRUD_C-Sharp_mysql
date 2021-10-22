using MySqlConnector;
using System;

namespace CRUD_c_sharp_mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //new Program()._insert();
            //new Program()._update();
            //new Program()._delete();
            new Program()._selectAll();
        }


        private void _selectAll()
        {
            try
            {
                //Connection string
                string MyConnection = "datasource=localhost;port=3306;username=root;password=1234";

                //Query String
                string Query = "select * from c_sharp_test.student;";

                //Connection and command objects created
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);

                //Opens connection
                MyConn.Open();
                Console.WriteLine("Connection Open");
                using MySqlDataReader reader = MyCommand.ExecuteReader();

                //Reads data
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                }

                MyConn.Close();
                Console.WriteLine("Connection Closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        private void _delete()
        {
            int studentId = 3;

            try
            {
                //Connection string
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                //Query String
                string Query = "delete from c_sharp_test.student where studentId='" + studentId + "';";


                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                //Opens connection and execute command
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                Console.WriteLine("Data deleted");

                //Close connection
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        private void _update()
        {
            string name = "Hansen";
            int age = 102;
            int studentId = 4;

            try
            {
                //Connection string
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                //Query String
                string Query = "update c_sharp_test.student set name='" + name + "',age='" + age + "' where studentId='" + studentId + "';";

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                Console.WriteLine("Connection open");
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                Console.WriteLine("Data updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here  
                Console.WriteLine("Connection closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        private void _insert()
        {
            //skal flyttes op som parameter
            string name = "Fisker";
            int age = 45;

            try
            {
                //Connection string
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=1234";

                //Query String
                string Query = "insert into c_sharp_test.student(name,Age) values('" + name + "','" + age + "');";

                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                Console.WriteLine("Save Data");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }


    }
}
