using System;

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
        static void Main(string[] args)
        {
            Teacher t1 = new Teacher(1, "Fidaa", 2, 20);
            Console.WriteLine("ID: {0}, Name: {1}, Class Number: {2}, Sec: {3}", t1.id, t1.name, t1.classNum, t1.section);
        }
    }
}
