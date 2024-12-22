using System.Text.RegularExpressions;
using Lab4_GIK299;

namespace LAB4TEMP;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Welcome to person tracker 2000");
            Console.WriteLine("""
                              What would you like to do?
                              1. Add person
                              2. Print a list of all people
                              3. exit program
                              """);
            string userInput = Console.ReadKey().KeyChar.ToString();
            ClearLastConsoleLine();

            switch (userInput)
            {
                case "1":
                    Person person = AddPerson();
                    people.Add(person);
                    break;

                case "2":
                    PrintListOfPeople(people);
                    break;

                case "3":
                    continueRunning = false;
                    break;

            }

        }


    }

    private static Person AddPerson()
    {
        #region DateInputRegion
        //prompt the user for a date
        Console.WriteLine("\nWhat is the persons birthday? write it as: yyyy,MM,dd or press Enter if you dont know.");
        //variable to hold the input
        DateTime birthday = default;
        string input;
        //if the input is empty and not a valid date 
        while ((input = Console.ReadLine()) !="" && !DateTime.TryParse(input, out birthday))
        {
            Console.WriteLine("Pleas enter a valid date or press Enter if you dont know.");
            input = Console.ReadKey().KeyChar.ToString();
        }
        //if the input is whitespace
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"No birthday entered.");
        }
        //if input is valid 
        else
        {
            Console.WriteLine($"Valid birthday entered: {birthday:yyyy MMMM dd}");
        }
        #endregion
        
        #region eyeColorInputRegion
        //prompts the user for eyecolor 
        Console.WriteLine("What is the persons eye color? Press Enter if you dont know.");
        string eyeColor;
        while (!string.IsNullOrEmpty(eyeColor = Console.ReadLine()))
        {
            //checks to se if valid input, letters only
            if (Regex.IsMatch(eyeColor, @"^[a-zA-Z]+$"))
            {
                //make first leter uppercase
                eyeColor = char.ToUpper(eyeColor[0]) + eyeColor.Substring(1);
                Console.WriteLine($"You entered: {eyeColor}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an eye color (letters only) or press Enter if you dont know.");
            }
        }
        #endregion
        
        #region hairStyleInputRegion
        //prompts the user for a hairstyle 
        Console.WriteLine("What hair style does the person have? Press Enter if you dont know.");
        string hairStyle;
        while (!string.IsNullOrEmpty(hairStyle = Console.ReadLine()))
        {
            //checks to se if valid input, letters only
            if (Regex.IsMatch(hairStyle, @"^[a-zA-Z]+$"))
            {
                //make first leter uppercase
                hairStyle = char.ToUpper(hairStyle[0]) + hairStyle.Substring(1);
                Console.WriteLine($"You entered: {hairStyle}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid hair style (letters only) or press Enter if you dont know.");
            }
        }
        #endregion
        
        #region hairColorInputRegion
        //prompts user for hair color
        Console.WriteLine("What hair color? does the person have? Press Enter if you dont know.");
        string hairColor;
        while (!string.IsNullOrEmpty(hairColor = Console.ReadLine()))
        {
            if (Regex.IsMatch(hairColor, @"^[a-zA-Z]+$"))
            {
                //make first leter uppercase
                hairColor = char.ToUpper(hairColor[0]) + hairColor.Substring(1);
                Console.WriteLine($"You entered: {hairColor}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid hair color (letters only) or press Enter if you dont know.");
            }
        }
        #endregion
        
        #region genderInputRegion
        //promt user for a gender
        Console.WriteLine("What is the person's gender? Male, Female, Other or Unknown");
        Gender gender;
        //Trys to pars users input to enum value || checks if input is in enum Gender
        while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender))
        {
            Console.WriteLine("Invalid gender. Please enter Male, Female, or Other:");
        }
        #endregion
        
        //instantiating person obj
        Person person = new Person(new Hair(hairStyle,  hairColor), gender, birthday, eyeColor);

        return person;
    }

    private static void PrintListOfPeople(List<Person> people)
    { 
        Console.WriteLine("\nPeople:");
        int counter = 0;
        foreach (var person in people)
        {
            Console.WriteLine($"Person nr: {counter +1} ");
            Console.WriteLine(person.ToString());
            Console.WriteLine();
            counter++;
        }
    }
    
    //Method to clear the last line in console to get rid of the numbers after menu choice 
    private static void ClearLastConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

}