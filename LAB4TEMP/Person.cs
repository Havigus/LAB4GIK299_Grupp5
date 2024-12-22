namespace Lab4_GIK299;

internal class Person
{
    private DateTime Birthday  { get; set; }
    private string EyeColor { get; set; }
    private Hair Hair  { get; set; }
    private Gender Gender { get; set; }

    internal Person(Hair hair, Gender gender, DateTime? birthday = null, string? eyeColor = null)
    {
        Birthday = birthday ?? DateTime.MinValue;
        EyeColor = string.IsNullOrWhiteSpace(eyeColor) ? "Unknown" : eyeColor;
        Hair = hair;
        Gender = gender;
    }
    

    public override string ToString()
    {
        return $"Birthday: {Birthday:yyyy MMMM dd}, EyeColor: {EyeColor}, HairColor: {Hair.HairColor}, HairLenght: {Hair.HairLenght}, Gender: {Gender}";
    }
}