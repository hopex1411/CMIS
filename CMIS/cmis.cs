using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmis
{
    class cmis
    {
        static void Main(string[] args)
        {
            string myLine = "";
            string myPath = @"C:\xampp\htdocs\github\CMIS\CMIS\database.txt";
            string menuAnswer;
            // arrayet myTxt contains menuItems
            string[] myTxt = { "Telefon", "Fornavn", "Efternavn", "Gade/Vej", "Husnummer", "Postnr", "Bynavn", "Email" };
            string[] myValues = new string[myTxt.Length];

                
                // Main menu,
                Console.WriteLine("[O] Opret [F] Find [V] Vis alle [Q] Afslut :");
                menuAnswer = Console.ReadLine();

                    // User creation
                    if (menuAnswer.ToLower() == "o")
                    {
                        // Outputs myTxt and takes the data the user has inputted
                        for (int myRecord = 0; myRecord < myTxt.Length; myRecord++)
                        {
                            Console.Write(myTxt[myRecord] + ": ");
                            myValues[myRecord] = Console.ReadLine();
                        }
                        Console.WriteLine("Tak - du har indtastet : ");

                        // Outputs the data the user inputted
                        for (int myRecord = 0; myRecord < myTxt.Length; myRecord++)
                        {
                            myLine = myLine + myValues[myRecord] + ", ";
                        }

                        myLine = myLine + "\n";

                        Console.WriteLine(myLine);
                        Console.WriteLine("\n Skal data skrives til filen ?? j/n");
                        string yesNo = Console.ReadLine();
                        if (yesNo.ToLower() == "j")
                        {
                        // Takes the data the user has inputted, and puts in the database
                            File.AppendAllText(myPath, myLine, Encoding.Unicode);
                            Console.WriteLine("Oplysninger gemmes ......");
                        }  
                    }
                
                    // User search
                    if (menuAnswer.ToLower() == "f")
                    {
                        // Reads all data in the database
                        string[] myDatabase = File.ReadAllLines(myPath);

                        Console.Write("Søg efter: ");
                        string mySearchString = Console.ReadLine();

                        foreach (string line in myDatabase)
                        {
                            //Checks if the user input matches anything in the database
                            if (line.Contains(mySearchString))
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }

                    // Full database output
                    if (menuAnswer.ToLower() == "v")
                    {
                        string[] myDatabase = File.ReadAllLines(myPath);
                        foreach (string line in myDatabase)
                        {
                            Console.WriteLine(line);
                        }
                    }
                
            // Closes the application
            if (menuAnswer.ToLower()=="q")
            {
                Environment.Exit(0);
            }
            
            Console.ReadKey();
        }
    }
}
