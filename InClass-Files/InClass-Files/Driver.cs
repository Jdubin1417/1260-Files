using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Files
{
    public class Driver
    {
        public static void Main()
        {
            //WriteExample1();
            //WriteExample2();
            //WriteExample3();
            //WriteExample4();

            //ReadExample1();
            //ReadExample2();
            //ReadExample3();
        }

        private static void WriteExample1()
        {
            int x = 5;

            //by default, below is creating if not exist otherwise edit the file; overwrites the file if it exists, not append
            StreamWriter writer = new StreamWriter("../../../Text Files/example.txt"); //the string is the path to write to; this opens the file
            //StreamWriter writer = new StreamWriter("E:\\Fall 2022\\1260\\Code\\InClass-Files\\InClass-Files\\Text Files\\example.txt"); //absolute path - won't work on another computer
            writer.WriteLine("hello!");
            writer.WriteLine("writing text from my program");
            writer.WriteLine("the value of x is " + x);
            writer.Close(); //have to be sure to close the file when we are done writing
        }

        private static void WriteExample2()
        {
            //second argument of boolean is whether or not to allow appending
            StreamWriter writer2 = new StreamWriter("../../../Text Files/example2.txt", true);
            writer2.WriteLine("hello!");
            writer2.Close();
        }

        private static void WriteExample3()
        {
            StreamWriter writer3 = new StreamWriter(new FileStream("../../../Text Files/example3.txt", //location
                                                                   FileMode.OpenOrCreate, //mode of how to open, see FileMode for more info
                                                                   FileAccess.Write) //amount of access: Read, Write, or ReadWrite
            );
            writer3.WriteLine("testing");
            writer3.Close();
        }
        private static void WriteExample4()
        {
            //Imagine that this list was created by asking the user for the information for each
            //of the people...it'd be nice to save it so they don't have to enter it all again
            //the next time they open the program
            List<Person> people = new List<Person>();
            people.Add(new Person("Bob", "Jones", 23));
            people.Add(new Person("Jan", "Jones", 52));
            people.Add(new Person("Bill", "Johnson", 72));
            people.Add(new Person("Katie", "Wilson", 23));
            people.Add(new Person("James", "Leroy", 44));

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            /*
            //Exceptions could be thrown - we need to handle them
            StreamWriter writer = new StreamWriter("../../../Text Files/people.txt");
            for(int i = 0; i < people.Count; i++)
            {
                writer.WriteLine(people[i].FirstName + "|" + people[i].LastName + "|" + people[i].Age);
            }
            writer.Close();
            */

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter("../../../Text Files/people.txt");
                for (int i = 0; i < people.Count; i++)
                {
                    writer.WriteLine(people[i].FirstName + "|" + people[i].LastName + "|" + people[i].Age);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not access file. Failed to write data to the file.");
            }
            finally
            {
                if(writer != null)
                    writer.Close();
            }
        }

        private static void ReadExample1()
        {
            StreamReader reader = new StreamReader("../../../Text Files/filethatdoesntexist.txt");
        }

        private static void ReadExample2()
        {
            StreamReader reader = new StreamReader("../../../Text Files/example.txt");
            //string line1 = reader.ReadLine(); //reads one line
            //Console.WriteLine(line1);
            string allText = reader.ReadToEnd(); //read the entire thing all at once
            Console.WriteLine(allText);
            //int oneChar = reader.Read(); //reads one character at a time; represented as an int with its corresponding number in ASCII
            //Console.WriteLine(oneChar);

            reader.Close();
        }

        private static void ReadExample3()
        {
            List<Person> people = new List<Person>();
            StreamReader reader = null;

            try
            {
                reader = new StreamReader("../../../Text Files/people.txt");
                while (reader.Peek() != -1) //Peek returns -1 if there is no more text left to process
                {
                    string line = reader.ReadLine(); //Bob|Jones|23
                    string[] fields = line.Split("|"); //fields[0] = Bob, fields[1] = Jones, fields[2] = 23
                    Person p = new Person(fields[0], fields[1], int.Parse(fields[2]));
                    people.Add(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read from the file.");
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
        }
    }
}
