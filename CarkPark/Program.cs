/*
 Create a "car park" program that lets us assign vehicles to parking spots using the console.
 First, the program should ask the user to initialize the spaces. It will ask how many spaces exist in the park.
 Spaces are named [Letter][Number 0 -9]
 13 spaces: [A0, A1, A2 - B1, B2, B3]
 Spaces should be initialized as "empty". The console then prompts for a space to fill.
 Users enter a space number. If that number is "full", the console displays a warning and asks for another space.
 If that space is empty, the user is then prompted for a six-letter license. That license will then be recorded for the requested space.
 If instead of a spot number the user enters "List", all spots are listed as well as if they are occupied, and by what license.
 */
class Program
{
    static void Main(string[] args)
    {
        // Declare
        bool endApp = false;
        var carParkl = new Dictionary<string, string>();
        string result="";
        int totalSpaces = 0;
        // Display title as the C# console 
        Console.WriteLine("================= CAR PARK =================");
        Console.WriteLine("--------------------------------------------\n");

        while (!endApp)
        {
            
            if (totalSpaces==0) {
                Console.WriteLine("Please enter  the number of spots for the car park:");
                totalSpaces = Int32.Parse(Console.ReadLine());
                Calcspaces(totalSpaces);
            }
            
            Console.WriteLine("Please enter the parking number you want:");
            string nspot = Console.ReadLine();

            try
            {
                result = Parking.DoOperation(nspot,carParkl);
                if (result=="Lista")
                {
                    carParkl.ToList().ForEach(x => Console.WriteLine(x.Key + "-" + x.Value));
                }
                else if(result == "Found") {
                    Console.WriteLine("Please enter the number a license:");
                    string license = Console.ReadLine();
                    result=Parking.UpdateValue(nspot, license, carParkl);
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred \n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;


        void Calcspaces(int totalSpaces)
        {
            char[] letters = new char[25] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z' };
            char[] ints = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int contL = 0;
            int contN = 0;

            for (int i = 0; i < totalSpaces; i++)
            {
                carParkl.Add(($"{letters[contL]}{ints[contN]}"), ("Empty"));

                if (contN == 9)
                {
                    contL++;
                    contN = 0;
                }
                else
                {
                    contN++;
                }
            }

        }
    }
}