using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    { 
        class Activity
        {
            public string date;
            public string state;
            public string title;
            public Activity(string D, string S, String T)
            {
                date = D; state = S;
                title = T;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hej och välkomen till att göra listan!");
            Console.WriteLine("För att avsluta skriv 'quit', för hjälp skriv 'help'");

            string command;
            string[] commandWord;
            List<Activity> Todolist;

            do
            {
                Console.Write(">");
                command = Console.ReadLine();
                commandWord = command.Split(' ');

                if (command == "quit")
                {
                    Console.WriteLine("Bye");
                }
                else if (commandWord[0] == "load")
                {
                    Console.WriteLine("Reading file{0}", commandWord[1]);
                    Todolist = ReadTodoListFile(commandWord[1]);
                }
                else
                {
                    Console.WriteLine("Unkown command :{0}", command);
                }

            } while (command != "quit");
        } 

        private static List<Activity>ReadTodoListFile(String fileName)
        {
            List<Activity> todoList = new List<Activity>();
            
            using(StreamReader sr=new StreamReader(fileName))
            {

                while (sr.Peek() >= 0)
                {
                    string[] lword = sr.ReadLine().Split('#');
                    Activity A = new Activity(lword[0], lword[1], lword[2]);
                    todoList.Add(A);
                }
            }
            return todoList;
        }
    }
}
