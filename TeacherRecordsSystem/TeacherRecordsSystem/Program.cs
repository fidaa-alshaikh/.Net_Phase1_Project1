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
        // Store Data Functions
        // Write data
        public static void WriteData()
        {
            FileStream fs = new FileStream("C:\\Users\\fedaa_1zoqddg\\OneDrive\\Desktop\\.NET-COURSE\\Projects\\Project1_Phase1\\.Net_Phase1_Project1\\TeachersRecord.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Teachers Records");
            sw.WriteLine("ID \t Name \t Class \t Section");
            
            sw.Close();
            fs.Close();
        }
 
        static void Main(string[] args)
        {
            Teacher t1 = new Teacher(1, "Fidaa", 2, 20);
            Console.WriteLine("ID: {0}, Name: {1}, Class Number: {2}, Sec: {3}", t1.id, t1.name, t1.classNum, t1.section);
            WriteData();
        }
    }
}
