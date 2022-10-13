// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.CompilerServices;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

// En lista för att spara historik för räkningar
List<String> ListOfCalculations = new List<string>();
//Varialer som används för att spara ner värden för uträckningen
float ValueOne;
float ValueTwo;
float Result = 0.0f;
String EquationSelector = ""; 
String CurrentCalculationInput;
String YesOrNoString;
List<String> CurrentCalculationSave;
bool KeepCounting = true;

//En while loop för att se om användaren vill fortsätta räkna i konsollen
while(KeepCounting == true)
{
    // Välkomnande meddelande
    Console.WriteLine("Welcome to your calculator! Put in your calculation for example(x*x)");

    //Användaren matar in en beräkning som sparas ner i en string
    CurrentCalculationInput = Console.ReadLine();

    //Contains används för att ta reda på ekvation användaren vill göra
    if(CurrentCalculationInput.Contains("*"))
    {
        EquationSelector = "*";
    }
    else if(CurrentCalculationInput.Contains("+"))
    {
        EquationSelector = "+";
    }
    else if(CurrentCalculationInput.Contains("-"))
    {
        EquationSelector = "-";
    }
    else if(CurrentCalculationInput.Contains("/"))
    {
        EquationSelector = "/";
    }
    else
    {
        EquationSelector = "Wrong";
    }

    //En lista med dom nuvarande talen som ska räknas ut görs för att kunna indexera talen och spara ner dom som float variabler
    //Equation selector används också för att indexera talen
    CurrentCalculationSave = new List<String>(CurrentCalculationInput.Split(EquationSelector));
    //Jag använder mig av TryParse funktionen för att se om inmatningen faktist är tal, annars skickas användaren tillbacks för att skriva om
    if (float.TryParse(CurrentCalculationSave[0], out ValueOne) == false || float.TryParse(CurrentCalculationSave[1], out ValueTwo) == false || EquationSelector == "Wrong")
    {
        Console.WriteLine("Cant continue without inputing correct syntax");
    }
    else if(float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat) == 0 && float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat) == 0 && EquationSelector == "/")
    {
        // Funktion kollar om input syntax är 0/0 och om den är det skickas användaren tillbacks till start för att skriva in nya värden
        Console.WriteLine("Ivalid cant divide zero with zero");
    }
    else
    {
        // Talen i beräkningen sparas ner i float variabler
        //Man skulle använda sig av Parse direkt och inte spara ner värdena i float variabler för att spara minne,
        //men jag anser att det ser bättre och är mer lättförståligt att spara ner dem i float variabler
        ValueOne = float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat);
        ValueTwo = float.Parse(CurrentCalculationSave[1], CultureInfo.InvariantCulture.NumberFormat);

        //Uträckning görs
        if (EquationSelector == "/")
        {
            Result = ValueOne / ValueTwo;
        }
        else if (EquationSelector == "+")
        {
            Result = ValueOne + ValueTwo;
        }
        else if (EquationSelector == "-")
        {
            Result = ValueOne - ValueTwo;
        }
        else if (EquationSelector == "*")
        {
            Result = ValueOne * ValueTwo;
        }

        // Resulatet läggs in i listan
        ListOfCalculations.Add(Convert.ToString(Result));

        //Visa resultatet
        Console.WriteLine("Your Result:" + Result.ToString());

        //Fråga användaren om den vill visa tidigare resultat.
        Console.WriteLine("\nDo you want to see previous results?(yes/no)");
        YesOrNoString = Console.ReadLine().ToLower();

        //Visa tidigare resultat
        if (YesOrNoString == "yes")
        {
            Console.WriteLine();
            ListOfCalculations.ForEach(Console.WriteLine);
        }

        //Fråga användaren om den vill avsluta eller fortsätta.
        Console.WriteLine("\nDo you want to continue calculating?(yes/no)");
        YesOrNoString = Console.ReadLine().ToLower();
        if (YesOrNoString == "yes")
        {
            Console.WriteLine();
        }
        else
        {
            KeepCounting = false;
        }
    }
}