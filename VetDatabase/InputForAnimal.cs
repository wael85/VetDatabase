using System;

namespace InsertInDatabas
{
    class InputForAnimal
    {
        public static Animal Input()
        {
            Console.WriteLine("Inter Patient Name");
            String name = Console.ReadLine();
            Console.WriteLine("Inter Type");
            String type = Console.ReadLine();
            Console.WriteLine("Inter Date of birth");
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            DateTime dob = new DateTime(year, month, day);

            Console.WriteLine("inter OwnerId");
            int ownerID = Convert.ToInt32(Console.ReadLine());
            Animal x = new Animal { Name = name, Type = type, Dob = dob, OwnerID = ownerID };
            return x;

        }
    }
}
