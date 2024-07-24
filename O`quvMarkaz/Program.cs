
using O_quvMarkaz.Services;

public static class Program
{
    static void Main(string[] args)
    {
        var service = new Center();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            var choise = Console.ReadLine();
            Console.Clear();

            switch (choise)
            {
                case "1":
                    TrainingCenter(service);
                    Console.Clear();
                    break;
                case "2":
                    Student(service);
                    Console.Clear();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Error, please try again");
                    break;

            }
        }

    }

    static void TrainingCenter(Center center)
    {
        Console.WriteLine("Admin");
        bool back = false;
        while (!back)
        {
            Console.WriteLine("1. Courses");
            Console.WriteLine("2. Mentors");
            Console.WriteLine("3. Petitions");
            Console.WriteLine("4. Markaz haqida");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                        Console.WriteLine("Courses");
                    bool back1 = false;
                    while (!back1)
                    {
                        Console.WriteLine("1. Add Course");
                        Console.WriteLine("2. Update Course");
                        Console.WriteLine("3. Delete Course");
                        Console.WriteLine("4. List Courses");
                        Console.WriteLine("5. Back");
                        Console.Write("Choose an option: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Type Course Name: ");
                                var tName = Console.ReadLine();
                                center.AddKurs(tName);
                                Console.WriteLine("Successfuly added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                if (center.ListKurslar())
                                {
                                    Console.Write("Type Course Id: ");
                                    var tId = int.Parse(Console.ReadLine());
                                    Console.Write("Type New Course Name: ");
                                    var newTName = Console.ReadLine();
                                    center.UpdateKurs(tId, newTName);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                if (center.ListKurslar())
                                {
                                    Console.Write("Type Course Id: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                center.DeleteKurs(deleteTId);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                center.ListKurslar();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back1 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Error, please try again");
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Mentor");
                    bool back2 = false;
                    while (!back2)
                    {
                        Console.WriteLine("1. Add Mentor");
                        Console.WriteLine("2. Update Mentor");
                        Console.WriteLine("3. Delete Mentor");
                        Console.WriteLine("4. List Mentors");
                        Console.WriteLine("5. Back");
                        Console.Write("Choose an option: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Enter Mentor Name: ");
                                var tName = Console.ReadLine();
                                center.AddMentor(tName);
                                Console.WriteLine("Successfuly added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                if (center.ListMentorlar())
                                {
                                Console.Write("Enter Mentor Id: ");
                                var tId = int.Parse(Console.ReadLine());
                                Console.Write("Enter New Mentor Name: ");
                                var newTName = Console.ReadLine();
                                center.UpdateMentor(tId, newTName);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case "3":
                                if (center.ListMentorlar())
                                {
                                    Console.Write("Enter Mentor Id: ");
                                    var deleteTId = int.Parse(Console.ReadLine());
                                    center.DeleteMentor(deleteTId);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                center.ListMentorlar();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back2 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Error, please try again");
                                break;
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Petitions");
                    center.ListArizalar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("About Academy");
                    center.About();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    back = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Error, please try again");
                    break;
            }

        }
    }

    static void Student(Center center)
    {
        Console.WriteLine("Student");
        bool back = false;
        while (!back)
        {
            Console.WriteLine("1. Courses");
            Console.WriteLine("2. Mentors");
            Console.WriteLine("3. Petitions");
            Console.WriteLine("4. About Academy");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Courses");
                    center.ListKurslar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Mentors");
                    center.ListMentorlar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Petition");
                    bool back1 = false;
                    while (!back1)
                    {
                        Console.WriteLine("1. Add Petition");
                        Console.WriteLine("2. Update Petition");
                        Console.WriteLine("3. Delete Petition");
                        Console.WriteLine("4. Show Petitions");
                        Console.WriteLine("5. Back");
                        Console.Write("Choose an option: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Enter Your Name: ");
                                var tName = Console.ReadLine();
                                Console.Write("Enter Your Surname: ");
                                var fName = Console.ReadLine();
                                Console.Write("Enter Your Phone Number: ");
                                var rName = Console.ReadLine();
                                center.AddAriza(tName, fName, rName);
                                Console.WriteLine("Successfuly added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                if (center.ListArizalar())
                                {
                                Console.Write("Enter an Id: ");
                                var tId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Your New Name: ");
                                var newTName = Console.ReadLine();
                                Console.Write("Enter Your New Surname: ");
                                var newTSurname = Console.ReadLine();
                                Console.Write("Enter Your New Phone Number: ");
                                var newTPhone = Console.ReadLine();
                                center.UpdateAriza(tId, newTName,newTSurname,newTPhone);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "3":
                                if (center.ListArizalar())
                                {
                                    Console.Write("Enter an Id: ");
                                    var deleteTId = int.Parse(Console.ReadLine());
                                    center.DeleteAriza(deleteTId);
                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "4":
                                center.ListArizalar();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back1 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Error, please try again");
                                break;
                        }


                    }
                    break;
                case "4":
                    Console.WriteLine("About Academy");
                    center.About();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    back = true;
                    Console.Clear();
                    Console.WriteLine("Thanks for choosing us:)");
                    break;
                default:
                    Console.WriteLine("Error, please try again");
                    break;

            }
        }
    }
}

