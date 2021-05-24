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
        //public static int count;
        public static void AppendData()
        {
            // try to make id auto increament !
            //int id = count + 1;
            //count++;
            FileStream fs = new FileStream(fileLocation, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Console.Write("Please add teacher's ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Please add teacher's Class Number:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Section:");
                int section = Convert.ToInt32(Console.ReadLine());

                Teacher t1 = new Teacher(id, name, classNum, section);
                sw.WriteLine("{0} \t {1} \t {2} \t {3}", t1.id, t1.name, t1.classNum, t1.section);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message); // to print input error.
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

        }

        //Read data function (Print Record)
        
        public static void ReadData()
        {
         FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
         StreamReader sr= new StreamReader(fs);
         sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }

        // Update data function
        public static void UpdateData(int id)
        {
         FileStream fs3 = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
         StreamReader sr3 = new StreamReader(fs3);

    try {  
            Console.Write("Please add teacher's Name:");
            string name = Console.ReadLine();
            Console.Write("Please add teacher's Class Number:");
            int classNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please add teacher's Section:");
            int section = Convert.ToInt32(Console.ReadLine());

            Teacher t1 = new Teacher(id, name, classNum, section);
            string updatedData = $"{t1.id} \t {t1.name} \t {t1.classNum} \t {t1.section}";

            string[] lines;
            using (fs3)
            {
                using (sr3)
                {
                    lines = File.ReadAllLines(fileLocation);

                    for (int i = 2; i < lines.Length; i++)
                    {
                        string[] split = lines[i].Split(',');
                        foreach (var item in split)
                           
                        {
                            if (Char.GetNumericValue(item[0]) == id)
                            {
                                lines[i] = updatedData;
                            }
                        }
                    }

                    foreach (var item in lines)
                    {
                        Console.WriteLine(item);
                    }
                }
            }



        //File.WriteAllLines(fileLocation, lines);
        using (FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write))
                {
                using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in lines)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message); // to print input error.
            }

        }


                static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("## Teacher Records System ## \n\n" +
               "(1) to enter new data \n" +
               "(2) to update existing data \n" +
               "(3) to display teacher records \n" +
               "(4) to exit \n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        WriteData();
                        AppendData();
                        break;
                    case 2:
                        ReadData();
                        Console.Write("Please enter teacher's ID to update:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        UpdateData(id);
                        break;
                    case 3:
                        ReadData();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
                if (choice == 4){break;}

            }

        }
    }
}
