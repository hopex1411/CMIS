using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace cmis
{
    class cmis
    {
        static void Main(string[] args)
        {
            // Fejlmeddelser
            // Gør programmet mere lækkert(visuelt)

            Directory.CreateDirectory(@"C:\cmisData");
            string myLine = "";
            string myPath = @"C:\cmisData\database.txt";
            string menuAnswer;
            // arrayet myTxt contains menuItems
            string[] myTxt = { "Telefon", "Fornavn", "Efternavn", "Gade/Vej", "Husnummer", "Postnr", "Bynavn", "Email" };
            string[] myValues = new string[myTxt.Length];
            string yesNo = "";
            int counter = 0;


            do
            {
                // Main menu,
                Console.WriteLine("\n[O] Opret   [F] Find   [V] Vis alle   [Q] Afslut :");
                Console.Write("\nVælg funktion : ");
                menuAnswer = Console.ReadLine();


                // User creation
                if (menuAnswer.ToLower() == "o")
                {
                    Console.Clear();

                    if (File.Exists(myPath))
                    {
                        // Outputs myTxt and takes the data the user has inputted
                        for (int myRecord = 0; myRecord < myTxt.Length; myRecord++)
                        {
                            Console.Write(myTxt[myRecord] + ": ");
                            myValues[myRecord] = Console.ReadLine();
                        }
                        Console.WriteLine("\nTak - du har indtastet : ");

                        // Outputs the data the user inputted
                        for (int myRecord = 0; myRecord < myTxt.Length; myRecord++)
                        {
                            myLine = myLine + myValues[myRecord] + ", ";
                        }

                        myLine = myLine + "\n";
                        Console.WriteLine(myLine);
                        do
                        {

                            Console.WriteLine("\n Skal data skrives til filen ?? j/n");
                            yesNo = Console.ReadLine();
                            if (yesNo.ToLower() != "j" && yesNo.ToLower() != "n")
                            {
                                Console.WriteLine("Ugyldig indtastning");
                            }

                            if (yesNo.ToLower() == "j")
                            {
                                // Takes the data the user has inputted, and puts in the database
                                File.AppendAllText(myPath, myLine, Encoding.Unicode);
                                Console.Write("\nOplysninger gemmes ......");
                                Thread.Sleep(2000);
                                Console.WriteLine("\n\nOplysninger gemt");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }

                        } while (yesNo.ToLower() != "j" && yesNo.ToLower() != "n");



                        myLine = "";

                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(myPath))
                        {
                        }
                        Console.Write("\nDer er ingen database...... Database oprettes");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nDatabase oprettet");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }


                }
                // User search
                if (menuAnswer.ToLower() == "f")
                {
                    Console.Clear();
                    if (File.Exists(myPath))
                    {
                        // Reads all data in the database
                        string[] myDatabase = File.ReadAllLines(myPath);

                        Console.Write("Søg efter: ");
                        string mySearchString = Console.ReadLine();
                        if (new FileInfo(myPath).Length == 0)
                        {
                            Console.WriteLine("databasen er tom");
                        }

                        foreach (string line in myDatabase)
                        {
                            //Checks if the user input matches anything in the database
                            if (line.Contains(mySearchString))
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(myPath))
                        {
                        }
                        Console.WriteLine("Der er ingen database...... Database oprettet");
                    }
                    Console.WriteLine("\n\n\nTryk på en tast for at åbne menuen");
                    Console.ReadKey();

                }

                // Full database output
                if (menuAnswer.ToLower() == "v")
                {
                    Console.Clear();
                    if (File.Exists(myPath))
                    {
                        string[] myDatabase = File.ReadAllLines(myPath);
                        foreach (string line in myDatabase)
                        {
                            Console.WriteLine(line);
                            counter++;
                            if (counter % 15 == 0)
                            {
                                Console.WriteLine("Tryk for at se flere");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }

                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(myPath))
                        {
                        }
                        Console.WriteLine("Der er ingen database...... Database oprettet");
                    }
                    if (new FileInfo(myPath).Length == 0)
                    {
                        Console.WriteLine("databasen er tom");
                    }
                    Console.WriteLine("\n\n\nTryk på en tast for at åbne menuen");
                    Console.ReadKey();
                }
                if (menuAnswer.ToLower() != "o" && menuAnswer.ToLower() != "f" && menuAnswer.ToLower() != "v" && menuAnswer.ToLower() != "q")
                {
                    Console.WriteLine("Du har indtastet et ugyldigt tegn.");
                }
            }
            while (menuAnswer.ToLower() != "q");

            // Closes the application
            if (menuAnswer.ToLower() == "q")
            {
                Environment.Exit(0);
            }

            Console.ReadKey();
        }
    }
}
