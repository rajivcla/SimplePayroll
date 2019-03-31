using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimplePayroll
{
    class FileReader
    {
        private static string path = "staff.txt";
        private static string[] separator = {", "};
        public static List<Staff> GetStaff()
        {
            List<Staff> staffNames = new List<Staff>();


            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] result = sr.ReadLine().Split(separator, StringSplitOptions.None);
                        // get type based on class name saved in file
                        try
                        {
                            object o = Activator.CreateInstance(Type.GetType($"SimplePayroll.{result[1]}"),
                                new Object[] { result[0] });
                            staffNames.Add((Staff)o);
                        }catch(Exception ex)
                        {
                            Console.WriteLine($"\nIncorrect employee type '{result[1]}' for: {result[0]}.  Enter Manager or Admin");
                            sr.Close();
                            Console.WriteLine("press any key to exit");
                            Console.Read();
                            System.Environment.Exit(0);
                        }
                    }

                    sr.Close();
                }
            }
            
            return staffNames;
        }
    }
}
