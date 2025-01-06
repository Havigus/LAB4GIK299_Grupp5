namespace LAB4TEMP;

internal class Person
{
    //property's for the class
    private DateTime Birthday  { get; set; }
    private string EyeColor { get; set; }
    private Hair Hair  { get; set; }
    private Gender Gender { get; set; }

    //constructor 
    internal Person(Hair hair, Gender gender, DateTime? birthday = null, string? eyeColor = null)
    {
        //default birthday to DateTime.MinValue if arg is empty
        Birthday = birthday ?? DateTime.MinValue;
        //default eyeColor to "Unknown" if arg is empty or null
        EyeColor = string.IsNullOrEmpty(eyeColor) ? "Unknown" : eyeColor; 
        Hair = hair;
        Gender = gender;
    }
    

    public override string ToString()
    {
        return $" Birthday: {Birthday:yyyy MMMM dd}\n" +
               $" EyeColor: {EyeColor}\n" +
               $" HairColor: {Hair.HairColor}\n" +
               $" HairLenght: {Hair.HairLenght}\n" +
               $" Gender: {Gender}";
    }
}