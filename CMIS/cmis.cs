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
            string allData = myPath;

                

                Console.WriteLine("[O] Opret [F] Find [V] Vis alle [Q] Afslut :");
                menuAnswer = Console.ReadLine();
                do
                {
                    if (menuAnswer.ToLower() == "o")
                    {
                        for (int myRecord = 0; myRecord < myTxt.Length; myRecord++)
                        {
                            Console.Write(myTxt[myRecord] + ": ");
                            myValues[myRecord] = Console.ReadLine();
                        }
                        Console.WriteLine("Tak - du har indtastet : ");

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
                            File.AppendAllText(myPath, myLine, Encoding.Unicode);
                            Console.WriteLine("Oplysninger gemmes ......");
                        }  
                    }
                } while (menuAnswer.ToLower() == "o");

                do
                {
                    if (menuAnswer.ToLower() == "f")
                    {
                        string[] myDatabase = File.ReadAllLines(myPath);

                        Console.Write("Søg efter: ");
                        string mySearchString = Console.ReadLine();

                        foreach (string line in myDatabase)
                        {
                            if (line.Contains(mySearchString))
                            {
                                Console.WriteLine(myDatabase);
                            }
                            else
                            {
                                Console.WriteLine("Nope");
                            }
                        }
                    }
                } while (menuAnswer.ToLower() == "f");

                do
                {
                    if (menuAnswer.ToLower() == "v")
                    {
                        string[] myDatabase = File.ReadAllLines(myPath);
                        foreach (string line in myDatabase)
                        {
                            Console.WriteLine(line);
                        }
                        break;
                    }
                } while (menuAnswer.ToLower() == "v");
                

            if (menuAnswer.ToLower()=="q")
            {
                Environment.Exit(0);
            }
            
            Console.ReadKey();
        }
    }
}
