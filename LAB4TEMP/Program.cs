using System.Text.RegularExpressions;
namespace LAB4TEMP;

class Program
{
    static void Main()
    {
        //List to hold the Person objects 
        List<Person> people = new List<Person>();
        
        // Flag to check if the user wants to exit program
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Welcome to Person tracker 2000");
            Console.WriteLine("""
                              What would you like to do?
                              1. Add person
                              2. Print a list of all people
                              3. Exit program
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
        Console.WriteLine("\nWhat is the persons birthday? Write it as: yyyy,mm,dd or press Enter if you dont know.");
        //variable to hold the input
        DateTime birthday = default;
        string input;
        //if the input is not empty and not a valid date prompt the user again
        while ((input = Console.ReadLine()) !="" && !DateTime.TryParse(input, out birthday))
        {
            Console.WriteLine("Please enter a valid date or press Enter if you dont know.");
            
        }
        //if the input is empty (Enter pressed)
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine($"No birthday entered.\n");
        }
        //if input is valid 
        else
        {
            Console.WriteLine($"Valid birthday entered: {birthday:yyyy MMMM dd}\n");
        }
        #endregion
        
        #region eyeColorInputRegion
        //prompts the user for eye color 
        Console.WriteLine("What is the persons eye color? Press Enter if you dont know.");
        string eyeColor;
        while (!string.IsNullOrEmpty(eyeColor = Console.ReadLine()))
        {
            //checks to se if valid input, letters only
            if (Regex.IsMatch(eyeColor, @"^[a-zA-Z]+$"))
            {
                //make first leter uppercase
                eyeColor = char.ToUpper(eyeColor[0]) + eyeColor.Substring(1);
                Console.WriteLine($"You entered: {eyeColor}\n");
                break;
            }

            Console.WriteLine("Invalid input. Please enter an eye color (letters only) or press Enter if you dont know.");
        }
        //if input is empty (Enter pressed)
        if (string.IsNullOrEmpty(eyeColor))
        {
            Console.WriteLine($"No eye color entered.\n");
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
                Console.WriteLine($"You entered: {hairStyle}\n");
                break;
            }

            Console.WriteLine("Invalid input. Please enter a valid hair style (letters only) or press Enter if you dont know.");
        }
        //if input is empty (Enter pressed)
        if (string.IsNullOrEmpty(hairStyle))
        {
            Console.WriteLine($"No hair style entered.\n");
        }
        #endregion
        
        #region hairColorInputRegion
        //prompts user for hair color
        Console.WriteLine("What hair color does the person have? Press Enter if you dont know.");
        string hairColor;
        while (!string.IsNullOrEmpty(hairColor = Console.ReadLine()))
        {
            //checks to se if valid input, letters only
            if (Regex.IsMatch(hairColor, @"^[a-zA-Z]+$"))
            {
                //make first leter uppercase
                hairColor = char.ToUpper(hairColor[0]) + hairColor.Substring(1);
                Console.WriteLine($"You entered: {hairColor}\n");
                break;
            }

            Console.WriteLine("Invalid input. Please enter a valid hair color (letters only) or press Enter if you dont know.");
        }
        //if input is empty (Enter pressed)
        if (string.IsNullOrEmpty(hairColor))
        {
            Console.WriteLine($"No hair color entered.\n");
        }
        #endregion
        
        #region genderInputRegion
        //promt user for a gender
        Console.WriteLine("What is the person's gender? Male, Female, Other or Unknown");
        Gender gender;
        //Trys to pars users input to enum value || checks if input is in enum Gender
        while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender))
        {
            Console.WriteLine("Invalid gender. Please enter Male, Female, Other or Unknown");
        }
        #endregion
        
        //instantiating person obj
        Person person = new Person(new Hair(hairStyle,  hairColor), gender, birthday, eyeColor);

        return person;
    }

    //Method to print all the people in the list
    private static void PrintListOfPeople(List<Person> people)
    { 
        Console.WriteLine("\nPeople:");
        int counter = 0;
        foreach (var person in people)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"Person nr: {counter +1} ");
            Console.WriteLine(person.ToString());
            Console.WriteLine();
            counter++;
        }

        Console.WriteLine(new string('-', 60));
    }
    
    //Method to clear the last line in console to get rid of the numbers after menu choice 
    //https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
    private static void ClearLastConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

}