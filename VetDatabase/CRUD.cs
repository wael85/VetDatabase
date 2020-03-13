using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InsertInDatabas
{
    abstract class CRUD
    {
        private SqlConnection mycon;
        public void Conect(SqlConnection c)
        {
            mycon = c;
        }
        
        protected int InsertIntoDatabase(string tableName, ArrayList values, List<string> keys)
        {
            mycon = Conection.MakeCon();
            string fieldNames = string.Join(",", keys);
            string parameters = "@" + string.Join(",@", keys);
            string quary = "INSERT INTO " + tableName + "(" + fieldNames + ")" + " OUTPUT INSERTED.PatientID " + "VALUES" + "(" + parameters + ") ";
            SqlCommand cmd = new SqlCommand(quary, mycon);
            for (int i = 0; i < keys.Count; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);

            }

            try
            {
                mycon.Open();
                int ID = (int)cmd.ExecuteScalar();


                mycon.Close();
                return ID;
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    Console.WriteLine(ex.Errors[i].Message);

                    Console.WriteLine(ex.Errors[i].LineNumber);

                    Console.WriteLine(ex.Errors[i].Source);

                    Console.WriteLine(ex.Errors[i].Number);
                }
            }
            return 0;
        }
        public static void ReadFromDatabas(string tableName)
        {
           SqlConnection mycon = Conection.MakeCon();
            List<Animal> mylist = new List<Animal>();
            String select = "select * from " + tableName;
            SqlCommand cmd = new SqlCommand(select, mycon);
            mycon.Open();
            SqlDataReader Result = cmd.ExecuteReader();
            while (Result.Read())
            {
                Animal a = new Animal();
                a.PatientID = Result.GetInt32(0);
                a.Name = Result.GetString(1);
                a.Type = Result.GetString(2);
                a.Dob = Result.GetDateTime(3);
                a.OwnerID = Result.GetInt32(4);
                mylist.Add(a);

            }

            mycon.Close();
            foreach (Animal x in mylist)
            {
                Console.WriteLine(x.PatientID + " " + x.Name + " " + x.Type + " " + x.Dob + " " + x.OwnerID);
            }


        }
        protected void UpdatePatient(int id ,string tableName, ArrayList values, List<string> keys)
        {
            SqlConnection mycon = Conection.MakeCon();           
            string build ="";
            for (int i = 0; i < keys.Count; i ++)
            {
                if (i == keys.Count - 1)
                {
                    build += keys[i] + " = @" + keys[i];
                }
                else
                {
                    build += keys[i] + " = @" + keys[i] + ",";
                }

            }
            

            string update = "update Animal  set "+build+ " where patientId = "+id;  // "update " + tableName + "SET "+build+"  where patientId = "+ id ;
            
            SqlCommand cmd = new SqlCommand(update, mycon);
            for (int i = 0; i < keys.Count; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);

            }

            try
            {
                mycon.Open();
                cmd.ExecuteNonQuery();
                mycon.Close();
                
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {

                    Console.WriteLine(ex.Errors[i].Message);

                    Console.WriteLine(ex.Errors[i].LineNumber);

                    Console.WriteLine(ex.Errors[i].Source);

                    Console.WriteLine(ex.Errors[i].Number);
                }
            }
            

        }
        public static void DeleteRow(string tableName, string columnName ,int id)
        {
            SqlConnection mycon = Conection.MakeCon();
            string deleteById = "DELETE FROM " + tableName + " WHERE " + columnName + "=" + id;
            SqlCommand cmd = new SqlCommand(deleteById, mycon);
            mycon.Open();
            cmd.ExecuteNonQuery();
            mycon.Close();


        }
        public static void Options()
        {
          
            while (true)
            {
                Console.WriteLine("Welcom to Animal planet\n" +
              "Choose one off fowlowing options: \n" +
              "1) New Patient.\n" +
              "2) Update existed Patient.\n" +
              "3) Delete Patient. \n" +
              "4) Show all patient .\n" +
              "5) To exit.");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Animal A = InputForAnimal.Input();
                        int ID = A.ToSave();
                        if (ID != 0)
                         {
                         Console.WriteLine("Your data are interd successfuly by ID : {0} ",ID );
                         }
                        Console.WriteLine("#######################################################\n");
                        break;
                    case 2:
                        Console.WriteLine("please Inter the ID of Patient you need to update:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Animal B = InputForAnimal.Input();
                        B.ToUpdate(id);
                        Console.WriteLine("#######################################################\n");
                        break;
                    case 3:
                        Console.WriteLine("please Inter the ID of Patient you need to Delete:");
                        int deleteID = Convert.ToInt32(Console.ReadLine());
                        DeleteRow("Animal", "PatientID", deleteID);
                        Console.WriteLine("Patient with ID number {0} is deleted .",deleteID);
                        Console.WriteLine("#######################################################\n");
                        break;
                    case 4:
                        ReadFromDatabas("Animal");
                        Console.WriteLine("#######################################################\n");
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Your intering is not valid please try Again.");
                        Console.WriteLine("#######################################################\n");
                        break;
                                                                                                                                                   

                }
            }
        }
    }
}
