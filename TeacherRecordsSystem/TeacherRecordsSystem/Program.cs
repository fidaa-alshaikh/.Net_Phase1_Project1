using System;
using System.IO;
namespace TeacherRecordsSystem
{

    class Teacher
    {
        public int id;
        public string name;
        public int classNum;
        public int section;

        public Teacher(int id, string name, int classNum, int section)
        {
            this.id = id;
            this.name = name;
            this.classNum = classNum;
            this.section = section;
        }
    }

    class Program
    {
        public static string fileLocation = "C:\\Users\\fedaa_1zoqddg\\OneDrive\\Desktop\\.NET-COURSE\\Projects\\Project1_Phase1\\.Net_Phase1_Project1\\TeachersRecord.txt";
        // Store Data Functions
        // Write data
        public static void WriteData()
        {
            FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Teachers Records");
            sw.WriteLine("ID \t Name \t Class \t Section");
            
            sw.Close();
            fs.Close();
        }
        // Append data
        public static void AppendData()
        {
            Console.Write("Please add teacher's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            // will try to make id auto increament !
            Console.Write("Please add teacher's Name:");
            string name = Console.ReadLine();
            Console.Write("Please add teacher's Class Number:");
            int classNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please add teacher's Section:");
            int section = Convert.ToInt32(Console.ReadLine());

            FileStream fs = new FileStream(fileLocation, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            Teacher t1 = new Teacher(id, name, classNum, section);
            sw.WriteLine("{0} \t {1} \t {2} \t {3}", t1.id, t1.name, t1.classNum, t1.section);

            sw.Close();
            fs.Close();

        }
        static void Main(string[] args)
        {
            //Teacher t1 = new Teacher(1, "Fidaa", 2, 20);
           // Console.WriteLine("ID: {0}, Name: {1}, Class Number: {2}, Sec: {3}", t1.id, t1.name, t1.classNum, t1.section);
            WriteData();
            AppendData();
            Console.ReadKey();
        }
    }
}
