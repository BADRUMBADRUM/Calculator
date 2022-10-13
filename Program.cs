// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.CompilerServices;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

// En lista för att spara historik för räkningar
List<String> ListOfCalculations = new List<string>();


float ValueOne;
float ValueTwo;
float Result = 0.0f;
String EquationSelector = ""; 
String CurrentCalculationInput;
String YesOrNoString;
List<String> CurrentCalculationSave;
bool KeepCounting = true;

while(KeepCounting == true)
{
    // Välkomnande meddelande
    Console.WriteLine("Welcome to your calculator! Put in your calculation for example(x*x)");

    //OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
    CurrentCalculationInput = Console.ReadLine();

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

    CurrentCalculationSave = new List<String>(CurrentCalculationInput.Split(EquationSelector));
    if (float.TryParse(CurrentCalculationSave[0], out ValueOne) == false || float.TryParse(CurrentCalculationSave[1], out ValueTwo) == false || EquationSelector == "Wrong")
    {
        Console.WriteLine("Cant continue without inputing correct syntax");
    }
    else if(float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat) == 0 && float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat) == 0 && EquationSelector == "/")
    {
        // Funktion kollar om input syntax är 0/0 och om den är det får användaren skriva in nya värden
        Console.WriteLine("Ivalid cant divide zero with zero");
    }
    else
    {
        // Talen i beräkningen sparas ner i int variabler
        ValueOne = float.Parse(CurrentCalculationSave[0], CultureInfo.InvariantCulture.NumberFormat);
        ValueTwo = float.Parse(CurrentCalculationSave[1], CultureInfo.InvariantCulture.NumberFormat);


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

        //Visa resultat
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

