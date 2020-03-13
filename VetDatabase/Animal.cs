using System;
using System.Collections;
using System.Collections.Generic;
namespace InsertInDatabas
{
    class Animal : CRUD
    {
        private string tableName = "Animal";
        private int patientID;
        private string name;
        private string type;
        private DateTime dob;
        private int ownerID;
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Dob { get; set; }
        public int OwnerID { get; set; }





        public int ToSave()
        {
            ArrayList values = new ArrayList() { Name, Type, Dob, OwnerID };
            List<String> keys = new List<string>() { "name", "Type", "dob", "ownerID" };
            string tableName = "Animal";
            int ID = InsertIntoDatabase(tableName, values, keys);
            return ID;

        }
        public void ToUpdate(int id)
        {
            ArrayList values = new ArrayList() { Name, Type, Dob, OwnerID };
            List<String> keys = new List<string>() { "name", "Type", "dob", "ownerID" };
            string tablName = tableName;
            
            UpdatePatient(id ,tableName,  values, keys);


        }

       
    }
}
